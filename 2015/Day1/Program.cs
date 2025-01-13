namespace Day1
{
    class NotQuiteLisp
    {
        static void Main(string[] args)
        {
            var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
            string input = File.ReadAllText(fileName).Trim();

            int floor = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(') floor++;
                if (input[i] == ')') floor--;
            }

            Console.WriteLine("Part 1: " + floor);

            int position = 0;
            floor = 0;

            for (int i = 0; i < input.Length; i++ )
            {
                if (input[i] == '(') floor++;
                if (input[i] == ')') floor--;

                if (floor == -1)
                {
                    position = i + 1;
                    break;
                }
            }

            Console.WriteLine("Part 2: " + position);
        }
    }
}
