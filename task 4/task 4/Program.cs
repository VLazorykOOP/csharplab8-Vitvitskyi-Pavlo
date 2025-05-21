using System;
using System.IO;

class Program
{
    static void Main()
    {
        string binaryFile = "fibonacci.dat";
        string textFile = "output.txt";

        // Введення n
        Console.Write("Введіть кількість чисел Фібоначчі (n): ");
        int n = int.Parse(Console.ReadLine());

        // Генеруємо n чисел Фібоначчі
        long[] fib = new long[n];
        if (n > 0) fib[0] = 0;
        if (n > 1) fib[1] = 1;
        for (int i = 2; i < n; i++)
        {
            fib[i] = fib[i - 1] + fib[i - 2];
        }

        // Запис у двійковий файл
        using (BinaryWriter writer = new BinaryWriter(File.Open(binaryFile, FileMode.Create)))
        {
            foreach (long number in fib)
            {
                writer.Write(number);
            }
        }

        // Читання з двійкового файлу і запис у текстовий
        using (BinaryReader reader = new BinaryReader(File.Open(binaryFile, FileMode.Open)))
        using (StreamWriter textWriter = new StreamWriter(textFile))
        {
            int index = 1;
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                long number = reader.ReadInt64();
                if (index % 3 != 0)
                {
                    textWriter.WriteLine($"{index}: {number}");
                }
                index++;
            }
        }

        Console.WriteLine($"Результат записано у файл: {textFile}");
    }
}
