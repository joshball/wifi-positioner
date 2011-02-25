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

using NativeWifi;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WiFiPositioner.Datastructures;
using WiFiPositioner.Properties;
using WiFiPositioner.Utilities;

namespace WiFiPositioner.Interfaces
{
    /// <summary>
    /// This interface can be used to implement new types of creating maps and calculate the position.
    /// </summary>
    interface Positionable
    {
        void start();
        Position findPosition(WlanClient client);
        bool createSectorAtPosition(int sector, int xSector, int ySector, WlanClient client);
        Position printFinalResult(List<SectorDifference> list);
        SortedDictionary<int, Sector> getAccessPointMap();
        SortedDictionary<int, Sector> loadMap(string type, string mapName);
        void saveMap(string mapName);
    }
}
