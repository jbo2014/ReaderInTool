using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.Common;
using System.Data.SQLite;

namespace Reader
{
    class DBHelper
    {
        private string connectString = string.Empty; 

        public DBHelper()
        {

        }

        public SQLiteConnection _init(string db, string pwd=null) 
        {
            connectString = @"Data Source=D:\Projects\DotNet\Reader\DB\"+db+".db;Pooling=true;FailIfMissing=false";       
            /*D:\sqlite.db就是sqlite数据库所在的目录,它的名字你可以随便改的*/

            SQLiteConnection conn = new SQLiteConnection(connectString); //新建一个连接
            if(!string.IsNullOrEmpty(pwd))
            {
                conn.SetPassword(pwd);
            }
            conn.Open();  //打开连接,如果sqlite.db存在就正常打开,如果不存在则创建一个SQLite.db文件
            return conn;
        }

        /// <summary>
        /// 创建一个密码为pwd的sqlite数据库
        /// </summary>
        /// <param name="db">新建数据库名</param>
        /// <param name="pwd">新建数据库密码</param>
        public void CreateJMDB(string db, string pwd)
        {
            SQLiteConnection.CreateFile(@"D:\Projects\DotNet\Reader\DB\" + db + ".db");
            SQLiteConnection cnn = new SQLiteConnection(@"Data Source=D:\Projects\DotNet\Reader\DB\" + db + ".db");

            cnn.Open();
            cnn.ChangePassword(pwd);
        }

        /// <summary>
        /// 创建一个无密码的sqlite数据库
        /// </summary>
        /// <param name="db">新建数据库的名字</param>
        public void CreateDB(string db)
        {
            SQLiteConnection.CreateFile(@"D:\Projects\DotNet\Reader\DB\"+db+".db");
            SQLiteConnection cnn = new SQLiteConnection(@"Data Source=D:\Projects\DotNet\Reader\DB\pt.db");

            cnn.Open();
        }

        /// <summary>
        /// 设置/改变密码
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="pwd"></param>
        public void Xpwd(SQLiteConnection conn, string pwd) 
        {
            conn.ChangePassword(pwd);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="sltStr"></param>
        /// <returns></returns>
        public string slt(SQLiteConnection conn, string sltStr) 
        {
            SQLiteCommand cmd = conn.CreateCommand();

            cmd.CommandText = sltStr;   //数据库中要事先有个orders表

            cmd.CommandType = CommandType.Text;

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                string a = "";
                while (reader.Read())
                {
                    a += reader[1].ToString() + "+" + reader[2].ToString() + "+" + reader[4].ToString()+"     ";
                }
                return a;
            }
        }

        /// <summary>      
        /// 对SQLite数据库执行增删改操作，返回受影响的行数。---执行一条记录的操作              
        /// </summary>      
        /// <param name="sql">要执行的增删改的SQL语句</param>      
        /// <param name="parameters">执行增删改语句所需要的参数，参数必须以它们在SQL语句中的顺序为准</param>      
        /// <returns></returns>      
        public int ExecuteNonQuery(string sql, IList<SQLiteParameter> parameters)
        {
            int affectedRows = 0;
            using (SQLiteConnection connection = new SQLiteConnection(connectString))
            {
                connection.Open();
                using (DbTransaction transaction = connection.BeginTransaction())
                {
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = sql;
                        if (!(parameters == null || parameters.Count == 0))
                        {
                            foreach (SQLiteParameter parameter in parameters)
                            {
                                command.Parameters.Add(parameter);
                            }
                        }
                        affectedRows = command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
            }
            return affectedRows;
        }

        /// <summary>      
        /// 对SQLite数据库执行增删改操作，返回受影响的行数。---执行多条记录的操作              
        /// </summary>      
        /// <param name="sql">要执行的增删改的SQL语句</param>      
        /// <param name="parameters">执行增删改语句所需要的参数，参数必须以它们在SQL语句中的顺序为准</param>      
        /// <returns></returns>      
        public int ExecuteNonQueryRows(string sql, IList<SQLiteParameter> parameters)
        {
            int affectedRows = 0;
            using (SQLiteConnection connection = new SQLiteConnection(connectString))
            {
                connection.Open();
                using (DbTransaction transaction = connection.BeginTransaction())
                {
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = sql;
                        if (!(parameters == null || parameters.Count == 0))
                        {
                            foreach (SQLiteParameter parameter in parameters)
                            {
                                command.Parameters.Add(parameter);
                            }
                        }
                        affectedRows = command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
            }
            return affectedRows;
        }   

    }
}
