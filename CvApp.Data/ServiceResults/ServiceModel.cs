using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvApp.Data.ServiceResults
{
    public class ServiceModel
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; } = null;


    }
    public class ServiceModel<T> : ServiceModel
    {
        public new T? Data { get; set; }
    }
}
