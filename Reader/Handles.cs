using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;

namespace Reader
{
    class Handles
    {
        public Handles()
        { }




        /******************************************************** 左侧目录树 **************************************************/
        //得到树行结构需要的表
        public DataSet GetDataSet(string tableName)
        {
            string sql = "SELECT * FROM " + tableName + " ORDER BY No";
            return SqlHelper.Query(sql);
        }


        /******************************************************** 右侧内容部分 ************************************************/
        //在章回节点，查找内容
        public DataSet GetChp(string chp) 
        {
            string sql = "SELECT chp.id,chp.title,chp.no,typ.type FROM chapter AS chp LEFT JOIN type AS typ ON chp.BokID=typ.ID WHERE chp.ID=" + chp;
            return SqlHelper.Query(sql);
        }
        //在章回节点，查找内容
        public DataSet GetVol(string vol)
        {
            string sql = "SELECT vol.id AS volid,cov.id AS covid,cat.id AS catid,vol.title,vol.img AS img1,cov.Img AS img2,cat.img AS img3 FROM Volume AS vol LEFT JOIN Catalog AS cat ON vol.ID=cat.VolID LEFT JOIN Cover AS cov ON vol.ID=cov.VolID WHERE vol.ID=" + vol;
            return SqlHelper.Query(sql);
        }





        /******************************************************** 分册 **************************************************/
        public void InsertVolume(Hashtable ht)
        {
            string sql = null;
            SQLiteParameter[] sps = null;
            Hashtable ht2 = new Hashtable();

            sql = "INSERT INTO Volume (No, BokID, Title) VALUES (" + ht["No"] + ", " + ht["ID"] + ", '" + ht["Tit"] + "'); select last_insert_rowid()";
            int volid = Convert.ToInt32(SqlHelper.GetSingle(sql));

            sql = "UPDATE Volume SET Img=@Img";
            sps = new SQLiteParameter[] { new SQLiteParameter("@Img", this.img2EncByte(ht["Img"].ToString())) };
            ht2.Add(sql, sps);

            sql = "INSERT INTO Cover (VolID, Img) VALUES (@VolID, @Img)";
            sps = new SQLiteParameter[] {                                        
                new SQLiteParameter("@VolID",volid),
                new SQLiteParameter("@Img", this.img2EncByte(ht["Img1"].ToString())) 
            };
            ht2.Add(sql, sps);

            sql = "INSERT INTO Catalog (VolID, Img) VALUES (@VolID, @Img)";
            sps = new SQLiteParameter[] {                                        
                new SQLiteParameter("@VolID",volid),
                new SQLiteParameter("@Img", this.img2EncByte(ht["Img2"].ToString())) 
            };
            ht2.Add(sql, sps);

            SqlHelper.ExecuteSqlTran(ht2);
        }
        //ID、Title、No、Img、Img1、Img2
        //public int UpdateVolume(Hashtable ht)
        //{
        //    string sql = "Update Volume Set Title=@Tit, No=@No";
        //    byte[] encImg = null;

        //    ArrayList al = new ArrayList();
        //    al.Add(new SQLiteParameter("@Tit", ht["Tit"]));
        //    al.Add(new SQLiteParameter("@No", ht["No"]));

        //    if (!string.IsNullOrEmpty(ht["Img"].ToString()))
        //    {
        //        encImg = img2EncByte(ht["Img"].ToString());
        //        sql += ", Img=@Img";
        //        al.Add(new SQLiteParameter("@Img", encImg));
        //    }
        //    if (!string.IsNullOrEmpty(ht["Img1"].ToString()))
        //    {
        //        encImg = img2EncByte(ht["Img1"].ToString());
        //        sql += ", Img1=@Img1";
        //        al.Add(new SQLiteParameter("@Img1", encImg));
        //    }
        //    if (!string.IsNullOrEmpty(ht["Img2"].ToString()))
        //    {
        //        encImg = img2EncByte(ht["Img2"].ToString());
        //        sql += ", Img2=@Img2";
        //        al.Add(new SQLiteParameter("@Img2", encImg));
        //    }
        //    sql += " Where ID=@ID";
        //    al.Add(new SQLiteParameter("@ID", ht["ID"]));

        //    SQLiteParameter[] sp = (SQLiteParameter[])al.ToArray(typeof(SQLiteParameter));
        //    return SqlHelper.ExecuteSql(sql, sp);
        //}

