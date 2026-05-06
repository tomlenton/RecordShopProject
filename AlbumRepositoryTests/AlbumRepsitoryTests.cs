using Microsoft.EntityFrameworkCore;
using RecordShopProject.Repositories;
using RecordShopProject.DBContext;
using RecordShopProject.DataModels;

namespace RecordShopTests.Repositories
{
    public class AlbumRepositoryTests
    {
        private RecordShopContext _context;
        private AlbumRepository _repo;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<RecordShopContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new RecordShopContext(options);
            _repo = new AlbumRepository(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public void GetAllAlbums_ReturnsAllAlbums()
        {
            _context.Albums.Add(new Album { Name = "Album 1", Artist = "Artist 1" });
            _context.Albums.Add(new Album { Name = "Album 2", Artist = "Artist 2" });
            _context.SaveChanges();

            var result = _repo.GetAllAlbums();

            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetAlbumById_ReturnsCorrectAlbum()
        {
            var album = new Album { Name = "Test Album", Artist = "Artist" };
            _context.Albums.Add(album);
            _context.SaveChanges();

            var result = _repo.GetAlbumById(album.AlbumId);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo("Test Album"));
        }

        [Test]
        public void GetAlbumById_ReturnsNull_WhenNotFound()
        {
            var result = _repo.GetAlbumById(999);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void AddAlbum_AddsAlbumToDatabase()
        {
            var album = new Album { Name = "New Album", Artist = "Artist" };

            var result = _repo.AddAlbum(album);

            Assert.That(_context.Albums.Count(), Is.EqualTo(1));
            Assert.That(result.Name, Is.EqualTo("New Album"));
        }
    }
}