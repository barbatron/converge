namespace WinFormsTest
{
    partial class ClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Basic");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Advanced");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Post data", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Show log");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            this.panelFormHeader = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelConvergeLogo = new System.Windows.Forms.Label();
            this.labelFormHeader = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panelFormBody = new System.Windows.Forms.Panel();
            this.splitContainerTasks = new System.Windows.Forms.SplitContainer();
            this.labelTaskSelectorHeader = new System.Windows.Forms.Label();
            this.treeViewTasks = new System.Windows.Forms.TreeView();
            this.labelResult = new System.Windows.Forms.Label();
            this.buttonPubEvent = new System.Windows.Forms.Button();
            this.buttonPubConnect = new System.Windows.Forms.Button();
            this.checkBoxSignalExitEvent = new System.Windows.Forms.CheckBox();
            this.panelFormHeader.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelFormBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTasks)).BeginInit();
            this.splitContainerTasks.Panel1.SuspendLayout();
            this.splitContainerTasks.Panel2.SuspendLayout();
            this.splitContainerTasks.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFormHeader
            // 
            this.panelFormHeader.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panelFormHeader.Controls.Add(this.tableLayoutPanel1);
            this.panelFormHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFormHeader.Location = new System.Drawing.Point(0, 0);
            this.panelFormHeader.Name = "panelFormHeader";
            this.panelFormHeader.Size = new System.Drawing.Size(599, 26);
            this.panelFormHeader.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.labelConvergeLogo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelFormHeader, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonClose, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(599, 26);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // labelConvergeLogo
            // 
            this.labelConvergeLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelConvergeLogo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConvergeLogo.Location = new System.Drawing.Point(3, 0);
            this.labelConvergeLogo.Name = "labelConvergeLogo";
            this.labelConvergeLogo.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.labelConvergeLogo.Size = new System.Drawing.Size(76, 26);
            this.labelConvergeLogo.TabIndex = 3;
            this.labelConvergeLogo.Text = "CONVERGE";
            this.labelConvergeLogo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelFormHeader
            // 
            this.labelFormHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFormHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFormHeader.Location = new System.Drawing.Point(82, 0);
            this.labelFormHeader.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.labelFormHeader.Name = "labelFormHeader";
            this.labelFormHeader.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.labelFormHeader.Size = new System.Drawing.Size(488, 26);
            this.labelFormHeader.TabIndex = 2;
            this.labelFormHeader.Text = "Test node";
            this.labelFormHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.buttonClose.Location = new System.Drawing.Point(573, 0);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(26, 26);
            this.buttonClose.TabIndex = 5;
            this.buttonClose.Text = "X";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // panelFormBody
            // 
            this.panelFormBody.Controls.Add(this.splitContainerTasks);
            this.panelFormBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFormBody.Location = new System.Drawing.Point(0, 26);
            this.panelFormBody.Margin = new System.Windows.Forms.Padding(15);
            this.panelFormBody.Name = "panelFormBody";
            this.panelFormBody.Padding = new System.Windows.Forms.Padding(6);
            this.panelFormBody.Size = new System.Drawing.Size(599, 234);
            this.panelFormBody.TabIndex = 3;
            // 
            // splitContainerTasks
            // 
            this.splitContainerTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTasks.Location = new System.Drawing.Point(6, 6);
            this.splitContainerTasks.Name = "splitContainerTasks";
            // 
            // splitContainerTasks.Panel1
            // 
            this.splitContainerTasks.Panel1.Controls.Add(this.labelTaskSelectorHeader);
            this.splitContainerTasks.Panel1.Controls.Add(this.treeViewTasks);
            // 
            // splitContainerTasks.Panel2
            // 
            this.splitContainerTasks.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(64)))), ((int)(((byte)(69)))));
            this.splitContainerTasks.Panel2.Controls.Add(this.checkBoxSignalExitEvent);
            this.splitContainerTasks.Panel2.Controls.Add(this.labelResult);
            this.splitContainerTasks.Panel2.Controls.Add(this.buttonPubEvent);
            this.splitContainerTasks.Panel2.Controls.Add(this.buttonPubConnect);
            this.splitContainerTasks.Size = new System.Drawing.Size(587, 222);
            this.splitContainerTasks.SplitterDistance = 195;
            this.splitContainerTasks.TabIndex = 0;
            // 
            // labelTaskSelectorHeader
            // 
            this.labelTaskSelectorHeader.BackColor = System.Drawing.Color.PaleTurquoise;
            this.labelTaskSelectorHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTaskSelectorHeader.ForeColor = System.Drawing.Color.Black;
            this.labelTaskSelectorHeader.Location = new System.Drawing.Point(0, 0);
            this.labelTaskSelectorHeader.Name = "labelTaskSelectorHeader";
            this.labelTaskSelectorHeader.Size = new System.Drawing.Size(195, 13);
            this.labelTaskSelectorHeader.TabIndex = 4;
            this.labelTaskSelectorHeader.Text = "Tasks";
            // 
            // treeViewTasks
            // 
            this.treeViewTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewTasks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(64)))), ((int)(((byte)(69)))));
            this.treeViewTasks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewTasks.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewTasks.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.treeViewTasks.Location = new System.Drawing.Point(0, 13);
            this.treeViewTasks.Margin = new System.Windows.Forms.Padding(0);
            this.treeViewTasks.Name = "treeViewTasks";
            treeNode1.Name = "Node3";
            treeNode1.Text = "Basic";
            treeNode1.ToolTipText = "Post basic messages";
            treeNode2.Name = "Node4";
            treeNode2.Text = "Advanced";
            treeNode3.Name = "Node0";
            treeNode3.Text = "Post data";
            treeNode3.ToolTipText = "Post messages";
            treeNode4.Name = "Node5";
            treeNode4.Text = "Show log";
            this.treeViewTasks.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
            this.treeViewTasks.Size = new System.Drawing.Size(195, 206);
            this.treeViewTasks.TabIndex = 3;
            // 
            // labelResult
            // 
            this.labelResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelResult.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.labelResult.Location = new System.Drawing.Point(113, 13);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(252, 187);
            this.labelResult.TabIndex = 3;
            this.labelResult.Text = "1\r\n2\r\n3\r\n4\r\n5\r\n6\r\n7\r\n8\r\n9\r\n10\r\n11\r\n12\r\n13\r\n14\r\n15\r\n16\r\n17\r\n18\r\n19\r\n20\r\n";
            // 
            // buttonPubEvent
            // 
            this.buttonPubEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPubEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPubEvent.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.buttonPubEvent.Location = new System.Drawing.Point(17, 46);
            this.buttonPubEvent.Name = "buttonPubEvent";
            this.buttonPubEvent.Size = new System.Drawing.Size(90, 26);
            this.buttonPubEvent.TabIndex = 2;
            this.buttonPubEvent.Text = "Generic event...";
            this.buttonPubEvent.UseVisualStyleBackColor = true;
            // 
            // buttonPubConnect
            // 
            this.buttonPubConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPubConnect.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.buttonPubConnect.Location = new System.Drawing.Point(17, 13);
            this.buttonPubConnect.Name = "buttonPubConnect";
            this.buttonPubConnect.Size = new System.Drawing.Size(90, 27);
            this.buttonPubConnect.TabIndex = 1;
            this.buttonPubConnect.Text = "Connect";
            this.buttonPubConnect.UseVisualStyleBackColor = true;
            this.buttonPubConnect.Click += new System.EventHandler(this.buttonPubConnect_Click);
            // 
            // checkBoxSignalExitEvent
            // 
            this.checkBoxSignalExitEvent.Checked = true;
            this.checkBoxSignalExitEvent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSignalExitEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxSignalExitEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxSignalExitEvent.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.checkBoxSignalExitEvent.Location = new System.Drawing.Point(17, 78);
            this.checkBoxSignalExitEvent.Name = "checkBoxSignalExitEvent";
            this.checkBoxSignalExitEvent.Size = new System.Drawing.Size(88, 42);
            this.checkBoxSignalExitEvent.TabIndex = 4;
            this.checkBoxSignalExitEvent.Text = "Auto-complete connect saga";
            this.checkBoxSignalExitEvent.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.checkBoxSignalExitEvent.UseVisualStyleBackColor = true;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(599, 260);
            this.Controls.Add(this.panelFormBody);
            this.Controls.Add(this.panelFormHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(180, 49);
            this.Name = "ClientForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Test node";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.panelFormHeader.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelFormBody.ResumeLayout(false);
            this.splitContainerTasks.Panel1.ResumeLayout(false);
            this.splitContainerTasks.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTasks)).EndInit();
            this.splitContainerTasks.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFormHeader;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelConvergeLogo;
        private System.Windows.Forms.Label labelFormHeader;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panelFormBody;
        private System.Windows.Forms.SplitContainer splitContainerTasks;
        private System.Windows.Forms.Label labelTaskSelectorHeader;
        private System.Windows.Forms.TreeView treeViewTasks;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Button buttonPubEvent;
        private System.Windows.Forms.Button buttonPubConnect;
        private System.Windows.Forms.CheckBox checkBoxSignalExitEvent;
    }
}

