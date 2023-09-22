using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvApp.Business.Services.Abstract
{
    public interface IAuthManager 
    {
        public string? GenerateToken(string userName, string password);
    }
}
