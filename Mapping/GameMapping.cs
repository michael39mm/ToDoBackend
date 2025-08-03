using System;
using GameStore.API.Data;
using GameStore.API.Dtos;
using GameStore.API.Entities;

namespace GameStore.API.Mapping;

public static class GameMapping
{
    public static Event ToEntity(this CreateEventDto dto)
    {
        return new()
        {
            Name = dto.Name,
            Datetime = dto.Datetime,
            EventTypeId = dto.EventTypeId,
            Completed = false
        };
    }
    public static Event ToEntity(this updateDto dto,int id)
    {
        return new()
        {
            Id = id,
            Name = dto.Name,
            Datetime = dto.Datetime,
            EventTypeId = dto.EventTypeId,
            Completed = dto.Completed
        };
    }
    public static EventDto toDto(this Event eventt)
    {
        return new(eventt.Id, eventt.Name, eventt.Datetime, eventt.EventType.Name);
    }
    
    }

