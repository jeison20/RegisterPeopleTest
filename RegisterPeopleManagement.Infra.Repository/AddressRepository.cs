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
    public class AddressRepository : IAddressRepository
    {
        private readonly DataContext _context;

        public AddressRepository(DataContext context)
        {
            _context = context;
        }

        public int Create(AddressEntity address)
        {
            _context.Add(address);
            _context.SaveChanges();
            return address.Id;
        }

        public AddressEntity? Get(int id)
        {
            return _context.Address.FirstOrDefault(c => c.Id == id);
        }

        public List<AddressEntity> GetByPeople(int peopleId)
        {
            return _context.Address.Where(c => c.PeopleId == peopleId).ToList();
        }

        public int Update(AddressEntity address)
        {
            _context.Update(address);
            _context.SaveChanges();
            return address.Id;
        }
    }
}
