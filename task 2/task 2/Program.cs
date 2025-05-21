using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string inputFile = "input.txt";
        string outputFile = "output.txt";

        // Зчитування вхідного тексту
        string text = File.ReadAllText(inputFile);

        // Розділення на слова
        string[] words = Regex.Split(text, @"[\s,.!?;:\-()\[\]{}]+");

        // Створення списку для фільтрованих слів
        List<string> filteredWords = new List<string>();

        foreach (string word in words)
        {
            // Пропустити порожні слова
            if (string.IsNullOrWhiteSpace(word)) continue;

            // Пропустити однобуквені слова
            if (word.Length == 1) continue;

            // Пропустити слова, що починаються з a-e або A-E
            char firstChar = char.ToLower(word[0]);
            if ("abcde".Contains(firstChar)) continue;

            // Додати слово до результату
            filteredWords.Add(word);
        }

        // Об'єднання у фінальний рядок
        string result = string.Join(" ", filteredWords);

        // Запис до нового файлу
        File.WriteAllText(outputFile, result);

        Console.WriteLine("Результат збережено у файл: output.txt");
    }
}
