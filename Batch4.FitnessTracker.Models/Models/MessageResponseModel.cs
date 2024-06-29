using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch4.FitnessTracker.Models.Models
{
    public class MessageResponseModel
    {
        public MessageResponseModel()
        {

        }

        public MessageResponseModel(bool isSuccess, string? message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public MessageResponseModel(bool isSuccess, Exception ex)
        {
            IsSuccess = isSuccess;
            Message = ex.ToString();
        }

        public bool IsSuccess { get; set; }
        public bool IsError { get { return !IsSuccess; } }
        public string? Message { get; set; }
    }
}
