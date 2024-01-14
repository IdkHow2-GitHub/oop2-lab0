//NECESSARY FOR CODE TO MAKE SENSE WITHOUT HAVING TO CONSTANTLY ASK FOR A LOW/HIGH NUMBER
using System.Globalization;
using System.IO;

static int getLowNum()
{
    int new_low;
    while (true)
    {
        Console.WriteLine("Enter a lower number below.");
        Console.Write(">>> ");
        string low = Console.ReadLine();
        if (int.TryParse(low, out new_low) && new_low > 0)
        {
            return new_low;
        }
        else
        {
            Console.WriteLine("Invalid input");
            Console.WriteLine("");
        }
    }
}

static int getHighNum(int low_num)
{
    int new_high;
    while (true)
    {
        Console.WriteLine("");
        Console.WriteLine("Enter a higher number below.");
        Console.Write(">>> ");
        string high = Console.ReadLine();
        if (int.TryParse(high, out new_high) && new_high > low_num)
        {
            return new_high;
        }
        else
        {
            Console.WriteLine("Invalid input");
            Console.WriteLine("");
        }
    }
}

//methods for each main task
static int Task1(int low_num, int high_num) 
{
    Console.WriteLine("//////");
    Console.WriteLine("TASK 1");
    Console.WriteLine("//////");
    Console.WriteLine("");

    int difference = high_num - low_num;
    Console.WriteLine($"The diffrenece between {high_num} and {low_num} is : {difference}");
    return difference;
}

static void Task2(int low_num, int high_num)
{
    Console.WriteLine("//////");
    Console.WriteLine("TASK 2");
    Console.WriteLine("//////");
    Console.WriteLine("");

    while (low_num >= high_num)
    {
        Console.WriteLine("Try again. Enter a number that's higher than your previous number.");
        high_num = int.Parse(Console.ReadLine());
    }
    Console.WriteLine($"Good job! {low_num} is in fact lower than {high_num}");
    Console.WriteLine("");
    return;
}

static void Task3(int low_num, int high_num)
{
    Console.WriteLine("//////");
    Console.WriteLine("TASK 3");
    Console.WriteLine("//////");
    Console.WriteLine();

    string file_path = "C:\\Users\\bsimm\\source\\repos\\Lab 1\\numbers.txt";
    using (StreamWriter sw = File.CreateText(file_path));

    //print to console
    int[] array = { };
    Console.Write($"Here's what the list looks like normally: [");
    for (int i = low_num; i < high_num + 1; i++)
    //                    ^^^^^^^^^^^^^^^^ includes the final number
    {
        if (i < high_num)
        {
            array.Append(i);
            Console.Write(i);
            Console.Write(", ");
        }
       else
        {
            array.Append(i);
            Console.Write(i);
            Console.Write("].\n");
        }
    }

    int[] reverse_array = { };
    string reverse_array_string = "";
    Console.Write($"And here's what the list looks like backwards: [");
    for (int j = high_num; j > low_num - 1; j--)
    //                    ^^^^^^^^^^^^^^^^ includes the final number
    {
        if (j > low_num)
        {
            reverse_array.Append(j);
            Console.Write(j);
            Console.Write(", ");
            reverse_array_string += (j.ToString() + "\n");
        }
        else
        {
            reverse_array.Append(j);
            Console.Write(j);
            Console.Write("].\n\n");
            reverse_array_string += (j.ToString() + "\n");
        }

        File.WriteAllText(file_path, reverse_array_string);
    }
    

}

    //write to .txt file

int low_num = getLowNum();
int high_num = getHighNum(low_num);

Task1(low_num, high_num);
Task2(low_num, high_num);
Task3(low_num, high_num);
