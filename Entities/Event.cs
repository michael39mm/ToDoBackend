using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace GameStore.API.Entities;

public class Event
{
    public int Id { get; set; }
    public required String Name{ get; set; }
    public required DateTime Datetime { get; set; }
    public  EventType EventType { get; set; }
    public int EventTypeId { get; set; }


}
