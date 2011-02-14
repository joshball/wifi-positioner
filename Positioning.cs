using NativeWifi;

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.XPath;

using Newtonsoft.Json;

using SpykeeWifiPositionFancy.Interfaces;
using SpykeeWifiPositionFancy.Datastructures;
using SpykeeWifiPositionFancy.Utilities;

namespace SpykeeWifiPositionFancy
{
    /// <summary>
    /// This class does all the neede operations in oder to calculate the current position of the wifi adapter. Due to the fact that
    /// Windows needs some time to recreate the wifi access point lists, the code, if it used without redefined parameteres, will 
    /// pause for five seconds after each measuring, during the map creation process. The same pause is also used for the measuring 
    /// of access point signal strength during the position calculatin process.
    /// 
    /// The first measuring will always be dropped because it has the same values. It should be different from the 2nd otherwise it
    /// intervents too much into the calculation.
    /// 
    /// Example:
    /// </summary>
    /// <example>
    /// <code>
    /// using NativeWifi;
    /// 
    /// namespace Main
    /// {
    ///     public class Main
    ///     {
    ///         public static void Main(String[] args)
    ///         {
    ///             // standard values
    ///             Positionable myPos = new Positioning(4000, // scanpause in ms
    ///                                                   -60, // minimum range rssi
    ///                                                 false, // standard error buffer deactivate
    ///                                                     0, // standard error buffer value
    ///                                                     4, // measurements for map creation
    ///                                                     4, // measurements for position calculation);
    ///         
    ///             WlanClient client = new WlanClient();
    ///             
    ///             // hit enter to start
    ///             string sInput = Console.ReadLine();
    ///             
    ///             // create virtual sector map
    ///             while(sInput.Equals(""))
    ///             {
    ///                 int tempSector = myPos.getSectorCounter();
    ///                 myPos.setSectorCounter(tempSector++);
    ///                 myPos.createSectorAtPosition(tempSector, client);
    ///                 
    ///                 // hit enter to do it again
    ///                 sInput = Console.ReadLine();
    ///             }
    ///             
    ///             // find position
    ///             while (true)
    ///             {
    ///                 myPos.findPosition(client);
    ///             }
    ///         }
    ///     }
    /// }
    /// </code>
    /// </example>
    class Positioning : Positionable
    {
        /// <summary>
        /// SortedDictionary - is used to save the entire virtual map including all sectors, access points, and many more data
        /// </summary>
        private SortedDictionary<int, Sector> accessPointsMap;

        /// <summary>
        /// int - this counter helps to know which is the last sector that has been saved
        /// </summary>
        private int sectorCount;

        /// <summary>
        /// int - this value gives the breaktime for the multiple measuring
        /// </summary>
        private int scanPause;

        /// <summary>
        /// int - this value sets a minimum signal strength which has to be used as a border. All access points with a more worse signal
        /// than this will be ignored. This only works if the <c>standardError</c> parameter is set to true.
        /// </summary>
        private int minimumRangeRssi;

        /// <summary>
        /// Boolean - this is the switch which can be turned on and off to ignore access points which have a very weak signal strength.
        /// </summary>
        private Boolean standardError;

        /// <summary>
        /// int - this value is used together with the calculated signal strength differences. If the difference is under 2 it will be
        /// set to 0.
        /// </summary>
        private int errorBuffer;

        /// <summary>
        /// int - this value defines how many measurements have to be done during the map creation process for every sector.
        /// </summary>
        private int mapCreationCount;

        /// <summary>
        /// int - this value defines how many measurements have to be done during the position finding process for the current position.
        /// </summary>
        private int findPositionCount;

        /// <summary>
        /// int - xml sector counter
        /// </summary>
        private int xmlCountSector = 0;

        /// <summary>
        /// int - xml access points counter
        /// </summary>
        private int xmlCountAps = 0;

        /// <summary>
        /// Empty constructor just creates an instance of this class.
        /// </summary>
        public Positioning()
        {
            this.accessPointsMap = new SortedDictionary<int, Sector>();
        }

