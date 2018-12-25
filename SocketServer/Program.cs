using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketServer {
    class Program {
        static string ip = "192.168.0.18";
        static int port = 8080;
        static Socket serverSocket;
        static void Main( string[] args ) {
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(ip) , port);
            Socket socket = new Socket(AddressFamily.InterNetwork , SocketType.Stream , ProtocolType.Tcp);
            socket.Bind(iPEndPoint);
            socket.Listen(10);
            Console.WriteLine("Start to Listen.....");
            Thread thread = new Thread(( ) => { RunableInput(serverSocket); });
            thread.Start();
            while ( true ) {
                serverSocket = socket.Accept();
                Console.WriteLine("client : {0}    online" , serverSocket.RemoteEndPoint.ToString());
                while ( serverSocket != null ) {
                    try {
                        byte[] b = new byte[1024];
                        int size = serverSocket.Receive(b);
                        if ( size > 0 ) {
                            Console.WriteLine(System.Text.Encoding.UTF8.GetString(b , 0 , size));
                        }
                    } catch ( ObjectDisposedException e ) {
                        Console.WriteLine("客户端断开连接" + e.Message);
                        serverSocket = null;
                    } catch ( SocketException e ) {
                        Console.WriteLine(e.Message);
                        serverSocket = null;
                    }
                }
            }
        }

        static void RunableInput( Socket socket ) {
            while ( true ) {
                if(socket == null ) {
                    continue;
                }
                string input = Console.ReadLine();
                serverSocket.Send(System.Text.Encoding.UTF8.GetBytes(input));
            }
        }
    }
}
