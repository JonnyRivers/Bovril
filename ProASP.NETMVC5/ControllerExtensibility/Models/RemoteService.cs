using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ControllerExtensibility.Models
{
    public class RemoteService
    {
        public String GetRemoteData()
        {
            System.Threading.Thread.Sleep(2000);
            return "Hello from the other side of the world";
        }

        public async Task<String> GetRemoteDataAsync()
        {
            return await Task<String>.Factory.StartNew(() => {
                System.Threading.Thread.Sleep(2000);
                return "Hello from the other side of the world";
            });
        }
    }
}