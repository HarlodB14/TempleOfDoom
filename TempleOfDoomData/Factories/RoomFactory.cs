using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempleOfDoomModel;

namespace TempleOfDoomData.Factories
{
    public class RoomFactory
    {
        private readonly ItemFactory _itemFactory;

        public RoomFactory(ItemFactory itemFactory)
        {
            _itemFactory = itemFactory;
        }

        public Room CreateRoom(RoomDTO roomDTO)
        {
            var room = new Room(roomDTO.type, roomDTO.width, roomDTO.height);

            foreach (var itemDTO in roomDTO.items ?? Enumerable.Empty<ItemDTO>())
            {
                var item = _itemFactory.CreateItem(itemDTO);
                room.Items.Add(item);
            }

            return room;
        }
    }


}
