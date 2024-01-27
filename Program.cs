using System;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

public class Figure
{
    public string Name { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    public Figure(string name, int width, int height)
    {
        Name = name;
        Width = width;
        Height = height;
    }
}

public class FileHandler
{
    private Figure figure;

    public void ReadFile(string filePath)
    {
        string fileExtension = Path.GetExtension(filePath);

        if (fileExtension == ".txt")
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string name = reader.ReadLine();
                int width = int.Parse(reader.ReadLine());
                int height = int.Parse(reader.ReadLine());
                figure = new Figure(name, width, height);
            }
        }
        else if (fileExtension == ".json")
        {
            string json = File.ReadAllText(filePath);
            figure = JsonConvert.DeserializeObject<Figure>(json);
        }
        else if (fileExtension == ".xml")
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Figure));
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                figure = (Figure)serializer.Deserialize(fileStream);
            }
        }
        else
        {
            Console.WriteLine("Unsupported file format");
        }
    }

    public void SaveFile(string filePath)
    {
        string fileExtension = Path.GetExtension(filePath);

        if (fileExtension == ".txt")
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(figure.Name);
                writer.WriteLine(figure.Width);
                writer.WriteLine(figure.Height);
            }
        }
        else if (fileExtension == ".json")
        {
            string json = JsonConvert.SerializeObject(figure);
            File.WriteAllText(filePath, json);
        }
        else if (fileExtension == ".xml")
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Figure));
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fileStream, figure);
            }
        }
        else
        {
            Console.WriteLine("Unsupported file format");
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите путь к файлу:");
        string filePath = Console.ReadLine();

        FileHandler fileHandler = new FileHandler();

        fileHandler.ReadFile(filePath);

        Console.WriteLine("Для сохранения файла нажмите F1. Для выхода - Escape.");

        bool running = true;
        do
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.F1:
                        fileHandler.SaveFile(filePath);
                        Console.WriteLine("Файл сохранен");
                        break;
                    case ConsoleKey.Escape:
                        running = false;
                        break;
                }
            }
        } while (running);
    }
}