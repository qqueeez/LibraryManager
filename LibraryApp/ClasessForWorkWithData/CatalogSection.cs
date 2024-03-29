using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasessForWorkWithData
{
    // Клас CatalogSection аналогічно з класом Book не буде містити жодних методів,
    // а тільки властивості та конструктори для заповнення властивостей даними.
    // Цей клас буде структурою об’єкта – секція каталогу.
    // Кожна секція каталогу повинна містити ім’я основної секції та номер.
    public class CatalogSection
    {
        // Назва каталогу
        public string CatalogTitle { get; set; }
        // id каталогу
        public int Catalog_ID { get; set; }
        
        // конструктор для заповнення інформації щодо назви каталогу та його номеру(ID)
        public CatalogSection(string catalogTitle, int catalog_ID)
        {
            CatalogTitle = catalogTitle;
            Catalog_ID = catalog_ID;
        }
    }
}
