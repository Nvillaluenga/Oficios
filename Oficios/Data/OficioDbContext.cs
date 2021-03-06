﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Oficios.Models;

namespace Oficios.Data
{
    public class OficioDbContext : DbContext
    {
        public OficioDbContext(DbContextOptions<OficioDbContext> options) : base(options)
        {

        }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillCategory> SkillCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder mbldr)
        {
            mbldr.Entity<User>().HasData(new User
                {
                    UserId = 1,
                    Name = "Nacho",
                    LastName = "Villaluenga",
                    Address = "Houssay 1925",
                    Email = "nachovillaluenga@gmail.com",
                    PostalCode = 4146
                }, new User
                {
                    UserId = 2,
                    Name = "Nacho 2",
                    LastName = "Villaluenga2",
                    Address = "Houssay 2925",
                    Email = "nachovillaluenga2@gmail.com",
                    PostalCode = 4146
                });

            mbldr.Entity<SkillCategory>()
                .HasData(new SkillCategory
                {
                    SkillCategoryId = 1,
                    Name = "Plomber",
                    Description = "Plomber stuff you know"
                }, new SkillCategory
                {
                    SkillCategoryId = 2,
                    Name = "Electrical technician",
                    Description = "Electrical technician stuff you know"
                });
            mbldr.Entity<Skill>()
                .HasData(new
                {
                    SkillId = 1,
                    Name = "General Mantainance",
                    Description = "Various Jobs you know",
                    SkillCategoryId = 2
                }, new
                {
                    SkillId = 2,
                    Name = "Change installation",
                    Description = "change cables and stuff you know",
                    SkillCategoryId = 2
                }, new
                {
                    SkillId = 3,
                    Name = "General Mantainance",
                    Description = "Various Jobs you know",
                    SkillCategoryId = 1
                }, new
                {
                    SkillId = 4,
                    Name = "Fix toilet",
                    Description = "fix toilet and stuff you know",
                    SkillCategoryId = 1
                });
            mbldr.Entity<Worker>()
                .HasData(new
                {
                    UserId = 3,
                    Name = "Worker",
                    LastName = "Walker",
                    Address = "work street 1",
                    Email = "worker@gmail.com",
                    Description = "Some description.",
                    PostalCode = 4146
                }, new
                {
                UserId = 4,
                    Name = "Worker2",
                    LastName = "Walker2",
                    Address = "work street 2",
                    Email = "worker2@gmail.com",
                    Description = "Some description2.",
                    PostalCode = 4146
                });
            mbldr.Entity<Job>().HasOne(j => j.User).WithMany(u => u.JobsReceived).OnDelete(DeleteBehavior.Restrict);
            mbldr.Entity<Job>().HasOne(j => j.Worker).WithMany(w => w.JobsMade).OnDelete(DeleteBehavior.Restrict);
            // mbldr.Entity<Job>().HasOne(j => j.Skill).

            mbldr.Entity<Job>().HasData(new
                {
                    JobId = 1,
                    Score = 5,
                    SkillId = 1,
                    JobPlaced = DateTime.Now,
                    UserId = 1,
                    WorkerUserId = 3,
                    Opinion = "A pretty good worker."
                }, new
                {
                    JobId = 2,
                    Score = 5,
                    SkillId = 2,
                    JobPlaced = DateTime.Now,
                    UserId = 2,
                    WorkerUserId = 4,
                    Opinion = "A pretty good worker."
                });
            base.OnModelCreating(mbldr);
        }
    }
}
