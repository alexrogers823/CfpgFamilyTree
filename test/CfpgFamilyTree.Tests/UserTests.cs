using System;
using CfpgFamilyTree.Models;
using Xunit;

namespace CfpgFamilyTree.Tests
{
    public class UserTests : IDisposable
    {
        User testUser;

        public UserTests()
        {
            testUser = new User
            {
                FirstName = "Oliver",
                LastName = "Queen",
                Email = "green.arrow@yahoo.com",
                Password = "l1an!yu",
            };
        }

        public void Dispose()
        {
            testUser = null;
        }

        [Fact]
        public void CanChangeName()
        {
            testUser.FirstName = "John";
            testUser.LastName = "Diggle";

            Assert.Equal("John", testUser.FirstName);
            Assert.Equal("Diggle", testUser.LastName);
        }

        [Fact]
        public void CanChangeEmail()
        {
            testUser.Email = "black.canary@yahoo.com";
            
            Assert.Equal("black.canary@yahoo.com", testUser.Email);
        }

        [Fact]
        public void CanChangePassword()
        {
            testUser.Password = "c4naryCry!";

            Assert.Equal("c4naryCry!", testUser.Password);
        }

        // TODO: Write test(s) for testing null values 

    } 
}