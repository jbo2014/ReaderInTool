using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;


namespace Reader
{
    public partial class MainWin : Form
    {

        Handles hs = null;

        public MainWin()
        {
            InitializeComponent();
            BindTreeView();
        }

        //左侧菜单树绑定
        private void BindTreeView()
        {
            treeView1.LabelEdit = false;//不可编辑
            //添加结点
            TreeNode root = new TreeNode();
            root.Text = "根节点";
            //一级
            TreeNode node1 = new TreeNode();
            node1.Text = "漫画";
            TreeNode node2 = new TreeNode();
            node2.Text = "原著";
            TreeNode node3 = new TreeNode();
            node3.Text = "绘本";
            TreeNode node4 = new TreeNode();
            node4.Text = "百科";

            hs = new Handles();
            DataSet typs = hs.GetDataSet("type");
            DataSet vols = hs.GetDataSet("volume");
            DataSet chps = hs.GetDataSet("chapter");
            if (typs.Tables[0].Rows.Count < 0)
            { 
                return;
            }

            foreach (DataRow typ in typs.Tables[0].Rows)
            {
                TreeNode typNode = new TreeNode();
                typNode.Tag = typ;
                typNode.Text = typ["Title"].ToString();
                typNode.Name = "t" + typ["ID"].ToString();
                if(typ["type"].ToString() == "1")
                {
                    node1.Nodes.Add(typNode);
                }
                else if (typ["type"].ToString() == "2")
                {
                    node2.Nodes.Add(typNode);
                }
                else if (typ["type"].ToString() == "3")
                {
                    node3.Nodes.Add(typNode);
                }
                else if (typ["type"].ToString() == "4")
                {
                    node4.Nodes.Add(typNode);
                }

                DataRow[] dr_vol = vols.Tables[0].Select("BokID="+typ["id"].ToString());
                if (dr_vol.Length > 0) 
                {
                    foreach (DataRow sdr_vol in dr_vol)
                    {
                        TreeNode volNode = new TreeNode();
                        volNode.Text = sdr_vol["Title"].ToString();
                        volNode.Name = "v" + sdr_vol["ID"].ToString();
                        typNode.Nodes.Add(volNode);

                        DataRow[] dr_chp = chps.Tables[0].Select("VolID=" + sdr_vol["id"].ToString());
                        if (dr_chp.Length > 0)
                        {
                            foreach (DataRow sdr_chp in dr_chp)
                            {
                                TreeNode chpNode = new TreeNode();
                                chpNode.Text = sdr_chp["Title"].ToString();
                                chpNode.Name = "c" + sdr_chp["ID"].ToString();
                                volNode.Nodes.Add(chpNode);
                            }
                        }
                    }
                }
            }            

            //一级加入根
            root.Nodes.Add(node1);
            root.Nodes.Add(node3);
            root.Nodes.Add(node2);
            root.Nodes.Add(node4);
            //
            treeView1.Nodes.Add(root);
        }

        //点击左侧目录树时触发的问题
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //if (treeView1.SelectedNode != null)
            DataSet ds = null;
            hs = new Handles();
            panel2.Visible = false;
            rtb_txt.Visible = false;
            lvImg.Visible = false;
            syncTxt.Visible = false;

