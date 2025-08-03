using System;

namespace GameStore.API.Entities;

public class EventType
{
    public required String Name { get; set; } = null!;
    public int EventTypeId { get; set; }
}
