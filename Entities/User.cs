using System;

namespace GameStore.API.Entities;

public class User
{
    public int Id{ get; set; }
    public string Email { get; set; } 
    public string Password{ get; set; }
}
