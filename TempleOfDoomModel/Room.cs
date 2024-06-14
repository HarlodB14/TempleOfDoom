using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempleOfDoomModel.Doors;
using TempleOfDoomModel.Doors.Decorators;
using TempleOfDoomModel.Items;

namespace TempleOfDoomModel
{
    public class Room
    {
        public string Type { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public List<Item> Items { get; private set; }
        private List<ItemStore> itemStores = new List<ItemStore>();
        private List<ItemInteract> itemInteractObservers = new List<ItemInteract>();
        private List<Door> doors = new List<Door>();

        public Dictionary<string, IConnection> _connections = new Dictionary<string, IConnection>();

        public Room(string type, int width, int height)
        {
            Type = type;
            Width = width;
            Height = height;
            Items = new List<Item>();
        }

        public void AddConnection(string direction, IConnection connection)
        {
            _connections[direction] = connection;
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
            NotifyItemStores(item);
        }

        public void RegisterItemStore(ItemStore itemStore)
        {
            itemStores.Add(itemStore);
        }

        public void RegisterItemInteractOberserver(ItemInteract itemInteractObserver)
        {
            itemInteractObservers.Add(itemInteractObserver);
        }

        public void NotifyItemStores(Item newItem)
        {
            foreach (ItemStore itemStore in itemStores)
            {
                itemStore.Update(newItem);
            }
        }


        public void NotifyItemInteractObservers(Item item)
        {
            foreach (var itemInteractObserver in itemInteractObservers)
            {
                itemInteractObserver.interact(item);
            }
        }

        public Room GetConnectedRoom(string direction)
        {
            if (_connections.TryGetValue(direction, out IConnection connection))
            {
                return connection.GetConnectedRoom(this);
            }
            return null;
        }

        public bool CanEntityPass(string direction, Player player)
        {
            if (_connections.TryGetValue(direction, out IConnection connection))
            {
                return connection.CanEntityPass(player);
            }
            return false;
        }

        // Implement CountItemsOfType method
        internal int CountItemsOfType(string itemType)
        {
            return Items.Count(item => item.Type.Equals(itemType, StringComparison.OrdinalIgnoreCase));
        }

        public bool CanEntityPass(Player player)
        {
            // A room as a connection is always passable
            return true;
        }

        public IEnumerable<Door> GetAllDoors()
        {
            // Create an empty list to hold all doors
            var allDoors = new List<Door>();

            // Iterate through each connection and add it to the list if it's a Door
            foreach (var connection in _connections.Values)
            {
                if (connection is Door door)
                {
                    allDoors.Add(door);
                }
                else if (connection is DoorDecorator decorator)
                {
                    // If the connection is a DoorDecorator, navigate through the decorator chain to find the base Door
                    while (decorator.DecoratedDoor is DoorDecorator innerDecorator)
                    {
                        decorator = innerDecorator;
                    }

                    // Add the base Door to the list
                    if (decorator.DecoratedDoor is Door baseDoor)
                    {
                        allDoors.Add(baseDoor);
                    }
                }
            }

            return allDoors;
        }

        public Room GetConnectedRoom(Room currentRoom)
        {
            // If the room is acting as a direct connection, it returns the connected room
            return this == currentRoom ? null : this;
        }

        public IEnumerable<T> FindConnectionsOfType<T>() where T : Door
        {
            return _connections.Values.OfType<T>();
        }

    }
}
