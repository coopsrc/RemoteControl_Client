using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    /// <summary>
    /// 继承于ListView类，修改DoubleBuffered属性获得双缓冲区防止界面闪烁
    /// </summary>
    class ListViewDoubleBuffered : ListView
    {
        //protected override bool DoubleBuffered
        //{
        //    get { return base.DoubleBuffered; }
        //    set { base.DoubleBuffered = value; }
        //}
        public ListViewDoubleBuffered()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }
    }
}
