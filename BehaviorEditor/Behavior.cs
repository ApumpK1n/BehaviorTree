using System;
using System.Windows.Forms;

namespace Behavior
{
    public partial class Behavior : Form
    {
        public Behavior()
        {
            InitializeComponent();
            InitializeOtherComponent();
        }

        private void NodetreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void BehaviorTree_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            TreeView treev = sender as TreeView;

            if (MouseButtons.Right == e.Button)
            {
                Console.WriteLine("右键点击");
            }
        }
    }
}
