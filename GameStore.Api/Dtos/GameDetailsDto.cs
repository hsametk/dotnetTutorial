namespace GameStore.Api.Dtos;

public record GameDetailsDto(
    int Id,
    string Name,
    int GenreID,
    decimal Price,
    DateOnly ReleseDate
);
