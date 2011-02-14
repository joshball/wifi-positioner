using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WiFiPositioner.Datastructures
{
    /// <summary>
    /// Stores a position in form of coordinates (int x, int y)
    /// </summary>
    class Position
    {
        /// <summary>
        /// the x value
        /// </summary>
        private int x;

        /// <summary>
        /// the y value
        /// </summary>
        private int y;

        /// <summary>
        /// Standard constructor doesn't do anything special
        /// </summary>
        public Position()
        {
        }

        /// <summary>
        /// Constructor writes the position values
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// returns the x value
        /// </summary>
        /// <returns>int</returns>
        public int getX()
        {
            return this.x;
        }

        /// <summary>
        /// returns the y value
        /// </summary>
        /// <returns>int</returns>
        public int getY()
        {
            return this.y;
        }
    }
}
