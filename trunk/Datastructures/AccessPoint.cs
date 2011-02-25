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
    /// This class is used to save data about an access point.
    /// </summary>
    class AccessPoint
    {
        /// <summary>
        /// string - the MAC address of the access point
        /// </summary>
        private string bssid;

        /// <summary>
        /// double - the signal strength during the measurement
        /// </summary>
        private double rssi;

        /// <summary>
        /// double - the fluctuation of the signal strength
        /// </summary>
        private double fluctuation;

        /// <summary>
        /// double - the minimum value measured during map creation
        /// </summary>
        private double mapMinRssi;

        /// <summary>
        /// double - the maximum value measured during map creation
        /// </summary>
        private double mapMaxRssi;

        /// <summary>
        /// Constructor creates an instance using the MAC address and the signal strength
        /// </summary>
        /// <param name="bssid">string</param>
        /// <param name="rssi">double</param>
        public AccessPoint(string bssid, double rssi)
        {
            this.bssid = bssid;
            this.rssi = rssi;
        }

        /// <summary>
        /// Constructor creates an instance using the MAC address, signal strength and fluctuation
        /// </summary>
        /// <param name="bssid">string</param>
        /// <param name="rssi">double</param>
        /// <param name="fluctuation">double</param>
        public AccessPoint(string bssid, double rssi, double fluctuation)
        {
            this.bssid = bssid;
            this.rssi = rssi;
            this.fluctuation = fluctuation;
        }

        /// <summary>
        /// Constructor creates an instance using the MAC address, signal strength and the max and min values for it
        /// </summary>
        /// <param name="bssid">string</param>
        /// <param name="rssi">double</param>
        /// <param name="mapMinRssi">double</param>
        /// <param name="mapMaxRssi">double</param>
        public AccessPoint(string bssid, double rssi, double mapMinRssi, double mapMaxRssi)
        {
            this.bssid = bssid;
            this.rssi = rssi;
            this.mapMaxRssi = mapMaxRssi;
            this.mapMinRssi = mapMinRssi;
        }


        /// <summary>
        /// returns the MAC address
        /// </summary>
        /// <returns>string</returns>
        public string getBssid()
        {
            return this.bssid;
        }

        /// <summary>
        /// returns the signal strength
        /// </summary>
        /// <returns>double</returns>
        public double getRssi()
        {
            return this.rssi;
        }

        /// <summary>
        /// returns the fluctuation
        /// </summary>
        /// <returns>double</returns>
        public double getFluctuation()
        {
            return this.fluctuation;
        }

        /// <summary>
        /// returns the minimum signal strength measured
        /// </summary>
        /// <returns>double</returns>
        public double getMapMinRssi()
        {
            return this.mapMinRssi;
        }

        /// <summary>
        /// returns the maximum signal strength measured
        /// </summary>
        /// <returns>double</returns>
        public double getMapMaxRssi()
        {
            return this.mapMaxRssi;
        }

        /// <summary>
        /// sets the MAC address to a new value
        /// </summary>
        /// <param name="bssid">string</param>
        public void setBssi(string bssid)
        {
            this.bssid = bssid;
        }

        /// <summary>
        /// sets the signal strength to a new value
        /// </summary>
        /// <param name="rssi">double</param>
        public void setRssi(double rssi)
        {
            this.rssi = rssi;
        }

        /// <summary>
        /// sets the fluctuation to a new value
        /// </summary>
        /// <param name="fluctuation">double</param>
        public void setFluctuation(double fluctuation)
        {
            this.fluctuation = fluctuation;
        }
    }
}
