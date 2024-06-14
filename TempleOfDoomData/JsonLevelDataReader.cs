using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TempleOfDoomData
{
    public class JsonLevelDataReader : ILevelDataReader
    {
        public RootobjectDTO ReadLevelData(string filePath)
        {
            string jsonContent = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<RootobjectDTO>(jsonContent);
        }
    }


}
