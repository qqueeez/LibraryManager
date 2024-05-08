using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasessForWorkWithData
{
    public class RentHistory
    {
        // Ідентифікатор запису
        public int Record_id { get; set; }
        // Ідентифікатор читача
        public int User_id { get; set; }
        // Ідентифікатор книги
        public int Book_id { get; set; }
        // Початок оренди
        public DateTime startDate { get; set; }
        // Кінець оренди
        public DateTime endDate { get; set; }

    }
}
