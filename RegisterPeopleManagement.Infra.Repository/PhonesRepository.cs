using RegisterPeopleManagement.Infra.Data.DbContextEntity;
using RegisterPeopleManagement.Infra.Entities;
using RegisterPeopleManagement.Infra.Interface;

namespace RegisterPeopleManagement.Infra.Repository
{
    public class PhonesRepository : IPhonesRepository
    {
        private readonly DataContext _context;

        public PhonesRepository(DataContext context)
        {
            _context = context;
        }

        public int Create(PhonesEntity address)
        {
            _context.Add(address);
            _context.SaveChanges();
            return address.Id;
        }

        public PhonesEntity? Get(int id)
        {
            return _context.Phones.FirstOrDefault(c => c.Id == id);
        }

        public List<PhonesEntity> GetByPeople(int peopleId)
        {
            return _context.Phones.Where(c => c.PeopleId == peopleId).ToList();
        }

        public int Update(PhonesEntity address)
        {
            _context.Update(address);
            _context.SaveChanges();
            return address.Id;
        }
    }
}