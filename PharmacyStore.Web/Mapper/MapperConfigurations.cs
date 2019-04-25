using AutoMapper;
using PharmacyStore.Services.dto.DoctorDto;
using PharmacyStore.Services.dto.MedicineCategory;
using PharmacyStore.Services.dto.Medicine;
using PharmacyStore.Services.dto.PurchaseDto;
using PharmacyStore.Web.ViewModels.Purchase;
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

            #region Medicine


            CreateMap<MedicineDto, MedicineVm>();
            CreateMap<MedicineVm, MedicineDto>();

            #endregion

            #region Purchase

            CreateMap<PurchaseDto, PurchaseVm>();
            CreateMap<AddUpdatePurchaseVm, AddUpdatePurchaseDto>();

            #endregion

        }
    }
}