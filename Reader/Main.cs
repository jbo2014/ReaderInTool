using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Collections;
using System.IO;
using System.Configuration;

namespace Reader
{
    public partial class Main : Form
    {
        ListItem vo = null;
        Handles hs = null;

        public Main()
        {
            InitializeComponent();
        }

        //public void SetDb() 
        //{
        //    if(string.IsNullOrEmpty(ConfigurationManager.ConnectionStrings["connectionStr"].ConnectionString.ToString()))
        //    {
        //        OpenFileDialog file = new OpenFileDialog();
        //        file.ShowDialog();
        //        this.SecPic.Text = file.FileName; 
        //    }
        //}

        private void WinLoad(object sender, EventArgs e)
        {
            //tabpage1初始化
            BingBook(comboBox6, comboBox10);

            //tabpage2初始化
            BingBook(comboBox4, comboBox11);

            //tabpage3初始化
            BingBook(comboBox5, comboBox1);

            richTextBox1.Visible = false;
        }

        //private void TabSelected(object sender, TabControlEventArgs e)
        //{
        //    vo = new ListItem();
        //    string sqlstr = "";
        //    if (e.TabPage == tabPage1)
        //    {
        //        //当选项卡切换tabpage1时处理的事件
        //        BingBook(comboBox6, comboBox10);
        //    }
        //    else if (e.TabPage == tabPage2)
        //    {
        //        //当选项卡切换tabpage2时处理的事件
        //        BingBook(comboBox4, comboBox11);
        //    }
        //    else if (e.TabPage == tabPage3)
        //    {
        //        //当选项卡切换tabpage3时处理的事件
        //        BingBook(comboBox5, comboBox1);
        //        //分册
        //        sqlstr = "select * from Volume";
        //        vo.ComboBoxBing(comboBox2, sqlstr, "Title", "ID");
        //        //章回
        //        sqlstr = "select * from Chapter";
        //        vo.ComboBoxBing(comboBox3, sqlstr, "Title", "ID");
        //        richTextBox1.Visible = false;
        //    }
        //}

        private ArrayList GetTyp() 
        {
            ArrayList list = new ArrayList();
            list.Add(new ListItem("1", "漫画"));
            list.Add(new ListItem("2", "小说"));
            list.Add(new ListItem("3", "绘本"));
            list.Add(new ListItem("4", "百科"));
            return list;
        }
        private ArrayList GetBok()
        {
            ArrayList list = new ArrayList();
            list.Add(new ListItem("1", "三国演义"));
            list.Add(new ListItem("2", "西游记"));
            list.Add(new ListItem("3", "红楼梦"));
            list.Add(new ListItem("4", "水浒"));
            return list;
        }

        private void BingBook(ComboBox type, ComboBox bok)
        {
            //vo = new ListItem();
            type.DataSource = GetTyp();
            type.DisplayMember = "Value";
            type.ValueMember = "Key";
            //string sqlstr = "select * from Book";
            //vo.ComboBoxBing(bok, sqlstr, "Title", "ID");
            bok.DataSource = GetBok();
            bok.DisplayMember = "Value";
            bok.ValueMember = "Key";
        }

