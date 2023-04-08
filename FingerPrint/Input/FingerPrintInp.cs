using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Model.FingerPrint.Input;

public class FingerPrintInp
{
    [JsonIgnore]
    public Guid Id { get; set; }
    [Required]
    public Guid EmployeeId { get; set; }
    [Required]
    public byte[] FingerPrintData { get; set; }
}