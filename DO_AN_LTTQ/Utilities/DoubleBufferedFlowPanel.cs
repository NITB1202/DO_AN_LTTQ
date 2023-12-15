using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO_AN_LTTQ.Utilities
{
    internal class DoubleBufferedFlowPanel:FlowLayoutPanel
    {
        public DoubleBufferedFlowPanel()
        {
            this.DoubleBuffered = true;
        }

    }
}
