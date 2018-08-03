using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HjDictClient
{
    class UctPanel:Panel
    {
        protected override System.Drawing.Point ScrollToControl(Control activeControl)
        {
            //return DisplayRectangle.Location;
            return this.AutoScrollPosition;
        }
    }
}
