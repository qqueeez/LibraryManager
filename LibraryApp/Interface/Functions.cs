using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClasessForWorkWithData;

namespace Interface
{
    public static class Functions
    {
        // Відобразити секції каталогу у дереві
        public static void AddCatalogsToTreeView(BookLibrary bookLibrary, ref System.Windows.Forms.TreeView treeView)
        {
            treeView.Nodes.Clear();

            foreach (var item in bookLibrary)
            {
                if (item is CatalogSection catalogSection)
                {
                    // Створити вузол з назвою каталогу
                    TreeNode sectionNode = new TreeNode(catalogSection.CatalogTitle);

                    // Присвоїти id вузлу таким як id секції
                    sectionNode.Tag = catalogSection.Catalog_ID;

                    // додати основний вузол у елемент TreeView
                    treeView.Nodes.Add(sectionNode);
                }
            }
        }
    }
}
