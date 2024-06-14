using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempleOfDoomModel.Items
{
    public class SankaraStone : Item, IPickable
    {
        public void Pickup(Player player)
        {
            player.Store(this);
        }
    }
}
