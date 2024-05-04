using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClasessForWorkWithData;
using static System.Collections.Specialized.BitVector32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        // Оновити дерево
        public static void UpdateTreeView(BookLibrary library, ref System.Windows.Forms.TreeView treeView)
        {
            AddCatalogsToTreeView(library, ref treeView);
            AddBookToSectionInTreeView(library, ref treeView);
        }

        // Відобразити історію оренди в DataGridView
        public static void AddInfoInDataGridView(BookLibrary library, ref DataGridView dg)
        {
            foreach (var item in library)
            {
                if (item is Book book)
                {
                    if (book.Rent_history != null && book.Rent_history.Count > 0)
                    {
                        // Якщо історія оренди не є порожньою, додати записи історії оренди книги в DataGridView
                        foreach (var rentRecord in book.Rent_history)
                        {
                            // Створити новий рядок для DataGridView
                            DataGridViewRow row = new DataGridViewRow();

                            // Створити ячейку для ідентифікатора та встановити її значення з історії оренди
                            DataGridViewCell idCell = new DataGridViewTextBoxCell();
                            idCell.Value = rentRecord.Id;
                            row.Cells.Add(idCell);

                            // Створити ячейку для повного імені клієнта та встановити її значення з історії оренди
                            DataGridViewCell full_client_nameCell = new DataGridViewTextBoxCell();
                            full_client_nameCell.Value = rentRecord.Reader_full_name;
                            row.Cells.Add(full_client_nameCell);

                            // Створити ячейку для номеру клієнта та встановити її значення з історії оренди
                            DataGridViewCell client_numberCell = new DataGridViewTextBoxCell();
                            client_numberCell.Value = rentRecord.Reader_phone_number;
                            row.Cells.Add(client_numberCell);

                            // Створити ячейку для періоду оренди та встановити її значення з історії оренди
                            DataGridViewCell rent_periodCell = new DataGridViewTextBoxCell();
                            rent_periodCell.Value = rentRecord.Rent_period;
                            row.Cells.Add(rent_periodCell);

                            // Додати рядок у DataGridView
                            dg.Rows.Add(row);
                        }
                    }
                    else
                    {
                        // Якщо історія оренди відсутня, додати порожній рядок або іншу інформацію
                        DataGridViewRow row = new DataGridViewRow();
                        DataGridViewCell emptyCell = new DataGridViewTextBoxCell();
                        emptyCell.Value = "Історія оренди відсутня";
                        row.Cells.Add(emptyCell);
                        dg.Rows.Add(row);
                    }
                }
            }
        }
    }

}