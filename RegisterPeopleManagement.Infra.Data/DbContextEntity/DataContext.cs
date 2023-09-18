using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RegisterPeopleManagement.Infra.Entities;

namespace RegisterPeopleManagement.Infra.Data.DbContextEntity
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DataContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<PeopleEntity> People { get; set; }
        public DbSet<PhonesEntity> Phones { get; set; }
        public DbSet<AddressEntity> Address { get; set; }
        public DbSet<EmailAddressEntity> EmailAddress { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string testAssemblyName = "Microsoft.TestPlatform";
            var result = AppDomain.CurrentDomain.GetAssemblies()
                .Any(a => a.FullName.StartsWith(testAssemblyName));
            if (!result)
            {
                var connectionStrings = _configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionStrings);
            }
            else
            {
                optionsBuilder.UseInMemoryDatabase(databaseName: "RegisterPeople");
            }
        }

        private void SeedDatabase()
        {
            var projects = new List<PeopleEntity>
            {
                new PeopleEntity{Id=1,FirstName="juan",LastName="perez",IdentityDocument="121542",BirthDate=new DateTime(1982,02,15) },
                 new PeopleEntity{Id=2,FirstName="carlos",LastName="lopez",IdentityDocument="48544545",BirthDate=new DateTime(1987,05,10) },
                 new PeopleEntity{Id=3,FirstName="luis",LastName="gonzales",IdentityDocument="3454541",BirthDate=new DateTime(1995,02,25) },
            };

            var phones = new List<PhonesEntity>
            {
                new PhonesEntity{Id=1,PeopleId=1,Number="121542"},
                 new PhonesEntity{Id=2,PeopleId=2,Number="48544545"},
                 new PhonesEntity{Id=3,PeopleId=3,Number="3454541" },
                 new PhonesEntity{Id=4,PeopleId=3,Number="44555541" },
            };

            var emails = new List<EmailAddressEntity>
            {
                new EmailAddressEntity{Id=1,PeopleId=1,Address="kof_98@hotmail.com"},
                 new EmailAddressEntity{Id=1,PeopleId=2,Address="kof_97@hotmail.com"},
                 new EmailAddressEntity{Id=2,PeopleId=3,Address="kof_2000@hotmail.com" },
                 new EmailAddressEntity{Id=3,PeopleId=3,Address="kof_2002@hotmail.com" },
            };

            var addresses = new List<AddressEntity>
            {
                new AddressEntity{Id=1,PeopleId=1,PhysicalAddress="cra 123"},
                 new AddressEntity{Id=1,PeopleId=2,PhysicalAddress="cra 45-15"},
                 new AddressEntity{Id=2,PeopleId=2,PhysicalAddress="calle 170 # 45" },
                 new AddressEntity{Id=3,PeopleId=3,PhysicalAddress="calle 100 # 12-44" },
            };

            AddRange(projects);
            AddRange(phones);
            AddRange(emails);
            AddRange(addresses);

            SaveChanges();
        }
    }
}