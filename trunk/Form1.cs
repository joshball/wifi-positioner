using NativeWifi;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using SpykeeWifiPositionFancy;
using SpykeeWifiPositionFancy.Datastructures;

namespace SpykeeWifiPositionFancy
{
    public partial class Form1 : Form
    {
        private string mapName = "";
        private int sectorCounter;

        private Positioning posSystem;

        private WlanClient client;

        private SortedDictionary<int, Sector> tempList;

        public Form1()
        {
            InitializeComponent();

            sectorCounter = 0;
            client = new WlanClient();
            posSystem = new Positioning();
        }       

        private void loadXML_Click(object sender, EventArgs e)
        {
            openFD.Title = "Load XML Map";
            openFD.FileName = "";
            openFD.Filter = "XML Map|*.xml";

            if (openFD.ShowDialog() != DialogResult.Cancel)
            {
                mapName = openFD.FileName;

                labelMapName.Text = mapName;

                tempList = posSystem.loadMap("xml", mapName);

                Console.WriteLine("adding loaded sectors to the global dictionary");

                posSystem.setAccessPointMap(tempList);

                labelAps.Text = posSystem.getXmlApCounter().ToString();
                labelSectors.Text = posSystem.getXmlSectorCounter().ToString();

                refreshValues();
            }
        }
        
        private void buttonMeasure_Click(object sender, EventArgs e)
        {
            refreshValues();

            if (posSystem.createSectorAtPosition(sectorCounter,
                                             int.Parse(textBoxSaveX.Text),
                                             int.Parse(textBoxSaveY.Text), client))
            {
                sectorCounter++;

                labelSectorNumber.Text = sectorCounter.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            refreshValues();

            string saveFile = "";

            saveFD.Title = "Save XML Map";
            saveFD.FileName = "";
            
            if (saveFD.ShowDialog() != DialogResult.Cancel)
            {
                saveFile = saveFD.FileName;

                posSystem.saveMap(saveFile);
            }
        }

        private void refreshValues()
        {
            if (textBoxScanPause.Text != "")
                posSystem.setScanPause(int.Parse(textBoxScanPause.Text));
            else
            {
                posSystem.setScanPause(3000);
                textBoxScanPause.Text = "3000";
            }

            if (textBoxMinRange.Text != "")
                posSystem.setMinimumRangeRssi(int.Parse(textBoxMinRange.Text));
            else
            {
                posSystem.setMinimumRangeRssi(-60);
                textBoxMinRange.Text = "-60";
            }

            posSystem.setStandardError(checkBoxStandardFluctuation.Checked);

            if (textBoxStandardFluctuation.Text != "")
                posSystem.setErrorBuffer(int.Parse(textBoxStandardFluctuation.Text));
            else
            {
                posSystem.setErrorBuffer(0);
                textBoxStandardFluctuation.Text = "0";
            }

            if (textBoxMapCreationCount.Text != "")
                posSystem.setMapCreationCounter(int.Parse(textBoxMapCreationCount.Text));
            else
            {
                posSystem.setMapCreationCounter(5);
                textBoxMapCreationCount.Text = "5";
            }

            if (textBoxFindCount.Text != "")
                posSystem.setFindPositionCounter(int.Parse(textBoxFindCount.Text));
            else
            {
                posSystem.setFindPositionCounter(5);
                textBoxFindCount.Text = "5";
            }
        }

        private void buttonFindPosition_Click(object sender, EventArgs e)
        {
            refreshValues();

            Position tempPos = posSystem.findPosition(client);

           // if (tempPos != null)
            //{
                labelXPos.Text = tempPos.getX().ToString();
                labelYPos.Text = tempPos.getY().ToString();
            //}
            //else
              //  Console.WriteLine("ERROR: Can't find position!");
        }
    }
}
