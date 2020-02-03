using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;

namespace ELearningApp.Core.Dtos.ApiModels.Auth
{
    public class EmailResponse
    {
        public IEnumerable<string> Errors { get; set; }
        public bool Successful => !(Errors?.Count() > 0);
    }
}