using CvApp.Data.ServiceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvApp.Data.ServiceResults
{
    
    public static class ServiceResult
    {
        public static ServiceModel Success(string? message, object? data = default)
        {

            return new ServiceModel
            {
                IsSuccess = true,
                Message = message,
                Data = data,
            };
        }
        public static ServiceModel<T> Success<T>(string? message, T? data = default)
        {
            return new ServiceModel<T>
            {
                IsSuccess = true,
                Message = message,
                Data = data
            };
        }
        public static ServiceModel Success(string? message)
        {
            return new ServiceModel
            {
                IsSuccess = true,
                Message = message

            };

        }
        public static ServiceModel<T> Success<T>(string message)
        {
            return new ServiceModel<T>
            {
                IsSuccess = true,
                Message = message
            };
        }
        public static ServiceModel Error(string? message)
        {
            return new ServiceModel
            {
                IsSuccess = false,
                Message = message
            };
        }
        public static ServiceModel<T> Error<T>(string message)
        {
            return new ServiceModel<T>
            {
                IsSuccess = false,
                Message = message
            };
        }

    }
}
