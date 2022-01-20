using System;
using System.Collections.Generic;

#nullable disable

namespace DataTables.Models
{
    public partial class VClient
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public string Idnumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public decimal? GenderId { get; set; }
        public string Gender { get; set; }
        public decimal? CountryId { get; set; }
        public string Country { get; set; }
    }
}
