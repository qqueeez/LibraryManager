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
        public int Id { get; set; }
        // Повне ім'я читача
        public string Reader_full_name { get; set; }
        // Номер телефону
        public string Reader_phone_number { get; set; }
        // Період оренди книги
        public string Rent_period { get; set; }
    }
}
