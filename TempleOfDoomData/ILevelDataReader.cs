using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempleOfDoomData
{
    public interface ILevelDataReader
    {
        RootobjectDTO ReadLevelData(string filePath);
    }
}
