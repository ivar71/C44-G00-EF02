using EF2.Data;   // لو الكلاس DbContext عندك جوه فولدر Data
using EF2.Models;
using Microsoft.EntityFrameworkCore;

namespace EF2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var db = new DBcontext();

            #region Part1

            #region DataSeeding
            // هنا ممكن نعمل داتا افتراضية
            // (طالب) أنا مش هعمل Seed فعلي بس هي الفكرة
            // db.SeedData();
            Console.WriteLine("Data Seed Example");
            #endregion

            #region Invalid Loading
            // تحميل بيانات بدون Include
            var std1 = db.Students.FirstOrDefault();
            if (std1 != null)
            {
                Console.WriteLine($"Student: {std1.FName} {std1.LName}, DeptId: {std1.Dep_Id}");
                Console.WriteLine($"Dept Name: {std1.Department?.Name}");
            }
            #endregion

            #region Loading Related Data

            #region Eager Loading
            var std2 = db.Students.Include(s => s.Department).FirstOrDefault();
            if (std2 != null)
            {
                Console.WriteLine($"[Eager] {std2.FName} {std2.LName} -> {std2.Department?.Name}");
            }

            var deptWithManager = db.Departments.Include(d => d.Head).FirstOrDefault();
            if (deptWithManager != null)
            {
                Console.WriteLine($"Dept: {deptWithManager.Name}, Manager: {deptWithManager.Head?.Name}");
            }
            #endregion

            #region Explicit Loading
            var std3 = db.Students.FirstOrDefault();
            if (std3 != null)
            {
                db.Entry(std3).Reference(s => s.Department).Load();
                Console.WriteLine($"[Explicit] {std3.FName} {std3.LName} -> {std3.Department?.Name}");
            }

            var dep1 = db.Departments.FirstOrDefault();
            if (dep1 != null)
            {
                db.Entry(dep1).Collection(d => d.Instructors).Load();
                Console.WriteLine($"Dept: {dep1.Name}");
                foreach (var ins in dep1.Instructors)
                    Console.WriteLine($"-- Instructor: {ins.Name}");
            }
            #endregion

            #region Lazy Loading
            var std4 = db.Students.FirstOrDefault();
            if (std4 != null)
            {
                Console.WriteLine($"[Lazy] {std4.FName} {std4.LName}, Dept: {std4.Department?.Name}");
            }
            #endregion

            #endregion

            #region Joins

            #region Inner Join
            var innerJoinRes = from s in db.Students
                               join d in db.Departments
                               on s.Dep_Id equals d.ID
                               select new { Stu = s.FName + " " + s.LName, Dept = d.Name };

            foreach (var item in innerJoinRes)
                Console.WriteLine($"[Inner] {item.Stu} -> {item.Dept}");
            #endregion

            #region Group Join
            var groupJoinRes = db.Departments.GroupJoin(db.Students,
                d => d.ID,
                s => s.Dep_Id,
                (d, studs) => new { d.Name, studs });

            foreach (var g in groupJoinRes)
            {
                Console.WriteLine($"Dept: {g.Name}");
                foreach (var s in g.studs)
                {
                    Console.WriteLine($"--- {s.FName} {s.LName}");
                }
            }
            #endregion

            #region Left Join
            var leftJoin = from d in db.Departments
                           join s in db.Students
                           on d.ID equals s.Dep_Id into g
                           from s in g.DefaultIfEmpty()
                           select new { Dept = d.Name, Student = s != null ? s.FName : "No Student" };

            foreach (var item in leftJoin)
                Console.WriteLine($"[Left] Dept: {item.Dept}, Student: {item.Student}");
            #endregion

            #region Cross Join
            var crossJoin = from s in db.Students
                            from d in db.Departments
                            select new { Stu = s.FName, Dept = d.Name };

            foreach (var item in crossJoin)
                Console.WriteLine($"[Cross] {item.Stu} - {item.Dept}");
            #endregion

            #endregion

            #endregion

            #region Part2

            #region Create
            var newStd = new Student { FName = "Omar", LName = "Ali", Age = 20, Address = "Cairo", Dep_Id = 1 };
            db.Students.Add(newStd);
            db.SaveChanges();
            Console.WriteLine("Student Inserted");
            #endregion

            #region Read
            var readStd = db.Students.FirstOrDefault(s => s.ID == newStd.ID);
            if (readStd != null)
                Console.WriteLine($"Read: {readStd.FName} {readStd.LName}");
            #endregion

            #region Update
            if (readStd != null)
            {
                readStd.Address = "Alex";
                db.SaveChanges();
                Console.WriteLine("Student Updated");
            }
            #endregion

            #region Delete
            if (readStd != null)
            {
                db.Students.Remove(readStd);
                db.SaveChanges();
                Console.WriteLine("Student Deleted");
            }
            #endregion

            #endregion

        }
    }
}
