using Agend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agend.ViewModel
{
    public class AgendViewModel
    {
        public PeopleModel People { get; set; }
        public DateTime Day { get; set; }
        public string Service { get; set; }
        public string ServiceStatus { get; set; }
    }
}
