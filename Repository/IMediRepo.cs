using Repository_Pattern_Design_Medicin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Pattern_Design_Medicin.Repository
{
    public interface IMediRepo
    {
        IEnumerable<Medicin> GetAll();
        Medicin GetById(int medicinSlNo);
        void Insert(Medicin medicin);
        void Update(Medicin medicin);
        void Delete(int medicinSlNo);
    }
}