        //ID、Title、No、Img、Img1、Img2
        public void UpdateVolume(Hashtable ht)
        {
            string sql = null;
            SQLiteParameter[] sps = null;
            Hashtable ht2 = new Hashtable();

            sql = "Update Volume Set Title=@Tit, No=@No";
            ArrayList al = new ArrayList();
            al.Add(new SQLiteParameter("@Tit", ht["Tit"]));
            al.Add(new SQLiteParameter("@No", ht["No"]));

            if (!string.IsNullOrEmpty(ht["Img"].ToString()))
            {
                sql += ", Img=@Img";
                al.Add(new SQLiteParameter("@Img", img2EncByte(ht["Img"].ToString())));
            }
            sql += " Where ID=@ID";
            al.Add(new SQLiteParameter("@ID", ht["ID"]));

            sps = (SQLiteParameter[])al.ToArray(typeof(SQLiteParameter));
            ht2.Add(sql, sps);

            if (!string.IsNullOrEmpty(ht["Img1"].ToString()))
            {
                sql = "UPDATE Cover SET Img = @Img WHERE VolID = @VolID";
                sps = new SQLiteParameter[] {                                        
                    new SQLiteParameter("@VolID",ht["ID"]),
                    new SQLiteParameter("@Img", this.img2EncByte(ht["Img1"].ToString())) 
                };
                ht2.Add(sql, sps);
            }
            if (!string.IsNullOrEmpty(ht["Img2"].ToString()))
            {
                sql = "UPDATE Catalog SET Img = @Img WHERE VolID = @VolID";
                sps = new SQLiteParameter[] {                                        
                    new SQLiteParameter("@VolID",ht["ID"]),
                    new SQLiteParameter("@Img", this.img2EncByte(ht["Img2"].ToString())) 
                };
                ht2.Add(sql, sps);
            }

            SqlHelper.ExecuteSqlTran(ht2);

        }
        //删除分册
        public void DelVolume(string vol, string type) 
        {
            string sql = null;
            ArrayList ht = new ArrayList();
            if (type == "2" || type == "4")
            {
                sql = "DELETE FROM Text WHERE ChpID IN (SELECT ID FROM Chapter WHERE VolID=" + vol + ")";
                ht.Add(sql);
            }
            else
            {
                sql = "DELETE FROM Manga WHERE ChpID IN (SELECT ID FROM Chapter WHERE VolID=" + vol + ")";
                ht.Add(sql);
            }
            sql = "DELETE FROM Chapter WHERE VolID=" + vol;
            ht.Add(sql);
            sql = "DELETE FROM Catalog WHERE VolID=" + vol;
            ht.Add(sql);
            sql = "DELETE FROM Cover WHERE VolID=" + vol;
            ht.Add(sql);
            sql = "DELETE FROM Volume WHERE ID=" + vol;
            ht.Add(sql);
            SqlHelper.ExecuteSqlTran(ht);
        }
        //删除分册----只根据VolID
        public void DelVolume(string vol)
        {
            string sql = null;
            ArrayList ht = new ArrayList();
            string type = SqlHelper.GetSingle("SELECT type FROM type WHERE id = (SELECT bokid FROM Volume WHERE id = " + vol + ")").ToString();
            
            if (type == "2" || type == "4")
            {
                sql = "DELETE FROM Text WHERE ChpID IN (SELECT ID FROM Chapter WHERE VolID=" + vol + ")";
                ht.Add(sql);
            }
            else
            {
                sql = "DELETE FROM Manga WHERE ChpID IN (SELECT ID FROM Chapter WHERE VolID=" + vol + ")";
                ht.Add(sql);
            }
            sql = "DELETE FROM Chapter WHERE VolID=" + vol;
            ht.Add(sql);
            sql = "DELETE FROM Catalog WHERE VolID=" + vol;
            ht.Add(sql);
            sql = "DELETE FROM Cover WHERE VolID=" + vol;
            ht.Add(sql);
            sql = "DELETE FROM Volume WHERE ID=" + vol;
            ht.Add(sql);
            SqlHelper.ExecuteSqlTran(ht);
        }




