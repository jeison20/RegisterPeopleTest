using RegisterPeople.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterPeople.Application.Interface
{
    public interface IPeopleApplication
    {
        Task<ResultRequestDto<InfoPeopleDto>> Create(CreatePeopleDto input);

        Task<ResultRequestDto<List<InfoPeopleDto>>> GetAllPeople();

        Task<ResultRequestDto<InfoPeopleDto>> GetPeople(int Id);

        Task<ResultRequestDto<bool>> DeleteAsync(int input);

        Task<ResultRequestDto<InfoPeopleDto>> UpdateAsync(UpdatePeopleDto input);
    }
}
