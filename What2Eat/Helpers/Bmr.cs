using System;
using System.Collections.Generic;
using What2Eat.Enums;

namespace What2Eat.Helpers
{
    public class Bmr
    {
        public static Dictionary<string,double> ActivityLevel = new Dictionary<string, double>()
        {
            {"Little or no Exercise/ desk job", 1.2},
            {"Light exercise/ sports 1 – 3 days/ week", 1.375},
            {"Moderate Exercise, sports 3 – 5 days/ week", 1.55},
            {"Heavy Exercise/ sports 6 – 7 days/ week", 1.725},
            {"Very heavy exercise/ physical job/ training 2 x/ day", 1.9}
        };

        public static double ComputeBmr(double weight, int height, int age, SexKind sex, double activity)
        {
            if (sex.ToString().ToUpper() == "MALE")
            {
                return Math.Round((66 + 13.7 * weight + 5 * height + 6.8 * age * activity), 2);
            }
            if (sex.ToString().ToUpper() == "FEMALE")
            {
                return Math.Round((655 + 9.6 * weight + 1.8 * height + 4.7 * age * activity), 2);
            }
                return 0;
        }
    }
}