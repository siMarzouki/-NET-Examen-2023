using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Domain
{
    public class Kafala
    {
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [DataType(DataType.Currency)]
        public int Amount { get; set; }

        public virtual Beneficiary Beneficiary { get; set; }
        public virtual Donator Donator { get; set; }

        public string BeneficiaryCIN { get; set; }
        public  int DonatorId { get; set; } 
    }
}
