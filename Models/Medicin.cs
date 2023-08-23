using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Pattern_Design_Medicin.Models
{
    public class Medicin
    {
        public int MedicinSlNo { get; set; }
        public string MedicinName { get; set; }
        public int Quntity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
