using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models.Data
{
    public class OrderForm
    {
        public int Id { get; set; }

        public int Client_Id { get; set; }

        public int Employee_id { get; set; }

        public int Book_id { get; set; }

        public DateOnly IssueData { get; set; }

        public DateOnly? ReturnDate { get; set; }

        public DateOnly DeadLine { get; set; }
    }
}
