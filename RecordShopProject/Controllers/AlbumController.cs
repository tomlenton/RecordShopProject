using Microsoft.AspNetCore.Mvc;
using RecordShopProject.DataModels;
using RecordShopProject.Services;

namespace RecordShopProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumService _albumService;
        public AlbumsController(IAlbumService albumService)
        {
            _albumService = albumService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Album>> GetAll()
        {
            var albums = _albumService.GetAllAlbums();
            return Ok(albums);
        }
        [HttpGet("{id}")]
        public ActionResult<Album> GetById(int id)
        {
            var album = _albumService.GetAlbumById(id);
            if (album == null)
                return NotFound();
            return Ok(album);
        }
        [HttpPost]
        public ActionResult<Album> Create(Album newAlbum)
        {
            var created = _albumService.AddAlbum(newAlbum);
            return CreatedAtAction(nameof(GetById), new { id = created.AlbumId }, created);
        }
    }
}
