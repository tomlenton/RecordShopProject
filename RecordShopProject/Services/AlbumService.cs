using RecordShopProject.DataModels;
using RecordShopProject.Repositories;

namespace RecordShopProject.Services
{
    public interface IAlbumService
    {
        IEnumerable<Album> GetAllAlbums();
        Album? GetAlbumById(int id);
        Album AddAlbum(Album newAlbum);
    }
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;
        public AlbumService(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }
        public IEnumerable<Album> GetAllAlbums()
        {
            return _albumRepository.GetAllAlbums();
        }
        public Album? GetAlbumById(int id)
        {
            return _albumRepository.GetAlbumById(id);
        }
        public Album AddAlbum(Album newAlbum)
        {
            return _albumRepository.AddAlbum(newAlbum);
        }
    }
}
