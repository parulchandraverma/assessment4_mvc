using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using AssessmentUser.Models;



namespace AssessmentUser.Context
{
    public class Userdbcontext : DbContext
    {



        public Userdbcontext()
        {



        }
        public Userdbcontext(DbContextOptions<Userdbcontext> options) : base(options)
        {
        }



        public DbSet<User> Users { set; get; }



        public DbSet<Batch>? Batch { get; set; }



        public DbSet<Course>? Course { get; set; }



        public DbSet<LoginPage>? LoginPage { get; set; }
    }
}