﻿// SOURCE: https://dariosantarelli.wordpress.com/2010/10/18/c-how-to-programmatically-find-a-com-port-by-friendly-name/

using System;
using System.Collections.Generic;

using System.Management;

namespace DualVoltAmpMeter.Data
{
    internal class ProcessConnection
    {
        public static ConnectionOptions ProcessConnectionOptions()
        {
            ConnectionOptions options = new ConnectionOptions()
            {
                Impersonation = ImpersonationLevel.Impersonate,
                Authentication = AuthenticationLevel.Default,
                EnablePrivileges = true
            };

            return options;
        }

        public static ManagementScope ConnectionScope(string machineName, ConnectionOptions options, string path)
        {
            ManagementScope connectScope = new ManagementScope()
            {
                Path = new ManagementPath(@"\\" + machineName + path),
                Options = options
            };
            connectScope.Connect();

            return connectScope;
        }
    }
    public class ComPortItem
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }

        public static List<ComPortItem> GetCOMPortsInfo()
        {
            List<ComPortItem> comPortInfoList = new List<ComPortItem>();
            ConnectionOptions options = ProcessConnection.ProcessConnectionOptions();
            ManagementScope connectionScope = ProcessConnection.ConnectionScope(Environment.MachineName, options, @"\root\CIMV2");
            ObjectQuery objectQuery = new ObjectQuery("SELECT * FROM Win32_PnPEntity WHERE ConfigManagerErrorCode = 0");
            ManagementObjectSearcher comPortSearcher = new ManagementObjectSearcher(connectionScope, objectQuery);

            using (comPortSearcher)
            {
                string caption = null;
                foreach (ManagementObject obj in comPortSearcher.Get())
                {
                    if (obj != null)
                    {
                        object captionObj = obj["Caption"];
                        if (captionObj != null)
                        {
                            caption = captionObj.ToString();
                            if (caption.Contains("(COM"))
                            {
                                ComPortItem comPortInfo = new ComPortItem() {
                                    Name = caption.Substring(
                                                                caption.LastIndexOf("(COM")).Replace("(", string.Empty).Replace(")",
                                                                string.Empty),
                                    Description = caption
                                };
                                comPortInfoList.Add(comPortInfo);
                            }
                        }
                    }
                }
            }

            return comPortInfoList;
        }
    }
}
