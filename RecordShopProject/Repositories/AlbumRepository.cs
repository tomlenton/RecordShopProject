using RecordShopProject.DataModels;
using RecordShopProject.DBContext;

namespace RecordShopProject.Repositories
{
    public interface IAlbumRepository
    {
        List<Album> GetAllAlbums();
        Album AddAlbum(Album newAlbum);
        Album? GetAlbumById(int id);
    }
    public class AlbumRepository : IAlbumRepository
    {
        private readonly RecordShopContext _dbContext;
        public AlbumRepository(RecordShopContext db)
        {
            _dbContext = db;
        }
        public List<Album> GetAllAlbums()
        {
            return _dbContext.Albums.ToList();
        }
        public Album? GetAlbumById(int id)
        {
            return _dbContext.Albums.FirstOrDefault(a => a.AlbumId == id);
        }
        public Album AddAlbum(Album newAlbum)
        {
            _dbContext.Albums.Add(newAlbum);
            _dbContext.SaveChanges();
            return newAlbum;
        }
    }
}
