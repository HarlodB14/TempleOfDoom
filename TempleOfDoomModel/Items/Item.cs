using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempleOfDoomModel.Items
{
    public abstract class Item : IPickable
    {
        public string Type { get; set; }
        public Position Position { get; set; }
        public void Pickup(Player player)
        {
            player.Store(this);
        }
    }
}
