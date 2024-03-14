namespace DiscoApp.Api.Dtos;

public record AlbumDto(
    int Id,
    string Nom,
    int NombreDeTitre,
    string Artist,
    string GenreMusical,
    DateOnly DateSortie
);
