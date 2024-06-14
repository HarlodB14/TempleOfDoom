using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempleOfDoomModel.Doors.Decorators
    {
        public class ColoredDoorDecorator : DoorDecorator
        {
            public string color { get; private set; }

            public ColoredDoorDecorator(Door decoratedDoor, Room connectedRoom1, Room connectedRoom2, string color)
                : base(decoratedDoor, connectedRoom1, connectedRoom2)
            {
                this.color = color;
            }

            public override bool CanEntityPass(Player player)
            {
                return base.CanEntityPass(player) && player.HasKeyOfColor(color);
            }
        }
    }



