using AutoMapper;
using PharmacyStore.Services.dto.DoctorDto;
using PharmacyStore.Web.Doctor.ViewModels;

namespace PharmacyStore.Web.Mapper.DoctorMapper
{
    public class DoctorMapper : Profile
    {
        public DoctorMapper()
        {
            CreateMap<DoctorDto, DoctorVm>();
            CreateMap<AddUpdateDoctorVm, AddUpdateDoctorDto>();
        }
    }
}
