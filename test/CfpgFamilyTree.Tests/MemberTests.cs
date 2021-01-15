using System;
using CfpgFamilyTree.Models;
using Xunit;

namespace CfpgFamilyTree.Tests
{
    public class MemberTests : IDisposable
    {
        Member testMember;

        public MemberTests()
        {
            testMember = new Member
            {
                FirstName = "Bartholemew",
                MiddleName = "James",
                LastName = "Allen",
                PreferredName = "Barry",
                ProfilePhotoUrl = "www.fake.com/1234567",
                BirthDay = 31,
                BirthMonth = 10,
                BirthYear = 1990,
                Birthplace = "Central City",
                Residence = "Central City",
                IsAlive = true,
                HasSpouse = true,
                PrimaryParentId = 1,
                SecondaryParentId = 2,
                SpouseId = 5,
                UserId = 144
            };
        }

        public void Dispose()
        {
            testMember = null;
        }

        [Fact]
        public void CanChangeName()
        {
            testMember.FirstName = "Jefferson";
            testMember.LastName = "Pierce";

            Assert.Equal("Jefferson", testMember.FirstName);
            Assert.Equal("Pierce", testMember.LastName);
        }

        [Fact]
        public void CanChangeResidence()
        {
            testMember.Residence = "Starling City";

            Assert.Equal("Starling City", testMember.Residence);
        }

        [Fact]
        public void CanChangeLifeStatus()
        {
            testMember.IsAlive = false;

            Assert.Equal(false, testMember.IsAlive);
        }

        [Fact]
        public void CanChangeMaritalStatus()
        {
            testMember.HasSpouse = false;

            Assert.Equal(false, testMember.HasSpouse);
        }
    }
}