using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GWebsite.AbpZeroTemplate.Core.Models;
namespace GWebsite.AbpZeroTemplate.Application.Share.Vehicles.Dto
{
    public class VehicleForViewDto
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Cartype { get; set; }
        public string IdCar { get; set; }
        public string status { get; set; }
        public string detail { get; set; }
    }
}
