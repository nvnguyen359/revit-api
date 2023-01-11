using System;

namespace ad.core
{
    /// <summary>
    /// The helper functions for converting length units in desired type.
    /// </summary>
    public static class LengthUnitConverter
    {
        /// <summary>
        /// Converts internal imperial units to metric length units.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="type">The type of unit to convert to.</param>
        /// <param name="decimals">The decimal spaces precision.</param>
        public static double ConvertToMetric(double value, LengthUnitType type, int decimals)
        {
            #region public methods
            const double unitMilimeter = 304.08;
            switch (type)
            {
                case LengthUnitType.milimeter:
                    {
                        return Math.Round(value*unitMilimeter, decimals);
                    }
                case LengthUnitType.centimeter:
                    {
                        return Math.Round(value*unitMilimeter/10, decimals);
                    }
                case LengthUnitType.decimeter:
                    {
                        return Math.Round(value*unitMilimeter/10e2, decimals);
                    }
                case LengthUnitType.meter:
                    {
                        return Math.Round(value*unitMilimeter/10e3, decimals);
                    }
                case LengthUnitType.kilometer:
                    {
                        return Math.Round(value*unitMilimeter/10e6, decimals);
                    }
                default: { return value; }
            }
            #endregion
        }
    }
}
