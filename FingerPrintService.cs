using Entities.Model.FingerPrint.Input;
using Entities.Model.FingerPrint.View;
using KonnectApiv4.Application.IRepository;
using KonnectApiv4.Application.IService;

namespace KonnectApiv4.Infrastructure.Service;

public class FingerPrintService: IFingerPrintService
{
    private readonly IFingerPrintRepo _fingerPrintRepo;

    public FingerPrintService(IFingerPrintRepo fingerPrintRepo)
    {
        _fingerPrintRepo = fingerPrintRepo;
    }

    public Task<FingerPrint> AddFingerPrintAsync(FingerPrintInp model)
    {
        return _fingerPrintRepo.AddFingerPrintAsync(model);
    }

    public Task<IEnumerable<FingerPrint>> GetAllFingerPrintAsync()
    {
        return _fingerPrintRepo.GetAllFingerPrintAsync();
    }
}