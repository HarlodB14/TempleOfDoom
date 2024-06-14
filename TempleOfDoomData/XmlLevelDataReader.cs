using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempleOfDoomData
{
    using System.Xml.Serialization;

    public class XmlLevelDataReader : ILevelDataReader
    {
        public RootobjectDTO ReadLevelData(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(RootobjectDTO));
            using (StreamReader reader = new StreamReader(filePath))
            {
                return (RootobjectDTO)serializer.Deserialize(reader);
            }
        }
    }

}
