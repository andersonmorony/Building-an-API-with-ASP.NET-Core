using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agend.Models
{
    public class AgendsModel
    {
        public int Id { get; set; }
        public PeopleModel People { get; set; }
        public DateTime Day { get; set; }
        public ServiceTypeModel ServiceType { get; set; }

    }
}
