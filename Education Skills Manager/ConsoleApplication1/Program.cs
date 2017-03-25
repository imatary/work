using EducationSkills.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {

        static void Main(string[] args)
        {
            //EducationSkillsDbContext context = new EducationSkillsDbContext();
            //List<PR_Mat> items = context.PR_Mat.Where(it => it.CapDo == "KTV A").ToList();
            //foreach (var item in items)
            //{

            //        var eye = context.PR_Mat.SingleOrDefault(c => c.StaffCode == item.StaffCode);

            //        eye.NangCap = item.CapDo;
            //        eye.NgayNangCap = item.NgayCap;
            //        eye.CapDo = null;
            //        eye.NgayCap = null;
            //    try
            //        {
            //            context.PR_Mat.Attach(eye);
            //            context.Entry(eye).State = EntityState.Modified;
            //            context.SaveChanges();
            //        }
            //        catch (Exception ex)
            //        {
            //            Console.Write(ex.Message);
            //            return;
            //        }

            //        //Console.WriteLine(item.StaffCode);
            //}


            DateTime endDate = DateTime.Today;
            Console.WriteLine(endDate.ToString());
            DateTime plusDate = endDate.AddDays(365);
            Console.WriteLine(plusDate.ToString());
            Console.ReadKey();
        }
    }
}
