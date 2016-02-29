using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bovril.ContentAddressableStorage
{
    public static class ContentAddressableStoreFactory
    {
        public static IContentAddressableStore CreateLocalContentAddressableStore(String localBaseDirectory)
        {
            return new ContentAddressableStore(localBaseDirectory);
        }
    }
}
