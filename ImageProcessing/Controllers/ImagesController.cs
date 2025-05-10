using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ImageProcessingApi.Services;

namespace ImageProcessingApi.Controllers
{
    [ApiController]
    [Route("api/images")]
    public class ImagesController : ControllerBase
    {
        private readonly IImageProcessingService _imageService;
        private readonly ICacheService _cacheService;

        public ImagesController(IImageProcessingService imageService, ICacheService cacheService)
        {
            _imageService = imageService;
            _cacheService = cacheService;
        }

        [HttpPost("process")]
        public async Task<IActionResult> ProcessImage([FromQuery] string filter, IFormFile image)
        {
            // Check if the uploaded image is null or empty
            // Copy the uploaded image stream into a memory stream to access its byte array
            // Generate a unique cache key based on the image content and the selected filter
            var cacheKey = ComputeHash(imageBytes, filter);
            // Check if a processed version of this image + filter is already in the cache
            // If found in cache, return the cached image with "image/png" content type


            // Process the image using the selected filter
            var processedImage = _imageService.ApplyFilter(imageBytes, filter);
            // Store the processed image in cache using the generated cache key
            // Return the processed image in the response with the "image/png" content type
            return File(processedImage, "image/png");

        }

        private static string ComputeHash(byte[] image, string filter)
        {
            using var sha = SHA256.Create();
            var inputBytes = image.Concat(Encoding.UTF8.GetBytes(filter)).ToArray();
            return Convert.ToBase64String(sha.ComputeHash(inputBytes));
        }
    }
}