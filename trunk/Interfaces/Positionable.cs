using NativeWifi;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SpykeeWifiPositionFancy.Datastructures;
using SpykeeWifiPositionFancy.Properties;
using SpykeeWifiPositionFancy.Utilities;

namespace SpykeeWifiPositionFancy.Interfaces
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
