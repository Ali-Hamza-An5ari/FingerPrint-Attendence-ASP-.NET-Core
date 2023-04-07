using Entities.Model.Enum;
using Entities.Model.FingerPrint.Input;
using Entities.Model.FingerPrint.View;
using KonnectApiv4.Application.IDal.IWorkBoardDal;
using KonnectApiv4.Application.IRepository;

namespace KonnectApiv4.Infrastructure.Repository;

public class FingerPrintRepo: IFingerPrintRepo
{
    private readonly IFingerPrintDal _fingerPrintDal;

    public FingerPrintRepo( IFingerPrintDal fingerPrintDal)
    {
        _fingerPrintDal = fingerPrintDal;
    }

    public async Task<FingerPrint> AddFingerPrintAsync(FingerPrintInp model)
    {
        if (await _fingerPrintDal.ExistsAsync(model))
                     throw new CustomException(ResponseCodeEnum.AlreadyExists, "FingerPrint already exists");
         
        return await _fingerPrintDal.AddFingerPrintAsync(model);
    }

    public async Task<FingerPrint> GetFingerPrintByIdAsync(Guid fingerPrintId)
    {
        return await _fingerPrintDal.GetFingerPrintByIdAsync(fingerPrintId);
    }

    public async Task<IEnumerable<FingerPrint>> GetAllFingerPrintAsync()
    {
        return await _fingerPrintDal.GetAllFingerPrintAsync();
    }

    public async Task<FingerPrint> GetFingerPrintByEmployeeAsync(Guid employeeId)
    {
        return await _fingerPrintDal.GetFingerPrintByEmployeeAsync(employeeId);
    }

    public async Task<FingerPrint> UpdateFingerPrintAsync(FingerPrintInp model)
    {
        
        if (model.Id == Guid.Empty)
            throw new CustomException(ResponseCodeEnum.Required, "Finger Print Id required");
        if (await _fingerPrintDal.GetFingerPrintByIdAsync(model.Id) == null)
            throw new CustomException(ResponseCodeEnum.Invalid, "Invalid Id");
        if (await _fingerPrintDal.ExistsAsync(model))
            throw new CustomException(ResponseCodeEnum.AlreadyExists, "Finger already exists");

        return await _fingerPrintDal.UpdateFingerPrintAsync(model);
    }

    public Task<bool> RemoveFingerPrintAsync(Guid fingerPrintId)
    {
        throw new NotImplementedException();
    }
}