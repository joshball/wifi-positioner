using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpykeeWifiPositionFancy.Utilities
{
    /// <summary>
    /// In order to calculate the position of the client wifi adapter a difference between the access points of the map and the access points
    /// which have been just measured, have to be compared. This storage type is designed to save all needed data temporary for further
    /// calculation.
    /// </summary>
    class SectorDifference
    {
        /// <summary>
        /// int - stores the x coordinate of the sector
        /// </summary>
        private int x;

        /// <summary>
        /// int - stores the y coordinate of the sector
        /// </summary>
        private int y;

        /// <summary>
        /// double - stores the difference between the access points
        /// </summary>
        private double dRssi;

        /// <summary>
        /// Constructor creates an instance of this class and initializes the private data fields by a list of parameters.
        /// </summary>
        /// <param name="x">int</param>
        /// <param name="y">int</param>
        /// <param name="dRssi">double</param>
        public SectorDifference(int x, int y, double dRssi)
        {
            this.x = x;
            this.y = y;
            this.dRssi = dRssi;
        }

        /// <summary>
        /// returns the x coordinate
        /// </summary>
        /// <returns>int</returns>
        public int getX()
        {
            return this.x;
        }

        /// <summary>
        /// returns the y coordinate
        /// </summary>
        /// <returns>int</returns>
        public int getY()
        {
            return this.y;
        }

        /// <summary>
        /// returns the difference of the signal strengths
        /// </summary>
        /// <returns></returns>
        public double getRssi()
        {
            return this.dRssi;
        }

        /// <summary>
        /// sets the x coordinate to a new value
        /// </summary>
        /// <param name="x">int</param>
        public void setX(int x)
        {
            this.x = x;
        }

        /// <summary>
        /// sets the y coordinate to a new value
        /// </summary>
        /// <param name="y">int</param>
        public void setY(int y)
        {
            this.y = y;
        }

        /// <summary>
        /// sets the signal strength to a new value
        /// </summary>
        /// <param name="dRssi">double</param>
        public void setdRssi(double dRssi)
        {
            this.dRssi = dRssi;
        }
    }
}
