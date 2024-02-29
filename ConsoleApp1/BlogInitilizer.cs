using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BlogInitilizer : DropCreateDatabaseIfModelChanges<BlogDbContext>
    {
        protected override void Seed(BlogDbContext blogDbContext)
        {
            List<Admin> admins = new List<Admin>()
            {
                new Admin() {Email_Id="resuresh0@gmail.com",Password="Suresh@123"},
                new Admin(){Email_Id="admin",Password="admin@123"}
            };
            blogDbContext.Admins.AddRange(admins);
            blogDbContext.SaveChanges();

            List<Employee> employees = new List<Employee>()
            {
                new Employee() {Email_Id="ragendhu@gmail.com",Name="Ragendhu Ramesh",DataofJoining=new DateTime(2023,9,26),PassCode=25457 },
                new Employee() {Email_Id="sureshreddy@gmail.com",Name="suresh Reddy",DataofJoining=new DateTime(2023,9,26),PassCode=25829 },
                new Employee() {Email_Id="Naresh@gmail.com",Name="Naresh",DataofJoining=new DateTime(2023,9,26),PassCode=25698 }
            };
            blogDbContext.Employees.AddRange(employees);
            blogDbContext.SaveChanges();
            List<BlogInfo> blogs = new List<BlogInfo>()
            {
                new BlogInfo(){BlogId=new Random().Next(100,900),Subject="MS.Net",Title="Blog1",BlogUlrb="https://devblogs.microsoft.com/dotnet",DateOfCreation=new DateTime(2024,10,12),EmpEmailId="Sureshreddy@gmail.com"}
            };
            blogDbContext.Blogs.AddRange(blogs); blogDbContext.SaveChanges();

            base.Seed(blogDbContext);

        }
    }
}
