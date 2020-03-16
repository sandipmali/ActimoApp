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
        public readonly string ContactLinkApiUri;
        public readonly string ContactAuthApiUri;
        public readonly string EnagementApiUri;

        public ApiUriService(string baseUri, string contactApiUri, string contactManagerApiUri,
            string contactLinkApiUri, string contactAuthApiUri, string enagementApiUri)
        {
            BaseUri = baseUri;
            ContactApiUri = contactApiUri;
            ContactManagerApiUri = contactManagerApiUri;
            ContactLinkApiUri = contactLinkApiUri;
            ContactAuthApiUri = contactAuthApiUri;
            EnagementApiUri = enagementApiUri;
        }
    }
}
