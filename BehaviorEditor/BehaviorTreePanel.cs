using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Behavior
{
    public class BehaviorTreePanel
    {

        public void Show(Control control, Point position)
        {
            System.Diagnostics.Debug.WriteLine("显示");
            //contextMenuStrip.Show(control, position.X, position.Y);
        }
    }
}
