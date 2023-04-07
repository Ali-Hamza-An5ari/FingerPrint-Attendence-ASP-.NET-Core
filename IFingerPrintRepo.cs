using Entities.Model.FingerPrint.Input;
using Entities.Model.FingerPrint.View;

namespace KonnectApiv4.Application.IRepository;

public interface IFingerPrintRepo
{
    Task<FingerPrint> AddFingerPrintAsync(FingerPrintInp model);
    Task<FingerPrint> GetFingerPrintByIdAsync(Guid fingerPrintId);
    Task<IEnumerable<FingerPrint>> GetAllFingerPrintAsync();
    Task<FingerPrint> GetFingerPrintByEmployeeAsync(Guid employeeId);
    Task<FingerPrint> UpdateFingerPrintAsync(FingerPrintInp model);
    Task<bool> RemoveFingerPrintAsync(Guid fingerPrintId);
}