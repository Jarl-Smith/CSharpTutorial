using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketClient {
    class Program {
        static string ip = "192.168.0.18";
        static int port = 8080;
        static void Main( string[] args ) {

            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(ip) , port);
            Socket socket = new Socket(AddressFamily.InterNetwork , SocketType.Stream , ProtocolType.Tcp);
            socket.Connect(iPEndPoint);
            while ( true ) {
                byte[] b1 = new byte[1024];
                int size = socket.Receive(b1);
                if ( size > 0 ) {
                    Console.WriteLine(System.Text.Encoding.UTF8.GetString(b1 , 0 , size));
                }

                string input = Console.ReadLine();
                byte[] b = System.Text.Encoding.UTF8.GetBytes(input);
                socket.Send(b);
            }
        }

        static void RunableInput( Socket socket ) {
            while ( true ) {
                byte[] b1 = new byte[1024];
                int size = socket.Receive(b1);
                if ( size > 0 ) {
                    Console.WriteLine(System.Text.Encoding.UTF8.GetString(b1 , 0 , size));
                }
            }
        }
    }
}
