using System.Threading.Tasks;
using Amazon.S3.Model;
using ELearningApp.Core.Interfaces.Repositories.AmazonS3;
using ELearningApp.Core.Interfaces.Services.AmazonS3;

namespace ELearningApp.Core.Services.AmazonS3
{
    public class BucketService : IBucketService
    {
        private readonly IBucketRepository _repository;

        public BucketService(IBucketRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<PutBucketResponse> PutBucket(string bucketName)
        {
            return await _repository.PutBucket(bucketName);
        }

        public async Task<ListBucketsResponse> GetBuckets()
        {
            return await _repository.GetBuckets();
        }

        public async Task<DeleteBucketResponse> DeleteBucket(string bucketName)
        {
            return await _repository.DeleteBucket(bucketName);
        }
    }
}