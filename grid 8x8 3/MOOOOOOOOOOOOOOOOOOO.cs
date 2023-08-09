using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grid_8x8_3
{
    public class Movess
    {
        public Position startPosition { get; set; }

        public Position endPosition { get; set; }

        public Mtype thing { get; set; }

        public Movess(Position startPosition, Position endPosition, Mtype thing)
        {
            this.startPosition = startPosition;
            this.endPosition = endPosition;
            this.thing = thing;
        }
    }
}
