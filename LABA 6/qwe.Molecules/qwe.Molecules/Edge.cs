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
    public class Edges
    {
        public List<Edge> EdgesList { get; set; } = new List<Edge>();
    }

    [Serializable]
    public class Edge
    {
        public Point PointFirst { get; set; }
        public Point PointSecond { get; set; }
        public int EdgeColor { get; set; }

        public Edge() { }

        public Edge(Point pointFirst, Point pointSecond, int edgeColor)
        {
            PointFirst = pointFirst;
            PointSecond = pointSecond;
            EdgeColor = edgeColor;
        }
    }
}
