namespace DiscoApp.Api.Dtos;

public record CreateAlbumDto(
    string Nom,
    int NombreDeTitre,
    string Artist,
    string GenreMusical,
    DateOnly DateSortie
);

