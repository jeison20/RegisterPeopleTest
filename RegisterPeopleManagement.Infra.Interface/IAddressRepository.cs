using RegisterPeopleManagement.Infra.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterPeopleManagement.Infra.Interface
{
    public interface IAddressRepository
    {
        int Create(AddressEntity address);
        AddressEntity? Get(int id);
        List<AddressEntity> GetByPeople(int peopleId);
        int Update(AddressEntity address);
    }
}
