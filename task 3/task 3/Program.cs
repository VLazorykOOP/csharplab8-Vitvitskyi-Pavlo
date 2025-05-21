using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string inputFile = "input.txt";
        string outputFile = "symmetric_words.txt";

        if (!File.Exists(inputFile))
        {
            Console.WriteLine("Файл input.txt не знайдено!");
            return;
        }

        string text = File.ReadAllText(inputFile);

        // Розділення на слова з урахуванням розділових знаків
        string[] words = Regex.Split(text, @"[\s.,!?;:\-()\[\]{}\""\']+");

        HashSet<string> symmetricWords = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        foreach (string word in words)
        {
            if (string.IsNullOrWhiteSpace(word)) continue;

            string cleanWord = word.ToLower();

            if (IsPalindrome(cleanWord))
            {
                symmetricWords.Add(word); // Зберігаємо з оригінальним регістром
            }
        }

        // Запис у новий файл
        File.WriteAllLines(outputFile, symmetricWords);

        Console.WriteLine($"Знайдено симетричних слів: {symmetricWords.Count}");
        Console.WriteLine($"Результат записано у файл: {outputFile}");
    }

    static bool IsPalindrome(string s)
    {
        int left = 0, right = s.Length - 1;

        while (left < right)
        {
            if (s[left] != s[right])
                return false;
            left++;
            right--;
        }
        return true;
    }
}
