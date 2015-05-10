using System;

namespace What2Eat.Helpers
{
    public static class Bmi
    {
        public static double ComputeBmi(double weight, double haight)
        {
            return Math.Round((weight/((haight/100.0)*(haight/100.0))), 2);
        }
    }
}