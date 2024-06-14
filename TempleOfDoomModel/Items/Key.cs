using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempleOfDoomModel.Doors;

namespace TempleOfDoomModel.Items
{
    public class Key : Item, IPickable
    {
        public string Color { get; set; }

        public void Pickup(Player player)
        {
            player.Store(this);
        }
    }
}
