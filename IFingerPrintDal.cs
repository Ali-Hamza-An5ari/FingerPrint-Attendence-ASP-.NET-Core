using Entities.Model.FingerPrint.Input;
using Entities.Model.FingerPrint.View;

namespace KonnectApiv4.Application.IDal.IWorkBoardDal;


public interface IFingerPrintDal
{
    Task<FingerPrint> AddFingerPrintAsync(FingerPrintInp model);
    Task<IEnumerable<FingerPrint>> GetAllFingerPrintAsync();
    Task<FingerPrint> GetFingerPrintByIdAsync(Guid fingerPrintId);
    Task<FingerPrint> GetFingerPrintByEmployeeAsync(Guid employeeId);
    Task<bool> ExistsAsync(FingerPrintInp model);
    Task<FingerPrint> UpdateFingerPrintAsync(FingerPrintInp model);
    Task<bool> RemoveFingerPrintAsync(Guid fingerPrintId);
}
