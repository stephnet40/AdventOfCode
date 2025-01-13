using System.Text.RegularExpressions;

namespace Day3
{
    class NoMatterHowYouSliceIt
    {
        static void Main(string[] args)
        {
            var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
            string[] inputs = File.ReadAllLines(fileName);

            //string[] inputs = { "#1 @ 1,3: 4x4",
            //                    "#2 @ 3,1: 4x4",
            //                    "#3 @ 5,5: 2x2" };

            List<List<int[]>> rectangles = new List<List<int[]>>();

            foreach (string input in inputs)
            {
                List<int[]> rectangle = new List<int[]>();
                List<int> coordinates = new List<int>();
                List<int> dim = new List<int>();

                string[] coordinate = Regex.Match(input, @"[\d]{1,3},[\d]{1,3}").Value.Split(',');
                string[] dimensions = Regex.Match(input, @"[\d]+x[\d]+").Value.Split('x');

                coordinates.Add(int.Parse(coordinate[0]));
                coordinates.Add(int.Parse(coordinate[1]));
                dim.Add(int.Parse(dimensions[0]));
                dim.Add(int.Parse(dimensions[1]));

                rectangle.Add(coordinates.ToArray());
                rectangle.Add(dim.ToArray());

                rectangles.Add(rectangle);
            }

            Dictionary<string, int> fabric = new Dictionary<string, int>();

            foreach (var rectangle in rectangles)
            {
                int startX = rectangle[0][0];
                int startY = rectangle[0][1];
                int endX = startX + rectangle[1][0];
                int endY = startY + rectangle[1][1];

                for (int i = startY; i < endY; i++) 
                {
                    for (int j = startX; j < endX; j++)
                    {
                        string coord = $"{j},{i}";

                        if (fabric.ContainsKey(coord))
                        {
                            fabric[coord]++;
                        } else
                        {
                            fabric.Add(coord, 1);
                        }
                    }
                }
            }

            int squares = 0;

            foreach (var coord in fabric)
            {
                if (coord.Value >= 2)
                {
                    squares++;
                }
            }

            Console.WriteLine($"Part 1: {squares}");

            int num = 0;

            int claim = 0;

            foreach (var rectangle in rectangles)
            {
                num++;
                bool noOverlap = true;
                int startX = rectangle[0][0];
                int startY = rectangle[0][1];
                int endX = startX + rectangle[1][0];
                int endY = startY + rectangle[1][1];

                for (int i = startY; i < endY; i++)
                {
                    for (int j = startX; j < endX; j++)
                    {
                        string coord = $"{j},{i}";

                        if (fabric[coord] > 1)
                        {
                            noOverlap = false;
                            break;
                        }
                    }
                }

                if (noOverlap)
                {
                    claim = num;
                }
            }

            Console.WriteLine($"Part 2: {claim}");
        }
    }
}