        /// <summary>
        /// Constructor creates an instance of this class and takes a complete virtual access point map.
        /// </summary>
        /// <param name="tempSector">SortedDictionary</param>
        public Positioning(SortedDictionary<int, Sector> tempSector)
        {
            this.accessPointsMap = tempSector;
            this.sectorCount = 0;
        }

        /// <summary>
        /// Constructor creates an instance of this class and takes a lot of parameters to personalize the entire position finding process.
        /// </summary>
        /// <param name="scanPause">int</param>
        /// <param name="minimumRangeRssi">int</param>
        /// <param name="standardError">Boolean</param>
        /// <param name="errorBuffer">int</param>
        /// <param name="mapCreationCount">int</param>
        /// <param name="findPositionCount">int</param>
        public Positioning(int scanPause, int minimumRangeRssi, Boolean standardError, int errorBuffer, int mapCreationCount, int findPositionCount)
        {
            this.accessPointsMap = new SortedDictionary<int, Sector>();

            this.sectorCount = 0;
            this.scanPause = scanPause;
            this.minimumRangeRssi = minimumRangeRssi;
            this.standardError = standardError;
            this.errorBuffer = errorBuffer;
            this.mapCreationCount = mapCreationCount;
            this.findPositionCount = findPositionCount;
        }

        /// <summary>
        /// Constructor creates an instance of this class and takes a lot of parameters to personalize the entire position finding process.
        /// In this case it is also possible to provide a complete new map of access points so that the map creation doesn't have to be done.
        /// </summary>
        /// <param name="tempSector">int</param>
        /// <param name="scanPause">int</param>
        /// <param name="minimumRangeRssi">int</param>
        /// <param name="standardError">Boolean</param>
        /// <param name="errorBuffer">int</param>
        /// <param name="mapCreationCount">int</param>
        /// <param name="findPositionCount">int</param>
        public Positioning(SortedDictionary<int, Sector> tempSector, int scanPause, int minimumRangeRssi, Boolean standardError, int errorBuffer, int mapCreationCount, int findPositionCount)
        {
            this.accessPointsMap = tempSector;

            this.sectorCount = 0;
            this.scanPause = scanPause;
            this.minimumRangeRssi = minimumRangeRssi;
            this.standardError = standardError;
            this.errorBuffer = errorBuffer;
            this.mapCreationCount = mapCreationCount;
            this.findPositionCount = findPositionCount;
        }

        /// <summary>
        /// method creates a frame where the entire process of the position finding can take place. In this case it is a standard
        /// procedure which can be used for testing. It is also possible to inherit this class and write a complete new start()
        /// method or to reimplement the <c>Positionable</c> interface, to create a complete new algorithm.
        /// </summary>
        public virtual void start()
        {
            /*Console.WriteLine("Starting ... hit enter to create a map or type 'm' and hit enter after you have finished!");
            WlanClient client = new WlanClient();
            string sInput = Console.ReadLine();

            while (sInput.Equals(""))
            {
                this.sectorCount++;
                createSectorAtPosition(this.sectorCount, client);

                sInput = Console.ReadLine();
            }

            Console.WriteLine("Hit enter to start finding the position");
            string sInput2 = Console.ReadLine();

            while (sInput2.Equals(""))
            {
                findPosition(client);
                sInput2 = Console.ReadLine();
            }*/
        }

