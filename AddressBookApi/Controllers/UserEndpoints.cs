using Microsoft.EntityFrameworkCore;
using API.Data.Models;
namespace AddressBookApi.Controllers;

public static class UserEndpoints
{
    public static void MapUserEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/User", async (Context db) =>
        {
            return await db.Users_Api.ToListAsync();
        })
        .WithName("GetAllUsers");

        routes.MapGet("/api/User/id", async (int Id, Context db) =>
        {
            return await db.Users_Api.FindAsync(Id)
                is User model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetUserById");

        routes.MapPut("/api/User/id", async (int Id, User user, Context db) =>
        {
            user.Id = Id;
            db.Update(user);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateUser");

        routes.MapPost("/api/User/", async (User user, Context db) =>
        {
            db.Users_Api.Add(user);
            await db.SaveChangesAsync();
            return Results.Created($"/Users/{user.Id}", user);
        })
        .WithName("CreateUser");

        routes.MapDelete("/api/User/id", async (int Id, Context db) =>
        {
            if (await db.Users_Api.FindAsync(Id) is User user)
            {
                db.Users_Api.Remove(user);
                await db.SaveChangesAsync();
                return Results.Ok(user);
            }

            return Results.NotFound();
        })
        .WithName("DeleteUser");

        routes.MapGet("/api/User/default", async (Context db) =>
        {
            var records = await db.Users_Api.ToListAsync();
            var firstRecord = records.First();
            return firstRecord
                is User model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
       .WithName("GetDefaultUser");

        routes.MapGet("/api/User/latest", async (Context db) =>
        {
            var records = await db.Users_Api.ToListAsync();
            var firstRecord = records.Last();
            return firstRecord
                is User model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
       .WithName("GetLatestUser");
    }
}
