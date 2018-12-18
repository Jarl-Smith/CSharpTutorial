using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOStreamDemo {
    /// <summary>
    /// 该类用于将序列帧动画图片的文件名字格式化，比如1.jpg 34.jpg 456.jpg会格式化为001.jpg 034.jpg 456.jpg，方便不同操作系统能够按照文件名顺序查看图片
    /// </summary>
    public class PictureFilesRenameHelper {
        private string inputPath;
        private string outputPath;
        private int formatFileNameCount;

        public void Start( ) {
            Console.WriteLine("请输入图片文件夹所在目录:");
            inputPath = Console.ReadLine();
            Console.WriteLine("请输入输出路径:");
            outputPath = Console.ReadLine();
            Console.WriteLine("请输入格式化文件名的字符个数:");
            formatFileNameCount = Convert.ToInt32(Console.ReadLine());

            DirectoryInfo source = new DirectoryInfo(inputPath);

            if ( !Directory.Exists(inputPath) || Directory.Exists(Path.Combine(outputPath , source.Name)) ) {
                Console.WriteLine("路径不存在或输出路径已存在");
                return;
            }
            formatPicName();
        }

        private void formatPicName( ) {
            DirectoryInfo source = new DirectoryInfo(inputPath);
            DirectoryInfo target = new DirectoryInfo(Path.Combine(outputPath , source.Name));
            target.Create();
            foreach ( FileInfo pic in source.GetFiles() ) {
                string[] fullName = pic.Name.Split('.');
                string name = fullName[0].PadLeft(formatFileNameCount , '0');
                string picFileFullPath = Path.Combine(target.FullName , name + "." + fullName[1]);
                //Console.WriteLine(picFileFullPath);
                pic.CopyTo(picFileFullPath);
            }

            Console.WriteLine("重命名成功");
        }
    }
}
