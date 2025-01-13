using System.Text.RegularExpressions;

namespace Day2
{
    class RockPaperScissors
    {
        static void Main(string[] args)
        {
            var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
            string[] inputs = File.ReadAllLines(fileName);

            // A = Rock; B = Paper; C = Scissors
            // X = Rock; Y = Paper; Z = Scissors

            // Scores:
            // Rock = 1; Paper = 2; Scissors = 3
            // Lost = 0; Draw = 3; Win = 6

            List<string> opponent = new List<string>();
            List<string> player = new List<string>();

            foreach (string input in inputs)
            {
                string modified = Regex.Replace(input, @"\s", string.Empty);
                opponent.Add(modified[0].ToString());
                player.Add(modified[1].ToString());
            }

            int score = 0;

            // Part 1

            for (int i = 0; i < opponent.Count; i++)
            {
                switch(opponent[i])
                {
                    case "A":
                        score += OppRock(player[i]);
                        break;
                    case "B":
                        score += OppPaper(player[i]);
                        break;
                    case "C":
                        score += OppScissors(player[i]);
                        break;
                }
            }

            Console.WriteLine("Part 1: " + score);

            // Part 2

            // A = Rock; B = Paper; C = Scissors
            // X = Lose; Y = Draw; Z = Win

            score = 0;

            for (int i = 0; i < opponent.Count; i++)
            {
                switch (opponent[i])
                {
                    case "A":
                        score += OppRock2(player[i]);
                        break;
                    case "B":
                        score += OppPaper2(player[i]);
                        break;
                    case "C":
                        score += OppScissors2(player[i]);
                        break;
                }
            }

            Console.WriteLine("Part 2: " + score);
        }

        // Part 1
        public static int OppRock(string player)
        {
            int score = 0;

            switch(player)
            {
                case "X":
                    score = 1 + 3;
                    break;
                case "Y":
                    score = 2 + 6;
                    break;
                case "Z":
                    score = 3 + 0;
                    break;
            }

            return score;
        }

        public static int OppPaper(string player)
        {
            int score = 0;

            switch (player)
            {
                case "X":
                    score = 1 + 0;
                    break;
                case "Y":
                    score = 2 + 3;
                    break;
                case "Z":
                    score = 3 + 6;
                    break;
            }

            return score;
        }

        public static int OppScissors(string player)
        {
            int score = 0;

            switch (player)
            {
                case "X":
                    score = 1 + 6;
                    break;
                case "Y":
                    score = 2 + 0;
                    break;
                case "Z":
                    score = 3 + 3;
                    break;
            }

            return score;
        }

        // Part 2
        public static int OppRock2(string player)
        {
            int score = 0;

            switch (player)
            {
                case "X":
                    score = 0 + 3;
                    break;
                case "Y":
                    score = 3 + 1;
                    break;
                case "Z":
                    score = 6 + 2;
                    break;
            }

            return score;
        }

        public static int OppPaper2(string player)
        {
            int score = 0;

            switch (player)
            {
                case "X":
                    score = 0 + 1;
                    break;
                case "Y":
                    score = 3 + 2;
                    break;
                case "Z":
                    score = 6 + 3;
                    break;
            }

            return score;
        }

        public static int OppScissors2(string player)
        {
            int score = 0;

            switch (player)
            {
                case "X":
                    score = 0 + 2;
                    break;
                case "Y":
                    score = 3 + 3;
                    break;
                case "Z":
                    score = 6 + 1;
                    break;
            }

            return score;
        }
    }
}
