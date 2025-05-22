using System;
using System.IO;

class Program
{
    static void Main()
    {
        
        string studentLastName = "Vitvitskiy"; 

        // Шлях до нової папки
        string folderName = studentLastName + "2";
        Directory.CreateDirectory(folderName);

        // Шляхи до файлів
        string file1 = "t1.txt";
        string file2 = "t2.txt";
        string targetFile = Path.Combine(folderName, "t3.txt");

        try
        {
            // Зчитування вмісту з t1.txt та t2.txt
            string text1 = File.Exists(file1) ? File.ReadAllText(file1) : "";
            string text2 = File.Exists(file2) ? File.ReadAllText(file2) : "";

            // Запис у файл t3.txt (створення або перезапис)
            using (StreamWriter writer = new StreamWriter(targetFile))
            {
                writer.WriteLine(text1);
                writer.WriteLine(text2);
            }

            Console.WriteLine($"Файл 't3.txt' успішно створено у папці: {folderName}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Сталася помилка: " + ex.Message);
        }
    }
}
