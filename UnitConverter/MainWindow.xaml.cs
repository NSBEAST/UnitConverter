using System.Windows;

namespace UnitConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    { 

        ConversionSelector conversionSelector = new ConversionSelector();
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

            OutputTextBlock.Text = convertedValue.ToString();
        }

        private double ConvertLength(double value, string from, string to)
        {
            // LengthFactors now store meters-per-unit, so convert to meters then to target unit:
            double fromFactor = conversionSelector.LengthFactors[from];
            double toFactor = conversionSelector.LengthFactors[to];
            return (value * fromFactor) / toFactor;
        }
    }
}