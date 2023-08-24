using System.Net.Sockets;

namespace PortScanner;

public class PortScanner
{
    public string IpAdress { get; set; }
    public int DefaultTimeOut { get; set; } = 1000;
    public PortScanner()
    {
    }
    public PortScanner(string ipAdress)
    {
        IpAdress = ipAdress;
    }


    public void ScanSpecificPort(int Port,int timeOut = 6000)
    {
        using TcpClient client = new TcpClient() { ReceiveTimeout = timeOut, SendTimeout = timeOut};
        try
        {
            client.Connect(IpAdress, Port);
            Console.WriteLine($"{Port}/tcp is opened");
            
        }
        catch (SocketException exception)
        {
            switch (exception.SocketErrorCode)
            {
                case SocketError.ConnectionRefused:
                    Console.WriteLine($"{Port}/tcp is closed");
                    break;
                case SocketError.TimedOut:
                    Console.WriteLine($"{Port}/tcp is filtered");
                    break;
                default:
                    Console.WriteLine($"Error: {exception.SocketErrorCode}");
                    break;
            }
        }
    }
    
    public void ScanPortRange(int from, int to, int timeOut = 500)
    {
        for (int i = from; i <= to; i++)
        {
            using TcpClient client = new TcpClient() { ReceiveTimeout = timeOut, SendTimeout = timeOut};
            try
            {
                client.Connect(IpAdress, i);
                Console.WriteLine($"[+]{i}/tcp is opened");
            }
            catch (SocketException exception)
            {
                switch (exception.SocketErrorCode)
                {
                    case SocketError.ConnectionRefused:
                        Console.WriteLine($"{i}/tcp is closed");
                        break;
                    case SocketError.TimedOut:
                        Console.WriteLine($"{i}/tcp is filtered");
                        break;
                    default:
                        Console.WriteLine($"{i}/tcp Error: {exception.SocketErrorCode}");
                        break;
                }
            }
        }
    }

    public void ScanPorts(params int[] ports)
    {
        for (int i = 0; i <= ports.Length; i++)
        {
            using TcpClient client = new TcpClient() { ReceiveTimeout = DefaultTimeOut, SendTimeout = DefaultTimeOut};
            try
            {
                client.Connect(IpAdress, ports[i]);
                Console.WriteLine($"{ports[i]} Client is opened");
            }
            catch (SocketException exception)
            {
                switch (exception.SocketErrorCode)
                {
                    case SocketError.ConnectionRefused:
                        Console.WriteLine($"{ports[i]}/tcp Connection is closed");
                        break;
                    case SocketError.TimedOut:
                        Console.WriteLine($"{ports[i]}/tcp Port is filtered");
                        break;
                    default:
                        Console.WriteLine($"{ports[i]}/tcp Error: {exception.SocketErrorCode}");
                        break;
                }
            }
        }
    }
}