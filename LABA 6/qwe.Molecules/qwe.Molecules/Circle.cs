using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace qwe.Molecules
{
    [Serializable]
    public class Circles
    {
        public List<Circle> CirclesList { get; set; } = new List<Circle>();
    }

    [Serializable]
    public class Circle
    {
        public Point CircleCoordinate { get; set; }
        public int CircleColor { get; set; }
        public string CircleText { get; set; }
        public int Radius { get; set; }

        public Circle() { }

        public Circle(Point circleCoordinate, int circleColor, string circleText, int radius)
        {
            CircleCoordinate = circleCoordinate;            
            CircleColor = circleColor;
            if (circleText == "default")
            {
                CircleText = default(string);
            }
            else
            {
                CircleText = circleText;
            }
            Radius = radius;
        }
    }
}
