/*
 *  WiFi Positioner - Finds your position within WiFi Hotspots
    Copyright (C) 2011  Andre Silaghi

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

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
