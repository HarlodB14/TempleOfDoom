using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempleOfDoomModel.Items;
using TempleOfDoomModel;

namespace TempleOfDoomData.Factories
{
    public class ItemFactory
    {
        public Item CreateItem(ItemDTO itemDTO)
        {
            switch (itemDTO.type.ToLower())
            {
                case "boobytrap":
                    return new BoobyTrap { Type = itemDTO.type, Damage = itemDTO.damage, Position = new Position(itemDTO.x, itemDTO.y) };
                case "disappearing boobytrap":
                    return new DisappearingBT { Type = itemDTO.type, Damage = itemDTO.damage, Position = new Position(itemDTO.x, itemDTO.y) };
                case "sankara stone":
                    return new SankaraStone { Type = itemDTO.type, Position = new Position(itemDTO.x, itemDTO.y) };
                case "key":
                    return new Key { Type = itemDTO.type, Color = itemDTO.color, Position = new Position(itemDTO.x, itemDTO.y) };
                case "pressure plate":
                    return new PressurePlate { Type = itemDTO.type, Position = new Position(itemDTO.x, itemDTO.y) };
                // Add more cases as needed for different item types
                default:
                    throw new ArgumentException("Unknown item type");
            }
        }
    }

}
