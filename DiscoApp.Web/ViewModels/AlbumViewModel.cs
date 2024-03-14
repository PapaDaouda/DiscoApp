namespace DiscoApp.Web.ViewModels;

public record AlbumViewModel(
    int Id,
    string Nom,
    int NombreDeTitre,
    string Artist,
    string GenreMusical,
    DateOnly DateSortie
);