using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WiFiPositioner.Datastructures
{
    /// <summary>
    /// This class is used to save all data that is neede to describe a sector. A sector consists of
    /// the coordinates given by the private data fields <c>x</c> and <c>y</c>. There is also a list of all
    /// access points, called <c>apList</c>, which are available in this sector and seem to be useful for 
    /// further calculation.
    /// </summary>
    class Sector
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
        /// Dictionary - stores all access points available in this sector which seems to be useful for further calculation
        /// </summary>
        private Dictionary<string, AccessPoint> apList;

        /// <summary>
        /// int - stores the id of a sector if it is needed
        /// </summary>
        private int id;

        /// <summary>
        /// Standardconstructor creates an instance of this class and initializes the primitives to 0.
        /// </summary>
        public Sector()
        {
            this.apList = new Dictionary<string,AccessPoint>();
            
            this.x = 0;
            this.y = 0;

            this.id = 1;
        }

        /// <summary>
        /// Constructor creates an instance of this class and uses the coordinates for this
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Sector(int x, int y)
        {
            this.x = x;
            this.y = y;

            this.id = 1;
        }

        /// <summary>
        /// Constructor creates an instance of this class and uses some initiliazing parameters. The coordinates by
        /// the integers <c>x</c> and <c>y</c> and the <c>id</c>.
        /// </summary>
        /// <param name="x">int</param>
        /// <param name="y">int</param>
        /// <param name="id">int</param>
        public Sector(int x, int y, int id)
        {
            this.apList = new Dictionary<string, AccessPoint>();

            this.x = x;
            this.y = y;

            this.id = id;
        }

        /// <summary>
        /// Constructor creates an instance of this class with coordinates and the list of accesspoints
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="apList"></param>
        public Sector(int x, int y, Dictionary<string, AccessPoint> apList)
        {
            this.x = x;
            this.y = y;
            this.apList = apList;

            this.id = 1;
        }
        
        /// <summary>
        /// method takes an <c>AccessPoint</c> and adds it to this sector.
        /// </summary>
        /// <param name="ap">AccessPoint</param>
        public void addAccessPointToSector(AccessPoint ap)
        {
            string bssid = ap.getBssid();
            this.apList.Add(bssid, ap);
        }

        /// <summary>
        /// method takes a MAC address and a signal strength and adds an <c>AccessPoint</c> object
        /// to the list.
        /// </summary>
        /// <param name="bssid">string</param>
        /// <param name="rssi">double</param>
        public void addAccessPointToSector(string bssid, double rssi)
        {
            AccessPoint ap = new AccessPoint(bssid, rssi);
            this.apList.Add(bssid, ap);
        }

        /// <summary>
        /// methods takes a lot of parameters belonging to an access point and adds the object to it's list
        /// </summary>
        /// <param name="bssid">string</param>
        /// <param name="rssi">double</param>
        /// <param name="mapMinRssi">double</param>
        /// <param name="mapMaxRssi">double</param>
        public void addAccessPointToSector(string bssid, double rssi, double mapMinRssi, double mapMaxRssi)
        {
            AccessPoint ap = new AccessPoint(bssid, rssi, mapMinRssi, mapMaxRssi);
            this.apList.Add(bssid, ap);
        }

        /// <summary>
        /// returns the entire list of access points
        /// </summary>
        /// <returns>Dictionary</returns>
        public Dictionary<string, AccessPoint> getAccessPoints()
        {
            return this.apList;
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
        /// returns the sector id
        /// </summary>
        /// <returns>int</returns>
        public int getSectorId()
        {
            return this.id;
        }

        /// <summary>
        /// sets the x coordinate
        /// </summary>
        /// <param name="x">int</param>
        public void setX(int x)
        {
            this.x = x;
        }
        
        /// <summary>
        /// sets the y coordinate
        /// </summary>
        /// <param name="y">int</param>
        public void setY(int y)
        {
            this.y = y;
        }

        /// <summary>
        /// sets the id of the sector
        /// </summary>
        /// <param name="id">int</param>
        public void setSectorId(int id)
        {
            this.id = id;
        }

        /// <summary>
        /// sets the access point list
        /// </summary>
        /// <param name="list">Dictionary</param>
        public void setAccessPointList(Dictionary<string, AccessPoint> list)
        {
            this.apList = list;
        }
    }
}
