using RegisterPeopleManagement.Infra.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterPeopleManagement.Infra.Interface
{
    public interface IPhonesRepository
    {
        int Create(PhonesEntity address);
        PhonesEntity? Get(int id);
        List<PhonesEntity> GetByPeople(int peopleId);
        int Update(PhonesEntity address);
    }
}
