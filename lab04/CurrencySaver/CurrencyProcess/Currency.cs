using CurrencySaver.ExternalQueries;
using CurrencySaver.InputCurrenciesNames;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencySaver.Currency
{
    public class Result
    {
        public int FaceValue { get; set; }
        public string Currency { get; set; }
        public decimal Rate { get; set; }

        public override string ToString()
        {
            string result = String.Format("{0} {1} по курсу {2} руб.", FaceValue, Currency, Rate);
            return result;
        }
    }

    public class Info
    {
        private readonly CurrencyRequest _currencyRequest;

        public Info(CurrencyRequest currencyRequest)
        {
            _currencyRequest = currencyRequest;
        }

        public List<Result> GetSync()
        {
            return Process(_currencyRequest.GetAllSync());
        }

        public async Task<List<Result>> GetAsync()
        {
            return Process(await _currencyRequest.GetAllAsync());
        }

        private List<Result> Process(Currencies сurrencies)
        {
            if (сurrencies == null)
                return new List<Result>();

            return сurrencies.Valute.Values
                .Select(e => new Result
                {
                    Currency = e.CharCode,
                    FaceValue = e.Nominal,
                    Rate = e.Value
                })
                .ToList();
        }
    }

    public class Saver
    {
        public void SaveSync( string path, List<Result> currencies )
        {
            using ( var streamWriter = new StreamWriter( path ) )
            {
                foreach ( Result currency in currencies )
                {
                    streamWriter.WriteLine( currency.ToString() );
                }
            }
        }

        public async Task SaveAsync( string path, List<Result> currencies )
        {
            using ( var streamWriter = new StreamWriter( path ) )
            {
                foreach ( Result currency in currencies )
                {
                    await streamWriter.WriteLineAsync( currency.ToString() );
                }
            }
        }
    }

    public class Updater
    {
        private readonly Info _info = new Info(new CurrencyRequest());
        private readonly InputCurrencies _inputCurrencies = new InputCurrencies();
        private readonly Saver _saver = new Saver();

        public void UpdateSync(string currencyNamesPath, string updatePath)
        {
            List<string> currencyNames = _inputCurrencies.GetAllSync(currencyNamesPath);
            List<Result> currencyInfo = _info.GetSync();
            if (currencyNames.Any())
            {
                currencyInfo = currencyInfo.Where(ci => currencyNames.Contains(ci.Currency)).ToList();
            }

            _saver.SaveSync(updatePath, currencyInfo);
        }

        public async Task UpdateAsync(string currencyNamesPath, string updatePath)
        {
            Task<List<string>> currencyNamesTask = _inputCurrencies.GetAllAsync(currencyNamesPath);
            Task<List<Result>> currencyInfoTask = _info.GetAsync();
            List<string> currencyNames = await currencyNamesTask;
            List<Result> currencyInfo = await currencyInfoTask;

            if (currencyNames.Any())
            {
                currencyInfo = currencyInfo.Where(ci => currencyNames.Contains(ci.Currency)).ToList();
            }

            await _saver.SaveAsync(updatePath, currencyInfo);
        }
    }
}
