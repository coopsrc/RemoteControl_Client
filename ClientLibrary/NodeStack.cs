using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientLibrary
{
    static class NodeStack
    {
        public static Stack<TreeNode> nodeStack = new Stack<TreeNode>();
        public static TreeNode lastNode = new TreeNode();
        public static TreeNode curNode = new TreeNode();
    }
}
