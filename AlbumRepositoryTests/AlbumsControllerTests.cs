using Moq;
using Microsoft.AspNetCore.Mvc;
using RecordShopProject.Controllers;
using RecordShopProject.Services;
using RecordShopProject.DataModels;

namespace RecordShopTests.Controllers
{
    public class AlbumsControllerTests
    {
        private Mock<IAlbumService> _mockService;
        private AlbumsController _controller;

        [SetUp]
        public void Setup()
        {
            _mockService = new Mock<IAlbumService>();
            _controller = new AlbumsController(_mockService.Object);
        }

        [Test]
        public void GetAll_ReturnsOk_WithAlbums()
        {
            var albums = new List<Album>
            {
                new Album { AlbumId = 1, Name = "Album 1" }
            };

            _mockService.Setup(s => s.GetAllAlbums()).Returns(albums);

            var result = _controller.GetAll();

            var okResult = result.Result as OkObjectResult;

            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(okResult.Value, Is.EqualTo(albums));
        }

        [Test]
        public void GetById_ReturnsOk_WhenFound()
        {
            var album = new Album { AlbumId = 1, Name = "Album 1" };

            _mockService.Setup(s => s.GetAlbumById(1)).Returns(album);

            var result = _controller.GetById(1);

            var okResult = result.Result as OkObjectResult;

            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.Value, Is.EqualTo(album));
        }

        [Test]
        public void GetById_ReturnsNotFound_WhenMissing()
        {
            _mockService.Setup(s => s.GetAlbumById(1)).Returns((Album?)null);

            var result = _controller.GetById(1);

            Assert.That(result.Result, Is.TypeOf<NotFoundResult>());
        }

        [Test]
        public void Create_ReturnsCreatedAtAction_WithAlbum()
        {
            var album = new Album { AlbumId = 1, Name = "New Album" };

            _mockService.Setup(s => s.AddAlbum(album)).Returns(album);

            var result = _controller.Create(album);

            var createdResult = result.Result as CreatedAtActionResult;

            Assert.That(createdResult, Is.Not.Null);
            Assert.That(createdResult.ActionName, Is.EqualTo("GetById"));
            Assert.That(createdResult.Value, Is.EqualTo(album));
        }
    }
}
