using System.Collections.Generic;
using System.Linq;

namespace Algorithm.Composition
{

    /// <summary>
    /// Should filter out measurements with an X or Y that are less than or equal to 2
    /// You'll need to implement IMeasureFilter to do the job
    /// </summary>
    /// 
    public class HighPassFilter : IMeasurementFilter
    {
        public IEnumerable<Measurement> Filter(IEnumerable<Measurement> measurements)
        {
            return measurements.Where(m => m.X > 2 && m.Y > 2);
        }
    }
}