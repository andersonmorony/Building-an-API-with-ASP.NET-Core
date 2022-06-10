using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agend.ViewModel
{
    public class AgendCreateViewModel
    {
        [Required]
        public int PeopleId { get; set; }
        [Required]
        public DateTime Day { get; set; }
        [Required]
        public int ServiceTypeId { get; set; }
    }
}
