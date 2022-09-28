using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Diagnostics;
namespace Lessons
{
    internal class LabsLauncher
    {
        public static string path = @"C:\Users\1\Desktop\DocSaves";
        static void Main(string[] args)
        {
            string[] Files = Directory.GetFiles(path, "*.exe");
            if (Files.Length != 0)
            {
                Console.WriteLine("Найдены следующие приложения:");
                for (int i = 0; i < Files.Length; i++)
                {
                    Console.WriteLine((i + 1).ToString() + ". " + Files[i].Replace(path + "\\", "").Replace(".exe", ""));
                }
                Console.WriteLine("Для запуска приложения введите его номер в списке.\nДля выхода введите 0.");
            }
            else Console.WriteLine("В данной директории ничего не найдено!");
            int cid = 1;
            /*
                if (Console.ReadLine() == "setpath")
                {
                    path = Console.ReadLine();
                    Console.Clear();
                    Main(args);
                }*/
            while (true)
            {
                    try
                    {
                        cid = Convert.ToInt16(Console.ReadLine());
                    }
                    catch { Console.WriteLine("Неверно введён номер файла!"); }
                    finally
                    {
                    if (cid > 0 && cid <= Files.Length)
                        try
                        {
                            Process proc = new Process();
                            proc.StartInfo.FileName = "cmd.exe";
                            proc.StartInfo.Arguments = "/C start " + Files[cid - 1];
                            proc.Start();
                            proc.Close();
                        }
                        catch (Win32Exception ex)
                        {
                            Console.WriteLine("Ошибка открытия файла! \n(" + ex.Message + ")");
                        }
                    }
                    if (cid == 0) return;
            }
        }
    }
}