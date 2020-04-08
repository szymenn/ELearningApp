using System.Threading.Tasks;
using Amazon.S3.Model;

namespace ELearningApp.Core.Interfaces.Services.AmazonS3
{
    public interface IBucketService
    {
        Task<PutBucketResponse> PutBucket(string bucketName);
        Task<ListBucketsResponse> GetBuckets();
        Task<DeleteBucketResponse> DeleteBucket(string bucketName);
    }
}