using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempleOfDoomModel
{
    public class Position
    {
        public int xPos { get;  set; }
        public int yPos { get;  set; }

        public Position(int x, int y)
        {
            xPos = x;
            yPos = y;
        }

        public void moveRight() { xPos++; }
    }
}
