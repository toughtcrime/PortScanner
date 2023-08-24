using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace PortScanner;

internal static class Program
{
    enum Menu : byte
    {
        SinglePort = 1,
        Range = 2 ,
        SpeicifcPorts = 3
    }

   
    public static void Main(string[] args)
    {
        while (true)
        {
            PortScannerMenu.PrintMenu();
            Menu choose = (Menu)byte.Parse(Console.ReadLine());
            string ip = ip = PortScannerMenu.GetIpAdress();
            
            PortScanner scanner = new PortScanner()
            {
                IpAdress = ip
            };
            
            
            switch (choose)
            {
                case Menu.SinglePort:
                    int port = PortScannerMenu.GetPort();
                    scanner.ScanSpecificPort(port);
                    break;
                case Menu.Range:
                    var range = PortScannerMenu.GetPortRange();
                    scanner.ScanPortRange(range.Item1,range.Item2);
                    break;
                case Menu.SpeicifcPorts:
                    int[] ports = PortScannerMenu.GetSpecificPorts();
                    scanner.ScanPorts(ports);
                    break;
            }
        }
     

        
     
    }
}