        /// <summary>
        /// loads a virtual access point map. you have to supply the type of the file and the name. possibles types are:
        ///
        /// - json (TODO: read file and interpret)
        /// 
        /// </summary>
        /// <param name="type">string</param>
        /// <param name="mapName">string</param>
        /// <returns>SortedDictionary</returns>
        public virtual SortedDictionary<int, Sector> loadMap(string type, string mapName)
        {
            SortedDictionary<int, Sector> apMap = new SortedDictionary<int, Sector>();
            
            Dictionary<string, AccessPoint> apList = new Dictionary<string, AccessPoint>();
            Sector tempSector = new Sector();

            if (type.Equals("xml"))
            {
                // xpath
                XPathNavigator nav;
                XPathDocument docNav;
                XPathNodeIterator NodeIter;
                String strExpression;

                docNav = new XPathDocument(mapName);
                Console.WriteLine("reading " + mapName);

                nav = docNav.CreateNavigator();

                // read map
                strExpression = "//map/sector/*";
                NodeIter = nav.Select(strExpression);

                int counter = 0;
                while (NodeIter.MoveNext())
                {
                    if (counter == 0)
                    {
                        Console.WriteLine("number: " + NodeIter.Current.Value);
                        tempSector.setSectorId(int.Parse(NodeIter.Current.Value));
                        this.xmlCountSector++;
                    }
                    else if (counter == 1)
                    {
                        Console.WriteLine("x: " + NodeIter.Current.Value);
                        tempSector.setX(int.Parse(NodeIter.Current.Value));
                    }
                    else if (counter == 2)
                    {
                        Console.WriteLine("y: " + NodeIter.Current.Value);
                        tempSector.setY(int.Parse(NodeIter.Current.Value));
                    }
                    else
                    {
                        if (NodeIter.Current.Value.Equals("stop"))
                        {
                            tempSector.setAccessPointList(apList);

                            Console.WriteLine("counter = " + counter);

                            apMap.Add(tempSector.getSectorId(), tempSector);
                            counter = 0;                            

                            // reset temp dicitionary
                            apList = null;
                            apList = new Dictionary<string, AccessPoint>();

                            Console.WriteLine("sector saved");
                        }
                        else
                        {
                           Console.WriteLine("accesspoint: " + NodeIter.Current.Value);
                           string[] splitted = NodeIter.Current.Value.Split('|');

                           Console.WriteLine("split0: " + splitted[0]);
                           Console.WriteLine("split1: " + splitted[1]);

                           AccessPoint tempAp = new AccessPoint(splitted[0], double.Parse(splitted[1]));
                           
                           apList.Add(splitted[0], tempAp);

                           this.xmlCountAps++;
                        }
                    }

                    if(!NodeIter.Current.Value.Equals("stop"))
                        counter++;
                }

                Console.WriteLine("finished reading");

                if (apMap.Count == 0)
                    Console.WriteLine("ap map while xml loading is empty!");

                return apMap;
            }
            else if (type.Equals("json"))
            {
                Console.WriteLine("json file loading ... ");
                // MAKE ME WORK
                return null;
            }
            else
            {
                Console.WriteLine("only 'xml' or 'json' files could be read!");
                return null;
            }
        }

        /// <summary>
        /// saves the current map into a file
        /// </summary>
        /// <param name="mapName">string</param>
        public virtual void saveMap(string mapName)
        {
            XmlTextWriter xml = new XmlTextWriter(mapName, null);

            try
            {
                //string json = JsonConvert.SerializeObject(this.accessPointsMap);
                //fileWriter.Write(json);

                xml.WriteStartDocument();
                xml.WriteStartElement("map");
                xml.WriteWhitespace("");

                int sectorCounter = 0;

                // cycle through map
                foreach (KeyValuePair<int, Sector> keyValPair in this.accessPointsMap)
                {
                    sectorCounter++;

                    int maxSectors = this.accessPointsMap.Count;

                    int sectorNumber = keyValPair.Key;
                    Sector sector = keyValPair.Value;

                    xml.WriteStartElement("sector");

                    xml.WriteStartElement("number");
                    xml.WriteString(sectorNumber.ToString());
                    xml.WriteEndElement();

                    xml.WriteStartElement("x");
                    xml.WriteString(sector.getX().ToString());
                    xml.WriteEndElement();

                    xml.WriteStartElement("y");
                    xml.WriteString(sector.getY().ToString());
                    xml.WriteEndElement();
 
                    Dictionary<string, AccessPoint> accessPointDictionary = sector.getAccessPoints();

                    int apCount = 0;
                    foreach (KeyValuePair<string, AccessPoint> entryPair in accessPointDictionary)
                    {
                        string bssid = entryPair.Key;
                        AccessPoint accessPoint = entryPair.Value;

                        xml.WriteStartElement("accesspoint");
                        xml.WriteStartElement("bssid");
                        xml.WriteString(accessPoint.getBssid());
                        xml.WriteEndElement();
                        xml.WriteStartElement("rssi");
                        xml.WriteString(accessPoint.getRssi().ToString());
                        xml.WriteEndElement();
                        xml.WriteEndElement();

                        apCount++;
                    }

                    xml.WriteStartElement("stop");
                    xml.WriteString("stop");
                    xml.WriteEndElement();

                    xml.WriteEndElement();
                }

                xml.WriteEndElement();
                xml.WriteEndDocument();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                xml.Close();
            }

        }

