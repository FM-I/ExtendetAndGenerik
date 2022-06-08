using ExtendetAndGenerik.Extendet;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

string str = "hello world";

Console.WriteLine($"Початковий рядок: {str}\n");

Console.Write($"1. Реверс рядка : {str.Reverse()}\n");

Console.Write($"2. Кількість входження символа \"l\" : {str.CountIn('l')}\n");

var arr = new int[5] { 1, 1, 3 ,3 ,5 };

Console.WriteLine($"\nПочатковий масив: {string.Join(",", arr)}\n");

Console.Write($"3. Кількість входження елемента в массив 1 : {string.Join(",", arr.CountIn(1))}\n");

Console.Write($"4. Новий масив без дублів : {string.Join(",", arr.DeleteDublicate())}\n");

ExtendedDictionary<int, int, int> extended = new();

Console.WriteLine("Додавання");
extended.Add(1, 2, 3);
extended.Add(2, 2, 5);
extended.Add(3, 4, 3);
extended.Add(4, 34, 3);
extended.Add(5, 1, 5);

foreach (var item in extended)
{
    Console.WriteLine(item);
}

Console.WriteLine("Видалення");
extended.Remove(5);

foreach (var item in extended)
{
    Console.WriteLine(item);
}

Console.WriteLine("Перевірка за ключем 1");

Console.WriteLine(extended.TryGet(1, out var res1));

Console.WriteLine("Перевірка за ключем 5");

Console.WriteLine(extended.TryGet(5, out var res2));

Console.WriteLine("Перевірка за значенням 2 3");

Console.WriteLine(extended.TryGetValue(2, 3, out var val1));

Console.WriteLine("Перевірка за значенням 1 5");

Console.WriteLine(extended.TryGetValue(1, 5, out var val2));