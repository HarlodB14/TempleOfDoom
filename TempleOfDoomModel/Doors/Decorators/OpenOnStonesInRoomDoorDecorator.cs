using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempleOfDoomModel.Doors.Decorators
{
    public class OpenOnStonesInRoomDoorDecorator : DoorDecorator
    {
        private int _requiredStones;

        public OpenOnStonesInRoomDoorDecorator(Door decoratedDoor, Room connectedRoom1, Room connectedRoom2, int requiredStones)
            : base(decoratedDoor, connectedRoom1, connectedRoom2)
        {
            _requiredStones = requiredStones;
        }

        public override bool CanEntityPass(Player player)
        {
            return base.CanEntityPass(player) && player.CurrentRoom.CountItemsOfType("sankara stone") == _requiredStones;
        }


    }
}
