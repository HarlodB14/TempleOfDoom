using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempleOfDoomModel.Items
{
    public class BoobyTrap : Item, IInteractable
    {
        public int Damage { get; set; }

        public BoobyTrap()
        {
            Damage = 1;
        }

        public virtual void Interact(Player player)
        {
            player._lives -= Damage;
        }
    }
}
