using System.Collections.Generic;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace  Stock.GUI.Helpers
{
    public static class TreeHelper
    {
        public static List<T> GetVisibleNodesData<T>(TreeList tree)
        {
            var list = new List<T>();

            foreach (TreeListNode node in tree.Nodes)
            {
                if (node.Visible)
                {
                    list.Add((T)tree.GetDataRecordByNode(node));
                }
            }

            return list;
        }
    }
}
