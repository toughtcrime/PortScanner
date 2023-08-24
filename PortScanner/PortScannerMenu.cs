using System.Net;
using System.Text.RegularExpressions;

namespace PortScanner;

public static class PortScannerMenu
{
    public static string GetIpAdress()
    {
       
        string? ip = string.Empty;
        Console.Write("Type your scan target here: \n");
        string? ipORhost = Console.ReadLine();
        bool isIp = IPAddress.TryParse(ipORhost, out _);
        bool passed = false;
        

        if (!isIp)
        {
            IPHostEntry host = Dns.GetHostEntry(ipORhost);
            ip = host.AddressList[0].ToString();
        }
        return string.IsNullOrEmpty(ipORhost) ? ip : ipORhost;
    }

    public static int GetPort()
    {
        Console.Clear();
        Console.WriteLine("Type port here: ");
        int port = int.Parse(Console.ReadLine());
        return port;
    }

    public static (int,int) GetPortRange()
    {
        Console.Clear();
        int from, to;
        Console.WriteLine("Start port:");
        from = int.Parse(Console.ReadLine());
        Console.WriteLine("End port: ");
        to = int.Parse(Console.ReadLine());
        return (from, to);
    }
    
    public static int[] GetSpecificPorts()
    {
        Console.Clear();
        Console.WriteLine("Type your ports in next format with comma for example: 22,443,80");
        string portsInput = Console.ReadLine();
        int[] ports = Array.ConvertAll(portsInput.Split(','),int.Parse);
        return ports;
    }
    public static void PrintMenu()
    {
        Console.WriteLine("Welcome to the PortScanner");
        Console.WriteLine("Author's Github: https://github.com/toughtcrime\n\n\n\n");
        Console.WriteLine("1. Type 1 if you want to scan specific port");
        Console.WriteLine("2. Type 2 if you want to scan port range. ");
        Console.WriteLine("3. Type 3 if you want to scan speicifc ports.");
    }
}