
namespace WiresharkUnivariedDistribution
{
    class Program
    {
        public Dictionary<string, int> univarDistr(string filePath)
        {
            string[] csvData = System.IO.File.ReadAllLines(filePath);
            int len = csvData.Length;
            string[] headers = csvData[0].Split(',');
            Dictionary<string, int> distribution = new Dictionary<string, int>();
            for (int i = 1; i < len; i++)
            {
                string[] row = csvData[i].Split(',');
                for (int j = 1; j < row.Length; j++)
                {
                    int value = Convert.ToInt32(row[j]);
                    if (value > 0)
                    {
                        if (distribution.ContainsKey(headers[j]))
                        {
                            distribution[headers[j]] += 1;
                        }
                        else
                        {
                            distribution.Add(headers[j], 1);
                        }
                    }
                }
            }
            return distribution;
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            Dictionary<string, int> freq = p.univarDistr("..\\..\\..\\..\\..\\wireshark.csv");
            string res = "Protocol | Frequency + \n";
            foreach (var pair in freq)
            {
                res += pair.Key + ": " + pair.Value + "\n";
            }
            Console.WriteLine(res);
        }
    }
}