        /******************************************************** 章节 **************************************************/
        //ID、Title、No
        public int UpdateChapter(Hashtable ht)
        {
            string sql = "Update Chapter Set Title='" + ht["Tit"] + "', No=" + ht["No"] + " Where ID=" + ht["ID"];
            return SqlHelper.ExecuteSql(sql);
        }
        //批量插图片
        public void InsertImgBat(Hashtable ht)
        {
            string bokid = SqlHelper.GetSingle("SELECT BokID FROM Volume WHERE id = " + ht["Vol"]).ToString();
            //string sql = "INSERT INTO Chapter(No, BokID, VolID, Title) VALUES (" + ht["No"] + ", " + ht["Bok"] + ", " + ht["Vol"] + ", '" + ht["Tit"] + "'); select last_insert_rowid()";
            string sql = "INSERT INTO Chapter(No, BokID, VolID, Title) VALUES (" + ht["No"] + ", " + bokid + ", " + ht["Vol"] + ", '" + ht["Tit"] + "'); select last_insert_rowid()";
            int chpid = Convert.ToInt32(SqlHelper.GetSingle(sql));
            ImageCollection ic = new ImageCollection();
            ic.Location = ht["Path"].ToString();

            ArrayList sqlist = new ArrayList();
            string ins = "INSERT INTO Manga (No, BokID, ChpID, Contents) VALUES (@No, @BokID, @ChpID, @Contents)";
            for (int i = 0; i < ic.Images.Count; i++)
            {
                byte[] encImg = img2EncByte(ic.Images[i]);
                SQLiteParameter[] parameters = new SQLiteParameter[]{
                    new SQLiteParameter("@No",i+1),                                          
                    new SQLiteParameter("@BokID",bokid),                                         
                    new SQLiteParameter("@ChpID",chpid),
                    new SQLiteParameter("@Contents",encImg)
                };
                sqlist.Add(parameters);
            }
            SqlHelper.ExecuteSqlTran(ins, sqlist);
        }
        //插入该章回文本
        public int InsertTxt(Hashtable ht) 
        {
            string txt = ReadFileString(ht["Path"].ToString());
            string sql = "";
            string bokid = SqlHelper.GetSingle("SELECT BokID FROM Volume WHERE id = " + ht["Vol"]).ToString();

            //sql = "INSERT INTO Chapter(No, BokID, VolID, Title) VALUES (" + ht["No"] + ", " + ht["Bok"] + ", " + ht["Vol"] + ", '" + ht["Tit"] + "'); select last_insert_rowid()";
            sql = "INSERT INTO Chapter(No, BokID, VolID, Title) VALUES (" + ht["No"] + ", " + bokid + ", " + ht["Vol"] + ", '" + ht["Tit"] + "'); select last_insert_rowid()";
            int chpid = Convert.ToInt32(SqlHelper.GetSingle(sql));

            sql = "INSERT INTO Text (No, BokID, ChpID, Contents) VALUES (@No, @BokID, @ChpID, @Contents)";
            SQLiteParameter[] parameters = new SQLiteParameter[]{
                new SQLiteParameter("@No",ht["No"]),                                          
                new SQLiteParameter("@BokID",bokid),                                         
                new SQLiteParameter("@ChpID",chpid),
                new SQLiteParameter("@Contents",txt)
            };
            return SqlHelper.ExecuteSql(sql, parameters);
        }
        //删除选择的章回及其下面的文本、图片
        public void DelChp(string chp, string type) 
        {
            string sql = null;
            Hashtable ht = new Hashtable();
            if (type == "2" || type == "4")
            {
                sql = "DELETE FROM Text WHERE ChpID = @chp";
                ht.Add(sql, new SQLiteParameter[]{ new SQLiteParameter("@chp", chp)});
            }
            else
            {
                sql = "DELETE FROM Manga WHERE ChpID = @chp";
                ht.Add(sql, new SQLiteParameter[] { new SQLiteParameter("@chp", chp) });
            }
            sql = "DELETE FROM Chapter WHERE ID=@chp";
            ht.Add(sql, new SQLiteParameter[] { new SQLiteParameter("@chp", chp) });
            SqlHelper.ExecuteSqlTran(ht);
        }
        //删除选择的章回及其下面的文本、图片----只根据ChpID
        public void DelChp(string chp)
        {
            string sql = null;
            Hashtable ht = new Hashtable();
            string type = SqlHelper.GetSingle("SELECT type FROM type WHERE id = (SELECT bokid FROM chapter WHERE id = " + chp + ")").ToString();

            if (type == "2" || type == "4")
            {
                sql = "DELETE FROM Text WHERE ChpID = @chp";
                ht.Add(sql, new SQLiteParameter[] { new SQLiteParameter("@chp", chp) });
            }
            else
            {
                sql = "DELETE FROM Manga WHERE ChpID = @chp";
                ht.Add(sql, new SQLiteParameter[] { new SQLiteParameter("@chp", chp) });
            }
            sql = "DELETE FROM Chapter WHERE ID=@chp";
            ht.Add(sql, new SQLiteParameter[] { new SQLiteParameter("@chp", chp) });
            SqlHelper.ExecuteSqlTran(ht);
        }







