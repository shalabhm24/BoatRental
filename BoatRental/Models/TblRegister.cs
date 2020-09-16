using System;
using System.Collections.Generic;

namespace BoatRental.Models
{
    public partial class TblRegister
    {
        public int Id { get; set; }
        public string BoatName { get; set; }
        public int HourlyRate { get; set; }
    }
}
