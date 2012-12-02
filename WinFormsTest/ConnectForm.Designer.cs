namespace WinFormsTest
{
    partial class ConnectForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxServerHost = new System.Windows.Forms.TextBox();
            this.nodeIdContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setRandomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.recentlyUsedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.textBoxAppName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNodeGuid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelFormHeader = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelConvergeLogo = new System.Windows.Forms.Label();
            this.labelFormHeader = new System.Windows.Forms.Label();
            this.panelFormBody = new System.Windows.Forms.Panel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.nodeIdContextMenuStrip.SuspendLayout();
            this.panelFormHeader.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelFormBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxServerHost);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.buttonConnect);
            this.groupBox1.Controls.Add(this.textBoxAppName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxNodeGuid);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.groupBox1.Location = new System.Drawing.Point(25, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(437, 191);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Node details";
            // 
            // textBoxServerHost
            // 
            this.textBoxServerHost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(51)))));
            this.textBoxServerHost.ContextMenuStrip = this.nodeIdContextMenuStrip;
            this.textBoxServerHost.ForeColor = System.Drawing.Color.LightCyan;
            this.textBoxServerHost.Location = new System.Drawing.Point(148, 97);
            this.textBoxServerHost.Name = "textBoxServerHost";
            this.textBoxServerHost.Size = new System.Drawing.Size(140, 20);
            this.textBoxServerHost.TabIndex = 7;
            // 
            // nodeIdContextMenuStrip
            // 
            this.nodeIdContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setRandomToolStripMenuItem,
            this.toolStripSeparator1,
            this.recentlyUsedToolStripMenuItem});
            this.nodeIdContextMenuStrip.Name = "nodeIdContextMenuStrip";
            this.nodeIdContextMenuStrip.Size = new System.Drawing.Size(148, 54);
            // 
            // setRandomToolStripMenuItem
            // 
            this.setRandomToolStripMenuItem.Name = "setRandomToolStripMenuItem";
            this.setRandomToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.setRandomToolStripMenuItem.Text = "Set random";
            this.setRandomToolStripMenuItem.Click += new System.EventHandler(this.setRandomToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(144, 6);
            // 
            // recentlyUsedToolStripMenuItem
            // 
            this.recentlyUsedToolStripMenuItem.Name = "recentlyUsedToolStripMenuItem";
            this.recentlyUsedToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.recentlyUsedToolStripMenuItem.Text = "Recently used";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Server host";
            // 
            // buttonConnect
            // 
            this.buttonConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConnect.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.buttonConnect.Location = new System.Drawing.Point(148, 133);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(84, 22);
            this.buttonConnect.TabIndex = 5;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // textBoxAppName
            // 
            this.textBoxAppName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(51)))));
            this.textBoxAppName.ContextMenuStrip = this.nodeIdContextMenuStrip;
            this.textBoxAppName.ForeColor = System.Drawing.Color.LightCyan;
            this.textBoxAppName.Location = new System.Drawing.Point(148, 36);
            this.textBoxAppName.Name = "textBoxAppName";
            this.textBoxAppName.Size = new System.Drawing.Size(140, 20);
            this.textBoxAppName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "App name";
            // 
            // textBoxNodeGuid
            // 
            this.textBoxNodeGuid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(51)))));
            this.textBoxNodeGuid.ContextMenuStrip = this.nodeIdContextMenuStrip;
            this.textBoxNodeGuid.ForeColor = System.Drawing.Color.LightCyan;
            this.textBoxNodeGuid.Location = new System.Drawing.Point(148, 62);
            this.textBoxNodeGuid.Name = "textBoxNodeGuid";
            this.textBoxNodeGuid.Size = new System.Drawing.Size(140, 20);
            this.textBoxNodeGuid.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Branch GUID";
            // 
            // panelFormHeader
            // 
            this.panelFormHeader.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panelFormHeader.Controls.Add(this.tableLayoutPanel1);
            this.panelFormHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFormHeader.Location = new System.Drawing.Point(0, 0);
            this.panelFormHeader.Name = "panelFormHeader";
            this.panelFormHeader.Size = new System.Drawing.Size(487, 26);
            this.panelFormHeader.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.labelConvergeLogo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelFormHeader, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonClose, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(487, 26);
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
            this.labelFormHeader.Size = new System.Drawing.Size(376, 26);
            this.labelFormHeader.TabIndex = 2;
            this.labelFormHeader.Text = "Connection setup";
            this.labelFormHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelFormHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelFormHeader_MouseDown);
            // 
            // panelFormBody
            // 
            this.panelFormBody.Controls.Add(this.groupBox1);
            this.panelFormBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFormBody.Location = new System.Drawing.Point(0, 26);
            this.panelFormBody.Margin = new System.Windows.Forms.Padding(15);
            this.panelFormBody.Name = "panelFormBody";
            this.panelFormBody.Padding = new System.Windows.Forms.Padding(25, 20, 25, 30);
            this.panelFormBody.Size = new System.Drawing.Size(487, 241);
            this.panelFormBody.TabIndex = 3;
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
            this.buttonClose.Location = new System.Drawing.Point(461, 0);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(26, 26);
            this.buttonClose.TabIndex = 6;
            this.buttonClose.Text = "X";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // ConnectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(487, 267);
            this.Controls.Add(this.panelFormBody);
            this.Controls.Add(this.panelFormHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConnectForm";
            this.Text = "Connection setup";
            this.Load += new System.EventHandler(this.ConnectForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.nodeIdContextMenuStrip.ResumeLayout(false);
            this.panelFormHeader.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelFormBody.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxServerHost;
        private System.Windows.Forms.ContextMenuStrip nodeIdContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem setRandomToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem recentlyUsedToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.TextBox textBoxAppName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNodeGuid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelFormHeader;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelConvergeLogo;
        private System.Windows.Forms.Label labelFormHeader;
        private System.Windows.Forms.Panel panelFormBody;
        private System.Windows.Forms.Button buttonClose;
    }
}

