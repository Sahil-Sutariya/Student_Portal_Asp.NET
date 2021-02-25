using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentPortalFinal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentPortalFinal.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Student> student { get; set; }
        public DbSet<StudentInfo> studentinfo { get; set; }
        public DbSet<Fees> fees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //Define Relationships and Keys

            builder.Entity<StudentInfo>()
                    .HasOne(p => p.student)
                    .WithMany(c => c.Students)
                    .HasForeignKey(p => p.AdminId)
                    .HasConstraintName("FK_Students_StudentId");

            builder.Entity<Fees>()
                .HasOne(f => f.Student)
                .WithMany(s => s.fees)
                .HasForeignKey(f => f.StudentId)
                .HasConstraintName("FK_Students_FeesId");
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
