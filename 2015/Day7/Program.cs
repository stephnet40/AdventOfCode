namespace Day7
{
    class SomeAssemblyRequired
    {
        static void Main(string[] args)
        {
            var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
            //string[] inputs = File.ReadAllLines(fileName);

            string[] inputs = { "123 -> x",
                                "456 -> y",
                                "x AND y -> d",
                                "x OR y -> e",
                                "x LSHIFT 2 -> f",
                                "y RSHIFT 2 -> g",
                                "NOT x -> h",
                                "NOT y -> i" };

            Dictionary<string, string> circuitMap = new Dictionary<string, string>();

            foreach (string input in inputs)
            {
                string[] temp = input.Split("->");

                circuitMap.Add(temp[1].Trim(), temp[0].Trim());
            }

            foreach (KeyValuePair<string, string> item in circuitMap)
            {
                Console.WriteLine($"Key: {item.Key} Value: {item.Value}");
            }
        }
    }
}
