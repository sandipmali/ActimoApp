using System;
using System.Collections.Generic;
using System.Text;

namespace Actimo.Business.Services
{
    public class ApiUriService
    {
        public readonly string BaseUri;
        public readonly string ContactApiUri;
        public readonly string ContactManagerApiUri;

        public ApiUriService(string baseUri,string contactApiUri,string contactManagerApiUri)
        {
            BaseUri = baseUri;
            ContactApiUri = contactApiUri;
            ContactManagerApiUri = contactManagerApiUri;
        }        
    }
}
