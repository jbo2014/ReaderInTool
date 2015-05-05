using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;

namespace Reader
{
    class ListItem
    {
        public ListItem()
        {}
        public ListItem(string strKey, string strValue)
        {
            this.Key = strKey;
            this.Value = strValue;
        }

        public string Key { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return this.Value;
        }
        /// <summary>
        /// 根据ListItem中的Value找到特定的ListItem(仅在ComboBox的Item都为ListItem时有效)
        /// </summary>
        /// <param name="cmb">要查找的ComboBox</param>
        /// <param name="strValue">要查找ListItem的Value</param>
        /// <returns>返回传入的ComboBox中符合条件的第一个ListItem，如果没有找到则返回null.</returns>
        public static ListItem FindByValue(ComboBox cmb, string strValue)
        {
            foreach (ListItem li in cmb.Items)
            {
                if (li.Value == strValue)
                {
                    return li;
                }
            }
            return null;
        }
        /// <summary>
        /// 根据ListItem中的Key找到特定的ListItem(仅在ComboBox的Item都为ListItem时有效)
        /// </summary>
        /// <param name="cmb">要查找的ComboBox</param>
        /// <param name="strValue">要查找ListItem的Key</param>
        /// <returns>返回传入的ComboBox中符合条件的第一个ListItem，如果没有找到则返回null.</returns>
        public static ListItem FindByText(ComboBox cmb, string strText)
        {
            foreach (ListItem li in cmb.Items)
            {
                if (li.Value == strText)
                {
                    return li;
                }
            }
            return null;
        }

        /**  
         * cb 绑定的Combobox
         * sqlstr 查询sql
         * t 显示内容
         * v 实际值
         */
        public void ComboBoxBing(ComboBox cb, string sqlstr, string tit, string id)
        {
            //DataSet ds = SqlHelper.Query(sqlstr);
            ////cb.Items.Clear();
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    // 填充数据到DataSet
            //    cb.DataSource = ds.Tables[0];
            //    ///////  给combobox绑定数据源
            //    cb.DisplayMember = t;   /// 字段的名称。
            //    cb.ValueMember = v;
            //}

            SQLiteDataReader sdr = SqlHelper.ExecuteReader(sqlstr);
            ListItem item = null;
            cb.Items.Clear();
            if(sdr.HasRows)
            {
                while(sdr.Read())
                {
                    item = new ListItem();
                    item.Key = sdr[id].ToString();
                    item.Value = sdr[tit].ToString();
                    cb.Items.Add(item);
                }
            }else
            {
                item = new ListItem();
                item.Key = "";
                item.Value = "";
                cb.Items.Add(item);
            }
        }
    }
}


        