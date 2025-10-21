using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Rurune
{
    internal class PenCtrl : Base
    {
        internal override List<string> GetLayers() => new() { "PenCtrl_R", "PenCtrl_L" };

        internal override List<string> GetParameters() =>
            new() { "PenColor", "Pen1", "Pen1Grab", "Pen2", "Pen2Grab" };

        internal override List<string> GetMenuPath() => new() { "Particle", "Pen" };

        internal override List<string> GetDelPath() =>
            new()
            {
                "Advanced/Particle/7",
                "Advanced/Constraint/Index_R_Constraint",
                "Advanced/Constraint/Index_L_Constraint",
                "Advanced/Constraint/Hand_R_Constraint0",
                "Advanced/Constraint/Hand_L_Constraint0",
            };
    }
}
