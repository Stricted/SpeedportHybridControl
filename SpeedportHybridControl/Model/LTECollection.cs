using Microsoft.Research.DynamicDataDisplay.Common;

namespace SpeedportHybridControl.Model
{
    public class LTECollection : RingArray<LTEData>
    {
        private const int TOTAL_POINTS = 200;

        public LTECollection() : base(TOTAL_POINTS)
        {
        }
    }
}
