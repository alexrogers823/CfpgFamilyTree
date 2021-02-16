using System;
using CfpgFamilyTree.Models;
using Xunit;

namespace CfpgFamilyTree.Tests
{
    public class ArtifactTests : IDisposable
    {
        Artifact testArtifact;

        public ArtifactTests()
        {
            testArtifact = new Artifact
            {
                PhotoUrl = "www.familyHistory.com/123",
                Title = "Marriage License 1"
            };
        }

        public void Dispose()
        {
            testArtifact = null;
        }

        [Fact]
        public void CanChangeUrl()
        {
            testArtifact.PhotoUrl = "www.conspiracyTheory.com/123";

            Assert.Equal("www.conspiracyTheory.com/123", testArtifact.PhotoUrl);
        }

        [Fact]
        public void CanChangeTitle()
        {
            testArtifact.Title = "Deed to Rogers house";

            Assert.Equal("Deed to Rogers house", testArtifact.Title);
        }
    }
}