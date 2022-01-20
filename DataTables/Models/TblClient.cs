using System;
using System.Collections.Generic;

#nullable disable

namespace DataTables.Models
{
    public partial class TblClient
    {
        public TblClient()
        {
            TblAddresses = new HashSet<TblAddress>();
            TblContacts = new HashSet<TblContact>();
        }

        public decimal Id { get; set; }
        public string Name { get; set; }
        public string Idnumber { get; set; }
        public decimal? GenderId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public decimal? CountryId { get; set; }

        public virtual ICollection<TblAddress> TblAddresses { get; set; }
        public virtual ICollection<TblContact> TblContacts { get; set; }
    }
}
