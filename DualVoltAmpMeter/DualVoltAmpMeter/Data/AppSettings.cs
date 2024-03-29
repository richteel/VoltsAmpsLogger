﻿using System.Windows.Forms;

namespace DualVoltAmpMeter.Data
{
    public class AppSettings
    {
        /*********************************************************************************
         * Properties 
         *********************************************************************************/
        public ChartSettings MeterChartSettings { get; set; }
        public bool OptionPanelCollapsed { get; set; }
        public int OptionPanelTabIndex { get; set; }
        public int OptionPanelSplitterDistance { get; set; }
        public int WindowLeft { get; set; }
        public int WindowHeight { get; set; }
        public FormWindowState WindowState { get; set; }
        public int WindowTop { get; set; }
        public int WindowWidth { get; set; }


        /*********************************************************************************
         * Class Constructor 
         *********************************************************************************/
        public AppSettings()
        {
            MeterChartSettings = new ChartSettings();
            OptionPanelCollapsed = false;
            OptionPanelTabIndex = 0;
            OptionPanelSplitterDistance = 220;
            WindowHeight = 490;
            WindowLeft = 100;
            WindowState = FormWindowState.Normal;
            WindowTop = 100;
            WindowWidth = 820;
        }
    }
}
