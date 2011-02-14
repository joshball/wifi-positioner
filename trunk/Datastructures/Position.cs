using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpykeeWifiPositionFancy.Datastructures
{
    class Position
    {
        private int x;
        private int y;

        public Position()
        {
        }

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int getX()
        {
            return this.x;
        }

        public int getY()
        {
            return this.y;
        }
    }
}
