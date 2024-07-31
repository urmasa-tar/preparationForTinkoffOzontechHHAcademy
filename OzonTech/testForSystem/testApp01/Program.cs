
class Program
{
    public static void Main(string[] args)
    {
        using var input = new StreamReader(Console.OpenStandardInput());
        using var output = new StreamWriter(Console.OpenStandardOutput());

        // var s = input.ReadLine().Split();
        // int a = int.Parse(s[0]);
        // int b = int.Parse(s[1]);
        output.Write("OK");
    }
}