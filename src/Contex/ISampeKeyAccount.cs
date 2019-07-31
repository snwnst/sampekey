using System;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Sampekey.Contex
{
    public interface ISampeKeyAccount
    {
        
        string CreateToken(SampekeyUserAccountRequest model);

    } 
}