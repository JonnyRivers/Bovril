using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;

namespace Bovril.ContentAddressableStorage
{
    public class ContentAddressableStore : IContentAddressableStore
    {
        private String m_baseDirectory;

        internal ContentAddressableStore(String baseDirectory)
        {
            m_baseDirectory = baseDirectory;

            if (!Directory.Exists(baseDirectory)) 
            {
                Directory.CreateDirectory(baseDirectory);
            }
        }

        public Hash AddContent(Stream contentStream)
        {
            Hash contentHash = Hash.Compute(contentStream);
            String cachePath = GetPathFromHash(contentHash);

            String cacheDirectory = Path.GetDirectoryName(cachePath);
            if (!Directory.Exists(cacheDirectory))
            {
                Directory.CreateDirectory(cacheDirectory);
            }

            using (FileStream cacheStream = File.Create(cachePath))
            {
                contentStream.CopyTo(cacheStream);
            }

            // TODO - we could verify

            return contentHash;
        }

        public bool ContentExists(Hash contentHash)
        {
            String cachePath = GetPathFromHash(contentHash);
            return File.Exists(cachePath);
        }

        public Stream OpenContentStreamRead(Hash contentHash)
        {
            String cachePath = GetPathFromHash(contentHash);
            return File.OpenRead(cachePath);
        }

        private String GetPathFromHash(Hash contentHash) {
            String hashAsHex = contentHash.ToString();
            return String.Format(@"{0}\{1}\{2}\{3}\{4}\{5}", m_baseDirectory, hashAsHex[0], hashAsHex[1], hashAsHex[2], hashAsHex[3], hashAsHex);
        }
    }
}
