using System.Threading.Tasks;
using ELearningApp.Core.Interfaces.Services.AmazonS3;
using Microsoft.AspNetCore.Mvc;

namespace ELearningApp.Api.Controllers.AmazonS3
{
    [ApiController, Route("[controller]")]
    public class BucketsController : ControllerBase
    {
        private readonly IBucketService _bucketService;

        public BucketsController(IBucketService bucketService)
        {
            _bucketService = bucketService;
        }
        
        [HttpPost("{bucketName}")]
        public async Task<IActionResult> CreateBucket(string bucketName)
        {
            return Ok(await _bucketService.PutBucket(bucketName));
        }

        [HttpGet]
        public async Task<IActionResult> GetBuckets()
        {
            return Ok(await _bucketService.GetBuckets());
        }

        [HttpDelete("{bucketName}")]
        public async Task<IActionResult> DeleteBucket(string bucketName)
        {
            return Ok(await _bucketService.DeleteBucket(bucketName));
        }

    }
}