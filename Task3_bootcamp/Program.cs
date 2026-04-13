string input = Console.ReadLine();
int userInput = int.Parse(input);

List<string> result = new List<string>();

for (int x = 1; x <= userInput; x++)
{
    string output = "";

    if (x % 3 == 0)
        output += "foo";
    if (x % 4 == 0)
        output += "baz";
    if (x % 5 == 0)
        output += "bar";
    if (x % 7 == 0)
        output += "jazz";
    if (x % 9 == 0)
        output += "huzz";
    if (output == "")
        output = x.ToString();

    result.Add(output);
}

Console.WriteLine(string.Join(", ", result));
