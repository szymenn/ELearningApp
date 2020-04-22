using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.S3;
using ELearningApp.Core.Interfaces.Repositories.AmazonS3;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace ELearningApp.Infrastructure.Repositories.AmazonS3
{
    public class FileRepository : IFileRepository
    {
        private IAmazonS3 _s3Client;

        public FileRepository(IAmazonS3 s3Client)
        {
            _s3Client = s3Client;
        }

        public async Task<IEnumerable<string>> UploadFiles(string bucketName, IEnumerable<FormFile> formFiles)
        {
            throw new NotImplementedException();
        }
    }
}