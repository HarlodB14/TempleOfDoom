using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempleOfDoomController
{
    public class ConsoleInput
    {
        public ConsoleKeyInfo GetInput()
        {
            return Console.ReadKey(true); 
        }
    }
}
