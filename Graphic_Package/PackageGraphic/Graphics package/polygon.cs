using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics.Graphics_package
{
    internal class polygon
    {
        private List<point> points;
        public polygon(List<point> points)
        {
            this.points = points;
        }

        public List<point> GetPoints()
        {
            return points;
        }
    }
}
