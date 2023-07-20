using System.ComponentModel.DataAnnotations;

namespace JacobMDoesThingsWebsite2.Web.Models;

public class PageVisitDTO : BaseDTO, IValidatableObject
{
    public string? SessionInformationId { get; set; }
    public string? URI { get; set; } = string.Empty;
    public DateTimeOffset StartTime { get; set; }
    public DateTimeOffset EndTime { get; set; }

    ///<inheritdoc/>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (EndTime < StartTime)
        {
            yield return new ValidationResult($"{EndTime} cannot be before {EndTime}.", new[] { nameof(StartTime), nameof(EndTime) });
        }
    }
}
