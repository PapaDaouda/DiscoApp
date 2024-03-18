using DiscoApp.Web.Services;
using DiscoApp.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace;

public class IndexModel : PageModel
{
    private readonly AlbumsService _albumsService;

    public IndexModel(AlbumsService albumsService)
    {
        _albumsService = albumsService;
    }

    public IList<AlbumViewModel> Albums { get;set; } = default!;
    public async Task OnGetAsync()
    {
        Albums = await _albumsService.GetAlbumsAsync();
    }
}
