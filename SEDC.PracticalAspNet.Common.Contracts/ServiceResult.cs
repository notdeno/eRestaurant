using System;
using System.Collections.Generic;

namespace SEDC.PracticalAspNet.Common.Contracts
{
    public class ServiceResult<T>
    {
        public T Item { get; set; }

        public IList<T> ListItems { get; set; }

        public bool Success { get; set; }

        public string ErrorMessage { get; set; }

        public Exception Exception { get; set; }
    }
}
