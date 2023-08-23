using Repository_Pattern_Design_Medicin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Pattern_Design_Medicin.Repository
{
    public class MedicinRepo : IMediRepo
    {
        public void Delete(int medicinSlNo)
        {
            Medicin medicin = MedicinDB.MedicinList.FirstOrDefault(x => x.MedicinSlNo == medicinSlNo);
            MedicinDB.MedicinList.Remove(medicin);
        }

        public IEnumerable<Medicin> GetAll()
        {
            return MedicinDB.MedicinList;
        }

        public Medicin GetById(int medicinSlNo)
        {
            Medicin medicin = MedicinDB.MedicinList.FirstOrDefault(x => x.MedicinSlNo == medicinSlNo);
            return medicin;
        }

        public void Insert(Medicin medicin)
        {
            MedicinDB.MedicinList.Add(medicin);
        }

        public void Update(Medicin medicin)
        {
            Medicin _medicin = MedicinDB.MedicinList.FirstOrDefault(x => x.MedicinSlNo == medicin.MedicinSlNo);
            if(medicin.MedicinName != null)
            {
                _medicin.MedicinName = medicin.MedicinName;
            }
            if(medicin.Quntity != 0)
            {
                _medicin.Quntity = medicin.Quntity;
            }
        }
    }
}
