using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        {
            //optionsbuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DbRent; Integrated security=true;");
            //optionsbuilder.UseSqlServer("Server = mssqlstud.fhict.local; Database = dbi485604_Carr;");
          
            optionsbuilder.UseSqlServer(@"Server = mssqlstud.fhict.local; Database = dbi485604_car; User Id =dbi485604_car; MultipleActiveResultSets=True; Password =Emir20015454.;");

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Review> Reviews { get; set; }



        public class Table1AndTable2
        {
            public DateTime LoanDate { get; set; }
            public DateTime ReturnDate { get; set; }
            public string Car { get; set; }

        }
        public class Table1AndTable2AndTable3
        {
            public DateTime LoanDate { get; set; }
            public DateTime ReturnDate { get; set; }
            public string Car { get; set; }
            public string user { get; set; }    

        }

        public class ReviewDto
        {
            public string ReviewContent { get; set; }
            public string user { get; set; }
            public string Car { get; set; }


        }

    }
}
