using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Vehicle : FullAuditModel
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Cartype { get; set; }
        public string detail { get; set; }
        public string status { get; set; }
        public string IdCar { get; set; }
    }

}

