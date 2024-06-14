using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempleOfDoomModel.Doors.Decorators
{
    public class ClosingGateDecorator : DoorDecorator
    {
        private bool _hasBeenUsed = false;

        public ClosingGateDecorator(Door decoratedDoor, Room connectedRoom1, Room connectedRoom2)
            : base(decoratedDoor, connectedRoom1, connectedRoom2) { }

        public override bool CanEntityPass(Player player)
        {
            if (!_hasBeenUsed && base.CanEntityPass(player))
            {
                _hasBeenUsed = true;
                DecoratedDoor.SetOpenState(false);  // Close the door permanently after passing through
                return true;
            }
            return false;
        }
    }
}

