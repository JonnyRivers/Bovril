using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;

namespace Bovril.ContentAddressableStorage
{
    public class Hash
    {
        public static Hash Compute(byte[] contentData)
        {
            System.Security.Cryptography.SHA1 hashAlgorithm = System.Security.Cryptography.SHA1.Create();
            byte[] hashData = hashAlgorithm.ComputeHash(contentData);

            return new Hash(hashData);
        }

        public static Hash Compute(Stream contentStream)
        {
            System.Security.Cryptography.SHA1 hashAlgorithm = System.Security.Cryptography.SHA1.Create();
            long position = contentStream.Position;
            byte[] hashData = hashAlgorithm.ComputeHash(contentStream);
            contentStream.Position = position;

            return new Hash(hashData);
        }

        public override bool Equals(object rhs)
        {
            if (rhs is Hash)
            {
                Hash rhsHash = (Hash)rhs;
                return this.m_hashData.SequenceEqual(rhsHash.m_hashData);
            }

            return base.Equals(rhs);
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        private Hash(byte[] hashData)
        {
            m_hashData = hashData;
        }

        public override string ToString()
        {
            return BitConverter.ToString(m_hashData).Replace("-", string.Empty);
        }

        private readonly byte[] m_hashData;
    }
}
