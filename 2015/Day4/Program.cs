using System.Security.Cryptography;
using System.Text;

namespace Day4
{
    class TheIdealStockingStuffer
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetSuffixOfAdventCoin("ckczppom"));
            Console.ReadKey();
        }

        static int GetSuffixOfAdventCoin(string source)
        {
            using (MD5 md5hash = MD5.Create())
                for (int i = 0; ; i++)
                    if (IsAdventCoin(md5hash, source + i.ToString()))
                        return i;
        }

        static bool IsAdventCoin(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < 4; i++)
                sBuilder.Append(data[i].ToString("x2"));

            return sBuilder.ToString().Substring(0, 6) == "000000";
            //for first part replace with: Substring(0,5) and "00000"
        }
    }
}
