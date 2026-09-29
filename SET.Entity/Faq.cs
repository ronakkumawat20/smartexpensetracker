using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SET.Entity
{
     public class Faq : BaseEntity
    {
        public string FaqQuestion { get; set; }

        public string FaqAnswer { get; set; }

        public bool IsActive { get; set; }
    }
}
