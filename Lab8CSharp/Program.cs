using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string inputFile = "input.txt";
        string outputFile = "found_ips.txt";
        string replacedFile = "replaced_output.txt";

        // Читання вхідного файлу
        string text = File.ReadAllText(inputFile);

        // Регулярний вираз для IP у форматі HEX
        string pattern = @"\b([0-9A-Fa-f]{1,2})\.([0-9A-Fa-f]{1,2})\.([0-9A-Fa-f]{1,2})\.([0-9A-Fa-f]{1,2})\b";
        Regex regex = new Regex(pattern);

        // Знаходження всіх IP-адрес
        MatchCollection matches = regex.Matches(text);
        List<string> foundIPs = new List<string>();

        foreach (Match match in matches)
        {
            foundIPs.Add(match.Value);
        }

        // Запис знайдених IP-адрес у файл
        File.WriteAllLines(outputFile, foundIPs);

        // Вивід кількості знайдених адрес
        Console.WriteLine($"Знайдено IP-адрес: {foundIPs.Count}");

        // Заміна адрес за умовою користувача
        Console.WriteLine("Введіть IP-адресу для заміни (у HEX-форматі d.d.d.d):");
        string oldIP = Console.ReadLine();

        Console.WriteLine("Введіть нову IP-адресу для заміни:");
        string newIP = Console.ReadLine();

        // Заміна у тексті
        string replacedText = regex.Replace(text, match =>
        {
            if (match.Value.Equals(oldIP, StringComparison.OrdinalIgnoreCase))
            {
                return newIP;
            }
            return match.Value;
        });

        // Запис результату після заміни
        File.WriteAllText(replacedFile, replacedText);

        Console.WriteLine("Заміна виконана. Результат збережено у файл.");
    }
}
