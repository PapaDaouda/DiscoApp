namespace DiscoApp.Api.Dtos;

public record UpdateAlbumDto(
    string Nom,
    int NombreDeTitre,
    string Artist,
    string GenreMusical,
    DateOnly DateSortie
);

