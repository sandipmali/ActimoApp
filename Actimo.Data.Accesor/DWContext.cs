using Actimo.Data.Accesor.Entities;
using Microsoft.EntityFrameworkCore;

namespace Actimo.Data.Accesor
{
    public partial class DWContext : DbContext
    {
        public DWContext()
        {
        }

        public DWContext(DbContextOptions<DWContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Relationship> ContactManager { get; set; }
        public virtual DbSet<Engagement> Engagement { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {  

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client", "config");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.ActimoApikey)
                    .IsRequired()
                    .HasColumnName("Actimo_APIKey")
                    .HasMaxLength(100);

                entity.Property(e => e.ActimoDummyMessageId).HasColumnName("Actimo_DummyMessageID");

                entity.Property(e => e.ActimoManagerContactId).HasColumnName("Actimo_ManagerContactID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Contact", "Mirror");

                entity.Property(e => e.AddrCity)
                    .HasColumnName("addr_city")
                    .HasMaxLength(100);

                entity.Property(e => e.AddrCountry)
                    .HasColumnName("addr_country")
                    .HasMaxLength(100);

                entity.Property(e => e.AddrLine1)
                    .HasColumnName("addr_line_1")
                    .HasMaxLength(100);

                entity.Property(e => e.AddrLine2)
                    .HasColumnName("addr_line_2")
                    .HasMaxLength(100);

                entity.Property(e => e.AddrState)
                    .HasColumnName("addr_state")
                    .HasMaxLength(100);

                entity.Property(e => e.AddrZip)
                    .HasColumnName("addr_zip")
                    .HasMaxLength(100);

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.Company)
                    .HasColumnName("company")
                    .HasMaxLength(100);

                entity.Property(e => e.CompanyReg)
                    .HasColumnName("company_reg")
                    .HasMaxLength(100);

                entity.Property(e => e.CountryCode)
                    .HasColumnName("country_code")
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100);

                entity.Property(e => e.Data1)
                    .HasColumnName("data1")
                    .HasMaxLength(100);

                entity.Property(e => e.Data10)
                    .HasColumnName("data10")
                    .HasMaxLength(100);

                entity.Property(e => e.Data11)
                    .HasColumnName("data11")
                    .HasMaxLength(100);

                entity.Property(e => e.Data12)
                    .HasColumnName("data12")
                    .HasMaxLength(100);

                entity.Property(e => e.Data13)
                    .HasColumnName("data13")
                    .HasMaxLength(100);

                entity.Property(e => e.Data14)
                    .HasColumnName("data14")
                    .HasMaxLength(100);

                entity.Property(e => e.Data15)
                    .HasColumnName("data15")
                    .HasMaxLength(100);

                entity.Property(e => e.Data16)
                    .HasColumnName("data16")
                    .HasMaxLength(100);

                entity.Property(e => e.Data17)
                    .HasColumnName("data17")
                    .HasMaxLength(100);

                entity.Property(e => e.Data18)
                    .HasColumnName("data18")
                    .HasMaxLength(100);

                entity.Property(e => e.Data19)
                    .HasColumnName("data19")
                    .HasMaxLength(100);

                entity.Property(e => e.Data2)
                    .HasColumnName("data2")
                    .HasMaxLength(100);

                entity.Property(e => e.Data20)
                    .HasColumnName("data20")
                    .HasMaxLength(100);

                entity.Property(e => e.Data3)
                    .HasColumnName("data3")
                    .HasMaxLength(100);

                entity.Property(e => e.Data4)
                    .HasColumnName("data4")
                    .HasMaxLength(100);

                entity.Property(e => e.Data5)
                    .HasColumnName("data5")
                    .HasMaxLength(100);

                entity.Property(e => e.Data6)
                    .HasColumnName("data6")
                    .HasMaxLength(100);

                entity.Property(e => e.Data7)
                    .HasColumnName("data7")
                    .HasMaxLength(100);

                entity.Property(e => e.Data8)
                    .HasColumnName("data8")
                    .HasMaxLength(100);

                entity.Property(e => e.Data9)
                    .HasColumnName("data9")
                    .HasMaxLength(100);

                entity.Property(e => e.Department)
                    .HasColumnName("department")
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(100);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LastActive)
                    .HasColumnName("last_active");

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(100);

                entity.Property(e => e.OptOut).HasColumnName("opt_out");

                entity.Property(e => e.Active).HasColumnName("Active");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phone_number")
                    .HasMaxLength(100);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(100);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at");
                   

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<Relationship>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ContactManager", "Mirror");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.ContactManagerId)
                    .HasColumnName("ContactManagerID")
                    .HasMaxLength(50);

                entity.Property(e => e.ContactName).HasMaxLength(50);

                entity.Property(e => e.ContactType).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<Engagement>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Engagement", "Mirror");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Key)
                    .HasColumnName("key")
                    .HasMaxLength(50);

                entity.Property(e => e.LowerThreshold).HasColumnName("lowerThreshold");

                entity.Property(e => e.Suffix)
                    .HasColumnName("suffix")
                    .HasMaxLength(10);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(50);

                entity.Property(e => e.UpperThreshold).HasColumnName("upperThreshold");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("decimal(18, 8)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
