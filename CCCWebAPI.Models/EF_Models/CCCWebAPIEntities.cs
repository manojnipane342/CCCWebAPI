using Microsoft.EntityFrameworkCore;
namespace CCCWebAPI.Models.EF_Models
{
    public partial class CCCWebAPIEntities : DbContext
    {
        public CCCWebAPIEntities()
        {
        }

        public CCCWebAPIEntities(DbContextOptions<CCCWebAPIEntities> options)
            : base(options)
        {
        }
        public virtual DbSet<TblPlumber> TblPlumber { get; set; } = null!;
        public virtual DbSet<TblIndividualInfo> TblIndividualInfo { get; set; } = null!;
        public virtual DbSet<TblInformationloc> TblInformationloc { get; set; } = null!;
        public virtual DbSet<TblUsers> TblUsers { get; set; } = null!;
        public virtual DbSet<TblOtpVerify> TblOtpVerify { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer();
                optionsBuilder.UseSqlServer("Server=DESKTOP-UFUU12M;Initial Catalog=CCC_APP_DB ;Integrated Security=true;Connection Timeout=30;", builder =>
                {
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                });
                //optionsBuilder.UseSqlServer("Data Source=DESKTOP-OOC39HJ\\SQLEXPRESS; Initial Catalog=Angular_POC; user id=sa; Password=sa123",
                //   sqlServerOptionsAction: sqlOptions =>
                //   {
                //       sqlOptions.EnableRetryOnFailure();
                //   });
            }

            base.OnConfiguring(optionsBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
