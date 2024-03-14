using DiscoApp.Web.Services;
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
    public void OnGet()
    {
    }
}
