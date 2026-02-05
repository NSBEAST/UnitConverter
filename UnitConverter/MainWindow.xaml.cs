using System.Windows;

namespace UnitConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    { 

        ConversionSelector conversionSelector = new();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = conversionSelector;

            InputUnitComboBox.SelectionChanged += (s, e) => MenuChange();
            OutputUnitComboBox.SelectionChanged += (s, e) => MenuChange();
            InputTextBox.TextChanged += (s, e) => MenuChange();
        }

        

        private void MenuChange()
        {
            string valueString = InputTextBox.Text;
            if (!double.TryParse(valueString, out double value))
            {;
                return;
            }

            string inputUnit;
            if (conversionSelector.SelectedInputUnit != null)
            {
                inputUnit = conversionSelector.SelectedInputUnit.Trim();
            }
            else return;

            string outputUnit;
            if (conversionSelector.SelectedOutputUnit != null)
            {
                outputUnit = conversionSelector.SelectedOutputUnit.Trim();
            }
            else return;

            double convertedValue = ConvertLength(value, inputUnit, outputUnit);
            double roundedConvertedValue = Math.Round(convertedValue, 5);
            OutputTextBlock.Text = roundedConvertedValue.ToString();
        }

        private double ConvertLength(double value, string from, string to)
        {
            double fromFactor = conversionSelector.LengthFactors[from];
            double toFactor = conversionSelector.LengthFactors[to];
            return (value * fromFactor) / toFactor;
        }
    }
}