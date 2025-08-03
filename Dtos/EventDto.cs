using System.ComponentModel.DataAnnotations;
using GameStore.API.Entities;

namespace GameStore.API.Dtos;

public record EventDto(
    int Id,
    [Required]string Name,
    [Required]DateTime Datetime, 
    [Required]string EventType
);
