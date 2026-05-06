using Moq;
using RecordShopProject.Services;
using RecordShopProject.Repositories;
using RecordShopProject.DataModels;

namespace RecordShopTests.Services
{
    public class AlbumServiceTests
    {
        private Mock<IAlbumRepository> _mockRepo;
        private AlbumService _service;

        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<IAlbumRepository>();
            _service = new AlbumService(_mockRepo.Object);
        }

        [Test]
        public void GetAllAlbums_ReturnsAlbumsFromRepository()
        {
            var albums = new List<Album>
            {
                new Album { AlbumId = 1, Name = "Test Album", Artist = "Test Artist" }
            };

            _mockRepo.Setup(r => r.GetAllAlbums()).Returns(albums);

            var result = _service.GetAllAlbums();

            Assert.That(result, Is.EqualTo(albums));
        }

        [Test]
        public void GetAlbumById_ReturnsAlbum_WhenExists()
        {
            var album = new Album { AlbumId = 1, Name = "Test" };

            _mockRepo.Setup(r => r.GetAlbumById(1)).Returns(album);

            var result = _service.GetAlbumById(1);

            Assert.That(result, Is.EqualTo(album));
        }

        [Test]
        public void GetAlbumById_ReturnsNull_WhenNotFound()
        {
            _mockRepo.Setup(r => r.GetAlbumById(99)).Returns((Album?)null);

            var result = _service.GetAlbumById(99);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void AddAlbum_ReturnsCreatedAlbum()
        {
            var album = new Album { AlbumId = 1, Name = "New Album" };

            _mockRepo.Setup(r => r.AddAlbum(album)).Returns(album);

            var result = _service.AddAlbum(album);

            Assert.That(result, Is.EqualTo(album));
        }
    }
}
