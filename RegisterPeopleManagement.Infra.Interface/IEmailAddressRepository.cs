using RegisterPeopleManagement.Infra.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterPeopleManagement.Infra.Interface
{
    public interface IEmailAddressRepository
    {
        int Create(EmailAddressEntity address);
        EmailAddressEntity? Get(int id);
        List<EmailAddressEntity> GetByPeople(int peopleId);
        int Update(EmailAddressEntity address);
    }
}
