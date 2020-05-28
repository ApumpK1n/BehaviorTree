using System.Diagnostics;

namespace Behavior
{
    partial class Behavior
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Behavior));
            this.IconImageList = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // IconImageList
            // 
            this.IconImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.IconImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IconImageList.ImageStream")));
            this.IconImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.IconImageList.Images.SetKeyName(0, "folder_new.png");
            this.IconImageList.Images.SetKeyName(1, "ICON__0029_17.png");
            this.IconImageList.Images.SetKeyName(2, "ICON__0017_29.png");
            this.IconImageList.Images.SetKeyName(3, "ICON__0020_26.png");
            this.IconImageList.Images.SetKeyName(4, "ICON__0021_25b.png");
            this.IconImageList.Images.SetKeyName(5, "action.png");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuBehaviorList";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Behavior
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 455);
            this.Name = "Behavior";
            this.Text = "Behavior";
            this.Load += new System.EventHandler(this.Behavior_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private void InitializeOtherComponent()
        {
            // 
            // NodetreeView
            // 
            this.NodetreeView = new System.Windows.Forms.TreeView();
            System.Windows.Forms.TreeNode treeNodePrecondition = new System.Windows.Forms.TreeNode("Precondition");
            System.Windows.Forms.TreeNode treeNodePreconditionChild = new System.Windows.Forms.TreeNode("Precondition");

            System.Windows.Forms.TreeNode treeNodeAction = new System.Windows.Forms.TreeNode("Action");
            System.Windows.Forms.TreeNode treeNodeActionChild = new System.Windows.Forms.TreeNode("Action");

            System.Windows.Forms.TreeNode treeNodeComposite = new System.Windows.Forms.TreeNode("Composite");
            System.Windows.Forms.TreeNode treeNodeSequence = new System.Windows.Forms.TreeNode("Sequence");
            System.Windows.Forms.TreeNode treeNodeSelector = new System.Windows.Forms.TreeNode("Selector");
            System.Windows.Forms.TreeNode treeNodeParallel = new System.Windows.Forms.TreeNode("Parallel");

            this.NodetreeView.ImageIndex = 0;
            this.NodetreeView.ImageList = this.IconImageList;
            this.NodetreeView.Location = new System.Drawing.Point(12, 166);
            this.NodetreeView.Name = "NodetreeView";

            treeNodePrecondition.Name = "Precondition";
            treeNodePrecondition.Text = "条件";
            treeNodePreconditionChild.Name = "Precondition";
            treeNodePreconditionChild.Text = "条件";
            treeNodePreconditionChild.SelectedImageIndex = 1;
            treeNodePreconditionChild.ImageIndex = 1;
            treeNodePrecondition.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNodePreconditionChild});

            treeNodeAction.Name = "Action";
            treeNodeAction.Text = "行为";
            treeNodeActionChild.Name = "Action";
            treeNodeActionChild.Text = "行为";
            treeNodeActionChild.SelectedImageIndex = 5;
            treeNodeActionChild.ImageIndex = 5;
            treeNodeAction.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNodeActionChild});

            treeNodeComposite.Name = "Composite";
            treeNodeComposite.Text = "组合";
            treeNodeSequence.Name = "Sequence";
            treeNodeSequence.Text = "序列";
            treeNodeSequence.SelectedImageIndex = 2;
            treeNodeSequence.ImageIndex = 2;

            treeNodeSelector.Name = "Selector";
            treeNodeSelector.Text = "选择";
            treeNodeSelector.SelectedImageIndex = 3;
            treeNodeSelector.ImageIndex = 3;

            treeNodeParallel.Name = "Parallel";
            treeNodeParallel.Text = "并行";
            treeNodeParallel.SelectedImageIndex = 4;
            treeNodeParallel.ImageIndex = 4;

            treeNodeComposite.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNodeSequence,
            treeNodeSelector,
            treeNodeParallel,
            });

            this.NodetreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNodePrecondition, 
            treeNodeAction,
            treeNodeComposite});
            this.NodetreeView.SelectedImageIndex = 0;
            this.NodetreeView.Size = new System.Drawing.Size(151, 258);
            this.NodetreeView.StateImageList = this.IconImageList;
            this.NodetreeView.TabIndex = 0;
            this.NodetreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.NodetreeView_AfterSelect);
            
            this.Controls.Add(this.NodetreeView);


            // 
            // BehaviorTree
            // 
            this.BehaviorTree = new System.Windows.Forms.TreeView();
            System.Windows.Forms.TreeNode treeNodeBehavior = new System.Windows.Forms.TreeNode("Behaviors");
            this.BehaviorTree.Location = new System.Drawing.Point(13, 24);
            this.BehaviorTree.Name = "BehaviorTree";
            this.BehaviorTree.Size = new System.Drawing.Size(121, 109);
            this.BehaviorTree.TabIndex = 0;
            this.BehaviorTree.ImageIndex = 0;
            this.BehaviorTree.SelectedImageIndex = 0;
            this.BehaviorTree.StateImageList = this.IconImageList;
            this.BehaviorTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNodeBehavior,
            });
            this.BehaviorTree.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BehaviorTree_MouseUp);
            this.behaviorTreePanel = new BehaviorTreePanel();
            this.Controls.Add(this.BehaviorTree);
        }

        private System.Windows.Forms.TreeView NodetreeView;
        private System.Windows.Forms.ImageList IconImageList;
        private System.Windows.Forms.TreeView BehaviorTree;
        private BehaviorTreePanel behaviorTreePanel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

