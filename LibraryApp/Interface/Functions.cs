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

        // Відобразити одну книгу у дереві
        public static void AddBookToSectionInTreeView(Book book, BookLibrary library, ref System.Windows.Forms.TreeView treeView)
        {
            CatalogSection section;

            // Властивість IdRelatedSections зберігається набір індексів секцій, до яких прив'язана книга
            for (int i = 0; i < book.IdRelatedSections.Count; i++)
            {
                // Створити вузол з назвою книги
                TreeNode BookNode = new TreeNode(book.Title);

                // Присвоїти id вузлу книги таким як id книги
                BookNode.Tag = book.Book_ID;

                // Пошук об'єкта "секція каталогу" за id
                section = library.FindCatalogSection(book.IdRelatedSections[i]);

                // Пошук розділа у TreeView за індексом
                TreeNode sectionNode = FindTreeNodeByTag(treeView.Nodes, section.Catalog_ID);

                // Запис книги у необхідну секцію
                sectionNode.Nodes.Add(BookNode);

            }
        }

        // Відобразити всі книги у дереві
        public static void AddBookToSectionInTreeView(BookLibrary library, ref System.Windows.Forms.TreeView treeView)
        {
            CatalogSection section = new CatalogSection();

            foreach (var item in library)
            {
                if (item is Book book)
                {
                    // Властивість IdRelatedSections зберігається набір індексів секцій, до яких прив'язана книга
                    for (int i = 0; i < book.IdRelatedSections.Count; i++)
                    {
                        // Створити вузол з назвою книги
                        TreeNode BookNode = new TreeNode(book.Title);

                        // Присвоїти id вузлу книги таким як id книги
                        BookNode.Tag = book.Book_ID;

                        // Пошук об'єкта "секція каталогу"
                        section = library.FindCatalogSection(book.IdRelatedSections[i]);

                        // Пошук секції каталогу у елементі TreeView за її індексом
                        TreeNode sectionNode = FindTreeNodeByTag(treeView.Nodes, section.Catalog_ID);

                        // Запис книги у необхідну секцію
                        sectionNode.Nodes.Add(BookNode);
                    }
                }
            }
        }



        // Знайти вузол каталогу за його id
        public static TreeNode FindTreeNodeByTag(TreeNodeCollection nodes, int tag)
        {
            foreach (TreeNode node in nodes)
            {
                if ((int)node.Tag == tag)
                {
                    return node;
                }
            }
            return null;
        }

        public static void UpdateTreeView(BookLibrary library, ref System.Windows.Forms.TreeView treeView)
        {
            AddCatalogsToTreeView(library, ref treeView);
            AddBookToSectionInTreeView(library, ref treeView);
        }
    }

}
