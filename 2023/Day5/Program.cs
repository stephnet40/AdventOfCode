namespace Day5
{
    class IfYouGiveASeedAFertilizer
    {
        static void Main (string[] args)
        {
            var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
            string[] inputs = File.ReadAllText(fileName).Split("\n\n");

            var seeds = inputs[0].Split(": ")[1].Split(" ").Select(long.Parse).ToList();

            var dataMappingSets = inputs[1..].Select(DataMappingSet.Parse).ToList();

            Part1(seeds, dataMappingSets);
        }

        static void Part1(List<long> seeds, List<DataMappingSet> dataMappingSets)
        {
            var locations = seeds.Select(seed =>
            {
                long transformed = seed;
                foreach (var set in dataMappingSets)
                {
                    transformed = set.Transform(transformed);
                }
                return transformed;
            }).ToList();

            long min = locations.Min();

            Console.WriteLine("Part 1: " + min);
        }
    }

    record DataMappingSet(string label, List<DataMapping> records)
    {
        public static DataMappingSet Parse(string data)
        {
            var split = data.Split("\n");
            return new DataMappingSet(split[0], split[1..].Select(DataMapping.Parse).ToList());
        }

        public override string ToString() => $"DMS ({label}, \n{string.Join("\n", records)})";

        public long Transform(long source)
        {
            return records.FirstOrDefault(mapping => mapping.IsInRange(source))?.Transform(source) ?? source;
        }
    }

    public record DataMapping(long destStart, long sourceStart, long rangeLength)
    {
        public bool IsInRange(long source) => source >= sourceStart && source < sourceStart + rangeLength;
        public long Transform(long source) => source + (destStart - sourceStart);

        public static DataMapping Parse(string data)
        {
            var parts = data.Split(" ").Select(long.Parse).ToArray();
            return new DataMapping(parts[0], parts[1], parts[2]);
        }
    }
}