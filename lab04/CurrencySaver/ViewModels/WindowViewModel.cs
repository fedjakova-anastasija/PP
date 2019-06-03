using CurrencySaver.Currency;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencySaver.ViewModels
{
    public class WindowViewModel : INotifyPropertyChanged
    {
        private const string Runs = "_runs";
        private const int RunsNumber = 30;

        public List<string> UpdateRuns => _runs.ConvertAll(ut => $"{ut.ToString()} ms");
        public string AverageTime => Math.Round(_runs.DefaultIfEmpty(0).Average(ut => ut), 4).ToString();

        private readonly Updater _updater;
        private List<long> _runs;

        public event PropertyChangedEventHandler PropertyChanged;
        
        public WindowViewModel()
        {
            _updater = new Updater();
            _runs = new List<long>();
            PropertyChanged += WindowViewModel_PropertyChanged;
        }

        public void SaveCurrencyInfo(string currencyNamesPath, string updatePath)
        {
            _runs.Clear();
            for (int i = 0; i < RunsNumber; i++)
            {
                Stopwatch stopWatch = Stopwatch.StartNew();
                _updater.UpdateSync(currencyNamesPath, updatePath);
                stopWatch.Stop();
                long updateTime = stopWatch.ElapsedMilliseconds;
                bool isCorrectTime = _runs.TrueForAll(ut => updateTime < ut * 2 && updateTime > ut / 2) || !_runs.Any();
                if (isCorrectTime)
                {
                    _runs.Add(stopWatch.ElapsedMilliseconds);
                }
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Runs));
        }

        public async Task SaveCurrencyInfoAsync(string currencyNamesPath, string updatePath)
        {
            _runs.Clear();
            for (int i = 0; i < RunsNumber; i++)
            {
                Stopwatch stopWatch = Stopwatch.StartNew();
                await _updater.UpdateAsync(currencyNamesPath, updatePath);
                stopWatch.Stop();
                long updateTime = stopWatch.ElapsedMilliseconds;
                bool isCorrectTime = _runs.TrueForAll(ut => updateTime < ut * 2 && updateTime > ut / 2) || !_runs.Any();
                if (isCorrectTime)
                {
                    _runs.Add(stopWatch.ElapsedMilliseconds);
                }
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Runs));
        }

        private void WindowViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == Runs)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UpdateTimes"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AverageTime"));
            }
        }
    }
}
