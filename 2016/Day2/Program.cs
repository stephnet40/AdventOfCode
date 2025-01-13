namespace Day2
{
    class BathroomSecurity
    {
        static void Main(string[] args)
        {
            var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
            string[] inputs = File.ReadAllLines(fileName);

            //string[] inputs = {"ULL",
            //                   "RRDDD",
            //                   "LURDL",
            //                   "UUUUD"};

            int[,] numPad1 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            string code = "";
            int posX = 1; int posY = 1;

            foreach (var input in inputs)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    switch (input[i])
                    {
                        case 'U':
                            if (posY - 1 >= 0)
                            {
                                posY--;
                            }
                            break;
                        case 'D':
                            if (posY + 1 <= 2)
                            {
                                posY++; 
                            }
                            break;
                        case 'L':
                            if (posX - 1 >= 0)
                            {
                                posX--;
                            }
                            break;
                        case 'R':
                            if (posX + 1 <= 2)
                            {
                                posX++;
                            }
                            break;
                    }
                }

                code += numPad1[posY, posX].ToString();
            }

            Console.WriteLine("Part 1: " + code);

            string[,] numPad2 = { { "0", "0", "1", "0", "0" },
                                  { "0", "2", "3", "4", "0" },
                                  { "5", "6", "7", "8", "9" },
                                  { "0", "A", "B", "C", "0" },
                                  { "0", "0", "D", "0", "0" } };
            code = "";
            posX = 0; posY = 2;

            foreach (var input in inputs)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    switch (input[i])
                    {
                        case 'U':
                            if (posY - 1 >= 0 && numPad2[posY - 1, posX] != "0")
                            {
                                posY--;
                            }
                            break;
                        case 'D':
                            if (posY + 1 <= 4 && numPad2[posY + 1, posX] != "0")
                            {
                                posY++;
                            }
                            break;
                        case 'L':
                            if (posX - 1 >= 0 && numPad2[posY, posX - 1] != "0")
                            {
                                posX--;
                            }
                            break;
                        case 'R':
                            if (posX + 1 <= 4 && numPad2[posY, posX + 1] != "0")
                            {
                                posX++;
                            }
                            break;
                    }
                }

                code += numPad2[posY, posX].ToString();
            }

            Console.WriteLine("Part 2: " + code);
        }
    }
}
