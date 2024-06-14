using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempleOfDoomModel.Items
{
    public class DisappearingBT : BoobyTrap, IInteractable
    {
        public override void Interact(Player player)
        {
            base.Interact(player); 

            if (player.CurrentRoom.Items.Contains(this))
            {
                player.CurrentRoom.Items.Remove(this);
                player.CurrentRoom.NotifyItemInteractObservers(this);
            }
        }
    }
}
