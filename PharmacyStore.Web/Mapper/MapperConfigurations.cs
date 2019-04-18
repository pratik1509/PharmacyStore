using AutoMapper;
using PharmacyStore.Services.dto.DoctorDto;
using PharmacyStore.Services.dto.MedicineCategory;
using PharmacyStore.Web.Doctor.ViewModels;

namespace PharmacyStore.Web.Mapper
{
    public class MapperConfigurations : Profile
    {
        public void MapperConfiguration()
        {
            #region Doctor

            CreateMap<DoctorDto, DoctorVm>();
            CreateMap<AddUpdateDoctorVm, AddUpdateDoctorDto>();

            #endregion

            #region MedicineCategory


            CreateMap<MedicineCategoryDto, MedicineCategoryVm>();
            CreateMap<MedicineCategoryVm, MedicineCategoryDto>();

            #endregion

        }
    }
}