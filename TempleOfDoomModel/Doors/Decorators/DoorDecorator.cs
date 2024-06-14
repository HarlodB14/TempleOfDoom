using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempleOfDoomModel.Doors.Decorators
{
    public abstract class DoorDecorator : Door
    {
        public Door DecoratedDoor;

        public DoorDecorator(Door decoratedDoor, Room connectedRoom1, Room connectedRoom2)
            : base(connectedRoom1, connectedRoom2)
        {
            DecoratedDoor = decoratedDoor;
            // If the wrapped door is a basic door, set the FirstDecoratorType
            if (decoratedDoor.FirstDecoratorType == "Basic")
            {
                this.FirstDecoratorType = this.GetType().Name; // This sets the name of the current decorator as the first
            }
            else
            {
                this.FirstDecoratorType = decoratedDoor.FirstDecoratorType; // Otherwise, keep the first decorator's type
            }
        }

        public override bool CanEntityPass(Player player)
        {
            return DecoratedDoor.CanEntityPass(player);
        }



    }


}
