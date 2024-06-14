using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempleOfDoomModel.Doors;

namespace TempleOfDoomModel
{
    public interface IConnection
    {
        bool CanEntityPass(Player player);
        Room GetConnectedRoom(Room currentRoom);
    }

}