        /// <summary>
        /// method is used to calculate the position of the wifi adapter (client). Be aware of the possibly long break!
        /// </summary>
        /// <param name="client">WlanClient</param>
        /// <returns>Position</returns>
        public virtual Position findPosition(WlanClient client)
        {
            LinkedList<BlindMeasurement> measured = new LinkedList<BlindMeasurement>();

            Dictionary<string, RssiCalcHelper> calcList = new Dictionary<string, RssiCalcHelper>();

            Wlan.WlanBssEntry[] bsses = client.Interfaces[0].GetNetworkBssList();

            int rssi = 0;

            for (int i = 0; i < this.findPositionCount; i++)
            {
                foreach (Wlan.WlanBssEntry bss in bsses)
                {
                    rssi = bss.rssi;    // signal strength
                    string bssid = Converter.getBssid(bss);

                    if (rssi > this.minimumRangeRssi || this.minimumRangeRssi == 0)
                    {
                        if (i != 0)
                        {
                            if (!calcList.ContainsKey(bssid))
                            {
                                calcList.Add(bssid, new RssiCalcHelper(rssi));
                            }
                            else if (calcList.ContainsKey(bssid))
                            {
                                RssiCalcHelper tempHelper = calcList[bssid];
                                calcList.Remove(bssid);

                                tempHelper.addRssi(rssi);
                                calcList.Add(bssid, tempHelper);
                            }

                            Console.WriteLine("Measurement - AP: bssid=" + bssid + " rssi=" + rssi);
                        }
                        else
                        {
                            Console.WriteLine("1st measurement dropped!");
                        }
                    }
                }

                Console.WriteLine("");

                Thread.Sleep(this.scanPause);
                bsses = client.Interfaces[0].GetNetworkBssList();
                client.Interfaces[0].Scan();
            }

            foreach (KeyValuePair<string, RssiCalcHelper> keyValPair in calcList)
            {
                string bssid = keyValPair.Key;
                RssiCalcHelper tempRssiHelper = keyValPair.Value;
                double averageRssi = tempRssiHelper.getAverageRssi();
                double averageFluctuation = tempRssiHelper.getAverageFluctuation();

                measured.AddLast(new BlindMeasurement(bssid, averageRssi, averageFluctuation));
                Console.WriteLine("Saved Middle value for: " + bssid + " rssi= " + averageRssi+" fluctuation= "+averageFluctuation);
            }

            List<SectorDifference> results = new List<SectorDifference>();

            int counterMap = 0;
            
            foreach (KeyValuePair<int, Sector> keyValPair in this.accessPointsMap)
            {
                int sector = keyValPair.Key;
                Sector tempSector = keyValPair.Value;

                Console.WriteLine("Sector: " + sector);

                int counter = 0;

                Dictionary<string, AccessPoint> tempApMap = tempSector.getAccessPoints();

                double result = 0;

                foreach (BlindMeasurement apData in measured)
                {
                    char[] delimiter = new char[] { '|' };
                    string[] splitted = apData.getBssid().Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
                    apData.setBssid(splitted[0]);
                    
                    if (tempApMap.ContainsKey(apData.getBssid()))
                    {                        
                        AccessPoint apTemp = tempApMap[apData.getBssid()];

                        double tempResult = Math.Abs(apTemp.getRssi() - apData.getRssi());

                        if (
                            (this.standardError == false && tempResult <= apData.getAverageFluctuation()) ||
                            (this.standardError == true && tempResult <= this.errorBuffer)
                           )
                        {
                           tempResult = 0;
                        }

                        result += tempResult;

                        Console.WriteLine("Result: bssid="+apData.getBssid()+" karte " + apTemp.getRssi() + " gemessen " + apData.getRssi() + " DIF: " + tempResult);
                        counter++;
                    }
                }
                counterMap++;

                double average = 0;

                if (counter == 0)
                {   
                    Console.WriteLine("");
                }
                else
                {
                    average = result / counter;

                    Console.WriteLine("calculated range " + result + "/" + counter + " = " + average);
                    results.Add(new SectorDifference(tempSector.getX(), tempSector.getY(), average));
                }
            }

            Console.WriteLine("Results: ");

            results.Sort(delegate(SectorDifference s1, SectorDifference s2)
            {
                return s1.getRssi().CompareTo(s2.getRssi());
            });

            Position tempPos = printFinalResult(results);
            Thread.Sleep(this.scanPause);
            return tempPos;
        }

