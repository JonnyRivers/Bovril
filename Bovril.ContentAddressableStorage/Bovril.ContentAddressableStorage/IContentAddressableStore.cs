using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bovril.ContentAddressableStorage
{
    public interface IContentAddressableStore
    {
        Hash AddContent(Stream contentStream);
        bool ContentExists(Hash contentHash);
        Stream OpenContentStreamRead(Hash contentHash);
    }
}
