namespace Higher_order_function
{
    internal class Program
    {
        static void Main()
        {
            // =========================================================
            // 1. ОБИКНОВЕНА СТОЙНОСТ
            // =========================================================

            Console.WriteLine("=== 1. ОБИКНОВЕНА СТОЙНОСТ ===");

            int number = 5;

            Console.WriteLine($"number = {number}");


            // =========================================================
            // 2. ИЗВИКВАНЕ НА ФУНКЦИЯ
            // =========================================================

            Console.WriteLine("\n=== 2. ИЗВИКВАНЕ НА ФУНКЦИЯ ===");

            int result = Square(5);

            Console.WriteLine($"Square(5) = {result}");


            // =========================================================
            // 3. ФУНКЦИЯ КАТО СТОЙНОСТ
            // =========================================================

            Console.WriteLine("\n=== 3. ФУНКЦИЯ КАТО СТОЙНОСТ ===");

            Func<int, int> operation = Square;

            // Тук Square НЕ се изпълнява.
            // Съхраняваме поведението.

            result = operation(5);

            Console.WriteLine($"operation(5) = {result}");


            // =========================================================
            // 4. СМЯНА НА ПОВЕДЕНИЕТО
            // =========================================================

            Console.WriteLine("\n=== 4. СМЯНА НА ПОВЕДЕНИЕТО ===");

            operation = Double;

            Console.WriteLine($"operation(5) = {operation(5)}");


            // =========================================================
            // 5. Func<T, TResult>
            // =========================================================

            Console.WriteLine("\n=== 5. FUNC ===");

            Func<int, int> triple = x => x * 3;

            Console.WriteLine($"triple(5) = {triple(5)}");


            // Func с два входни параметъра

            Func<int, int, int> add =
                (a, b) => a + b;

            Console.WriteLine($"add(4, 6) = {add(4, 6)}");


            // =========================================================
            // 6. Action<T>
            // =========================================================

            Console.WriteLine("\n=== 6. ACTION ===");

            Action<string> print =
                text => Console.WriteLine(text);

            print("Здравей от Action!");


            // Action не връща резултат.
            // Обикновено извършва действие / страничен ефект.

            Action<int> printNumber =
                x => Console.WriteLine($"Числото е {x}");

            printNumber(10);


            // =========================================================
            // 7. Predicate<T>
            // =========================================================

            Console.WriteLine("\n=== 7. PREDICATE ===");

            Predicate<int> isEven =
                x => x % 2 == 0;

            Console.WriteLine($"8 е четно: {isEven(8)}");
            Console.WriteLine($"9 е четно: {isEven(9)}");


            // Същата идея чрез Func<int, bool>

            Func<int, bool> isGreaterThanSeven =
                x => x > 7;

            Console.WriteLine($"10 > 7: {isGreaterThanSeven(10)}");


            // =========================================================
            // 8. СОБСТВЕН ДЕЛЕГАТ
            // =========================================================

            Console.WriteLine("\n=== 8. СОБСТВЕН ДЕЛЕГАТ ===");

            MathOperation mathOperation = Add;

            Console.WriteLine($"Add: {mathOperation(3, 4)}");

            mathOperation = Multiply;

            Console.WriteLine($"Multiply: {mathOperation(3, 4)}");


            // =========================================================
            // 9. ФУНКЦИЯ КАТО АРГУМЕНТ
            // =========================================================

            Console.WriteLine("\n=== 9. ФУНКЦИЯ КАТО АРГУМЕНТ ===");

            Execute(5, Square);
            Execute(5, Double);

            Execute(5, x => x * 10);


            // =========================================================
            // 10. Action КАТО АРГУМЕНТ
            // =========================================================

            Console.WriteLine("\n=== 10. ACTION КАТО АРГУМЕНТ ===");

            ProcessNumber(
                10,
                x => Console.WriteLine($"Получих: {x}"));


            // =========================================================
            // 11. PREDICATE / Func<T, bool> КАТО АРГУМЕНТ
            // =========================================================

            Console.WriteLine("\n=== 11. УСЛОВИЕ КАТО АРГУМЕНТ ===");

            CheckNumber(10, x => x > 7);
            CheckNumber(4, x => x > 7);

            CheckNumber(8, x => x % 2 == 0);


            // =========================================================
            // 12. LINQ PIPELINE
            // =========================================================

            Console.WriteLine("\n=== 12. LINQ PIPELINE ===");

            List<int> numbers =
                new List<int> { 2, 8, 4, 10 };


            var query = numbers
                .Where(x =>
                {
                    Console.WriteLine($"Where получава: {x}");

                    return x > 5;
                })
                .Select(x =>
                {
                    Console.WriteLine($"Select получава: {x}");

                    return x * 2;
                });


            Console.WriteLine("\nЗаявката е създадена.");
            Console.WriteLine("Но още НЕ е изпълнена.");


            // =========================================================
            // 13. ToList() ЗАДЕЙСТВА PIPELINE-А
            // =========================================================

            Console.WriteLine("\n=== 13. ToList() ===");

            List<int> filteredNumbers =
                query.ToList();


            Console.WriteLine("\nРезултат:");

            foreach (int item in filteredNumbers)
            {
                Console.WriteLine(item);
            }


            // =========================================================
            // 14. Where -> Select -> Sum
            // =========================================================

            Console.WriteLine("\n=== 14. Where -> Select -> Sum ===");

            int sum = numbers
                .Where(x =>
                {
                    Console.WriteLine($"Where: {x}");

                    return x > 5;
                })
                .Select(x =>
                {
                    Console.WriteLine($"Select: {x}");

                    return x * 2;
                })
                .Sum();


            Console.WriteLine($"Sum = {sum}");


            // Pipeline:
            //
            // 2  -> Where false
            //
            // 8  -> Where true
            //    -> Select 16
            //    -> Sum
            //
            // 4  -> Where false
            //
            // 10 -> Where true
            //    -> Select 20
            //    -> Sum
            //
            // Sum = 36


            // =========================================================
            // 15. LINQ НЕ ОЗНАЧАВА АВТОМАТИЧНО ЧИСТ КОД
            // =========================================================

            Console.WriteLine(
                "\n=== 15. LINQ СЪС СТРАНИЧЕН ЕФЕКТ ===");


            int counter = 0;


            var badQuery = numbers
                .Where(x =>
                {
                    counter++;       // променяме външно състояние

                    return x > 5;
                });


            badQuery.ToList();


            Console.WriteLine($"counter = {counter}");


            // Lambda функцията използва и променя
            // променлива извън себе си.
            //
            // Следователно тя НЕ е чиста функция.


            // =========================================================
            // 16. СКРИТА ЗАВИСИМОСТ
            // =========================================================

            Console.WriteLine(
                "\n=== 16. СКРИТА ЗАВИСИМОСТ ===");


            int limit = 7;


            Func<int, bool> condition =
                x => x > limit;


            Console.WriteLine(condition(10));


            limit = 20;


            Console.WriteLine(condition(10));


            // Подаваме един и същи вход: 10.
            //
            // Но получаваме различен резултат,
            // защото функцията зависи от външната
            // променлива limit.


            // =========================================================
            // 17. ПО-ЧИСТ ВАРИАНТ
            // =========================================================

            Console.WriteLine(
                "\n=== 17. ЧИСТА ФУНКЦИЯ ===");


            Console.WriteLine(
                IsGreaterThan(10, 7));

            Console.WriteLine(
                IsGreaterThan(10, 20));


            // Всички зависимости вече са
            // видими във входните параметри.
        }


        // =============================================================
        // МЕТОДИ
        // =============================================================

        static int Square(int number)
        {
            return number * number;
        }


        static int Double(int number)
        {
            return number * 2;
        }


        static int Add(int a, int b)
        {
            return a + b;
        }


        static int Multiply(int a, int b)
        {
            return a * b;
        }


        static void Execute(
            int number,
            Func<int, int> operation)
        {
            int result =
                operation(number);

            Console.WriteLine(result);
        }


        static void ProcessNumber(
            int number,
            Action<int> action)
        {
            action(number);
        }


        static void CheckNumber(
            int number,
            Func<int, bool> condition)
        {
            bool result =
                condition(number);

            Console.WriteLine(
                $"{number} -> {result}");
        }


        static bool IsGreaterThan(int number, int limit)
        {
            return number > limit;
        }


        // Собствен делегат

        delegate int MathOperation(int a, int b);
    }
}

