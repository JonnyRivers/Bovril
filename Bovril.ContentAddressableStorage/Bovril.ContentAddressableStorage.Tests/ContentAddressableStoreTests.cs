using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Bovril.ContentAddressableStorage;

namespace Bovril.ContentAddressableStorage.Tests
{
    [TestClass]
    public class ContentAddressableStoreTests
    {
        [TestMethod]
        public void TestAddContent()
        {
            // Arrange
            var testContent = new byte[] {
                0, 1, 2, 3, 4, 5
            };
            Hash expectedContentHash = Hash.Compute(testContent);
            var testContentStream = new MemoryStream(testContent);
            IContentAddressableStore store = ContentAddressableStoreFactory.CreateLocalContentAddressableStore("TestData");

            // Act
            Hash contentHash = store.AddContent(testContentStream);

            // Assert
            Assert.AreEqual(contentHash, expectedContentHash);
        }

        [TestMethod]
        public void TestContentExists()
        {
            // Arrange
            var testContent = new byte[] {
                0, 1, 2, 3, 4, 5
            };
            Hash expectedContentHash = Hash.Compute(testContent);
            var testContentStream = new MemoryStream(testContent);
            IContentAddressableStore store = ContentAddressableStoreFactory.CreateLocalContentAddressableStore("TestData");

            // Act
            Hash contentHash = store.AddContent(testContentStream);
            bool contentExists = store.ContentExists(contentHash);

            // Assert
            Assert.AreEqual(contentHash, expectedContentHash);
            Assert.IsTrue(contentExists);
        }

        [TestMethod]
        public void TestOpenContentStreamRead()
        {
            // Arrange
            var testContent = new byte[] {
                0, 1, 2, 3, 4, 5
            };
            Hash expectedContentHash = Hash.Compute(testContent);
            var testContentStream = new MemoryStream(testContent);
            IContentAddressableStore store = ContentAddressableStoreFactory.CreateLocalContentAddressableStore("TestData");

            // Act
            Hash contentHash = store.AddContent(testContentStream);
            byte[] contentFromStore;
            Stream contentStream = store.OpenContentStreamRead(contentHash);
            using (BinaryReader reader = new BinaryReader(contentStream))
            {
                contentFromStore = reader.ReadBytes((int)contentStream.Length);
            }

            // Assert
            Assert.AreEqual(contentHash, expectedContentHash);
            Assert.IsTrue(testContent.SequenceEqual(contentFromStore));
        }
    }
}
