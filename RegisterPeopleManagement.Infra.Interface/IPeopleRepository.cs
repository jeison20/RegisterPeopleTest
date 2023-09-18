using RegisterPeopleManagement.Infra.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterPeopleManagement.Infra.Interface
{
    public interface IPeopleRepository
    {
        int Create(PeopleEntity people);
        PeopleEntity? Get(int id);
        List<PeopleEntity> GetAllPeople();
        List<PeopleEntity> GetByName(string name);
        bool GetByIdentifier(string identityDocument);
        int Update(PeopleEntity people);
    }
}
