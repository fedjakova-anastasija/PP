using System;
using System.Windows.Forms;
using CurrencySaver.ViewModels;

namespace CurrencySaver
{
    public partial class Window : Form
    {
        private readonly WindowViewModel _viewModel;

        public Window( WindowViewModel mainFormViewModel )
        {
            InitializeComponent();
            _viewModel = mainFormViewModel;
            runs.DataBindings.Add( "DataSource", _viewModel, "UpdateRuns", true, DataSourceUpdateMode.OnPropertyChanged );
            _averageTimeResult.DataBindings.Add( "Text", _viewModel, "AverageTime", true, DataSourceUpdateMode.OnPropertyChanged );
            _async.Checked = true;
        }

        private void _asyncUsingRadioButton_CheckedChanged( object sender, System.EventArgs e )
        {
            _go.Click -= _saveCurrenciesButton_ClickAsync;
            _go.Click -= _saveCurrenciesButton_Click;
            _go.Click += new EventHandler( _saveCurrenciesButton_ClickAsync );
        }

        private void _syncUsingRadioButton_CheckedChanged( object sender, EventArgs e )
        {
            _go.Click -= _saveCurrenciesButton_ClickAsync;
            _go.Click -= _saveCurrenciesButton_Click;
            _go.Click += new EventHandler( _saveCurrenciesButton_Click );
        }

        private async void _saveCurrenciesButton_ClickAsync( object sender, EventArgs e )
        {
            _go.Enabled = false;
            await _viewModel.SaveCurrencyInfoAsync( _input.Text, _output.Text );
            _go.Enabled = true;
        }

        private void _saveCurrenciesButton_Click( object sender, EventArgs e )
        {
            _go.Enabled = false;
            _viewModel.SaveCurrencyInfo( _input.Text, _output.Text );
            _go.Enabled = true;
        }

        private void _saveCurrenciesButton_Click_1(object sender, EventArgs e)
        {

        }

        private void _updateTimesList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void _updateTimesGroup_Enter(object sender, EventArgs e)
        {

        }

        private void _currencyInfoUriLabel_Click(object sender, EventArgs e)
        {

        }

        private void _currencyNamesUriLabel_Click(object sender, EventArgs e)
        {

        }

        private void Window_Load(object sender, EventArgs e)
        {

        }
    }
}