            if (e.Node != null && e.Node.Name != "")
            {
                panel3.Visible = true;
                string p = e.Node.Name.Substring(0, 1);
                string id = e.Node.Name.Substring(1);
                if (p == "t") //点击书名
                {
                    tsb_add.Text = "增加分册";
                    tsb_add.Enabled = true;
                    tsb_del.Enabled = false;
                    tsb_edt.Enabled = false;
                    rtb_txt.Visible = false;

                    ds = hs.GetTableByWhere("type", "ID=" + e.Node.Name.Substring(1));
                    DataRow dr = ds.Tables[0].Rows[0];
                    Title.Text = dr["Title"].ToString();
                    No.Text = dr["No"].ToString();
                }
                else if (p == "v") //点击分册
                {
                    DataSet ds2 = null;

                    tsb_add.Text = "增加章回";
                    tsb_del.Text = "删除该分册";
                    tsb_edt.Text = "修改该分册";
                    tsb_add.Enabled = true;
                    tsb_del.Enabled = true;
                    tsb_edt.Enabled = true;
                    panel1.Visible = true;
                    lvImg.Visible = true;

                    ds = hs.GetTableByWhere("volume", "ID=" + e.Node.Name.Substring(1));
                    DataRow dr = ds.Tables[0].Rows[0];
                    Title.Text = dr["Title"].ToString();
                    No.Text = dr["No"].ToString();

                    ds2 = hs.GetVol(id);
                    lvImgBinding("v", ds2.Tables[0].Rows);
                    //byte[] imgByte = null;
                    //byte[] de = null;
                    
                    //填充imgList
                    //imgList.Images.Clear();
                    //imgList.ImageSize = new Size(136,242);
                    //imgByte = (byte[])dr2["img1"];
                    //de = Encrypt.DecryptByte(imgByte, "Za@$100%", "395^abC~");
                    //imgList.Images.Add("1", Transform.BytToImg(de));
                    //imgByte = (byte[])dr2["img2"];
                    //de = Encrypt.DecryptByte(imgByte, "Za@$100%", "395^abC~");
                    //imgList.Images.Add("2", Transform.BytToImg(de));
                    //imgByte = (byte[])dr2["img3"];
                    //de = Encrypt.DecryptByte(imgByte, "Za@$100%", "395^abC~");
                    //imgList.Images.Add("3", Transform.BytToImg(de));
                    
                    ////填充lvImg
                    //lvImg.Items.Clear();
                    //lvImg.View = View.LargeIcon;
                    //lvImg.LargeImageList = imgList;
                    //lvImg.SelectedIndexChanged -= lvImg_SelectedIndexChanged;
                    //ListViewItem li = null;

                    //string[] ltit = {"分册","封面","目录"};
                    //string[] lid = { dr2["volid"].ToString(), dr2["covid"].ToString(), dr2["catid"].ToString() };
                    //for (int i = 0; i < imgList.Images.Count; i++) 
                    //{
                    //    li = new ListViewItem();
                    //    li.Text = ltit[i];
                    //    li.Tag = lid[i];
                    //    li.ImageIndex = i;
                    //    lvImg.Items.Add(li);
                    //}
                }
                else if (p == "c") //点击章回
                {
                    DataSet ds2 = null;

                    tsb_add.Text = "增加图片";
                    tsb_del.Text = "删除该章回";
                    tsb_edt.Text = "修改该章回";
                    tsb_del.Enabled = true;
                    tsb_edt.Enabled = true;
                    panel1.Visible = true;

                    ds = hs.GetChp(e.Node.Name.Substring(1));
                    DataRow dr = ds.Tables[0].Rows[0];
                    Title.Text = dr["Title"].ToString();
                    No.Text = dr["No"].ToString();

                    if (dr["type"].ToString() == "1" || dr["type"].ToString() == "3")
                    {
                        tsb_add.Enabled = true;
                        lvImg.Visible = true;

                        ds2 = hs.GetTableByWhere("Manga", "ChpID=" + e.Node.Name.Substring(1));
                        lvImgBinding("c", ds2.Tables[0].Rows);
                        //byte[] imgByte = null;

                        ////填充imgList
                        //imgList.Images.Clear();
                        //imgList.ImageSize = new Size(136, 242);
                        ////填充lvImg
                        //lvImg.Items.Clear();
                        //lvImg.View = View.LargeIcon;

                        //int i = 0;
                        //foreach(DataRow dr2 in ds2.Tables[0].Rows)
                        //{
                        //    imgByte = (byte[])dr2["Contents"];
                        //    byte[] de = Encrypt.DecryptByte(imgByte, "Za@$100%", "395^abC~");

                        //    imgList.Images.Add(Transform.BytToImg(de));
                        //    lvImg.Items.Add("",i);
                        //    lvImg.Items[i].ImageIndex = i;
                        //    lvImg.Items[i].Tag = dr2["No"].ToString();
                        //    lvImg.Items[i].Name = dr2["Id"].ToString();
                        //    lvImg.Items[i].Text = "第" + dr2["No"].ToString() + "页";
                        //    i++;
                        //}

                        //lvImg.LargeImageList = imgList;
                        //lvImg.SelectedIndexChanged += lvImg_SelectedIndexChanged;
                    }
                    else if (dr["type"].ToString() == "2" || dr["type"].ToString() == "4")
                    {
                        tsb_add.Enabled = false;
                        rtb_txt.Visible = true;
                        
                        ds2 = hs.GetTableByWhere("Text", "ChpID=" + e.Node.Name.Substring(1));
                        DataRow dr2 = ds2.Tables[0].Rows[0];
                        rtb_txt.Text = dr2["Contents"].ToString();
                    }
                }
            }
            else
            {
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
                tsb_add.Enabled = false;
                tsb_del.Enabled = false;
                tsb_edt.Enabled = false;
                //MessageBox.Show("请选择下级节点");
            }
        }

