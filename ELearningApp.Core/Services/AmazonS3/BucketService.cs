using System.Threading.Tasks;
using Amazon.S3.Model;
using ELearningApp.Core.Interfaces.Repositories.AmazonS3;
using ELearningApp.Core.Interfaces.Services.AmazonS3;

namespace ELearningApp.Core.Services.AmazonS3
{
    public class BucketService : IBucketService
    {
        private IBucketRepository _repository;

        public BucketService(IBucketRepository repository)
        {
            _repository = repository;
        }
        
        public Task<PutBucketResponse> PutBucket(string bucketName)
        {
            throw new System.NotImplementedException();
        }

        public Task<ListBucketsResponse> GetBuckets()
        {
            throw new System.NotImplementedException();
        }

        public Task<DeleteBucketResponse> DeleteBucket(string bucketName)
        {
            throw new System.NotImplementedException();
        }
    }
}