using System;
using System.Collections.Generic;

#nullable disable

namespace DataTables.Models
{
    public partial class TblContact
    {
        public decimal Id { get; set; }
        public decimal ClientId { get; set; }
        public decimal ContactTypeId { get; set; }
        public string ContactNumber { get; set; }

        public virtual TblClient Client { get; set; }
    }
}
