using Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class CCCDBContext : DbContext
    {
        public CCCDBContext(DbContextOptions<CCCDBContext> options)
            : base(options)
        {

        }


        public DbSet<RoleModel> Role { get; set; }
        public DbSet<UserModel> User { get; set; }
        public DbSet<BoroughModel> Borough { get; set; }
        public DbSet<CertificationModel> Certification  { get; set; }
        public DbSet<QuestionModel> Question { get; set; }
        public DbSet<ReportModel> Report { get; set; }
        public DbSet<ReportQuestionModel> ReportQuestion { get; set; }

    }
}