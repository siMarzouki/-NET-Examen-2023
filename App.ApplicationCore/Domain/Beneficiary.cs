using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Domain
{
    public class Beneficiary

    {
        [Key]
        [MinLength(8)]
        [MaxLength(8)]
        [RegularExpression("[0-9]+")]
        public string CIN { get; set; }
        public string Name { get; set;}
        
        public string Description { get; set; }

        public Contact Contact { get; set; }

        public virtual IList<Kafala> kafalas { get; set; }
    }
}
