using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ResistanceCalculator
{
            public class Resistor
            {
            public int Id {  get; set; }
            public int RingCount { get; set; }
            public int TempK { get; set; }
            public double Resistance { get; set; }
            public double Tolerance { get; set; }
            public string Ring1 { get; set; }
            public string Ring2 { get; set; }
            public string Ring3 { get; set; }
            public string? Ring4 { get; set; }
            public string? Ring5 { get; set; }
            public string? Ring6 { get; set; }
            public string? deviationFor5 { get; set; }
            public string? precisions {  get; set; }
            public string? prefixes {  get; set; }

            public Resistor()
            {

            }

            public Resistor(string r1_color, string r2_color, string r3_color, string r4_color, string r5_color, string r6_color, int num_of_rings)
            {
                Ring1 = r1_color;
                Ring2 = r2_color;
                Ring3 = r3_color;
                Ring4 = r4_color;
                Ring5 = r5_color;
                Ring6 = r6_color;
                RingCount = num_of_rings;
                CalculateResistance();
            }

            public double CalculateResistance()
            {
                switch (RingCount)
                {
                    case 3:
                        Resistance = (((findNumber(Ring1) * 10) + findNumber(Ring2)) * Math.Pow(10,findNumber(Ring3)));
                    break;
                case 4:
                    Resistance = ((findNumber(Ring1) * 100) + (findNumber(Ring2) * 10) + (findNumber(Ring3))) * Math.Pow(10, findNumber(Ring4));
                    break;
                case 5:
                    Resistance = ((findNumber(Ring1) * 100) + (findNumber(Ring2) * 10) + (findNumber(Ring3))) * Math.Pow(10, findNumber(Ring4));
                    break;
                case 6:
                    Resistance = ((findNumber(Ring1) * 100) + (findNumber(Ring2) * 10) + (findNumber(Ring3))) * Math.Pow(10, findNumber(Ring4));
                    break;
            }
            return Resistance;
            }

        public string deviation(string ring)
        {
            switch (ring)
            {
                case "Red":
                deviationFor5 = "2";
                break;
            case "Blue":
                    deviationFor5 = "0.25";
                    break;
            case "Green":
                    deviationFor5 = "0.5";
                    break;
            case "Brown":
                    deviationFor5 = "1";
                    break;
            case "Gray":
                    deviationFor5 = "0.05";
                    break;
            case "Violet":
                    deviationFor5 = "5";
                    break;
            default:
                    deviationFor5 = "0";
                    break;
            }
            return deviationFor5;
        }

        public (string, double) prefix(double pref)
        {
            int temp = 0;
            string str = pref + "";
            temp = str.Length;
            if (temp <= 3 ) return (" Om", 1);
            if (temp > 3 && temp <= 6) return (" kOm", 3);
            if (temp > 6 && temp <=9) return (" MOm", 6);
            if (temp > 9 && temp <= 12) return (" GOm", 9);
            if (temp > 12) return (" TOm", 12);
            return ("Om", temp);
        }

        public int findNumber(string ring)
        {
            if (ring == "Black") return 0;
            if (ring == "Brown") return 1;
            if (ring == "Red") return 2;
            if (ring == "Orange") return 3;
            if (ring == "Yellow") return 4;
            if (ring == "Green") return 5;
            if (ring == "Blue") return 6;
            if (ring == "Violet") return 7;
            if (ring == "Gray") return 8;
            if (ring == "White") return 9;
            return 0;
        }
        public string Coefficient(string ring)
        {
            switch (ring)
            {
                case "Red":
                    precisions = "50";
                    break;
                case "Blue":
                    precisions = "10";
                    break;
                case "Orange":
                    precisions = "15";
                    break;
                case "Brown":
                    precisions = "100";
                    break;
                case "Yellow":
                    precisions = "25";
                    break;
                
                case "Violet":
                    precisions = "5";
                    break;
                case "White":
                    precisions = "1";
                    break;

                default:
                    precisions = "0";
                    break;
            }
            return precisions;
        }
    }
}

