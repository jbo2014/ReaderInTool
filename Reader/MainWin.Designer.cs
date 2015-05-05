namespace Reader
{
    partial class MainWin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWin));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsb_edt = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_del = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_add = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lvImg = new System.Windows.Forms.ListView();
            this.rtb_txt = new System.Windows.Forms.RichTextBox();
            this.No = new System.Windows.Forms.Label();
            this.LabNo = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            this.LabTit = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.编辑EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查找ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.替换ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除空行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.在线下载ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.章节阅读ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.检查章节ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel2 = new System.Windows.Forms.Panel();
            this.syncTxt = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.operate = new System.Windows.Forms.Label();
            this.lab3 = new System.Windows.Forms.Label();
            this.lab2 = new System.Windows.Forms.Label();
            this.lab1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.but3 = new System.Windows.Forms.Button();
            this.but2 = new System.Windows.Forms.Button();
            this.but1 = new System.Windows.Forms.Button();
            this.tb3 = new System.Windows.Forms.TextBox();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.Title2 = new System.Windows.Forms.TextBox();
            this.LabNo2 = new System.Windows.Forms.Label();
            this.No2 = new System.Windows.Forms.TextBox();
            this.LabTit2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.重新加载ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.移除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Location = new System.Drawing.Point(0, 50);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(229, 490);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(229, 50);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 487);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Location = new System.Drawing.Point(229, 537);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(655, 3);
            this.splitter2.TabIndex = 1;
            this.splitter2.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_edt,
            this.toolStripSeparator2,
            this.tsb_del,
            this.toolStripSeparator1,
            this.tsb_add,
            this.toolStripButton1,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(884, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsb_edt
            // 
            this.tsb_edt.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsb_edt.Enabled = false;
            this.tsb_edt.Margin = new System.Windows.Forms.Padding(10, 1, 10, 1);
            this.tsb_edt.Name = "tsb_edt";
            this.tsb_edt.Size = new System.Drawing.Size(36, 23);
            this.tsb_edt.Text = "修改";
            this.tsb_edt.Click += new System.EventHandler(this.tsb_edt_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsb_del
            // 
            this.tsb_del.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsb_del.Enabled = false;
            this.tsb_del.Margin = new System.Windows.Forms.Padding(10, 1, 10, 1);
            this.tsb_del.Name = "tsb_del";
            this.tsb_del.Size = new System.Drawing.Size(36, 23);
            this.tsb_del.Text = "删除";
            this.tsb_del.Click += new System.EventHandler(this.tsb_del_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsb_add
            // 
            this.tsb_add.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsb_add.Enabled = false;
            this.tsb_add.Margin = new System.Windows.Forms.Padding(10, 1, 10, 1);
            this.tsb_add.Name = "tsb_add";
            this.tsb_add.Size = new System.Drawing.Size(36, 23);
            this.tsb_add.Text = "增加";
            this.tsb_add.Click += new System.EventHandler(this.tsb_add_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lvImg);
            this.panel1.Controls.Add(this.rtb_txt);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(232, 94);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(652, 228);
            this.panel1.TabIndex = 4;
            // 
            // lvImg
            // 
            this.lvImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvImg.Location = new System.Drawing.Point(0, 0);
            this.lvImg.MultiSelect = false;
            this.lvImg.Name = "lvImg";
            this.lvImg.Size = new System.Drawing.Size(650, 226);
            this.lvImg.TabIndex = 5;
            this.lvImg.UseCompatibleStateImageBehavior = false;
            this.lvImg.Visible = false;
            // 
            // rtb_txt
            // 
            this.rtb_txt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_txt.Location = new System.Drawing.Point(0, 0);
            this.rtb_txt.Name = "rtb_txt";
            this.rtb_txt.Size = new System.Drawing.Size(650, 226);
            this.rtb_txt.TabIndex = 4;
            this.rtb_txt.Text = "";
            this.rtb_txt.Visible = false;
            // 
            // No
            // 
            this.No.Location = new System.Drawing.Point(533, 16);
            this.No.Name = "No";
            this.No.Size = new System.Drawing.Size(96, 12);
            this.No.TabIndex = 3;
            // 
            // LabNo
            // 
            this.LabNo.AutoSize = true;
            this.LabNo.Location = new System.Drawing.Point(498, 16);
            this.LabNo.Name = "LabNo";
            this.LabNo.Size = new System.Drawing.Size(29, 12);
            this.LabNo.TabIndex = 2;
            this.LabNo.Text = "序号";
            // 
            // Title
            // 
            this.Title.Location = new System.Drawing.Point(57, 16);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(399, 12);
            this.Title.TabIndex = 1;
            // 
            // LabTit
            // 
            this.LabTit.AutoSize = true;
            this.LabTit.Location = new System.Drawing.Point(22, 16);
            this.LabTit.Name = "LabTit";
            this.LabTit.Size = new System.Drawing.Size(29, 12);
            this.LabTit.TabIndex = 0;
            this.LabTit.Text = "标题";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.Title);
            this.panel3.Controls.Add(this.LabNo);
            this.panel3.Controls.Add(this.No);
            this.panel3.Controls.Add(this.LabTit);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(232, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(652, 44);
            this.panel3.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.编辑EToolStripMenuItem,
            this.工具TToolStripMenuItem,
            this.帮助HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 编辑EToolStripMenuItem
            // 
            this.编辑EToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查找ToolStripMenuItem,
            this.替换ToolStripMenuItem,
            this.删除空行ToolStripMenuItem});
            this.编辑EToolStripMenuItem.Name = "编辑EToolStripMenuItem";
            this.编辑EToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.编辑EToolStripMenuItem.Text = "编辑(&E)";
            // 
            // 查找ToolStripMenuItem
            // 
            this.查找ToolStripMenuItem.Name = "查找ToolStripMenuItem";
            this.查找ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.查找ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.查找ToolStripMenuItem.Text = "查找...";
            // 
            // 替换ToolStripMenuItem
            // 
            this.替换ToolStripMenuItem.Name = "替换ToolStripMenuItem";
            this.替换ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.替换ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.替换ToolStripMenuItem.Text = "替换...";
            // 
            // 删除空行ToolStripMenuItem
            // 
            this.删除空行ToolStripMenuItem.Name = "删除空行ToolStripMenuItem";
            this.删除空行ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.删除空行ToolStripMenuItem.Text = "删除空行";
            // 
            // 工具TToolStripMenuItem
            // 
            this.工具TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.在线下载ToolStripMenuItem,
            this.章节阅读ToolStripMenuItem,
            this.检查章节ToolStripMenuItem});
            this.工具TToolStripMenuItem.Name = "工具TToolStripMenuItem";
            this.工具TToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.工具TToolStripMenuItem.Text = "工具(&T)";
            // 
            // 在线下载ToolStripMenuItem
            // 
            this.在线下载ToolStripMenuItem.Name = "在线下载ToolStripMenuItem";
            this.在线下载ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.在线下载ToolStripMenuItem.Text = "在线下载...";
            // 
            // 章节阅读ToolStripMenuItem
            // 
            this.章节阅读ToolStripMenuItem.Name = "章节阅读ToolStripMenuItem";
            this.章节阅读ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.章节阅读ToolStripMenuItem.Text = "章节阅读";
            // 
            // 检查章节ToolStripMenuItem
            // 
            this.检查章节ToolStripMenuItem.Name = "检查章节ToolStripMenuItem";
            this.检查章节ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.检查章节ToolStripMenuItem.Text = "检查章节";
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.帮助HToolStripMenuItem.Text = "帮助(&H)";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 540);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(884, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.syncTxt);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.operate);
            this.panel2.Controls.Add(this.lab3);
            this.panel2.Controls.Add(this.lab2);
            this.panel2.Controls.Add(this.lab1);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.but3);
            this.panel2.Controls.Add(this.but2);
            this.panel2.Controls.Add(this.but1);
            this.panel2.Controls.Add(this.tb3);
            this.panel2.Controls.Add(this.tb2);
            this.panel2.Controls.Add(this.tb1);
            this.panel2.Controls.Add(this.Title2);
            this.panel2.Controls.Add(this.LabNo2);
            this.panel2.Controls.Add(this.No2);
            this.panel2.Controls.Add(this.LabTit2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(232, 322);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(652, 215);
            this.panel2.TabIndex = 5;
            this.panel2.Visible = false;
            // 
            // syncTxt
            // 
            this.syncTxt.AutoSize = true;
            this.syncTxt.Location = new System.Drawing.Point(153, 180);
            this.syncTxt.Name = "syncTxt";
            this.syncTxt.Size = new System.Drawing.Size(96, 16);
            this.syncTxt.TabIndex = 20;
            this.syncTxt.Text = "同步文本内容";
            this.syncTxt.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(473, 176);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "删除";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // operate
            // 
            this.operate.AutoSize = true;
            this.operate.Location = new System.Drawing.Point(618, 181);
            this.operate.Name = "operate";
            this.operate.Size = new System.Drawing.Size(11, 12);
            this.operate.TabIndex = 18;
            this.operate.Text = "0";
            this.operate.Visible = false;
            // 
            // lab3
            // 
            this.lab3.AutoSize = true;
            this.lab3.Location = new System.Drawing.Point(22, 141);
            this.lab3.Name = "lab3";
            this.lab3.Size = new System.Drawing.Size(29, 12);
            this.lab3.TabIndex = 17;
            this.lab3.Text = "目录";
            this.lab3.Visible = false;
            // 
            // lab2
            // 
            this.lab2.AutoSize = true;
            this.lab2.Location = new System.Drawing.Point(22, 101);
            this.lab2.Name = "lab2";
            this.lab2.Size = new System.Drawing.Size(29, 12);
            this.lab2.TabIndex = 16;
            this.lab2.Tag = "";
            this.lab2.Text = "封面";
            this.lab2.Visible = false;
            // 
            // lab1
            // 
            this.lab1.AutoSize = true;
            this.lab1.Location = new System.Drawing.Point(22, 63);
            this.lab1.Name = "lab1";
            this.lab1.Size = new System.Drawing.Size(29, 12);
            this.lab1.TabIndex = 15;
            this.lab1.Text = "分册";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(57, 176);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "确认";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // but3
            // 
            this.but3.Location = new System.Drawing.Point(554, 136);
            this.but3.Name = "but3";
            this.but3.Size = new System.Drawing.Size(75, 23);
            this.but3.TabIndex = 13;
            this.but3.Text = "浏览";
            this.but3.UseVisualStyleBackColor = true;
            this.but3.Visible = false;
            this.but3.Click += new System.EventHandler(this.but3_Click);
            // 
            // but2
            // 
            this.but2.Location = new System.Drawing.Point(554, 96);
            this.but2.Name = "but2";
            this.but2.Size = new System.Drawing.Size(75, 23);
            this.but2.TabIndex = 12;
            this.but2.Text = "浏览";
            this.but2.UseVisualStyleBackColor = true;
            this.but2.Visible = false;
            this.but2.Click += new System.EventHandler(this.but2_Click);
            // 
            // but1
            // 
            this.but1.Location = new System.Drawing.Point(554, 58);
            this.but1.Name = "but1";
            this.but1.Size = new System.Drawing.Size(75, 23);
            this.but1.TabIndex = 11;
            this.but1.Text = "浏览";
            this.but1.UseVisualStyleBackColor = true;
            this.but1.Click += new System.EventHandler(this.but1_Click);
            // 
            // tb3
            // 
            this.tb3.Location = new System.Drawing.Point(57, 138);
            this.tb3.Name = "tb3";
            this.tb3.Size = new System.Drawing.Size(491, 21);
            this.tb3.TabIndex = 10;
            this.tb3.Visible = false;
            // 
            // tb2
            // 
            this.tb2.Location = new System.Drawing.Point(57, 98);
            this.tb2.Name = "tb2";
            this.tb2.Size = new System.Drawing.Size(491, 21);
            this.tb2.TabIndex = 9;
            this.tb2.Visible = false;
            // 
            // tb1
            // 
            this.tb1.Location = new System.Drawing.Point(57, 60);
            this.tb1.Name = "tb1";
            this.tb1.Size = new System.Drawing.Size(491, 21);
            this.tb1.TabIndex = 8;
            // 
            // Title2
            // 
            this.Title2.Location = new System.Drawing.Point(57, 19);
            this.Title2.Name = "Title2";
            this.Title2.Size = new System.Drawing.Size(399, 21);
            this.Title2.TabIndex = 5;
            // 
            // LabNo2
            // 
            this.LabNo2.AutoSize = true;
            this.LabNo2.Location = new System.Drawing.Point(498, 24);
            this.LabNo2.Name = "LabNo2";
            this.LabNo2.Size = new System.Drawing.Size(29, 12);
            this.LabNo2.TabIndex = 6;
            this.LabNo2.Text = "序号";
            // 
            // No2
            // 
            this.No2.Location = new System.Drawing.Point(533, 19);
            this.No2.Name = "No2";
            this.No2.Size = new System.Drawing.Size(96, 21);
            this.No2.TabIndex = 7;
            this.No2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.No2_KeyPress);
            // 
            // LabTit2
            // 
            this.LabTit2.AutoSize = true;
            this.LabTit2.Location = new System.Drawing.Point(22, 24);
            this.LabTit2.Name = "LabTit2";
            this.LabTit2.Size = new System.Drawing.Size(29, 12);
            this.LabTit2.TabIndex = 4;
            this.LabTit2.Text = "标题";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.重新加载ToolStripMenuItem,
            this.移除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
            // 
            // 重新加载ToolStripMenuItem
            // 
            this.重新加载ToolStripMenuItem.Name = "重新加载ToolStripMenuItem";
            this.重新加载ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.重新加载ToolStripMenuItem.Text = "重新加载";
            // 
            // 移除ToolStripMenuItem
            // 
            this.移除ToolStripMenuItem.Name = "移除ToolStripMenuItem";
            this.移除ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.移除ToolStripMenuItem.Text = "移除";
            // 
            // imgList
            // 
            this.imgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.imgList.ImageSize = new System.Drawing.Size(16, 16);
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 22);
            // 
            // MainWin
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 562);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 编辑EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查找ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除空行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 替换ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem 工具TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 章节阅读ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 在线下载ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 重新加载ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 检查章节ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 移除ToolStripMenuItem;
        private System.Windows.Forms.RichTextBox rtb_txt;
        private System.Windows.Forms.Label No;
        private System.Windows.Forms.Label LabNo;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label LabTit;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripButton tsb_edt;
        private System.Windows.Forms.ToolStripButton tsb_add;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsb_del;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TextBox Title2;
        private System.Windows.Forms.Label LabNo2;
        private System.Windows.Forms.TextBox No2;
        private System.Windows.Forms.Label LabTit2;
        private System.Windows.Forms.Label lab3;
        private System.Windows.Forms.Label lab2;
        private System.Windows.Forms.Label lab1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button but3;
        private System.Windows.Forms.Button but2;
        private System.Windows.Forms.Button but1;
        private System.Windows.Forms.TextBox tb3;
        private System.Windows.Forms.TextBox tb2;
        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.ListView lvImg;
        private System.Windows.Forms.Label operate;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox syncTxt;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        //private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}