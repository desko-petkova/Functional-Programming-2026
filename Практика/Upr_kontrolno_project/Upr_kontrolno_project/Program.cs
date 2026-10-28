using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main()
    {
        // Задача 1. Изчисления чрез чисти функции
        Console.WriteLine("=== Задача 1 ===");

        Console.WriteLine($"Лице: {CalculateArea(5m, 8m)}");
        Console.WriteLine($"Периметър: {CalculatePerimeter(5m, 8m)}");
        Console.WriteLine($"Цена след отстъпка: {ApplyDiscount(120m, 15m):F2}");

        // Задача 2. Операции чрез делегати
        Console.WriteLine("\n=== Задача 2 ===");

        Func<int, int> square = x => x * x;
        Predicate<int> isEven = x => x % 2 == 0;
        Func<int, int, int> sum = (a, b) => a + b;
        Func<string> getMessage = () => "Обработката приключи.";
        Action<string> print = text => Console.WriteLine(text);

        Console.WriteLine($"Квадрат на 5: {square(5)}");
        Console.WriteLine($"8 е четно: {isEven(8)}");
        Console.WriteLine($"Сума на 4 и 7: {sum(4, 7)}");
        print(getMessage());
        print("Hello, word!");

        // Задача 3. Подаване на операция
        Console.WriteLine("\n=== Задача 3 ===");

        Console.WriteLine(Apply(7, x => x * x));   // 49
        Console.WriteLine(Apply(12, x => x * 3));  // 36
        Console.WriteLine(Apply(25, x => x - 8));  // 17
        Console.WriteLine(Apply(37, x => x % 10)); // 7

        // Задача 4. Собствено филтриране
        Console.WriteLine("\n=== Задача 4 ===");

        List<int> filterNumbers = new()
        {
            -8, 3, 12, 0, -5, 7, 18, 4  
        };

        List<int> positive = Filter(filterNumbers, x => x > 0);
        List<int> even = Filter(filterNumbers, x => x % 2 == 0);
        List<int> greaterThanFive = Filter(filterNumbers, x => x > 5);
        List<int> inRange = Filter(filterNumbers, x => x >= 0 && x <= 10);

        Console.WriteLine($"Положителни: {string.Join(", ", positive)}");
        Console.WriteLine($"Четни: {string.Join(", ", even)}");
        Console.WriteLine($"По-големи от 5: {string.Join(", ", greaterThanFive)}");
        Console.WriteLine($"В интервала [0, 10]: {string.Join(", ", inRange)}");
        Console.WriteLine($"Оригинал: {string.Join(", ", filterNumbers)}");

        // Задача 5. Собствено преобразуване
        Console.WriteLine("\n=== Задача 5 ===");

        List<int> transformNumbers = new() { 2, -3, 5, -7, 10 };

        List<int> squares = Transform(transformNumbers, x => x * x);
        List<int> doubled = Transform(transformNumbers, x => x * 2);
        List<int> absolute = Transform(transformNumbers, x => Math.Abs(x));

        Console.WriteLine($"Квадрати: {string.Join(", ", squares)}");
        Console.WriteLine($"Удвоени: {string.Join(", ", doubled)}");
        Console.WriteLine($"Абсолютни стойности: {string.Join(", ", absolute)}");
        Console.WriteLine($"Оригинал: {string.Join(", ", transformNumbers)}");

        // Задача 6. Обработка на числа с LINQ
        Console.WriteLine("\n=== Задача 6 ===");

        List<int> numbers = new()
        {
            14, -3, 8, 21, 0, -6, 8, 5, 12
        };

        List<int> negative = numbers
            .Where(x => x < 0)
            .ToList();

        List<int> multiplesOfThree = numbers
            .Where(x => x % 3 == 0)
            .ToList();

        List<int> positiveSquares = numbers
            .Where(x => x > 0)
            .Select(x => x * x)
            .ToList();

        List<int> increasedEven = numbers
            .Where(x => x % 2 == 0)
            .Select(x => x + 100)
            .ToList();

        int sumAboveTen = numbers
            .Where(x => x > 10)
            .Sum();

        int sumNegativeSquares = numbers
            .Where(x => x < 0)
            .Select(x => x * x)
            .Sum();

        Console.WriteLine($"Отрицателни: {string.Join(", ", negative)}");
        Console.WriteLine($"Кратни на 3: {string.Join(", ", multiplesOfThree)}");
        Console.WriteLine($"Квадрати на положителните: {string.Join(", ", positiveSquares)}");
        Console.WriteLine($"Четни + 100: {string.Join(", ", increasedEven)}");
        Console.WriteLine($"Сума на числата над 10: {sumAboveTen}");
        Console.WriteLine($"Сума от квадратите на отрицателните: {sumNegativeSquares}");

        // Задача 7. Обработка на думи
        Console.WriteLine("\n=== Задача 7 ===");

        List<string> words = new()
        {
            "код", "функция", "ламбда", "списък",
            "делегат", "метод", "програма", "клас"
        };

        List<string> longWords = words
            .Where(word => word.Length >= 6)
            .ToList();

        List<string> startingWithP = words
            .Where(word => word.StartsWith("п"))
            .ToList();

        List<string> uppercaseWords = words
            .Select(word => word.ToUpper())
            .ToList();

        List<int> lengths = words
            .Select(word => word.Length)
            .ToList();

        int totalCharacters = words
            .Select(word => word.Length)
            .Sum();

        List<string> descriptions = words
            .Where(word => word.Length >= 6)
            .Select(word => $"{word} — {word.Length} символа")
            .ToList();

        Console.WriteLine($"Поне 6 символа: {string.Join(", ", longWords)}");
        Console.WriteLine($"Започват с „п“: {string.Join(", ", startingWithP)}");
        Console.WriteLine($"Главни букви: {string.Join(", ", uppercaseWords)}");
        Console.WriteLine($"Дължини: {string.Join(", ", lengths)}");
        Console.WriteLine($"Общ брой символи: {totalCharacters}");

        foreach (string description in descriptions)
        {
            Console.WriteLine(description);
        }

        // Задача 8. Операция с явни параметри
        Console.WriteLine("\n=== Задача 8 ===");

        Func<int, int, int> multiply = (number, factor) => number * factor;

        Console.WriteLine(multiply(5, 2));  // 10
        Console.WriteLine(multiply(5, 4));  // 20
        Console.WriteLine(multiply(12, 3)); // 36

        // Задача 9. Запазване на резултат от заявка
        Console.WriteLine("\n=== Задача 9 ===");

        List<int> sourceNumbers = new() { 2, 5, 8, 11, 14 };

        IEnumerable<int> query = sourceNumbers.Where(x => x > 7);

        List<int> snapshot = query.ToList();

        sourceNumbers.Add(20);

        Console.WriteLine($"Заявка: {string.Join(", ", query)}");
        // 8, 11, 14, 20

        Console.WriteLine($"Запазен списък: {string.Join(", ", snapshot)}");
        // 8, 11, 14

        // Задача 10. Анализ на оценки
        Console.WriteLine("\n=== Задача 10 ===");

        List<double> grades = new()
        {
            5.50, 2.00, 6.00, 4.50, 3.00, 5.75, 2.50, 4.00
        };

        Func<double, bool> isExcellent = grade => grade >= 5.50;

        List<double> excellentGrades = grades
            .Where(isExcellent)
            .ToList();

        List<double> failingGrades = grades
            .Where(grade => grade < 3.00)
            .ToList();

        List<double> points = grades
            .Select(grade => grade * 10)
            .ToList();

        double totalPoints = points.Sum();

        Action<double> printGrade = grade => Console.WriteLine($"{grade:F2}");

        Console.WriteLine("Отлични оценки:");

        foreach (double grade in excellentGrades)
        {
            printGrade(grade);
        }

        Console.WriteLine($"Оценки под 3: {string.Join(", ", failingGrades)}");
        Console.WriteLine($"Точки: {string.Join(", ", points)}");
        Console.WriteLine($"Общо точки: {totalPoints:F2}");
    }

    // Методи за задача 1
    static decimal CalculateArea(decimal width, decimal height)
    {
        return width * height;
    }

    static decimal CalculatePerimeter(decimal width, decimal height)
    {
        return 2 * (width + height);
    }

    static decimal ApplyDiscount(decimal price, decimal discountPercent)
    {
        return price - price * discountPercent / 100;
    }

    // Метод за задача 3
    static int Apply(int number, Func<int, int> operation)
    {
        return operation(number);
    }

    // Метод за задача 4 — без LINQ
    static List<int> Filter(
        List<int> numbers,
        Func<int, bool> condition)
    {
        List<int> result = new();

        foreach (int number in numbers)
        {
            if (condition(number))
            {
                result.Add(number);
            }
        }

        return result;
    }

    // Метод за задача 5 — без LINQ
    static List<int> Transform(
        List<int> numbers,
        Func<int, int> operation)
    {
        List<int> result = new();

        foreach (int number in numbers)
        {
            result.Add(operation(number));
        }

        return result;
    }
}