        /******************************************** 分册 ****************************************/
        //分册页图片
        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            this.SecPic.Text = file.FileName; 
        }
        //封面页图片
        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            this.CovPic.Text = file.FileName;
        }
        //目录页图片
        private void button9_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            this.ChpPic.Text = file.FileName;
        }
        
        //导入信息
        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(SecPic.Text) || string.IsNullOrEmpty(CovPic.Text) || string.IsNullOrEmpty(ChpPic.Text))
            {
                DialogResult dr = MessageBox.Show("序号、标题、三个图片是必填项.", "导入分册", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dr == DialogResult.OK)//如果点击“确定”按钮
                    return;
            }

            hs = new Handles();
            Hashtable ht = new Hashtable();
            int id = hs.GetBokID(comboBox6, comboBox10);
            
            ht.Add("No", textBox4.Text);
            ht.Add("ID", id);
            ht.Add("Tit", textBox1.Text);
            ht.Add("Img", this.SecPic.Text);
            ht.Add("Img1", this.CovPic.Text);
            ht.Add("Img2", this.ChpPic.Text);
            hs.InsertVolume(ht);
        }

        //
        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox9.Items.Clear();
            textBox2.Text = "";
            textBox6.Text = "";
            vo = new ListItem();
            //分册
            int bokid = GetBokID(comboBox6, comboBox10);
            string sqlstr = "select * from Volume where BokID=" + bokid.ToString();
            vo.ComboBoxBing(comboBox9, sqlstr, "Title", "ID");
        }

        //
        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox6.Text = "";
            if (!string.IsNullOrEmpty(comboBox9.SelectedItem.ToString()))
            {
                vo = new ListItem();
                string sqlstr = "select * from Volume where ID=" + ((ListItem)comboBox9.SelectedItem).Key;
                DataSet ds =  SqlHelper.Query(sqlstr);
                if (ds.Tables[0].Rows.Count > 0) 
                {
                    textBox2.Text = ds.Tables[0].Rows[0]["Title"].ToString();
                    textBox6.Text = ds.Tables[0].Rows[0]["No"].ToString();
                }
            }
        }

        //删除选择的分册
        private void button14_Click(object sender, EventArgs e)
        {
            hs = new Handles();
            DialogResult dr;
            if (comboBox9.SelectedItem==null)
            {
                dr = MessageBox.Show("请选择分册.", "删除分册", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dr == DialogResult.OK)//如果点击“确定”按钮
                    return;
            }  

            dr = MessageBox.Show("确定删除该分册吗?该分册下的章回、内容信息也会一起删除。", "删除分册", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)//如果点击“确定”按钮
            {
                hs.DelVolume(((ListItem)comboBox9.SelectedItem).Key, comboBox6.SelectedValue.ToString());
            }
        }

        //修改选择的分册
        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox9.SelectedItem==null || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox6.Text))
            {
                DialogResult dr = MessageBox.Show("分册、序号、标题是必填项.", "修改分册", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dr == DialogResult.OK)//如果点击“确定”按钮
                    return;
            }
            hs = new Handles();
            Hashtable ht = new Hashtable();
            string volid = ((ListItem)comboBox9.SelectedItem).Key;
            ht.Add("ID", volid);
            ht.Add("Tit", textBox2.Text);
            ht.Add("No", textBox6.Text);
            ht.Add("Img", SecPic.Text);
            ht.Add("Img1", CovPic.Text);
            ht.Add("Img2", ChpPic.Text);
            hs.UpdateVolume(ht);
        }

        /******************************************** 章节 ****************************************/
        //
        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            vo = new ListItem();
            //分册
            int bokid = GetBokID(comboBox4, comboBox11);
            string sqlstr = "select * from Volume where BokID="+bokid.ToString();
            vo.ComboBoxBing(comboBox8, sqlstr, "Title", "ID");
        }

        //
        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox8.SelectedItem.ToString()))
            {
                vo = new ListItem();
                string cb8 = ((ListItem)comboBox8.SelectedItem).Key;
                string sqlstr = "select * from Chapter where VolID=" + cb8;
                vo.ComboBoxBing(comboBox12, sqlstr, "Title", "ID");
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedValue.ToString() == "2" || comboBox4.SelectedValue.ToString() == "4")
            {
                label37.Visible = true;
                button10.Visible = true;
                button11.Visible = true;
                ChpTxtPath.Visible = true;

                label30.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                ChpMagPath.Visible = false;
            }
            else
            {
                label30.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                ChpMagPath.Visible = true;

                label37.Visible = false;
                button10.Visible = false;
                button11.Visible = false;
                ChpTxtPath.Visible = false;
            }

        }
        
        //
        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox10.Text = "";
            textBox11.Text = "";
            if (!string.IsNullOrEmpty(comboBox12.SelectedItem.ToString()))
            {
                vo = new ListItem();
                string sqlstr = "select * from Chapter where ID=" + ((ListItem)comboBox12.SelectedItem).Key;
                DataSet ds = SqlHelper.Query(sqlstr);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    textBox10.Text = ds.Tables[0].Rows[0]["Title"].ToString();
                    textBox11.Text = ds.Tables[0].Rows[0]["No"].ToString();
                }
            }
        }

        //浏览图片包路径
        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            this.ChpMagPath.Text = path.SelectedPath;
        }

        //浏览文本
        private void button10_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            this.ChpTxtPath.Text = file.FileName;
        }

        //批量导入图片
        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox8.SelectedItem==null || string.IsNullOrEmpty(textBox9.Text) || string.IsNullOrEmpty(textBox7.Text) || string.IsNullOrEmpty(ChpMagPath.Text))
            {
                DialogResult dr = MessageBox.Show("分册、序号、标题、图片文件夹是必填项.", "批量导入漫画图片", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dr == DialogResult.OK)//如果点击“确定”按钮
                    return;
            }
            hs = new Handles();
            Hashtable ht = new Hashtable();
            string cb8 = ((ListItem)comboBox8.SelectedItem).Key;
            ht.Add("No", textBox9.Text);
            //ht.Add("Bok", hs.GetBokID(comboBox4, comboBox11));
            ht.Add("Vol", cb8);
            ht.Add("Tit", textBox7.Text);
            ht.Add("Path", ChpMagPath.Text);
            hs.InsertImgBat(ht);
        }

        //导入文本
        private void button11_Click(object sender, EventArgs e)
        {
            hs = new Handles();
            Hashtable ht = new Hashtable();

            if (comboBox8.SelectedItem==null || string.IsNullOrEmpty(textBox9.Text) || string.IsNullOrEmpty(textBox7.Text) || string.IsNullOrEmpty(ChpTxtPath.Text))
            {
                DialogResult dr = MessageBox.Show("分册、序号、标题、文本文件是必填项.", "导入章回文本", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dr == DialogResult.OK)//如果点击“确定”按钮
                    return;
            }
            string cb8 = ((ListItem)comboBox8.SelectedItem).Key;
            ht.Add("No", textBox9.Text);
            ht.Add("Tit", textBox7.Text);
            //ht.Add("Bok", hs.GetBokID(comboBox4, comboBox11));
            ht.Add("Vol", cb8);
            ht.Add("Path", ChpTxtPath.Text);
            hs.InsertTxt(ht);
        }

        //删除选择的章回
        private void button15_Click(object sender, EventArgs e)
        {
            hs = new Handles();
            DialogResult dr;

            if (comboBox12.SelectedItem==null || string.IsNullOrEmpty(comboBox4.SelectedValue.ToString()))
            {
                dr = MessageBox.Show("书目类别、待选章回是必填项.", "删除章回", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dr == DialogResult.OK)//如果点击“确定”按钮
                    return;
            }
            dr = MessageBox.Show("确定删除该章回吗?该章回下的内容信息也会一起删除。", "删除章回", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)//如果点击“确定”按钮
            {
                string cb12 = ((ListItem)comboBox12.SelectedItem).Key;
                hs.DelChp(cb12, comboBox4.SelectedValue.ToString());
            }
            else//如果点击“取消”按钮
            {
            }
        }

        //修改选择的章回序号、标题
        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox12.SelectedItem == null || string.IsNullOrEmpty(textBox10.Text) || string.IsNullOrEmpty(textBox11.Text))
            {
                DialogResult dr = MessageBox.Show("修改的章回、序号、标题是必填项.", "修改章回", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dr == DialogResult.OK)//如果点击“确定”按钮
                    return;
            }
            hs = new Handles();
            Hashtable ht = new Hashtable();
            string chp = ((ListItem)comboBox12.SelectedItem).Key;
            ht.Add("ID", chp);
            ht.Add("Tit", textBox10.Text);
            ht.Add("No", textBox11.Text);
            hs.UpdateChapter(ht);
        }




        /******************************************** 内容 ****************************************/
        //浏览漫画
        private void button12_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            this.textBox8.Text = file.FileName;
        }
        //类型改变
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedValue.ToString() == "2" || comboBox5.SelectedValue.ToString() == "4")
            {
                richTextBox1.Visible = true;
                label38.Visible = false;
                textBox8.Visible = false;
                button12.Visible = false;
                label4.Visible = false;
                textBox5.Visible = false;
                label25.Visible = false;
                comboBox7.Visible = false;
                button13.Visible = false;
                button16.Visible = false;
            }
            else
            {
                richTextBox1.Visible = false;
                label38.Visible = true;
                textBox8.Visible = true;
                button12.Visible = true;
                label4.Visible = true;
                textBox5.Visible = true;
                label25.Visible = true;
                comboBox7.Visible = true;
                button13.Visible = true;
                button16.Visible = true;
            }
        }
        //书名改变
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            vo = new ListItem();
            //分册
            int bokid = GetBokID(comboBox5, comboBox1);
            string sqlstr = "select * from Volume where BokID=" + bokid.ToString();
            vo.ComboBoxBing(comboBox2, sqlstr, "Title", "ID");
            comboBox3.Items.Clear();
        }
        //分册改变
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox2.SelectedItem.ToString()))
            {
                vo = new ListItem();
                string sqlstr = "select * from Chapter where VolID=" + ((ListItem)comboBox2.SelectedItem).Key;
                vo.ComboBoxBing(comboBox3, sqlstr, "Title", "ID");
            }
        }
        //
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            richTextBox1.Text = "";
            if (!string.IsNullOrEmpty(comboBox3.SelectedItem.ToString()))
            {
                string cb3 = ((ListItem)comboBox3.SelectedItem).Key;
                if (comboBox5.SelectedValue.ToString() == "2" || comboBox5.SelectedValue.ToString() == "4")
                {
                    string sqlstr = "select * from Text where ChpID=" + cb3;
                    DataSet ds = SqlHelper.Query(sqlstr);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        richTextBox1.Text = (string)ds.Tables[0].Rows[0]["Contents"];
                    }
                }
                else
                {
                    comboBox7.Items.Clear();
                    vo = new ListItem();
                    string sqlstr = "select ID,No from Manga where ChpID=" + cb3 + " Order by No";
                    vo.ComboBoxBing(comboBox7, sqlstr, "No", "ID");
                }
            }
        }
        //增加漫画图片
        private void button13_Click(object sender, EventArgs e)
        {
            hs = new Handles();
            Hashtable ht = new Hashtable();
            if (comboBox3.SelectedItem==null || string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox8.Text))
            {
                DialogResult dr = MessageBox.Show("章回、页数、图片文件是必填项.", "添加漫画图片", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dr == DialogResult.OK)//如果点击“确定”按钮
                    return;
            }
            string cb3 = ((ListItem)comboBox3.SelectedItem).Key;
            ht.Add("No", textBox5.Text);
            ht.Add("BokID", hs.GetBokID(comboBox5, comboBox1).ToString());
            ht.Add("ChpID", cb3);
            ht.Add("Img", textBox8.Text);
            hs.AddNewMag(ht);
        }
        //删除一页漫画图片
        private void button16_Click(object sender, EventArgs e)
        {
            if (comboBox7.SelectedItem==null)
            {
                DialogResult dr = MessageBox.Show("需要选择页数.", "删除该页漫画", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dr == DialogResult.OK)//如果点击“确定”按钮
                    return;
            }
            hs = new Handles();
            hs.DelMag(((ListItem)comboBox7.SelectedItem).Key);
        }
        //修改一页漫画图片或者整个章回的文本
        private void button1_Click(object sender, EventArgs e)
        {
            hs = new Handles();
            Hashtable ht = new Hashtable();

            if (comboBox5.SelectedValue.ToString() == "2" || comboBox5.SelectedValue.ToString() == "4")
            {
                if (comboBox3.SelectedItem==null || string.IsNullOrEmpty(richTextBox1.Text))
                {
                    DialogResult dr = MessageBox.Show("需要选择章回.", "修改该章回文本", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (dr == DialogResult.OK)//如果点击“确定”按钮
                        return;
                }
                ht.Add("type", "txt");
                ht.Add("ID", ((ListItem)comboBox3.SelectedItem).Key);
                ht.Add("Conts", richTextBox1.Text);
            }
            else
            {
                if (comboBox7.SelectedItem==null || string.IsNullOrEmpty(textBox8.Text))
                {
                    DialogResult dr = MessageBox.Show("需要选择页数.", "修改该页漫画", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (dr == DialogResult.OK)//如果点击“确定”按钮
                        return;
                }
                ht.Add("type", "mag");
                ht.Add("ID", ((ListItem)comboBox7.SelectedItem).Key);
                ht.Add("Conts", textBox8.Text);
            }
            hs.UpdateConts(ht);
        }


        /******************************************** 公用方法 ****************************************/
        /**
         * arg1, 类型
         * arg2, 书id
         */
        public int GetBokID(ComboBox cb1, ComboBox cb2) 
        {
            string type = ((ListItem)cb1.SelectedItem).Key;
            string bokid = ((ListItem)cb2.SelectedItem).Key;
            int id = Convert.ToInt32(SqlHelper.GetSingle("select ID from Type where Type =" + type + " and BokID =" + bokid));
            return id;
        }




       




    }
}
