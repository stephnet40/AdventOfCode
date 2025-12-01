namespace Day5
{
    class SupplyStacks
    {
        static void Main(string[] args)
        {
            var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
            //string[] inputs = File.ReadAllLines(fileName);

            string[] inputs = ["    [D]    ",
                               "[N] [C]    ",
                               "[Z] [M] [P]",
                               " 1   2   3 ",
                               "           ",
                               "move 1 from 2 to 1",
                               "move 3 from 1 to 3",
                               "move 2 from 2 to 1",
                               "move 1 from 1 to 2"];
        }
    }
}
