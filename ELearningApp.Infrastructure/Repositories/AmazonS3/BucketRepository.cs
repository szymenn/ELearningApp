using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using ELearningApp.Core.Interfaces.Repositories.AmazonS3;

namespace ELearningApp.Infrastructure.Repositories.AmazonS3
{
    public class BucketRepository : IBucketRepository
    {
        private readonly IAmazonS3 _s3Client;

        public BucketRepository(IAmazonS3 s3Client)
        {
            _s3Client = s3Client;
        }
        
        public async Task<bool> DoesS3BucketExist(string bucketName)
        {
            return await _s3Client.DoesS3BucketExistAsync(bucketName);
        }

        public async Task<PutBucketResponse> PutBucket(string bucketName)
        {
            var putBucketRequest = new PutBucketRequest
            {
                BucketName = bucketName,
                UseClientRegion = true
            };

            return await _s3Client.PutBucketAsync(putBucketRequest);
        }

        public async Task<ListBucketsResponse> GetBuckets()
        {
            return await _s3Client.ListBucketsAsync();
        }

        public async Task<DeleteBucketResponse> DeleteBucket(string bucketName)
        {
            return await _s3Client.DeleteBucketAsync(bucketName);
        }
    }
}