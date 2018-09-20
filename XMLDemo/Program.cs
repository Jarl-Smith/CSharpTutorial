using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLDemo {
    class Program {
        static string filepath = "data.xml";
        static void Main( string[] args ) {
            //demo1();
            demo2();
        }
        //普通方法遍历XML结构
        static void demo1( ) {
            XmlDocument document = new XmlDocument();
            try {
                document.Load(filepath);
                XmlElement root = document.DocumentElement;//获取文档的根节点
                if ( root.HasChildNodes ) {//如果根节点有子节点
                    foreach ( XmlNode node in root.ChildNodes ) {//遍历根节点的一级子节点
                        Console.Write("{0}\t" , node.Name);//输出每个一级子节点的名字
                        foreach ( XmlAttribute attr in node.Attributes ) {//遍历子节点的所有属性
                            Console.Write("{0},{1}" , attr.Name , attr.Value);//访问属性名称和值
                        }
                        Console.WriteLine();
                    }
                }
            } catch ( XmlException e ) {
                Console.WriteLine(e.Message);
            } catch ( System.IO.IOException e ) {
                Console.WriteLine(e.Message);
            }
        }
        //指定属性名称来访问特定属性，灵活性很差，开发速度快
        static void demo2( ) {
            XmlDocument document = new XmlDocument();
            try {
                document.Load(filepath);
                XmlElement root = document.DocumentElement;
                if ( root.HasChildNodes ) {
                    foreach ( XmlNode node in root.ChildNodes ) {
                        if(node.Attributes.Count < 1 ) {//如果当前节点没有属性
                            continue;
                        }
                        Console.Write("{0},{1}" , "wave" , node.Attributes["wave"].Value);
                        Console.Write("{0},{1}" , "enemyname" , node.Attributes["enemyname"].Value);
                        Console.Write("{0},{1}" , "level" , node.Attributes["level"].Value);
                        Console.Write("{0},{1}" , "wait" , node.Attributes["wait"].Value);
                        Console.Write("\n");
                    }
                }
            } catch ( XmlException e ) {

            } catch ( System.IO.IOException e ) {

            }
        }
    }
}
