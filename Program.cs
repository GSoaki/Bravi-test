public class Program
{
    public static bool IsValid(string symbols)
    {
        Dictionary<char, char> matchingSupport = new Dictionary<char, char>
        {
            { ')', '(' },
            { '}', '{' },
            { ']', '[' }
        };

        Stack<char> stack = new Stack<char>();

        foreach (char symbol in symbols)
        {
            if (stack.Count > 0 && matchingSupport.ContainsKey(symbol))
            {
                char topElement = stack.Pop();
                if (topElement != matchingSupport[symbol])
                {
                    return false;
                }
            }
            else
            {
                stack.Push(symbol);
            }
        }

        return stack.Count == 0;
    }

    public static void Main()
    {
        Console.WriteLine(IsValid("(){}[]")); // true
        Console.WriteLine(IsValid("[{()}](){}")); // true
        Console.WriteLine(IsValid("[]{()")); // false
        Console.WriteLine(IsValid("[{)]")); // false
    }
}