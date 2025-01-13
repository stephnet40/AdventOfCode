using System.Text.RegularExpressions;

namespace Day1
{
    class NoTimeForATaxicab
    {
        static void Main(string[] args)
        {
            var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
            string input = File.ReadAllText(fileName).Trim();
            //string input = "R8, R4, R4, R8";

            string[] dirArr = input.Split(", ");

            Part1(dirArr);
            Part2(dirArr);
        }

        static void Part1(string[] dirArr)
        {
            char direction = 'N';
            int[] position = { 0, 0 };

            foreach (string dir in dirArr)
            {
                int steps = int.Parse(Regex.Match(dir, @"\d+").Value);
                switch (direction)
                {
                    case 'N':
                        if (dir[0] == 'R')
                        {
                            direction = 'E';
                            position[1] += steps;
                        }
                        else
                        {
                            direction = 'W';
                            position[1] -= steps;
                        }
                        break;
                    case 'S':
                        if (dir[0] == 'R')
                        {
                            direction = 'W';
                            position[1] -= steps;
                        }
                        else
                        {
                            direction = 'E';
                            position[1] += steps;
                        }
                        break;
                    case 'E':
                        if (dir[0] == 'R')
                        {
                            direction = 'S';
                            position[0] -= steps;
                        }
                        else
                        {
                            direction = 'N';
                            position[0] += steps;
                        }
                        break;
                    case 'W':
                        if (dir[0] == 'R')
                        {
                            direction = 'N';
                            position[0] += steps;
                        }
                        else
                        {
                            direction = 'S';
                            position[0] -= steps;
                        }
                        break;
                }
            }

            int blocks = Math.Abs(position[0] + position[1]);

            Console.WriteLine("Part 1: " + blocks);
        }

        static void Part2(string[] dirArr)
        {
            char direction = 'N';
            int[] position = { 0, 0 };

            bool visitTwice = false;
            List<string> visited = new List<string>();
            visited.Add(position[0].ToString() + ", " + position[1].ToString());

            for (int i = 0; i < dirArr.Length; i++) 
            {
                int steps = int.Parse(Regex.Match(dirArr[i], @"\d+").Value);
                switch (direction)
                {
                    case 'N':
                        if (dirArr[i][0] == 'R')
                        {
                            direction = 'E';
                            for (int j = 1; j <= steps; j++)
                            {
                                position[1]++;
                                string posString = position[0].ToString() + ", " + position[1].ToString();
                                if (visited.Contains(posString))
                                {
                                    visitTwice = true;
                                    break;
                                }
                                else
                                {
                                    visited.Add(posString);
                                }
                            }
                        }
                        else
                        {
                            direction = 'W';
                            for (int j = 1; j <= steps; j++)
                            {
                                position[1]--;
                                string posString = position[0].ToString() + ", " + position[1].ToString();
                                if (visited.Contains(posString))
                                {
                                    visitTwice = true;
                                    break;
                                }
                                else
                                {
                                    visited.Add(posString);
                                }
                            }
                        }
                        break;
                    case 'S':
                        if (dirArr[i][0] == 'R')
                        {
                            direction = 'W';
                            for (int j = 1; j <= steps; j++)
                            {
                                position[1]--;
                                string posString = position[0].ToString() + ", " + position[1].ToString();
                                if (visited.Contains(posString))
                                {
                                    visitTwice = true;
                                    break;
                                }
                                else
                                {
                                    visited.Add(posString);
                                }
                            }
                        }
                        else
                        {
                            direction = 'E';
                            for (int j = 1; j <= steps; j++)
                            {
                                position[1]++;
                                string posString = position[0].ToString() + ", " + position[1].ToString();
                                if (visited.Contains(posString))
                                {
                                    visitTwice = true;
                                    break;
                                }
                                else
                                {
                                    visited.Add(posString);
                                }
                            }
                        }
                        break;
                    case 'E':
                        if (dirArr[i][0] == 'R')
                        {
                            direction = 'S';
                            for (int j = 1; j <= steps; j++)
                            {
                                position[0]--;
                                string posString = position[0].ToString() + ", " + position[1].ToString();
                                if (visited.Contains(posString))
                                {
                                    visitTwice = true;
                                    break;
                                }
                                else
                                {
                                    visited.Add(posString);
                                }
                            }
                        }
                        else
                        {
                            direction = 'N';
                            for (int j = 1; j <= steps; j++)
                            {
                                position[0]++;
                                string posString = position[0].ToString() + ", " + position[1].ToString();
                                if (visited.Contains(posString))
                                {
                                    visitTwice = true;
                                    break;
                                }
                                else
                                {
                                    visited.Add(posString);
                                }
                            }
                        }
                        break;
                    case 'W':
                        if (dirArr[i][0] == 'R')
                        {
                            direction = 'N';
                            for (int j = 1; j <= steps; j++)
                            {
                                position[0]++;
                                string posString = position[0].ToString() + ", " + position[1].ToString();
                                if (visited.Contains(posString))
                                {
                                    visitTwice = true;
                                    break;
                                }
                                else
                                {
                                    visited.Add(posString);
                                }
                            }
                        }
                        else
                        {
                            direction = 'S';
                            for (int j = 1; j <= steps; j++)
                            {
                                position[0]--;
                                string posString = position[0].ToString() + ", " + position[1].ToString();
                                if (visited.Contains(posString))
                                {
                                    visitTwice = true;
                                    break;
                                }
                                else
                                {
                                    visited.Add(posString);
                                }
                            }
                        }
                        break;                       
                    }
                if (visitTwice) break;
            }

            int blocks = Math.Abs(position[0] + position[1]);

            Console.WriteLine("Part 2: " + blocks);
        } 
    } 
}
