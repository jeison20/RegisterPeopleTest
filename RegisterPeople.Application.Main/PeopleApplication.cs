using RegisterPeople.Application.Dto;
using RegisterPeople.Application.Interface;
using RegisterPeopleManagement.Infra.Entities;
using RegisterPeopleManagement.Infra.Interface;

namespace RegisterPeople.Application.Main
{
    public class PeopleApplication : IPeopleApplication
    {
        private readonly IPeopleRepository _peopleRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IEmailAddressRepository _emailAddressRepository;
        private readonly IPhonesRepository _phonesRepository;

        public PeopleApplication(IPeopleRepository peopleRepository, IAddressRepository addressRepository, IEmailAddressRepository emailAddressRepository, IPhonesRepository phonesRepository)
        {
            _peopleRepository = peopleRepository;
            _addressRepository = addressRepository;
            _emailAddressRepository = emailAddressRepository;
            _phonesRepository = phonesRepository;
        }

        public async Task<ResultRequestDto<InfoPeopleDto>> Create(CreatePeopleDto input)
        {
            try
            {
                if (string.IsNullOrEmpty(input.IdentityDocument) ||
            string.IsNullOrEmpty(input.FirstName) ||
            string.IsNullOrEmpty(input.LastName) ||
            input.BirthDate == DateTime.MinValue)
                {
                    // No cumple con las validaciones básicas.
                    return new ResultRequestDto<InfoPeopleDto> { Data = new InfoPeopleDto(), IsSuccess = false, Message = "los datos iniciales son de caracter obligatorio.", Response = "500" };
                }

                if ((input.Phones == null || input.Phones.Count == 0) &&
            (input.EmailAddresses == null || input.EmailAddresses.Count == 0) &&
            (input.Addresses == null || input.Addresses.Count == 0))
                {
                    // No cumple con el requisito de al menos una información de contacto.
                    return new ResultRequestDto<InfoPeopleDto> { Data = new InfoPeopleDto(), IsSuccess = false, Message = "Se deben diligenciar al menos una informacion de Contacto.", Response = "500" };
                }

                if (input.Phones != null && input.Phones.Count > 2 ||
            input.EmailAddresses != null && input.EmailAddresses.Count > 2 ||
            input.Addresses != null && input.Addresses.Count > 2)
                {
                    // Supera el límite de 2 números telefónicos, correos electrónicos o direcciones físicas.
                    return new ResultRequestDto<InfoPeopleDto> { Data = new InfoPeopleDto(), IsSuccess = false, Message = "Se deben diligenciar un maximo de dos numeros telefonicos, correos electronicos o direcciones fisicas.", Response = "500" };
                }

                if (_peopleRepository.GetByIdentifier(input.IdentityDocument))
                    return new ResultRequestDto<InfoPeopleDto> { Data = new InfoPeopleDto(), IsSuccess = false, Message = "El numero de identificacion ya se encuentra registrado.", Response = "500" };


                PeopleEntity infoPeopleEntityDto = new() { IdentityDocument = input.IdentityDocument, FirstName = input.FirstName, LastName = input.LastName, BirthDate = input.BirthDate };
                int peopleId = _peopleRepository.Create(infoPeopleEntityDto);

                SetIdPeoplePhones(input, peopleId);
                SetIdPeopleEmails(input, peopleId);
                SetIdPeopleAddress(input, peopleId);

                InfoPeopleDto infoPeopleDto = new()
                {
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    BirthDate = input.BirthDate,
                    IdentityDocument = input.IdentityDocument,
                    Id = infoPeopleEntityDto.Id,
                    PhoneInfos = input.Phones,
                    AdressInfos = input.Addresses,
                    addressEmailInfos = input.EmailAddresses
                };

                return new ResultRequestDto<InfoPeopleDto> { Data = infoPeopleDto, IsSuccess = true, Message = "People register Created.", Response = "201" };
            }
            catch (Exception)
            {
                return new ResultRequestDto<InfoPeopleDto> { Data = new InfoPeopleDto(), IsSuccess = false, Message = "Internal Server Error! Try again later.", Response = "500" };
            }
        }

        private void SetIdPeopleAddress(CreatePeopleDto input, int peopleId)
        {
            foreach (var item in input.Addresses)
            {
                AddressEntity address = new() { PhysicalAddress = item.Address, PeopleId = peopleId };
                int _id = _addressRepository.Create(address);
                item.Id = _id;
            }
        }

        private void SetIdPeopleEmails(CreatePeopleDto input, int peopleId)
        {
            foreach (var item in input.EmailAddresses)
            {
                EmailAddressEntity emailAddress = new() { Address = item.Email, PeopleId = peopleId };
                int _id = _emailAddressRepository.Create(emailAddress);
                item.Id = _id;
            }
        }

        private void SetIdPeoplePhones(CreatePeopleDto input, int peopleId)
        {
            foreach (var phone in input?.Phones)
            {
                PhonesEntity phonesEntity = new() { Number = phone.Number, PeopleId = peopleId };
                int _id = _phonesRepository.Create(phonesEntity);
                phone.Id = _id;
            }
        }

        public Task<ResultRequestDto<bool>> DeleteAsync(int input)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultRequestDto<List<InfoPeopleDto>>> GetAllPeople()
        {
            try
            {
                List<PeopleEntity> peoples = _peopleRepository.GetAllPeople();
                List<InfoPeopleDto> lsPeople = new List<InfoPeopleDto>();

                foreach (var item in peoples)
                {
                    var phones = _phonesRepository.GetByPeople(item.Id);
                    List<PhoneInfoDto> phoneInfoDtos = new();
                    foreach (var phone in phones)
                    {
                        phoneInfoDtos.Add(new PhoneInfoDto { Id = phone.Id, Number = phone.Number });
                    }

                    var address = _addressRepository.GetByPeople(item.Id);
                    List<AdressInfoDto> addressInfoDtos = new();
                    foreach (var adress in address)
                    {
                        addressInfoDtos.Add(new AdressInfoDto { Id = adress.Id, Address = adress.PhysicalAddress });
                    }

                    var emailAddress = _emailAddressRepository.GetByPeople(item.Id);
                    List<AddressEmailInfoDto> addressEmailInfoDtos = new();
                    foreach (var adressEmail in emailAddress)
                    {
                        addressEmailInfoDtos.Add(new AddressEmailInfoDto { Id = adressEmail.Id, Email = adressEmail.Address });
                    }

                    InfoPeopleDto infoPeopleDto = new()
                    {
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        BirthDate = item.BirthDate,
                        IdentityDocument = item.IdentityDocument,
                        Id = item.Id,
                        PhoneInfos = phoneInfoDtos,
                        AdressInfos = addressInfoDtos,
                        addressEmailInfos = addressEmailInfoDtos
                    };

                    lsPeople.Add(infoPeopleDto);
                }

                return new ResultRequestDto<List<InfoPeopleDto>> { Data = lsPeople, IsSuccess = true, Message = "OK", Response = "200" };
            }
            catch (Exception)
            {
                return new ResultRequestDto<List<InfoPeopleDto>> { Data = new List<InfoPeopleDto>(), IsSuccess = false, Message = "Internal Server Error! Try again later.", Response = "500" };
            }
        }

        public Task<ResultRequestDto<InfoPeopleDto>> GetPeople(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ResultRequestDto<InfoPeopleDto>> UpdateAsync(UpdatePeopleDto input)
        {
            throw new NotImplementedException();
        }
    }
}