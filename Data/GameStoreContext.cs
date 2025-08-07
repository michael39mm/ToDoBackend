using System;
using GameStore.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.API.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{
    public DbSet<Event> Events => Set<Event>();
    public DbSet<User> Users => Set<User>();
    public DbSet<EventType> EventTypes => Set<EventType>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EventType>().HasData(
        new EventType { EventTypeId = 1, Name = "Concert" },
        new EventType { EventTypeId = 2, Name = "Conference" },
        new EventType { EventTypeId = 3, Name = "Workshop" },
        new EventType { EventTypeId = 4, Name = "Tech Talk" }
        );

        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Email = "michael", Password = "mmaher" }
        );




    }
}
