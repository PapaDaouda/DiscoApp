using DiscoApp.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

const string GetAlbumEndpointName = "GetAlbum";

List<AlbumDto> albums = [
    new(
        1,
        "Golden Cages",
        10,
        "Faada Fredy",
        "Rap Gospel",
        new DateOnly(2023, 12, 10)
    ),
    new(
        2,
        "Gospel Journey",
        7,
        "Faada Fredy",
        "Gospel",
        new DateOnly(2019, 1, 8)
    )
];

// GET /albums
app.MapGet("albums", () => 
{
    return albums;
})
.WithName(GetAlbumEndpointName)
.WithOpenApi();

// GET /albums/1
app.MapGet("albums/{id}", (int id) => 
{
    // On cherche l'album
    var album = albums.Find(al => al.Id == id);

    if(album == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(album);
    
})
.WithOpenApi();

// POST /albums
app.MapPost("albums", (CreateAlbumDto newAlbum) => 
{
    AlbumDto album = new(
        albums.Count() + 1,
        newAlbum.Nom,
        newAlbum.NombreDeTitre,
        newAlbum.Artist,
        newAlbum.GenreMusical,
        newAlbum.DateSortie
    );

    albums.Add(album);


    return Results.CreatedAtRoute(
        GetAlbumEndpointName, 
        new { id = album.Id}, 
        album);
})
.WithOpenApi();

// PUT albums/1
app.MapPut("albums/{id}", (int id,UpdateAlbumDto updatedAlbum) => 
{
    // On verifie si l'album existe
    var index = albums.FindIndex(al => al.Id == id);

    if(index == -1)
    {
        return Results.NotFound();
    }

    // On Modifie l'album
    albums[index] =  new AlbumDto(
        id,
        updatedAlbum.Nom,
        updatedAlbum.NombreDeTitre,
        updatedAlbum.Artist,
        updatedAlbum.GenreMusical,
        updatedAlbum.DateSortie
    );

    return Results.NoContent();
})
.WithOpenApi();

// DELETE /albums/1
app.MapDelete("albums/{id}", (int id) => 
{
    albums.RemoveAll(al => al.Id == id);

    return Results.NoContent();
})
.WithOpenApi();


app.Run();

