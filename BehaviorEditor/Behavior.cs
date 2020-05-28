using System;
using System.Drawing;
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
                System.Diagnostics.Debug.WriteLine("右键点击");
                //this.behaviorTreePanel.Show(this, new Point(e.X, e.Y));
                this.contextMenuStrip1.Show(this, e.X, e.Y);
            }
        }

        private void Behavior_Load(object sender, EventArgs e)
        {

        }

    }
}
