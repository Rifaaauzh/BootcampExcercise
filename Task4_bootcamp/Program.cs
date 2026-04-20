using System.Runtime.InteropServices;
using System.Text;

public class Generator
{
    Dictionary<int, string> rules = new Dictionary<int, string>();
    public bool AddRule(int number, string output)
    {
        //Because 0 not divisible
        if (number <= 0)
            return false;

        if (rules.ContainsKey(number))
            return false;

        rules[number] = output;
        return true;
    }
    public bool RemoveRule(int number)
    {
        if (!rules.ContainsKey(number))
            return false;

        rules.Remove(number);
        return true;
    }
    public string Generate(int number)
    {
        List<string> result = new List<string>();

        for (int i = 1; i<= number; i++)
        {
            string output = "";

            foreach(var rule in rules)
            {
                if (i % rule.Key == 0)
                {
                    output+=rule.Value;
                }
            }
            
            if (output == "")
                output = i.ToString();

            result.Add(output);
        }
  
        return string.Join(", ", result);
    }

    public void ShowRules()
    {
        Console.WriteLine("List of rules: ");

        foreach(var rule in rules)
        {
            Console.WriteLine($"{rule.Key} = {rule.Value}");
        }  
    }
}

class Program
{
    static void Main()
    {
        Generator generator = new Generator();

        while (true)
        {
            Console.WriteLine("\n     MENU     ");
            Console.WriteLine("1. Add Rule");
            Console.WriteLine("2. Remove Rule");
            Console.WriteLine("3. Show Rules");
            Console.WriteLine("4. Generate");
            Console.WriteLine("5. Exit");
            Console.Write("Pilih: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Divisor: ");
                if (!int.TryParse(Console.ReadLine(), out int key))
                {
                    Console.WriteLine("Input must be number");
                    continue;
                }

                Console.Write("Output: ");
                string value = Console.ReadLine();

                if (generator.AddRule(key, value))
                {
                    Console.WriteLine("Rule successfully added");
                }
                else
                {
                    Console.WriteLine("Failed. Rule is already exist");
                }
            }
            else if (choice == "2")
            {
                Console.Write("Divisor yang mau dihapus: ");
                if (!int.TryParse(Console.ReadLine(), out int key))
                {
                    Console.WriteLine("Input must be numer");
                    continue;
                }

                if (generator.RemoveRule(key))
                    Console.WriteLine("Rule successfully deleted");
                else
                    Console.WriteLine("Rule not found");
            }
            else if (choice == "3")
            {
                generator.ShowRules();
            }
            else if (choice == "4")
            {
                Console.Write("Enter n: ");
                if (!int.TryParse(Console.ReadLine(), out int n))
                {
                    Console.WriteLine("Input must be number");
                    continue;
                }

                Console.WriteLine(generator.Generate(n));
            }
            else if (choice == "5")
            {
                break;
            }
            else
            {
                Console.WriteLine("Your choice is not valid. Pick 1-5. Try again!");
            }
        }   
    }
}

