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
    public class PeopleRepository : IPeopleRepository
    {

        private readonly DataContext _context;

        public PeopleRepository(DataContext context)
        {
            _context = context;
        }

        public int Create(PeopleEntity people)
        {
            _context.Add(people);
            _context.SaveChanges();
            return people.Id;
        }

        public PeopleEntity? Get(int id)
        {
            return _context.People.FirstOrDefault(c => c.Id == id);
        }

        public List<PeopleEntity> GetAllPeople()
        {
            return _context.People.ToList();
        }

        public List<PeopleEntity> GetByName(string name)
        {
            return _context.People.Where(c => c.FirstName.ToLower().Contains(name.ToLower())).ToList();
        }

        public bool GetByIdentifier(string identityDocument)
        {
            return _context.People.Any(c => c.IdentityDocument == identityDocument);
        }

        public int Update(PeopleEntity people)
        {
            _context.Update(people);
            _context.SaveChanges();
            return people.Id;
        }
    }
}
