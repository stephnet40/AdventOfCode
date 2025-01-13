namespace Day2
{
    class PasswordPhilosophy
    {
        static void Main(string[] args)
        {
            var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
            string[] inputs = File.ReadAllLines(fileName);

            List<string[]> allPasswords = new List<string[]>();

            foreach (string input in inputs)
            {
                string[] password = input.Split(new char[] {'-', ' ', ':'}, StringSplitOptions.RemoveEmptyEntries);

                allPasswords.Add(password);
            }

            int valid = 0;

            foreach (string[] passwords in allPasswords)
            {
                int min = int.Parse(passwords[0]);
                int max = int.Parse(passwords[1]);
                string letter = passwords[2];
                string password = passwords[3];

                int count = password.Count(x => x.ToString() == letter);

                if (count >= min && count <= max)
                {
                    valid++;
                }
            }

            Console.WriteLine($"Part 1: {valid}");

            valid = 0;

            foreach (string[] passwords in allPasswords)
            {
                int ind1 = int.Parse(passwords[0]) - 1;
                int ind2 = int.Parse(passwords[1]) - 1;
                string letter = passwords[2];
                string password = passwords[3];

                string char1 = password.ElementAt(ind1).ToString();
                string char2 = password.ElementAt(ind2).ToString();

                if (char1 != char2 && (char1 == letter || char2 == letter))
                {
                    valid++;
                }
            }

            Console.WriteLine($"Part 2: {valid}");
        }
    }
}