        //刷新目录树
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            BindTreeView();
            treeView1.SelectedNode = treeView1.Nodes[0];
        }

        //右上角增加按钮
        private void tsb_add_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            //button1.Click += null;
            Helper.RemoveControlEvent(button1, "EventClick");
            button2.Visible = false;
            syncTxt.Visible = false;
            
            //operate，隐藏控件，0是增加、1是修改
            operate.Text = "0";

            lab1.Visible = true;
            tb1.Visible = true;
            but1.Visible = true;
            lab2.Visible = false;
            tb2.Visible = false;
            but2.Visible = false;
            lab3.Visible = false;
            tb3.Visible = false;
            but3.Visible = false;

            LabTit2.Visible = true;
            Title2.Visible = true;
            clearInput();

            string p = treeView1.SelectedNode.Name.Substring(0,1);
            if (p == "t") 
            {
                lab2.Visible = true;
                tb2.Visible = true;
                but2.Visible = true;
                lab3.Visible = true;
                tb3.Visible = true;
                but3.Visible = true;
                button1.Click += VOL_ADD_Click;
            }
            else if (p == "v")
            {
                string type = hs.GetTypeByID("Volume", treeView1.SelectedNode.Name.Substring(1));
                if (type == "1" || type == "3")
                {
                    lab1.Text = "目录";
                }
                else
                {
                    lab1.Text = "文本";
                }
                button1.Click += CHP_ADD_Click;
            }
            else if (p == "c") 
            {
                lab1.Text = "图片";
                Title2.Visible = false;
                LabTit2.Visible = false;
                button1.Click += MGA_ADD_Click;
            }
        }

        //右上角修改按钮
        private void tsb_edt_Click(object sender, EventArgs e)
        {
            hs = new Handles();

            panel2.Visible = true;
            clearInput();
            Helper.RemoveControlEvent(button1, "EventClick");
            button2.Visible = false;
            operate.Text = "1";

            LabTit2.Visible = true;
            Title2.Visible = true;
            Title2.Text = Title.Text;
            No2.Text = No.Text;
            syncTxt.Visible = false;

            string p = treeView1.SelectedNode.Name.Substring(0, 1);
            if (p == "v")
            {
                lab1.Visible = true;
                tb1.Visible = true;
                but1.Visible = true;
                lab2.Visible = true;
                tb2.Visible = true;
                but2.Visible = true;
                lab3.Visible = true;
                tb3.Visible = true;
                but3.Visible = true;
                button1.Click += VOL_EDT_Click;
            }
            else if (p == "c")
            {
                lab1.Visible = false;
                tb1.Visible = false;
                but1.Visible = false;
                lab2.Visible = false;
                tb2.Visible = false;
                but2.Visible = false;
                lab3.Visible = false;
                tb3.Visible = false;
                but3.Visible = false;
                string type = hs.GetTypeByID("Chapter", treeView1.SelectedNode.Name.Substring(1));
                if (type == "2" || type == "4")
                {
                    syncTxt.Visible = true;
                }
                button1.Click += CHP_EDT_Click;
            }
        }

        //右上角删除按钮
        private void tsb_del_Click(object sender, EventArgs e)
        {
            hs = new Handles();
            int rst = 0;
            string p = treeView1.SelectedNode.Name.Substring(0, 1);
            string id = treeView1.SelectedNode.Name.Substring(1);

            if (p == "v")
            {
                try
                {
                    hs.DelVolume(id);
                    rst = 1;
                }
                catch
                {
                    showExeMsg(rst);
                    return;
                }
            }
            else if (p == "c") 
            {
                try
                {
                    hs.DelChp(id);
                    rst = 1;
                }
                catch 
                {
                    showExeMsg(rst);
                    return;
                }
            }
            showExeMsg(rst);
            //TreeNode paTN = treeView1.SelectedNode.Parent;//Parent.Checked = true; // = treeView1.Nodes[0];
            toolStripButton1.PerformClick();
        }


        //panel2三个浏览按钮的点击事件
        private void but1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Name.Substring(0, 1) == "v" && operate.Text == "0")
            {
                string type = hs.GetTypeByID("Volume", treeView1.SelectedNode.Name.Substring(1));
                if ((type == "1" || type == "3"))
                {
                    openPathWin(tb1);
                    return;
                }
            }
            openFileWin(tb1);
        }
        private void but2_Click(object sender, EventArgs e)
        {
            openFileWin(this.tb2);
        }
        private void but3_Click(object sender, EventArgs e)
        {
            openFileWin(this.tb3);
        }

        //单击ImageList元素图片时触发
        private void lvImg_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearInput();
            if (lvImg.SelectedItems.Count > 0)
            {
                panel2.Visible = true;
                operate.Text = "1";
                lab1.Visible = true;
                tb1.Visible = true;
                but1.Visible = true;
                LabTit2.Visible = false;
                Title2.Visible = false;

                Helper.RemoveControlEvent(button1, "EventClick");
                button2.Visible = true;
                button2.Click += MGA_DEL_Click;
                button1.Click += MGA_EDT_Click;

                No2.Text = lvImg.SelectedItems[0].Tag.ToString();
            }
        }

        //检测填入的序号No2，是否为数字
        private void No2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))   // 如果当前输入的不是数字
            {
                MessageBox.Show("请输入数字！", "操作提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);   // 给出错误提示
                e.Handled = true;   // 取消当前操作，即取消在控件中现实该字符的操作
            }
        }



        /******************************************** Panel2 确认按钮的点击事件 START****************************************/

        /******************************************** 点击书目进入的界面操作 ****************************************/
        //添加分册
        private void VOL_ADD_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Title2.Text) || string.IsNullOrEmpty(No2.Text) || string.IsNullOrEmpty(tb1.Text) || string.IsNullOrEmpty(tb2.Text) || string.IsNullOrEmpty(tb3.Text))
            {
                DialogResult dr = MessageBox.Show("标题、序号、三个图片是必填项.", "增加分册", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dr == DialogResult.OK)//如果点击“确定”按钮
                    return;
            }
            else if ((!string.IsNullOrEmpty(tb1.Text) && !isPicture(tb1.Text)) || (!string.IsNullOrEmpty(tb2.Text) && !isPicture(tb2.Text)) || (!string.IsNullOrEmpty(tb3.Text) && !isPicture(tb3.Text)))
            {
                DialogResult dr = MessageBox.Show("需要上传图片", "操作错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dr == DialogResult.OK)//如果点击“确定”按钮
                    return;
            }

            hs = new Handles();
            Hashtable ht = new Hashtable();
            string bokid = treeView1.SelectedNode.Name.Substring(1);

            ht.Add("No", No2.Text);
            ht.Add("ID", bokid);
            ht.Add("Tit", Title2.Text);
            ht.Add("Img", this.tb1.Text);
            ht.Add("Img1", this.tb2.Text);
            ht.Add("Img2", this.tb3.Text);
            
            int rst = 0;
            try
            {
                hs.InsertVolume(ht);
                rst = 1;
            }
            catch
            {
                showExeMsg(rst);
                return;
            }
            showExeMsg(rst);
        }



        /******************************************** 点击分册进入的界面操作 ****************************************/
        //修改分册
        private void VOL_EDT_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(tb1.Text) && !isPicture(tb1.Text)) || (!string.IsNullOrEmpty(tb2.Text) && !isPicture(tb2.Text)) || (!string.IsNullOrEmpty(tb3.Text) && !isPicture(tb3.Text)))
            {
                DialogResult dr = MessageBox.Show("需要上传图片", "操作错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dr == DialogResult.OK)//如果点击“确定”按钮
                    return;
            }
            hs = new Handles();
            Hashtable ht = new Hashtable();
            string volid = treeView1.SelectedNode.Name.Substring(1);
            ht.Add("ID", volid);
            ht.Add("Tit", Title2.Text);
            ht.Add("No", No2.Text);
            ht.Add("Img", tb1.Text);
            ht.Add("Img1", tb2.Text);
            ht.Add("Img2", tb3.Text);
            
            int rst = 0;
            try
            {
                hs.UpdateVolume(ht);
                rst = 2;
            }
            catch
            {
                showExeMsg(rst);
                return;
            }
            showExeMsg(rst);
        }
        //添加章回
        private void CHP_ADD_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Title2.Text) || string.IsNullOrEmpty(No2.Text) || string.IsNullOrEmpty(tb1.Text))
            {
                DialogResult dr = MessageBox.Show("标题、序号、图片文件夹或小说文本是必填项.", "批量章回内容", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dr == DialogResult.OK)//如果点击“确定”按钮
                    return;
            }
            hs = new Handles();
            Hashtable ht = new Hashtable();
            string volid = treeView1.SelectedNode.Name.Substring(1);
            string type = hs.GetTypeByID("Volume", volid);

            if (type == "1" || type == "3")
            {
                if (!Directory.Exists(tb1.Text))
                {
                    DialogResult dr = MessageBox.Show("路径不存在.", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (dr == DialogResult.OK)//如果点击“确定”按钮
                        return;
                }
            }
            else 
            {
                if (Path.GetExtension(tb1.Text).ToLower() != ".txt")
                {
                    DialogResult dr = MessageBox.Show("需要上传TXT格式文件.", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (dr == DialogResult.OK)//如果点击“确定”按钮
                        return;
                }
            }
            
            ht.Add("No", No2.Text);
            ht.Add("Tit", Title2.Text);
            ht.Add("Vol", volid);
            ht.Add("Path", tb1.Text);
            int rst = 0;
            if(type=="1" || type=="3")
            {                
                try
                {
                    hs.InsertImgBat(ht);
                    rst = 1;
                }
                catch
                {
                    showExeMsg(rst);
                    return;
                }
            }
            else
            {
                rst = hs.InsertTxt(ht);
            }
            showExeMsg(rst); 
        }





        /******************************************** 点击章回进入的界面操作 ****************************************/
        //修改章回
        private void CHP_EDT_Click(object sender, EventArgs e)
        {
            hs = new Handles();
            Hashtable ht = new Hashtable();
            int rst = 0;
            string chpid = treeView1.SelectedNode.Name.Substring(1);
            string type = hs.GetTypeByID("Chapter", chpid);
            ht.Add("ID", chpid);
            ht.Add("Tit", Title2.Text);
            ht.Add("No", No2.Text);
            rst = hs.UpdateChapter(ht);
            if (syncTxt.Visible == true && syncTxt.Checked)
            {
                ht.Add("type", "txt");
                ht.Add("Conts", rtb_txt.Text);
                rst = hs.UpdateConts(ht);
            }
            showExeMsg(rst);
        }
        //添加新的漫画图片
        private void MGA_ADD_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(No2.Text) || string.IsNullOrEmpty(tb1.Text))
            {
                DialogResult dr = MessageBox.Show("序号、图片文件是必填项.", "添加漫画图片", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dr == DialogResult.OK)//如果点击“确定”按钮
                    return;
            }             
            hs = new Handles();
            Hashtable ht = new Hashtable();
            string chpid = treeView1.SelectedNode.Name.Substring(1);
            ht.Add("No", No2.Text);
            ht.Add("ChpID", chpid);
            ht.Add("Img", tb1.Text);
            int rst = hs.AddNewMag(ht);
            if (rst > 0)
                showExeMsg(2);
            else
                showExeMsg(0);
        }
        //修改选择的漫画图片
        private void MGA_EDT_Click(object sender, EventArgs e)
        {
            hs = new Handles();
            Hashtable ht = new Hashtable();
            if (string.IsNullOrEmpty(No2.Text))
            {
                DialogResult dr = MessageBox.Show("序号是必填项.", "修改选择的漫画", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dr == DialogResult.OK)//如果点击“确定”按钮
                    return;
            }
            if (lvImg.SelectedItems.Count == 0)
                return;
            string mgaid = lvImg.SelectedItems[0].Name.ToString();
            ht.Add("type", "mag");
            ht.Add("ID", mgaid);
            ht.Add("Conts", tb1.Text);
            ht.Add("No", No2.Text);

            int rst = hs.UpdateConts(ht);
            if (rst > 0)
                showExeMsg(2);
            else
                showExeMsg(0);

            button2.Visible = false;
        }
        //删除按钮 删除选择的漫画图片
        private void MGA_DEL_Click(object sender, EventArgs e)
        {
            hs = new Handles();
            if (lvImg.SelectedItems.Count > 0)
            {
                int rst = hs.DelMag(lvImg.SelectedItems[0].Name.ToString());
                if (rst > 0)
                    showExeMsg(2);
                else
                    showExeMsg(0);
            }
        }

        /******************************************** Panel2 确认按钮的点击事件 END****************************************/





        /******************************************** 公用方法 ****************************************/
        //打开文件选择窗口
        public void openFileWin(TextBox tb)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            tb.Text = file.FileName; 
        }
        //打开目录选择窗口
        public void openPathWin(TextBox tb)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            tb.Text = path.SelectedPath;
        }
        /** 判断文件是否图片、txt
         *  读取每个文件的头两个字节，
         *  byte[0].ToString()+byte[1].ToString()的值 
         *  255216:jpg,7173:gif,6677:bmp,13780:png
         */
        private bool isPicture(string filePath)//filePath是文件的完整路径 
        {
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(fs);
            string fileClass;
            byte buffer;
            byte[] b = new byte[2];
            try
            {
                buffer = reader.ReadByte();
                b[0] = buffer;
                fileClass = buffer.ToString();
                buffer = reader.ReadByte();
                b[1] = buffer;
                fileClass += buffer.ToString();

                reader.Close();
                fs.Close();
                if (fileClass == "255216" || fileClass == "7173" || fileClass == "6677" || fileClass == "13780")//255216是jpg;7173是gif;6677是BMP,13780是PNG;7790是exe,8297是rar 
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        //操作结果弹出框
        //0:操作失败,1:操作成功不需要刷新,2:操作成功需要刷新
        private void showExeMsg(int i) 
        {
            
            if (i == 0)
            {
                DialogResult dr = MessageBox.Show("操作失败！", "操作执行结果", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dr == DialogResult.OK)//如果点击“确定”按钮
                    return;
            }
            else if (i == 1)
            {
                DialogResult dr = MessageBox.Show("操作成功！", "操作执行结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)//如果点击“确定”按钮
                    return;
            }
            else if (i == 2)
            {
                DialogResult dr = MessageBox.Show("操作成功！", "操作执行结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)//如果点击“确定”按钮
                {
                    string p = treeView1.SelectedNode.Name.Substring(0, 1);
                    string id = treeView1.SelectedNode.Name.Substring(1);
                    DataSet ds2 = null;
                    if (p == "v" && operate.Text == "1")
                    {
                        ds2 = hs.GetVol(id);
                    }
                    else if (p == "c")
                    {
                        string typ = hs.GetTypeByID("Chapter", id);
                        if (typ == "2" || typ == "4")
                            return;
                        ds2 = hs.GetTableByWhere("Manga", "ChpID=" + id);
                    }
                    if (ds2.Tables.Count > 0)
                        lvImgBinding(p, ds2.Tables[0].Rows);
                    return;
                }
            }
        }
        //lvImg绑定
        private void lvImgBinding(string x, DataRowCollection drs) 
        {
            byte[] imgByte = null;

            imgList.Images.Clear();
            imgList.ImageSize = new Size(136, 242);
            lvImg.Items.Clear();
            if (x.ToLower() == "c") 
            {
                //填充imgList
                imgList.Images.Clear();
                imgList.ImageSize = new Size(136, 242);
                //填充lvImg
                lvImg.Items.Clear();
                lvImg.View = View.LargeIcon;

                int i = 0;
                foreach (DataRow dr in drs)
                {
                    imgByte = (byte[])dr["Contents"];
                    byte[] de = Encrypt.DecryptByte(imgByte, "Za@$100%", "395^abC~");

                    imgList.Images.Add(Transform.BytToImg(de));
                    lvImg.Items.Add("", i);
                    lvImg.Items[i].ImageIndex = i;
                    lvImg.Items[i].Tag = dr["No"].ToString();
                    lvImg.Items[i].Name = dr["Id"].ToString();
                    lvImg.Items[i].Text = "第" + dr["No"].ToString() + "页";
                    i++;
                }

                lvImg.LargeImageList = imgList;
                lvImg.SelectedIndexChanged += lvImg_SelectedIndexChanged;
            }
            else if (x.ToLower() == "v")
            {
                //填充imgList
                byte[] de = null;
                DataRow dr = drs[0];
                imgByte = (byte[])dr["img1"];
                de = Encrypt.DecryptByte(imgByte, "Za@$100%", "395^abC~");
                imgList.Images.Add("1", Transform.BytToImg(de));
                imgByte = (byte[])dr["img2"];
                de = Encrypt.DecryptByte(imgByte, "Za@$100%", "395^abC~");
                imgList.Images.Add("2", Transform.BytToImg(de));
                imgByte = (byte[])dr["img3"];
                de = Encrypt.DecryptByte(imgByte, "Za@$100%", "395^abC~");
                imgList.Images.Add("3", Transform.BytToImg(de));

                //填充lvImg
                lvImg.View = View.LargeIcon;
                lvImg.LargeImageList = imgList;
                lvImg.SelectedIndexChanged -= lvImg_SelectedIndexChanged;
                ListViewItem li = null;

                string[] ltit = { "分册", "封面", "目录" };
                string[] lid = { dr["volid"].ToString(), dr["covid"].ToString(), dr["catid"].ToString() };
                for (int i = 0; i < imgList.Images.Count; i++)
                {
                    li = new ListViewItem();
                    li.Text = ltit[i];
                    li.Tag = lid[i];
                    li.ImageIndex = i;
                    lvImg.Items.Add(li);
                }
            }
            else 
            {
                return;
            }
        }
        //清空填写内容
        private void clearInput() 
        {
            Title2.Text = "";
            No2.Text = "";
            tb1.Text = "";
            tb2.Text = "";
            tb3.Text = "";
            syncTxt.Checked = false;
        }

    }
}