        /******************************************************** 内容 **************************************************/
        //增加漫画图片
        public int AddNewMag(Hashtable ht) 
        {
            string bokid = SqlHelper.GetSingle("select BokID from Chapter where ID =" + ht["ChpID"]).ToString();
            byte[] encImg = null;
            string sql = "Insert into Manga (No, BokID, ChpID, Contents) Values (" + ht["No"] + ", " + bokid + ", " + ht["ChpID"] + ", @fs)";

            encImg = img2EncByte(ht["Img"].ToString());

            return SqlHelper.ExecuteSqlInsertImg(sql, encImg);
        }
        //删除一页漫画图片
        public void DelMag(string id)
        {
            string sql = "DELETE FROM Manga WHERE ID=" + id;
            SqlHelper.ExecuteSql(sql);
        }
        //
        public void UpdateConts(Hashtable ht)
        {
            string sql = null;
            if(ht["type"].ToString()=="txt")
            {
                sql = "Update Text Set Contents=@conts Where ChpID=@id";
                SQLiteParameter[] sp = new SQLiteParameter[]{
                    new SQLiteParameter("@conts", ht["Conts"]),  
                    new SQLiteParameter("@id", ht["ID"]) 
                };
                SqlHelper.ExecuteSql(sql, sp);
            }
            else if (ht["type"].ToString() == "mag")
            {
                ArrayList al = new ArrayList();
                SQLiteParameter[] sps = null;

                sql = "Update Manga Set No=@No";
                al.Add(new SQLiteParameter("@No", ht["No"]));

                if (!string.IsNullOrEmpty(ht["Conts"].ToString()))
                {
                    sql += ", Contents=@conts";
                    al.Add(new SQLiteParameter("@conts", img2EncByte(ht["Conts"].ToString())));
                }
                sql += " Where ID=@ID";
                al.Add(new SQLiteParameter("@ID", ht["ID"]));

                sps = (SQLiteParameter[])al.ToArray(typeof(SQLiteParameter));
                SqlHelper.ExecuteSql(sql, sps);
            }
            
        }
        
        
        
        
        
        
        /******************************************************** 公用方法 **************************************************/
        //得到Type表ID
        public int GetBokID(ComboBox cb1, ComboBox cb2)
        {
            string type = ((ListItem)cb1.SelectedItem).Key;
            string bokid = ((ListItem)cb2.SelectedItem).Key;
            int id = Convert.ToInt32(SqlHelper.GetSingle("select ID from Type where Type =" + type + " and BokID =" + bokid));
            return id;
        }
        //通过图片路径得到加密的字节流
        public byte[] img2EncByte(string imgPath)
        {
            byte[] img2b = Transform.getImageByte(imgPath);
            byte[] strEnc = Encrypt.EncryptByte(img2b, "Za@$100%", "395^abC~");
            return strEnc;
        }
        //读文件转字节流
        public byte[] ReadFileByte(string filePath)
        {
            FileStream file = new FileStream(filePath, FileMode.Open);
            byte[] infoByte = new byte[file.Length];
            file.Read(infoByte, 0, infoByte.Length);
            return infoByte;
        }
        //读文件转字符串
        public string ReadFileString(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open);
            byte[] txtByte = new byte[fs.Length];
            fs.Read(txtByte, 0, txtByte.Length);
            fs.Close();
            string infoByte = System.Text.Encoding.Default.GetString(txtByte);

            return infoByte;
        }
        //根据Where得到Table数据
        public DataSet GetTableByWhere(string table, string where)
        {
            string sql = "SELECT * FROM " + table + " WHERE " + where + " ORDER BY No";
            return SqlHelper.Query(sql);
        }
        //根据条件得到Table数据
        public DataSet GetTableByWhereTerm(string term, string table, string where)
        {
            string sql = "SELECT " + term + " FROM " + table + " WHERE " + where + " ORDER BY No";
            return SqlHelper.Query(sql);
        }
        //根据ID得到type
        public string GetTypeByID(string table, string id)
        {
            string sql = "SELECT type FROM type WHERE id = (SELECT bokid FROM " + table + " WHERE id = " + id + ")";
            return SqlHelper.GetSingle(sql).ToString();
        }
    }
}
