using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Files2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Продолжаем работу с файлами
            /*using (FileStream fs = new FileStream("log.txt",
                 FileMode.Open))
            using (StreamReader sr = new StreamReader(fs))
            { 
                while(!sr.EndOfStream)
                {
                    //string text = sr.ReadLine();
                    char chars = (char)sr.Read();
                    Console.Write(chars);
                }
            }*/
            /*using (StreamWriter sw = new StreamWriter(fs))
            { 
                while (true)
                {
                    string command = Console.ReadLine();
                    if (command == "exit")
                        break;
                    sw.WriteLine(command);
                }
            }*/
            /*
            using (var file = File.Create("test.db"))
            using (var br = new BinaryWriter(file))
            {
                // заголовок содержащий инфу о типе содержимого
                // например у нас может быть 30 байт информации о файле
                // 4 байта - маркер, подтверждающий расширение/тип файла
                // 1 байт - тип информации, хранящийся в данном типе файлы
                // 8 байт - может быть кол-во строк текста, находящегося в файле
                // 4 байта - указатель номера байта в файле, с которого 
                // начинается хранимый текст
                // 4 байта - указать номер байта в файле, с которого 
                // начинается хранение информации о каждой строке текста
                br.Write(Encoding.ASCII.GetBytes("t.db"));
                br.Write((byte)99);
                br.Write((long)10);
                br.Write(150); // указатель на строки
                br.Write(30); // указатель на данные о строках
                br.Seek(30, SeekOrigin.Begin);
                List<int> indexes = new List<int>();
                br.Seek(190, SeekOrigin.Begin);
                int i = 0 ,count = 10;
                while (i < count)
                {
                    indexes.Add((int)file.Position);
                    br.Write("hello" + i);
                    i++;
                }
                i = 0;
                br.Seek(30, SeekOrigin.Begin);
                while (i < count)
                {
                    br.Write(i); // номер строки
                    br.Write(1000 + i); // звук
                    br.Write(Encoding.ASCII.GetBytes("ru  "));
                    br.Write(indexes[i]);
                    i++;
                }
            }

            using (var file = File.OpenRead("test.db"))
            using (var br = new BinaryReader(file))
            {
                file.Seek(78, SeekOrigin.Begin);
                int number =  br.ReadInt32(); // номер строки
                int sound = br.ReadInt32(); // звук
                string lang = Encoding.ASCII.GetString(br.ReadBytes(4));// язык
                int index = br.ReadInt32();//положение
                Console.WriteLine(number);
                Console.WriteLine(sound);
                Console.WriteLine(lang);
                Console.WriteLine(index);
                file.Seek(index, SeekOrigin.Begin);
                string text = br.ReadString();
                Console.WriteLine(text);
            }*/

            using (var file = File.Create("test.db"))
            using (var bw = new BinaryWriter(file))
            {
                bw.Write("Горячие котики без смс и регистрации. За денюжку.");
                bw.Write((byte)3);

                bw.Write("hot_cat1");
                bw.Write(".png");

                bw.Write("hot_cat2");
                bw.Write(".jpg");

                bw.Write("hot_cat3");
                bw.Write(".jpg");

                var bytes = File.ReadAllBytes(@"C:\Users\Student\Pictures\123.png");
                bw.Write(bytes.Length);
                bw.Write(bytes);

                var bytes1 = File.ReadAllBytes(@"C:\Users\Student\Pictures\picture.jpg");
                bw.Write(bytes1.Length);
                bw.Write(bytes1);

                var bytes2 = File.ReadAllBytes(@"C:\Users\Student\Desktop\123.jpg");
                bw.Write(bytes2.Length);
                bw.Write(bytes2);
            }
        }
    }
}