using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempleOfDoomModel.Doors
{
    public abstract class Door : IConnection
    {
        public bool IsOpen { get; protected set; }
        protected Room _connectedRoom1;
        protected Room _connectedRoom2;
        public string FirstDecoratorType { get; protected set; } = "Basic";
        public string DoorColor { get; set; } = "white";

        public Door(Room connectedRoom1, Room connectedRoom2)
        {
            _connectedRoom1 = connectedRoom1;
            _connectedRoom2 = connectedRoom2;
        }
        public abstract bool CanEntityPass(Player player);

        public Room GetConnectedRoom(Room currentRoom)
        {
            return currentRoom == _connectedRoom1 ? _connectedRoom2 : _connectedRoom1;
        }
        public void SetOpenState(bool isOpen)
        {
            IsOpen = isOpen;
        }

        public void ToggleOpenState()
        {
            IsOpen = !IsOpen;
        }

    }

}
