using System;
using Microsoft.EntityFrameworkCore;
using store.Data;
using store.Mapping;

namespace store.Endpoints;

public static class GenresEndpoints
{
    public static RouteGroupBuilder MapGenresEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("genres");

        group.MapGet("/", async (GameStoreContext dbcontext) =>
        {
            await dbcontext.Genres
            .Select(genre => genre.ToDTO())
            .AsNoTracking()
            .ToListAsync();
        });

        return group;
    }
}
