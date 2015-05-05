using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;
using System.Windows.Forms;
using System.ComponentModel;

namespace Reader
{
    public static class Helper
    {
        /// <summary>
        /// 移除控件某个事件
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="eventName">需要移除的控件名称eg:EventClick</param>
        public static void RemoveControlEvent(this Control control, string eventName)
        {
            FieldInfo _fl = typeof(Control).GetField(eventName, BindingFlags.Static | BindingFlags.NonPublic);
            if (_fl != null)
            {
                object _obj = _fl.GetValue(control);
                PropertyInfo _pi = control.GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
                EventHandlerList _eventlist = (EventHandlerList)_pi.GetValue(control, null);
                if (_obj != null && _eventlist != null)
                    _eventlist.RemoveHandler(_obj, _eventlist[_obj]);
            }
        }
    }
}
