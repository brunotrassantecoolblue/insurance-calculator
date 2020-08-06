using System;
using System.Runtime.Serialization;

namespace Insurance.Infrastructure
{
    [Serializable]
    internal class DependencyApiException : Exception
    {
        private string productTypeResource;
        private int productTypeId;

        public DependencyApiException()
        {
        }

        public DependencyApiException(string message) : base(message)
        {
        }

        public DependencyApiException(string productTypeResource, int productTypeId) : base(CreateMessage(productTypeResource, productTypeId))
        {
            this.productTypeResource = productTypeResource;
            this.productTypeId = productTypeId;
        }

        private static string CreateMessage(string productTypeResource, int productTypeId)
        {
            throw new NotImplementedException();
        }

        public DependencyApiException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DependencyApiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}