        /// <summary>
        /// method is used to create a sector at a specified position. This sector and all it's access points will be saved in a
        /// large SortedDictionary type. Be aware of the possibly long pause !
        /// </summary>
        /// <param name="sector">int</param>
        /// <param name="client">WlanClient</param>
        /// <param name="x">int</param>
        /// <param name="y">int</param>
        public virtual bool createSectorAtPosition(int sector, int xSector, int ySector, WlanClient client)
        {
            //Console.WriteLine("X: ");
            int x = xSector;

            //Console.WriteLine("Y: ");
            int y = ySector;

            Sector tempSector = new Sector(x, y, sector);

            Wlan.WlanBssEntry[] bsses = client.Interfaces[0].GetNetworkBssList();
            
            double rssi = 0;

            Dictionary<string, RssiCalcHelper> calcList = new Dictionary<string, RssiCalcHelper>();

            for (int i = 0; i < this.mapCreationCount; i++)
            {
                foreach (Wlan.WlanBssEntry bss in bsses)
                {
                    rssi = bss.rssi;
                    string bssid = Converter.getBssid(bss);

                    if (rssi > this.minimumRangeRssi || this.minimumRangeRssi == 0)
                    {
                        // drop 1st measuring
                        if (i != 0)
                        {
                            if (!calcList.ContainsKey(bssid))
                            {
                                calcList.Add(bssid, new RssiCalcHelper(rssi));
                            }
                            else if (calcList.ContainsKey(bssid))
                            {
                                RssiCalcHelper tempHelper = calcList[bssid];
                                calcList.Remove(bssid);

                                tempHelper.addRssi(rssi);
                                calcList.Add(bssid, tempHelper);
                            }

                            Console.WriteLine("AP: bssid=" + bssid + " rssi=" + rssi + " x=" + x + " y=" + y + " added to list");
                        }
                        else
                        {
                            Console.WriteLine("1st measurement dropped!");
                        }
                    }                                          
                }

                Thread.Sleep(this.scanPause);
                bsses = client.Interfaces[0].GetNetworkBssList();
                client.Interfaces[0].Scan();  
                    
                Console.WriteLine("");
            }            

            foreach (KeyValuePair<string, RssiCalcHelper> keyValPair in calcList)
            {
                string bssid = keyValPair.Key;
                RssiCalcHelper tempRssiHelper = keyValPair.Value;
                double averageRssi = tempRssiHelper.getAverageRssi();

                tempSector.addAccessPointToSector(bssid, averageRssi);
                Console.WriteLine("Saved Middle value for: " + bssid + " rssi= " + averageRssi);
            }
            
            accessPointsMap.Add(sector, tempSector);
            Console.WriteLine("Sector " + sector + " saved at position x=" + x + " y=" + y);

            return true;
        }

        /// <summary>
        /// method prints the final result of the calculation process.
        /// </summary>
        /// <param name="list">List</param>
        public virtual Position printFinalResult(List<SectorDifference> list)
        {
            int resultCounter = 0;
            foreach (SectorDifference sectorDif in list)
            {
                if (resultCounter < 1)
                {
                    Console.WriteLine("Calculated position: x=" + sectorDif.getX() + " y=" + sectorDif.getY());
                    return new Position(sectorDif.getX(), sectorDif.getY());
                }
                else
                    break;

                resultCounter++;
            }
            return null;
        }
        
