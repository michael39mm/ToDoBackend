using System;
using GameStore.API.Data;
using GameStore.API.Dtos;
using GameStore.API.Entities;
using GameStore.API.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.API.EndPoints;

public static class EventsEndpoints
{
    public static WebApplication MapEventsEndpoints(this WebApplication app)
    {
        app.MapGet("/", () => "Hello World!");

        app.MapGet("/events", (GameStoreContext store) =>
            store.Events.Include(e => e.EventType)
            .Where(e => e.Completed == false)
                        .Select(e => e.toDto())
                        .AsNoTracking());

        app.MapGet("/events/{id}", (int id, GameStoreContext store) =>
            store.Events.Include(e => e.EventType)
                        .Where(e => e.Id == id)
                        .Select(e => e.toDto())
                        .SingleOrDefault() is EventDto dto
                ? Results.Ok(dto)
                : Results.NotFound())
            .WithName("getEvents");

        app.MapPost("/events", (CreateEventDto dto, GameStoreContext store) =>
        {
            var entity = dto.ToEntity();
            entity.EventType = store.EventTypes.Find(dto.EventTypeId);
            store.Events.Add(entity);
            store.SaveChanges();
            return Results.CreatedAtRoute("getEvents", new { id = entity.Id }, entity.toDto());
        }).WithParameterValidation();
        app.MapPost("/loginn", (LoginDto dto, GameStoreContext store) =>
        {
            var entity = dto.ToEntity();
            if (store.Users.Any(u => u.Email == dto.Email))
               return Results.Conflict("Email already exists.");
            store.Users.Add(entity);
            store.SaveChanges();
            return Results.Ok(entity);
        });

        app.MapPut("/events/{id}", (GameStoreContext store, updateDto dto, int id) =>
        {
            var existing = store.Events.Find(id);
            if (existing is null) return Results.NotFound();

            store.Entry(existing).CurrentValues.SetValues(dto.ToEntity(id));
            store.SaveChanges();
            return Results.NoContent();
        }).WithParameterValidation();
        app.MapPost("/login", (LoginDto login, GameStoreContext _context, TokenService tokenService) =>
{
    var user = _context.Users.FirstOrDefault(u => u.Email == login.Email && u.Password == login.Password);
    
    if (user is null)
        return Results.Unauthorized();

    var token = tokenService.GenerateJwtToken(user);
    return Results.Ok(new { token });
});


        app.MapDelete("/events/{id}", (int id, GameStoreContext store) =>
        {
            store.Events.Where(e => e.Id == id).ExecuteDelete();
            return Results.NoContent();
        });

        return app;
    }
    

}

