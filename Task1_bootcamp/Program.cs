
string input = Console.ReadLine();
int userInput = int.Parse(input);

for (int i = 1; i <= userInput; i++)
{
    if (i % 3 == 0 && i % 5 == 0 )
    {
        Console.Write("foobar");
    }
    else if (i % 3 == 0)
    {
        Console.Write("foo");
    }
    else if (i % 5 == 0)
    {
        Console.Write("bar");
    }
    else
    {
        Console.Write(i);
    }
    
    if (i < userInput)
    {
         Console.Write(", ");
    }
    
}
