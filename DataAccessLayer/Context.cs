﻿using Entity;
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
          
            optionsbuilder.UseSqlServer(@"Server = mssqlstud.fhict.local; Database = dbi485604_dbrent; User Id =dbi485604_dbrent;  MultipleActiveResultSets=True; Password = Emir20015454.;");

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Review> Reviews { get; set; }

    }
}