using System.ComponentModel.DataAnnotations;

namespace GameStore.API.Dtos;

public record updateDto(
    [Required] string Name,
    [Required] DateTime Datetime,
    int EventTypeId,
    Boolean Completed
);