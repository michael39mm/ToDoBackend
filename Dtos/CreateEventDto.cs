using System.ComponentModel.DataAnnotations;

namespace GameStore.API.Dtos;

public record CreateEventDto(
    [Required] string Name,
    [Required] DateTime Datetime, 
    [Required] int EventTypeId
);
