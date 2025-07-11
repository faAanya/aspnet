using System;
using System.Net.Http.Headers;
using store.DTOs;
using store.Entities;

namespace store.Mapping;

public static class GenreMapping
{
    public static GenreDTO ToDTO(this Genre genre)
    {
        return new GenreDTO(genre.Id, genre.Name);
    }
}
