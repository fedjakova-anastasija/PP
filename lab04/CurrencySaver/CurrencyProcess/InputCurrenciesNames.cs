using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencySaver.InputCurrenciesNames
{
    public class InputCurrencies
    {
        public List<string> GetAllSync(string path)
        {
            using (var streamReader = new StreamReader(path))
            {
                string line = streamReader.ReadLine() ?? "";
                return line.Split(' ').ToList();
            }
        }

        public async Task<List<string>> GetAllAsync(string path)
        {
            using (var streamReader = new StreamReader(path))
            {
                string line = (await streamReader.ReadLineAsync()) ?? "";
                return line.Split(' ').ToList();

            }
        }
    }
}
