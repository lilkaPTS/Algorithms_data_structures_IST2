using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qwe.Molecules
{
    [Serializable]
    public class CirclesAndEdges
    {
        public Edges EdgesList { get; set; } = new Edges();
        public Circles CirclesList { get; set; } = new Circles();

        public CirclesAndEdges() {}

        public CirclesAndEdges(Edges edgesList, Circles circlesList)
        {
            EdgesList = edgesList;
            CirclesList = circlesList;
        }
    }
}
