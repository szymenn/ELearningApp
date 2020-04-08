using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.S3.Model;

namespace ELearningApp.Core.Interfaces.Repositories.AmazonS3
{
    public interface IBucketRepository
    {
        Task<bool> DoesS3BucketExist(string bucketName);
        Task<PutBucketResponse> PutBucket(string bucketName);
        Task<ListBucketsResponse> GetBuckets();
        Task<DeleteBucketResponse> DeleteBucket(string bucketName);
    }
}