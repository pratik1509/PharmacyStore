using AutoMapper;
using PharmacyStore.Services.dto.DoctorDto;
using PharmacyStore.Web.DoctorVm.ViewModels;

namespace PharmacyStore.Web.Mapper.DoctorMapper
{
    public class DoctorMapper : Profile
    {
        public DoctorMapper()
        {
            CreateMap<AddUpdateDoctorVm, AddUpdateDoctorDto>();
        }        
    }
}
