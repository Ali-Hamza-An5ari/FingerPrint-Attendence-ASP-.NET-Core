using Entities.Model.FingerPrint.Input;
using Entities.Model.FingerPrint.View;
using KonnectApiv4.Application.IDal.IWorkBoardDal;
using KonnectApiv4.Application.IHelper;

namespace KonnectApiv4.Infrastructure.Dal;

public class FingerPrintDal: IFingerPrintDal
{
    private readonly IConnections _connections;

    public FingerPrintDal(IConnections connections)
    {
        _connections = connections;
    }

    public async Task<IEnumerable<FingerPrint>> GetAllFingerPrintAsync()
    {
        return await _connections.master.QueryListWithOutTransactionAsync<FingerPrint>("[dbo].[GradeGetAll]");
    }

    public async Task<FingerPrint> AddFingerPrintAsync(FingerPrintInp model)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@EmployeeId", model.EmployeeId);
        parameters.Add("@FingerPrintData", model.FingerPrintData);
        
        return await _connections.master.QueryAsync<FingerPrint>("[dbo].[FingerPrintAdd]", parameters);
    }
    
    public async Task<FingerPrint> GetFingerPrintByIdAsync(Guid fingerPrintId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@Id", fingerPrintId);
        return await _connections.master.QueryAsync<FingerPrint>("[dbo].[[FingerPrintGetById]]", parameters);
    }

    public async Task<FingerPrint> GetFingerPrintByEmployeeAsync(Guid employeeId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@EmployeeId", employeeId);
        return await _connections.master.QueryAsync<FingerPrint>("[dbo].[FingerPrintGetByEmployeeId]", parameters);
    }

    public async Task<bool> ExistsAsync(FingerPrintInp model)
    {
        var parameters = new DynamicParameters();
                var query = "SELECT count(*) from FingerPrints where ";
                if (model.Id != Guid.Empty)
                {
                    parameters.Add("@id", model.Id);
                    query += " (id!=@id) and ";
                }
        
                parameters.Add("@EmployeeId", model.EmployeeId);
                parameters.Add("@FingerPrintData", model.FingerPrintData);
                query += " [EmployeeId]=@EmployeeId and FingerPrintData=@FingerPrintData ";
                var result = await _connections.master.QueryAsync<int>(query, parameters, CommandType.Text);
                return result > 0;
    }

    public async Task<FingerPrint> UpdateFingerPrintAsync(FingerPrintInp model)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@EmployeeId", model.EmployeeId);
        parameters.Add("@FingerPrintData", model.FingerPrintData);
        
        return await _connections.master.QueryAsync<FingerPrint>("[dbo].[FingerPrintUpdate]", parameters);
    }
    
    public async Task<bool> RemoveFingerPrintAsync(Guid fingerPrintId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@Id", fingerPrintId);
        return await _connections.master.ExecuteAsync("[dbo].[FingerPrintRemove]", parameters);
    }
}
