namespace Entities.Model.FingerPrint.View;

public class FingerPrint
{
    public Guid Id { get; set; } = Guid.Empty;
    public Guid EmployeeId { get; set; } = Guid.Empty;
    public byte[] FingerPrintData { get; set; } = new byte[1024];
}