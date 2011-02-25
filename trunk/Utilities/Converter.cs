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
using NativeWifi;

namespace WiFiPositioner.Utilities
{
    /// <summary>
    /// This abstract class is used to convert different things like the <c>WlanBssEntry</c> into a readable string (MAC address)
    /// </summary>
    abstract class Converter
    {
        /// <summary>
        /// char[] - provides the class with all hexadecimal symbols
        /// </summary>
        private static readonly char[] hex = 
        {
            '0', '1', '2', '3', '4', '5',
            '6', '7', '8', '9', 'a', 'b',
            'c', 'd', 'e', 'f' 
        };

        /// <summary>
        /// method creates a string out of the <c>Dot11Ssid</c> type (network name)
        /// </summary>
        /// <param name="ssid">Wlan.Dot11Ssid</param>
        /// <returns>string</returns>
        public static string GetStringForSSID(Wlan.Dot11Ssid ssid)
        {
            return Encoding.ASCII.GetString(ssid.SSID, 0, (int)ssid.SSIDLength);
        }

        /// <summary>
        /// converts the <c>WlanBssEntry</c> type into a readable MAC address
        /// </summary>
        /// <param name="bss">Wlan.WlanBssEntry</param>
        /// <returns>string</returns>
        public static string getBssid(Wlan.WlanBssEntry bss)
        {
            string bssid = "";

            for (int i = 0; i < bss.dot11Bssid.Length; i++)
            {
                if(i == bss.dot11Bssid.Length-1)
                    bssid += "" + hex[bss.dot11Bssid[i] / 16] + hex[bss.dot11Bssid[i] % 16] + "|";
                else
                    bssid += "" + hex[bss.dot11Bssid[i] / 16] + hex[bss.dot11Bssid[i] % 16] + ":";
            }

            return bssid;
        }
    }
}
