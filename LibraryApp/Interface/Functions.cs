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
        public static void AddInfoInDataGridView(BookLibrary library, ref DataGridView dg, int selectedBookId)
        {
            // Додаємо стовпці до DataGridView
            dg.Columns.Add("id", "Номер запису");
            dg.Columns.Add("full_client_name", "Клієнт");
            dg.Columns.Add("client_number", "Номер телефону");
            dg.Columns.Add("startDate_period", "Дата початку оренди");
            dg.Columns.Add("endDate_period", "Дата закінчення оренди");

            // Проходимося по кожному елементу у бібліотеці книг
            foreach (var item in library)
            {
                // Перевіряємо, чи елемент є книгою та чи у неї є історія оренди, а також потрібно показати історію оренди тільки вибраної книги
                if (item is Book book && book.Book_ID == selectedBookId && book.Rent_history != null && book.Rent_history.Count > 0)
                {
                    // Проходимося по кожному запису історії оренди книги
                    foreach (var rentRecord in book.Rent_history)
                    {
                        // Створюємо новий рядок для DataGridView
                        DataGridViewRow row = new DataGridViewRow();

                        // Створюємо ячейку для номеру запису та встановлюємо її значення з історії оренди
                        DataGridViewCell idCell = new DataGridViewTextBoxCell();
                        idCell.Value = rentRecord.Record_id;
                        row.Cells.Add(idCell);

                        // Створюємо ячейку для повного імені клієнта та встановлюємо її значення з історії оренди
                        DataGridViewCell full_client_nameCell = new DataGridViewTextBoxCell();
                        Reader reader = library.FindReader(rentRecord.User_id);
                        full_client_nameCell.Value = reader.Full_name;
                        row.Cells.Add(full_client_nameCell);

                        // Створюємо ячейку для номеру телефону клієнта та встановлюємо її значення з історії оренди
                        DataGridViewCell client_numberCell = new DataGridViewTextBoxCell();
                        client_numberCell.Value = reader.PhoneNumber;
                        row.Cells.Add(client_numberCell);

                        // Створюємо ячейку для дати початку оренди та встановлюємо її значення з історії оренди
                        DataGridViewCell rent_startDateCell = new DataGridViewTextBoxCell();
                        rent_startDateCell.Value = rentRecord.startDate;
                        row.Cells.Add(rent_startDateCell);

                        // Створюємо ячейку для дати кінця оренди та встановлюємо її значення з історії оренди
                        DataGridViewCell rent_endDateCell = new DataGridViewTextBoxCell();
                        rent_endDateCell.Value = rentRecord.endDate;
                        row.Cells.Add(rent_endDateCell);

                        // Додаємо рядок у DataGridView
                        dg.Rows.Add(row);
                    }
                }
            }

            foreach (DataGridViewColumn column in dg.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        public static DataGridView DisplayInfoAboutReadersInDataGrid(List<Reader> users, BookLibrary library, DataGridView dg)
        {
            // Очищуємо всі стовпці перед додаванням нових
            dg.Columns.Clear();

            // Додаємо стовпці для відображення інформації про користувачів
            dg.Columns.Add("id", "Ідентифікатор користувача");
            dg.Columns.Add("full_client_name", "Повне ім'я");
            dg.Columns.Add("client_address", "Адреса");
            dg.Columns.Add("client_email", "Електронна пошта");
            dg.Columns.Add("client_phone", "Номер телефону");
            dg.Columns.Add("button_show_history", "Переглянути історію оренди"); // Кнопка для перегляду історії оренди
            dg.Columns.Add("button_give_book", "Видати книгу");   // Кнопка для видачі книги
            dg.Columns.Add("button_edit_user", "Редагувати читача"); // edit user 
            dg.Columns.Add("button_delete_user", "Видалити читача"); // Кнопка для видалення користувача
            

            foreach (DataGridViewColumn column in dg.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }


            foreach (var user in users)
            {
                // Створюємо рядок даних для кожного користувача
                DataGridViewRow row = new DataGridViewRow();

                // Додаємо дані користувача в рядок
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = user.Reader_ID });
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = user.Full_name });
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = user.Address });
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = user.Email });
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = user.PhoneNumber });

                // Додаємо рядок з кнопками в DataGridView
                DataGridViewButtonCell showHistory = new DataGridViewButtonCell();
                showHistory.Value = "";
                row.Cells.Add(showHistory);

                DataGridViewButtonCell giveBook = new DataGridViewButtonCell();
                giveBook.Value = "";
                row.Cells.Add(giveBook);

                DataGridViewButtonCell editReader = new DataGridViewButtonCell();
                editReader.Value = "";
                row.Cells.Add(editReader);

                DataGridViewButtonCell deleteUser = new DataGridViewButtonCell();
                deleteUser.Value = "";
                row.Cells.Add(deleteUser);

                // Додаємо рядок з даними і кнопками в DataGridView
                dg.Rows.Add(row);
            }

            // Додаємо обробник події для кнопки "Переглянути історію"
            dg.CellContentClick += (sender, e) =>
            {
                // Обробка натискання на кнопку "Переглянути історію"
                if (e.ColumnIndex == dg.Columns["button_show_history"].Index && e.RowIndex >= 0)
                {
                    // Отримати ідентифікатор користувача
                    int userId = (int)dg.Rows[e.RowIndex].Cells["id"].Value;
                }
            };

            // Додаємо обробник події для кнопки "Видати книгу"
            dg.CellContentClick += (sender, e) =>
            {
                // Обробка натискання на кнопку "Видати книгу"
                if (e.ColumnIndex == dg.Columns["button_give_book"].Index && e.RowIndex >= 0)
                {
                    // Отримати ідентифікатор користувача
                    int userId = (int)dg.Rows[e.RowIndex].Cells["id"].Value;

                    GiveBookForm form = new GiveBookForm(library, userId);
                    form.ShowDialog();
                }
            };

            dg.CellContentClick += (sender, e) =>
            {
                if (e.ColumnIndex == dg.Columns["button_edit_user"].Index && e.RowIndex >= 0)
                {
                    // Отримати ідентифікатор користувача
                    int userId = (int)dg.Rows[e.RowIndex].Cells["id"].Value;
                    EditReader editReader = new EditReader(library, userId);
                    editReader.ShowDialog();

                    // Обновляем DataGridView с информацией о читателях
                    DisplayInfoAboutReadersInDataGrid(users, library, dg);
                }
            };

            // Додаємо обробник події для кнопки "Видалити користувача"
            dg.CellContentClick += (sender, e) =>
            {
                // Обробка натискання на кнопку "Видалити користувача"
                if (e.ColumnIndex == dg.Columns["button_delete_user"].Index && e.RowIndex >= 0)
                {
                    // Отримати ідентифікатор користувача
                    int userId = (int)dg.Rows[e.RowIndex].Cells["id"].Value;
                    library.DeleteReader(userId);

                    // Обновляем DataGridView с информацией о читателях
                    DisplayInfoAboutReadersInDataGrid(users, library, dg);
                }
            };

            // Повертаємо змінений об'єкт DataGridView
            return dg;
        }
    }

}