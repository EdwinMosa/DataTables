using System;
using System.Collections.Generic;

#nullable disable

namespace DataTables.Models
{
    public partial class TblAddress
    {
        public decimal Id { get; set; }
        public decimal ClientId { get; set; }
        public decimal AddressTypeId { get; set; }
        public string Address { get; set; }

        public virtual TblClient Client { get; set; }
    }
}
