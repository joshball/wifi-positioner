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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;

using WiFiPositioner;
using WiFiPositioner.Datastructures;

namespace WiFiPositioner
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

            // test for entered x,y coordinates
            if (isInteger(textBoxSaveX.Text) && isInteger(textBoxSaveY.Text) &&
               !textBoxSaveX.Text.Equals("") && !textBoxSaveY.Text.Equals(""))
            {
                try
                {
                    if (posSystem.createSectorAtPosition(sectorCounter,
                                                     int.Parse(textBoxSaveX.Text),
                                                     int.Parse(textBoxSaveY.Text), client))
                    {
                        sectorCounter++;

                        labelSectorNumber.Text = sectorCounter.ToString();
                    }
                }
                catch (System.ComponentModel.Win32Exception w32)
                {
                    MessageBox.Show("Sorry, it seems that your windows is not able to make use of the NativeWifi library which is included here. "
                                        +"\n The following exception occured: \n\n " + w32.StackTrace+ "\n"
                                        +" The error is already known but not fixed yet. You can try it on Windows Vista or 7", "Library Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You have to enter a coordinate value for X and y", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sectorCounter != 0)
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
            else
            {
                MessageBox.Show("There is no data to save!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (sectorCounter != 0)
            {
                refreshValues();

                Position tempPos = posSystem.findPosition(client);

                labelXPos.Text = tempPos.getX().ToString();
                labelYPos.Text = tempPos.getY().ToString();
            }
            else
            {
                MessageBox.Show("There is no data which could be used to calculate the position!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool isInteger(String numberToTest)
        {
            Regex objNotIntPattern = new Regex("[^0-9-]");
            Regex objIntPattern = new Regex("^-[0-9]+$|^[0-9]+$");
            return !objNotIntPattern.IsMatch(numberToTest) && objIntPattern.IsMatch(numberToTest);
        }
    }
}
