using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Practical7
{
    internal class Program
    {
        
        

            public static class FileExplorer
        {
            public static void ShowDrives()
            {
                DriveInfo[] allDrives = DriveInfo.GetDrives();
                foreach (DriveInfo d in allDrives)
                {
                    Console.WriteLine($"Drive {d.Name} {d.DriveType}");
                }
            }

            public static void ShowDirectoryContent(string path)
            {
                try
                {
                    string[] dirs = Directory.GetDirectories(path);
                    Console.WriteLine("Directories:");
                    foreach (string dir in dirs)
                    {
                        Console.WriteLine(dir);
                    }

                    string[] files = Directory.GetFiles(path);
                    Console.WriteLine("Files:");
                    foreach (string file in files)
                    {
                        Console.WriteLine(file);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The process failed: {0}", e.ToString());
                }
            }

            public static void StartFile(string filePath)
            {
                System.Diagnostics.Process.Start(filePath);
            }
        }
    }

    public static class ArrowNavigation
    {
        private static int currentPosition = 0;
        private static int maxPosition;

        public static void Initialize(int max)
        {
            maxPosition = max;
        }

        public static void MoveUp()
        {
            if (currentPosition > 0)
            {
                currentPosition--;
            }
        }

        public static void MoveDown()
        {
            if (currentPosition < maxPosition)
            {
                currentPosition++;
            }
        }

        public static void ShowMenu(string[] menuItems)
        {
            for (int i = 0; i < menuItems.Length; i++)
            {
                if (i == currentPosition)
                {
                    Console.Write("> ");
                }
                else
                {
                    Console.Write("  ");
                }
                Console.WriteLine(menuItems[i]);
            }
        }

        public static int GetCurrentPosition()
        {
            return currentPosition;
        }
    }

    class Osnova
    {
        static void Main(string[] args)
        {
            string currentPath = "";
            
            while (true)
            {
                if (currentPath == "")
                {
                    FileExplorer.ShowDrives();
                }
                else
                {
                    FileExplorer.ShowDirectoryContent(currentPath);
                }

                string[] menuItems = new string[] { "Select", "Back" };
                ArrowNavigation.Initialize(menuItems.Length - 1);

                while (true)
                {
                    Console.Clear();
                    if (currentPath == "")
                    {
                        FileExplorer.ShowDrives();
                    }
                    else
                    {
                        FileExplorer.ShowDirectoryContent(currentPath);
                    }
                    ArrowNavigation.ShowMenu(menuItems);

                    var key = Console.ReadKey().Key;
                    if (key == ConsoleKey.UpArrow)
                    {
                        ArrowNavigation.MoveUp();
                    }
                    else if (key == ConsoleKey.DownArrow)
                    {
                        ArrowNavigation.MoveDown();
                    }
                    else if (key == ConsoleKey.Enter)
                    {
                        if (ArrowNavigation.GetCurrentPosition() == 0)
                        {
                            
                            if (currentPath == "")
                            {
                                
                                string[] drives = Environment.GetLogicalDrives();
                                currentPath = drives[ArrowNavigation.GetCurrentPosition()];
                            }
                            else
                            {
                                
                                string[] dirs = Directory.GetDirectories(currentPath);
                                currentPath = dirs[ArrowNavigation.GetCurrentPosition()];
                            }
                        }
                        else if (ArrowNavigation.GetCurrentPosition() == 1)
                        {
                            
                            if (currentPath != "")
                            {
                                currentPath = Directory.GetParent(currentPath).FullName;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else if (key == ConsoleKey.Escape)
                    {
                        if (currentPath != "")
                        {
                            currentPath = Directory.GetParent(currentPath).FullName;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}
    


