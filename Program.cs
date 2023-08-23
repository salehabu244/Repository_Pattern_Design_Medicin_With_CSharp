using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository_Pattern_Design_Medicin.Models;
using Repository_Pattern_Design_Medicin.Repository;

namespace Repository_Pattern_Design_Medicin
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayAllItem();

            Console.ReadKey();
        }
        public static void DisplayAllItem()
        {
            Console.WriteLine("1. Show All Medicin");
            Console.WriteLine("2. Insert Medicin");
            Console.WriteLine("3. Update Medicin");
            Console.WriteLine("4. Delete Medicin");

            var index = int.Parse(Console.ReadLine());
            Show(index);
        }
        public static void Show(int index)
        {
            MedicinRepo medicinRepo = new MedicinRepo();
            if (index == 1)
            {
                var medicinList = medicinRepo.GetAll();
                if (medicinList.Count() == 0)
                {
                    Console.WriteLine("***********************************");
                    Console.WriteLine("No Data Found");
                    Console.WriteLine("***********************************");
                    DisplayAllItem();
                }
                else
                {
                    foreach (var item in medicinRepo.GetAll())
                    {
                        Console.WriteLine($"Medicin Sl No: {item.MedicinSlNo}, Medicin Name : {item.MedicinName}, Quantity : {item.Quntity}, Manufacture Date: {item.ManufactureDate}, Expire Date : {item.ExpireDate}");
                    }
                    Console.WriteLine("************************************");
                    DisplayAllItem();
                }
            }
            else if (index == 2)
            {
                Console.WriteLine("*******************************************");
                Console.Write("Medicin Name: ");
                string name = Console.ReadLine();

                Console.Write("Quantity : ");
                int quantity = Convert.ToInt32(Console.ReadLine());

                Console.Write("Manufacture Date : ");
                DateTime dateTime = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Expire Date : ");
                DateTime dateTime1 = Convert.ToDateTime(Console.ReadLine());

                int maxId = medicinRepo.GetAll().Any() ? medicinRepo.GetAll().Max(x => x.MedicinSlNo) : 0;

                Medicin medicin = new Medicin
                {
                    MedicinSlNo = maxId + 1,
                    MedicinName = name,
                    Quntity = quantity,
                    ManufactureDate = dateTime,
                    ExpireDate = dateTime1
                };
                medicinRepo.Insert(medicin);
                Console.WriteLine("Data Inserted Successfully!!!");
                DisplayAllItem();
            }
            else if (index == 3)
            {
                Console.WriteLine("**********************************");
                Console.Write("Enter Medicin Sl No to Update: ");
                int sl = int.Parse(Console.ReadLine());
                var _medicin = medicinRepo.GetById(sl);

                if (_medicin == null)
                {
                    Console.WriteLine("***************************");
                    Console.WriteLine("Medicin Sl is Invalid!!!");
                    Console.WriteLine("******************************");
                    DisplayAllItem();
                }
                else
                {
                    Console.WriteLine($"Update Info for Medicin Sl : {sl}");
                    Console.WriteLine("*********************************");
                    Console.Write("Medicin Name : ");
                    string name = Console.ReadLine();

                    Console.Write("Quantity : ");
                    int quantity = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Manufacture Date : ");
                    DateTime dateTime = Convert.ToDateTime(Console.ReadLine());

                    Console.Write("Expire Date : ");
                    DateTime dateTime1 = Convert.ToDateTime(Console.ReadLine());

                    Medicin medicin = new Medicin
                    {
                        MedicinSlNo = sl,
                        MedicinName = name,
                        Quntity = quantity,
                        ManufactureDate = dateTime,
                        ExpireDate = dateTime1,
                    };
                    medicinRepo.Update(medicin);
                    Console.WriteLine("Data Update Successfully!!!");
                    Console.WriteLine("*************************");
                    DisplayAllItem();
                }
            }
            else if (index == 4)
            {
                Console.WriteLine("******************************");
                Console.Write("Enter Medicin Sl No to Delete: ");
                int sl = int.Parse(Console.ReadLine());
                var _medicin = medicinRepo.GetById(sl);

                if(_medicin == null)
                {
                    Console.WriteLine("**********************");
                    Console.WriteLine("Medicin Sl is Invalid!!!");
                    Console.WriteLine("***********************");
                    DisplayAllItem();
                }
                else
                {
                    medicinRepo.Delete(sl);
                    Console.WriteLine("Data Deleted Successfully!!!");
                    Console.WriteLine("****************************");
                    DisplayAllItem();
                }
            }
            
        }
    }
}
