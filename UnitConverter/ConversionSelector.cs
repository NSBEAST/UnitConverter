using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Text;

namespace UnitConverter
{
    public class ConversionSelector
    {
        public Dictionary<string, double> LengthFactors = new Dictionary<string, double>
        {
            {"Millimeter", 0.001},    
            {"Centimeter", 0.01},     
            {"Meter", 1},             
            {"Kilometer", 1000},    
            {"Inch", 0.0254},       
            {"Foot", 0.3048},      
            {"Yard", 0.9144},        
            {"Mile", 1609.344}      
        };

        public ObservableCollection<string> Units { get; } = new ObservableCollection<string>
         {
            "Millimeter",
            "Centimeter",
            "Meter",
            "Kilometer",
            "Inch",
            "Foot",
            "Yard",
            "Mile"
        };

        public string? SelectedInputUnit { get; set; } = "Meter";

        public string? SelectedOutputUnit { get; set; } = "Meter";
    }
}
