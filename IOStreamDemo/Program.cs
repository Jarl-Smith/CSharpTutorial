using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace IOStreamDemo {
    class Program {
        string path = @"../../demo.txt";
        string path1 = @"../../data.bin";

        static void Main( string[] args ) {
            //new Program().Deserialization();
            new PictureFilesRenameHelper().Start();
        }

        //字节流方法读取数据
        void ReadByteInfo( ) {
            byte[] bytes = new byte[200];
            char[] chars = new char[200];
            FileInfo file = null;
            try {
                file = new FileInfo(path);
                using ( FileStream fs = file.OpenRead() ) {
                    fs.Read(bytes , 0 , 200);
                }
                Decoder decoder = Encoding.UTF8.GetDecoder();
                decoder.GetChars(bytes , 0 , bytes.Length , chars , 0 , true);
                Console.WriteLine(chars);
            } catch ( IOException e ) {
                Console.WriteLine(e.Message);
            }
        }
        //字节流方法写入数据
        void WriteByteInfo( ) {
            byte[] bytes = null;
            char[] chars = null;
            FileInfo file = null;
            try {
                file = new FileInfo(path);
                using ( FileStream fs = file.Open(FileMode.OpenOrCreate) ) {
                    chars = "Hello World.".ToCharArray();
                    bytes = new byte[chars.Length];
                    Encoder encoder = Encoding.UTF8.GetEncoder();
                    encoder.GetBytes(chars , 0 , chars.Length , bytes , 0 , true);
                    fs.Write(bytes , 0 , bytes.Length);
                }
            } catch ( IOException e ) {
                Console.WriteLine(e.Message);
            }
        }
        //字符流方法读取数据
        void ReadCharInfo( ) {
            FileInfo file = new FileInfo(path);
            try {
                using ( StreamReader sr = new StreamReader(file.OpenRead() , Encoding.UTF8) ) {
                    string message = null;
                    do {
                        message = sr.ReadLine();
                        Console.WriteLine(message);
                    } while ( message != null );
                }
            } catch ( IOException e ) {
                Console.WriteLine(e.Message);
            }
        }
        //字符流方法写入数据
        void WriteCharInfo( ) {
            FileInfo file = new FileInfo(path);
            try {
                using ( StreamWriter sw = new StreamWriter(file.OpenWrite() , Encoding.UTF8) ) {
                    sw.WriteLine("12345");
                    sw.WriteLine("ashfuieg");
                }
            } catch ( IOException e ) {
                Console.WriteLine(e.Message);
            }
        }

        void Serialization( ) {
            Transform t = new Transform(new Vector2(12 , 13) , new Vector3(1 , 1 , 1));
            t.message = "Jack";
            FileInfo file = new FileInfo(path1);
            try {
                using ( FileStream fs = file.OpenWrite() ) {
                    IFormatter serializer = new BinaryFormatter();
                    serializer.Serialize(fs , t);
                }
            } catch ( IOException e ) {
                Console.WriteLine(e.Message);
            }
        }

        void Deserialization( ) {
            FileInfo file = new FileInfo(path1);
            try {
                using ( FileStream fs = file.OpenRead() ) {
                    IFormatter deserializer = new BinaryFormatter();
                    Transform t = deserializer.Deserialize(fs) as Transform;
                    Console.WriteLine("{0} {1} {2}" , t.V2.X , t.V3.Y , t.message);
                }
            } catch ( IOException e ) {
                Console.WriteLine(e.Message);
            }
        }
    }

    [Serializable]
    struct Vector2 {
        public double X;
        public double Y;
        public Vector2( double x , double y ) {
            X = x;
            Y = y;
        }
    }

    [Serializable]
    class Vector3 {
        public double X;
        public double Y;
        public double Z;
        public Vector3( ) { }
        public Vector3( double x , double y , double z ) {
            X = x;
            Y = y;
            Z = z;
        }
    }

    [Serializable]
    class Transform {
        public Vector2 V2;
        public Vector3 V3;
        public string message;

        public Transform( ) { }

        public Transform( Vector2 v2 , Vector3 v3 ) {
            V2 = v2;
            V3 = v3;
            message = "Default";
        }
    }
}
