using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempleOfDoomModel.Items;

namespace TempleOfDoomModel
{
    public class Player
    {
        public Position Position;
        public Position StartPosition;
        //public Room StartRoom;
        public Room CurrentRoom;

        public List<Item> _Items { get; set; }
        public int _lives { get; set; }

        public Player(Position position, Room room)
        {
            this.CurrentRoom = room;
            StartPosition = position;
            Position = position;
            _Items = new List<Item>();
        }

        public void Move(DirectionEnum direction)
        {
            int newXposition = Position.xPos;
            int newYposition = Position.yPos;

            switch (direction)
            {
                case DirectionEnum.North:
                    newYposition--;
                    break;
                case DirectionEnum.South:
                    newYposition++;
                    break;
                case DirectionEnum.West:
                    newXposition--;
                    break;
                case DirectionEnum.East:
                    newXposition++;
                    break;
            }

            if (IsWithinBordersOfRoom(newXposition, newYposition))
            {
                Position.xPos = newXposition;
                Position.yPos = newYposition;
                //checken of er eventueel een item in de room zit
                InteractWithItemAtCurrentPosition();
            }
            else if (CanPassThroughDoor(direction, newXposition, newYposition))
            {
                Room connectedRoom = CurrentRoom.GetConnectedRoom(direction.ToString());
                if (connectedRoom != null)
                {
                    CurrentRoom = connectedRoom;
                    // Update player's position to the new room's corresponding entry point
                    switch (direction)
                    {
                        case DirectionEnum.North:
                            Position.xPos = CurrentRoom.Width / 2;
                            Position.yPos = CurrentRoom.Height - 1;
                            break;
                        case DirectionEnum.South:
                            Position.xPos = CurrentRoom.Width / 2;
                            Position.yPos = 0;
                            break;
                        case DirectionEnum.West:
                            Position.xPos = CurrentRoom.Width - 1;
                            Position.yPos = CurrentRoom.Height / 2;
                            break;
                        case DirectionEnum.East:
                            Position.xPos = 0;
                            Position.yPos = CurrentRoom.Height / 2;
                            break;
                    }
                }
            }
        }

        private bool CanPassThroughDoor(DirectionEnum direction, int newX, int newY)
        {
            if (CurrentRoom.CanEntityPass(direction.ToString(), this))
            {
                // Check if the player is at the middle position of the wall
                switch (direction)
                {
                    case DirectionEnum.North:
                    case DirectionEnum.South:
                        if (newX != CurrentRoom.Width / 2) // Middle X position for North and South walls
                        {
                            return false;
                        }
                        break;
                    case DirectionEnum.East:
                    case DirectionEnum.West:
                        if (newY != CurrentRoom.Height / 2) // Middle Y position for East and West walls
                        {
                            return false;
                        }
                        break;
                }

                return true;
            }

            return false;
        }

        private void InteractWithItemAtCurrentPosition()
        {
            Item itemAtPlayerPosition = GetItemAtPlayerPosition();

            if (itemAtPlayerPosition != null)
            {
                if (itemAtPlayerPosition is BoobyTrap)
                {
                    ((IInteractable)itemAtPlayerPosition).Interact(this);
                    CurrentRoom.NotifyItemInteractObservers(itemAtPlayerPosition);
                }
                else if (itemAtPlayerPosition is IPickable && !(itemAtPlayerPosition is IInteractable))
                {
                    _Items.Add(itemAtPlayerPosition);
                    CurrentRoom.Items.Remove(itemAtPlayerPosition);
                    CurrentRoom.NotifyItemStores(itemAtPlayerPosition);
                }
                else if (itemAtPlayerPosition is IInteractable)
                {
                    ((IInteractable)itemAtPlayerPosition).Interact(this);
                    CurrentRoom.NotifyItemInteractObservers(itemAtPlayerPosition);
                }
            }
        }



        private Item GetItemAtPlayerPosition()
        {
            foreach (Item item in CurrentRoom.Items)
            {
                if (item.Position.xPos == Position.xPos && item.Position.yPos == Position.yPos)
                {
                    return item;
                }
            }
            return null;
        }

        private bool IsWithinBordersOfRoom(int x, int y)
        {
            int leftBorder = 1;
            int rightBorder = 1;
            int upperBorder = 1;
            int lowerBorder = 1;


            return x >= leftBorder && x < CurrentRoom.Width - rightBorder &&
                   y >= upperBorder && y < CurrentRoom.Height - lowerBorder;
        }

        public void SetLives(int lives)
        {
            this._lives = lives;
        }

        public int GetLives() { return this._lives; }

        public void Store(Item item)
        {
            if (this.Position == item.Position)
            {
                if (item is IPickable)
                {
                    _Items.Add(item);
                }
                else if (item is IInteractable)
                {
                    ((IInteractable)item).Interact(this);
                }
            }
        }


        public bool HasKeyOfColor(string color)
        {
            return _Items.OfType<Key>().Any(key => key.Color.Equals(color, StringComparison.OrdinalIgnoreCase));
        }


    }
}
