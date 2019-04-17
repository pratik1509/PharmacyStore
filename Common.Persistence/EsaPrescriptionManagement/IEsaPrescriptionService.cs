using Common.Persistence.EsaPrescriptionManagement.EsaPrescriptionDto;

namespace Common.Persistence.EsaPrescriptionManagement
{
    public interface IEsaPrescriptionService
    {
        void Send(ESAPrescription prescription);
    }
}
