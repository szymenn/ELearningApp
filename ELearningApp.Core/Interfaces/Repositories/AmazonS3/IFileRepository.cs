using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Internal;

namespace ELearningApp.Core.Interfaces.Repositories.AmazonS3
{
    public interface IFileRepository
    {
        Task<IEnumerable<string>> UploadFiles(string bucketName, IEnumerable<FormFile> formFiles);
    }
}