using System.Text;

Console.WriteLine("Simple Text Editor");
Console.WriteLine("Enter the number of operations first.");
Console.WriteLine("Then enter each operation:");
Console.WriteLine("1 W  -> append string W");
Console.WriteLine("2 k  -> delete the last k characters");
Console.WriteLine("3 k  -> print the k-th character");
Console.WriteLine("4    -> undo the last append/delete operation");
Console.WriteLine();

var operations = Convert.ToInt32(Console.ReadLine());
Console.WriteLine($"Number of operations: {operations}");

var stack = new Stack<string>();
var stringBuilder = new StringBuilder();
while (operations > 0)
{
    var operation = Console.ReadLine().Split();
    switch (operation[0])
    {
        case "1":
            stack.Push(stringBuilder.ToString());
            stringBuilder.Append(operation[1]);
            break;
        case "2":
            stack.Push(stringBuilder.ToString());
            var numberToDeleted = Convert.ToInt32(operation[1]);
            stringBuilder.Remove(stringBuilder.Length - numberToDeleted, numberToDeleted);
            break;
        case "3":
            Console.WriteLine(stringBuilder[Convert.ToInt32(operation[1]) - 1]);
            break;
        case "4":
            stringBuilder.Clear();
            stringBuilder.Append(stack.Pop());
            break;
    }

    operations--;
    Console.WriteLine($"Operation {operation[0]} completed. Current text: '{stringBuilder}'");
}