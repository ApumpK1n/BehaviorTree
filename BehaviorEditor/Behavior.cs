using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

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
                this.ContextMenuBehaviorList.Show(this, e.X, e.Y);
            }
        }

        private void BehaviorTree_NodeMouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.OpenBehavior(this.BehaviorTree.SelectedNode);
        }


        public void OpenBehavior(TreeNode treenode)
        {
            if (treenode == null)
            {
                return;
            }

        }

        private int _lastNewBehavior = 1;
        private TreeNode CreateTreeNode()
        {
            string label = GetUniqueLabel("NewBehavior", _lastNewBehavior, out _lastNewBehavior);
            BehaviorNode treeNode = new BehaviorNode();
            treeNode.Text = label;
            treeNode.Name = label;
            this.BehaviorTree.Nodes[0].Nodes.AddRange(new System.Windows.Forms.TreeNode[] { treeNode });
            return treeNode;
        }

        private string GetUniqueLabel(string label, int start, out int used)
        {
            int i = start;

            // gather all tree nodes
            List<TreeNode> nodes = new List<TreeNode>();
            AddChildNodes(this.BehaviorTree.Nodes, nodes);



            // if there is no tree node, simply output the first available name
            if (this.BehaviorTree.Nodes.Count < 1)
            {
                used = i;
                return string.Format("{0}_{1}", label, i);
            }

            do
            {
                // generate the new label
                string newlabel = string.Format("{0}_{1}", label, i);

                // check if there is any node with this name
                bool found = false;

                foreach (TreeNode node in nodes)
                {
                    if (node.Text == newlabel)
                    {
                        found = true;
                        break;
                    }
                }

                // if no node with the name exists, return it.
                if (!found)
                {
                    used = i;
                    return newlabel;
                }

                i++;
            }
            while (true);
        }

        private void AddChildNodes(TreeNodeCollection pool, List<TreeNode> list)
        {
            foreach (TreeNode node in pool)
            {
                list.Add(node);

                AddChildNodes(node.Nodes, list);
            }
        }

        private void ContextMenuBehaviorList_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            foreach (ToolStripItem item in this.ContextMenuBehaviorList.Items)
            {
                if (item.Selected == true)
                {
                    switch (item.Name)
                    {
                        case "toolStripMenuItem1": 

                            foreach(TreeNode treeNode in this.BehaviorTree.Nodes)
                            {
                                treeNode.ExpandAll();
                                System.Diagnostics.Debug.WriteLine("左键点击展开");
                            }
                            
                            break;
                        case "toolStripMenuItem2":
                            foreach (TreeNode treeNode in this.BehaviorTree.Nodes)
                            {
                                treeNode.Collapse();
                            }
                            System.Diagnostics.Debug.WriteLine("左键点击收起");
                            break;
                        case "toolStripMenuItem3":
                            this.CreateTreeNode();
                            System.Diagnostics.Debug.WriteLine("左键点击新建行为树");
                            break;
                        default:
                            break;
                    }
                    
                }

            }
        }
    }
}
