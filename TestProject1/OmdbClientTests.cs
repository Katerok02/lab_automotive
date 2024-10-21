using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using Project1;

namespace TestProject1
{
    [TestFixture]
    public class OMDbApiClientTests
    {
        private OMDbApiClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new OMDbApiClient("a0e4a358");
        }

        [Test]
        public async Task GetMovieByIdAsync_ReturnsExpectedMovieInfo()
        {
            var movieResponse = await _client.GetMovieByIdAsync("tt3896198");

            Assert.AreEqual("Guardians of the Galaxy Vol. 2", movieResponse.Title);
            Assert.AreEqual("2017", movieResponse.Year);
        }

        [Test]
        public async Task GetMovieByIdAsync_ReturnsExpectedMovieInfo2()
        {
            var movieResponse = await _client.GetMovieByIdAsync("tt2356777");

            Assert.AreEqual("True Detective", movieResponse.Title);
            Assert.AreEqual("2014–", movieResponse.Year);
        }

        [Test]
        public async Task GetMovieByIdAsync_ReturnsNotNull()
        {
            var movieResponse = await _client.GetMovieByIdAsync("tt2356777");

            Assert.NotNull(movieResponse.Title);
        }

        [Test]
        public async Task GetMovieByIdAsync_ReturnFamilyCategory()
        {
            var respond = await _client.DefineMovieRating("tt3896198");

            Assert.AreEqual("Family film", respond);
        }

        [Test]
        public async Task GetMovieByIdAsync_ReturnRestrictedCategory()
        {
            var respond = await _client.DefineMovieRating("tt0387564");

            Assert.AreEqual("Restricted film", respond);
        }

        [Test]
        public async Task GetMovieByIdAsync_ReturnAllCategory()
        {
            var respond = await _client.DefineMovieRating("tt1049413");

            Assert.AreEqual("For all", respond);
        }
    }
}