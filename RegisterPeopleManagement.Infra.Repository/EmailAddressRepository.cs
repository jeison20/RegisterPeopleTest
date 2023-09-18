using RegisterPeopleManagement.Infra.Data.DbContextEntity;
using RegisterPeopleManagement.Infra.Entities;
using RegisterPeopleManagement.Infra.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterPeopleManagement.Infra.Repository
{
    public class EmailAddressRepository : IEmailAddressRepository
    {
        private readonly DataContext _context;

        public EmailAddressRepository(DataContext context)
        {
            _context = context;
        }

        public int Create(EmailAddressEntity address)
        {
            _context.Add(address);
            _context.SaveChanges();
            return address.Id;
        }

        public EmailAddressEntity? Get(int id)
        {
            return _context.EmailAddress.FirstOrDefault(c => c.Id == id);
        }

        public List<EmailAddressEntity> GetByPeople(int peopleId)
        {
            return _context.EmailAddress.Where(c => c.PeopleId == peopleId).ToList();
        }

        public int Update(EmailAddressEntity address)
        {
            _context.Update(address);
            _context.SaveChanges();
            return address.Id;
        }
    }
}