        /// <summary>
        /// returns the entire sector/accesspoint map
        /// </summary>
        /// <returns>SortedDictionary</returns>
        public SortedDictionary<int, Sector> getAccessPointMap()
        {
            return this.accessPointsMap;
        }

        /// <summary>
        /// sets the sector/accesspoint map
        /// </summary>
        /// <param name="apMap">SortedDictionary</param>
        public void setAccessPointMap(SortedDictionary<int, Sector> apMap)
        {
            this.accessPointsMap = apMap;
        }

        /// <summary>
        /// returns the sector counter
        /// </summary>
        /// <returns>int</returns>
        public int getSectorCounter()
        {
            return this.sectorCount;
        }

        /// <summary>
        /// sets the sector counter
        /// </summary>
        /// <param name="sectorCounter">int</param>
        public void setSectorCounter(int sectorCounter)
        {
            this.sectorCount = sectorCounter;
        }

        /// <summary>
        /// returns the scan pause value
        /// </summary>
        /// <returns>int</returns>
        public int getScanPause()
        {
            return this.scanPause;
        }

        /// <summary>
        /// sets the scan pause value
        /// </summary>
        /// <param name="scanPause">int</param>
        public void setScanPause(int scanPause)
        {
            this.scanPause = scanPause;
        }

        /// <summary>
        /// returns the minimum range signal strength
        /// </summary>
        /// <returns>int</returns>
        public int getMinimumRangeRssi()
        {
            return this.minimumRangeRssi;
        }

        /// <summary>
        /// sets the minimum range signal strength
        /// </summary>
        /// <param name="minimumRangeRssi">int</param>
        public void setMinimumRangeRssi(int minimumRangeRssi)
        {
            this.minimumRangeRssi = minimumRangeRssi;
        }

        /// <summary>
        /// returns whether the standard error should be used (errorBuffer)
        /// </summary>
        /// <returns>Boolean</returns>
        public Boolean getStandardError()
        {
            return this.standardError;
        }

        /// <summary>
        /// sets whether the standard error should be used (errorBuffer)
        /// </summary>
        /// <param name="standardError">Boolean</param>
        public void setStandardError(Boolean standardError)
        {
            this.standardError = standardError;
        }

        /// <summary>
        /// returns the error buffer
        /// </summary>
        /// <returns>int</returns>
        public int getErrorBuffer()
        {
            return this.errorBuffer;
        }

        /// <summary>
        /// sets the error buffer
        /// </summary>
        /// <param name="errorBuffer">int</param>
        public void setErrorBuffer(int errorBuffer)
        {
            this.errorBuffer = errorBuffer;
        }

        /// <summary>
        /// returns the ammount of measurements during the map creation process
        /// </summary>
        /// <returns>int</returns>
        public int getMapCreationCounter()
        {
            return this.mapCreationCount;
        }

        /// <summary>
        /// sets the ammount of measurements during the map creation process
        /// </summary>
        /// <param name="mapCreationCount"></param>
        public void setMapCreationCounter(int mapCreationCount)
        {
            this.mapCreationCount = mapCreationCount;
        }

        /// <summary>
        /// returns the ammount of measurements during the position finding
        /// </summary>
        /// <returns></returns>
        public int getFindPositioinCounter()
        {
            return this.findPositionCount;
        }

        /// <summary>
        /// sets the ammount of measurements during the position finding
        /// </summary>
        /// <param name="findPositionCounter"></param>
        public void setFindPositionCounter(int findPositionCounter)
        {
            this.findPositionCount = findPositionCounter;
        }

        /// <summary>
        /// returns the number of sectors found in the xml file
        /// </summary>
        /// <returns>int</returns>
        public int getXmlSectorCounter()
        {
            return this.xmlCountSector;
        }

        /// <summary>
        /// returns the number of access points found in the xml file
        /// </summary>
        /// <returns></returns>
        public int getXmlApCounter()
        {
            return this.xmlCountAps;
        }
    }
}