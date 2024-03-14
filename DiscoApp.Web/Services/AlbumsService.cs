using DiscoApp.Web.ViewModels;

namespace DiscoApp.Web.Services;

public class AlbumsService
{
    private readonly HttpClient _http;

    public AlbumsService(HttpClient http)
    {
        _http = http;
    }

    public async Task<AlbumViewModel[]> GetAlbumsAsync()
    {
        return await _http.GetFromJsonAsync<AlbumViewModel[]>("albums") ?? [];
    }
}
