using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Data.SQLite;

namespace Reader
{
    public partial class Form1 : Form
    {

        DBHelper eDs = new DBHelper();
        FileStream files = null;

        public Form1()
        {
            InitializeComponent();
            //label1.Text = eDs.slt(eDs._init("pt","jw123"),"select * from test");
            SQLiteDataReader sdr = SqlHelper.ExecuteReader("select * from Manga");
            string str = "";
            while(sdr.Read())
            {
                 str += sdr[1].ToString();
            }
            label1.Text = str;//eDs.slt(eDs._init("pt", "jw123"), "select * from sqlite_master WHERE type = 'table'");
        }



        /// <summary>
        /// toImg
        /// textBox1填写字节流的字符串
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //byte[] img2b = Convert.FromBase64String(textBox1.Text);
            //pictureBox1.Image = BytToImg(img2b);
            files = new FileStream("c.txt", FileMode.Open);
            byte[] imgByte = new byte[files.Length];
            files.Read(imgByte, 0, imgByte.Length);
            pictureBox1.Image = Transform.BytToImg(imgByte);
        }

        /// <summary>
        /// toByte
        /// textBox1填写图片的路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            byte[] img2b = Transform.getImageByte(textBox1.Text);
            string strByte = Convert.ToBase64String(img2b);
            MessageBox.Show(strByte);
            files = new FileStream("a.txt", FileMode.Create);
            //byte[] txtByte = new byte[files.Length];
            files.Write(img2b, 0, img2b.Length);
            files.Close();
        }

        /// <summary>
        /// 字节流加密
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            //string strEnc = Encrypt(textBox1.Text, "12345678", "09876543");
            //MessageBox.Show(strEnc);
            files = new FileStream("a.txt", FileMode.Open);
            byte[] txtByte = new byte[files.Length];
            files.Read(txtByte, 0, txtByte.Length);
            files.Close();
            FileStream files2 = new FileStream("b.txt", FileMode.Create);
            byte[] strEnc = Encrypt.EncryptByte(txtByte, "Za@$100%", "395^abC~");
            //byte[] strEnc = Encrypt.EncryptByte(txtByte, "12345678", "09876543");
            files2.Write(strEnc, 0, strEnc.Length);
            files2.Close();
        }

        /// <summary>
        /// 字节流解密
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            files = new FileStream("b.txt", FileMode.Open);
            byte[] txtByte = new byte[files.Length];
            files.Read(txtByte, 0, txtByte.Length);
            files.Close();
            FileStream files2 = new FileStream("c.txt", FileMode.Create);
            byte[] strEnc = Encrypt.DecryptByte(txtByte, "Za@$100%", "395^abC~");
            files2.Write(strEnc, 0, strEnc.Length);
            files2.Close();
        }


        ///////////////数据库部分///////////////


        /// <summary>
        /// 创建新数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string pwd = textBox1.Text;
            //eDs.aNewJMDB(pwd);
            eDs.CreateJMDB(pwd, "jw123");
        }

        /// <summary>
        /// 设置/更改数据库密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            string pwd = textBox1.Text;
            eDs.Xpwd(eDs._init("pt"), pwd);
            //eDs.slt(eDs._init("pt.db"), "create");
        }

        public static void InsertData(int a, string b, byte[] c, byte[] d, byte[] e)
        {
            //string sql = "INSERT INTO Content(ID,Title,Contents) values(@ID, @Title, @Contents)";  
            //string sql = "INSERT INTO \"Content\" (\"ID\", \"Title\", \"Contents\") VALUES (@ID, @Title, @Contents)";
            //string sql = "INSERT INTO Manga (BokID, ChpID, Title, Contents) VALUES (@BokID, @ChpID, @Title, @Contents)";
            string sql = "INSERT INTO Section (No, BokID, Title, Img, Img1, Img2) VALUES (@No, @BokID, @Title, @Img, @Img1, @Img2)";
            //SqlHelper db = new SqlHelper();
            //db._init("ShenJie");
            SQLiteParameter[] parameters = new SQLiteParameter[]{
                new SQLiteParameter("@No",a),                                          
                new SQLiteParameter("@BokID",a),                                         
                new SQLiteParameter("@ChpID",a),                                         
                new SQLiteParameter("@Title",b),                                          
                //new SQLiteParameter("@Contents",c)                                        
                new SQLiteParameter("@Img",c),                                        
                new SQLiteParameter("@Img1",d),                                        
                new SQLiteParameter("@Img2",e)
            };
            SqlHelper.ExecuteSql(sql, parameters);
        }

        /// <summary>
        /// 往sqlite插入加密后的图片字节流
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            files = new FileStream("b.txt", FileMode.Open);
            byte[] txtByte = new byte[files.Length];
            files.Read(txtByte, 0, txtByte.Length);
            files.Close();
            files = new FileStream("d.txt", FileMode.Open);
            byte[] txtByte1 = new byte[files.Length];
            files.Read(txtByte1, 0, txtByte1.Length);
            files.Close();
            files = new FileStream("e.txt", FileMode.Open);
            byte[] txtByte2 = new byte[files.Length];
            files.Read(txtByte2, 0, txtByte2.Length);
            files.Close();
            InsertData(11, "abc", txtByte, txtByte1, txtByte2);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //UnsafeNativeMethods.
            MessageBox.Show(Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(textBox1.Text)));
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SQLiteDataReader sdr = SqlHelper.ExecuteReader("select * from Volume where ID=1");
            byte[] txtByte = null;
            while (sdr.Read())
            {
                txtByte = (byte[])sdr["Img2"];
            }
            byte[] de = Encrypt.DecryptByte(txtByte, "Za@$100%", "395^abC~");
            //byte[] de = Encrypt.DecryptByte(txtByte, "12345678", "09876543");
            pictureBox1.Image = Transform.BytToImg(de);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            byte[] img2b = Transform.getImageByte(textBox1.Text);
            byte[] strEnc = Encrypt.EncryptByte(img2b, "Za@$100%", "395^abC~");
            //byte[] strEnc = Encrypt.EncryptByte(img2b, "12345678", "09876543");
            string sql = "INSERT INTO Manga (No, BokID, ChpID, Contents) VALUES (@No, @BokID, @ChpID, @Contents)";
            //SqlHelper db = new SqlHelper();
            //db._init("ShenJie");
            SQLiteParameter[] parameters = new SQLiteParameter[]{
                new SQLiteParameter("@No",1),                                          
                new SQLiteParameter("@BokID",3),                                         
                new SQLiteParameter("@ChpID",1),                                          
                new SQLiteParameter("@Contents",strEnc)
            };
            SqlHelper.ExecuteSql(sql, parameters);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            files = new FileStream("b.txt", FileMode.Open);
            byte[] txtByte = new byte[files.Length];
            files.Read(txtByte, 0, txtByte.Length);
            files.Close();

            string sql = "INSERT INTO Manga (No, BokID, ChpID, Contents) VALUES (@No, @BokID, @ChpID, @Contents)";
            //SqlHelper db = new SqlHelper();
            //db._init("ShenJie");
            SQLiteParameter[] parameters = new SQLiteParameter[]{
                new SQLiteParameter("@No",1),                                          
                new SQLiteParameter("@BokID",3),                                         
                new SQLiteParameter("@ChpID",1),                                          
                new SQLiteParameter("@Contents",txtByte)
            };
            SqlHelper.ExecuteSql(sql, parameters);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SQLiteDataReader sdr = SqlHelper.ExecuteReader("select * from Volume where ID=1");
            byte[] txtByte = null;
            while (sdr.Read())
            {
                txtByte = (byte[])sdr["Img2"];
            }
            files = new FileStream("x.txt", FileMode.Create);
            //byte[] txtByte = new byte[files.Length];
            files.Write(txtByte, 0, txtByte.Length);
            files.Close();
        }

        

    }
}
