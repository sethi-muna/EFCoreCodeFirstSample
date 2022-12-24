using EFCoreCodeFirstSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSample.Services
{
    public interface IAuthenticateService
    {
        string Authenticate(string userName, string Password);
        bool IsTokenValid(string key, string token);
    }
}
