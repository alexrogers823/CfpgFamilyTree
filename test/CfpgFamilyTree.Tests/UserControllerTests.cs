using System;
using AutoMapper;
using CfpgFamilyTree.Data;
using CfpgFamilyTree.Profiles;
using Moq;

namespace CfpgFamilyTree.Tests
{
    public class UserControllerTests : IDisposable
    {
        Mock<IUserRepo> mockRepo;
        UsersProfile realProfile;
        MapperConfiguration configuation;
        Mapper mapper;

        public UserControllerTests()
        {
            mockRepo = new Mock<IUserRepo>();
            realProfile = new UsersProfile();
            configuation = new MapperConfiguration(cfg => cfg.AddProfile(realProfile));
            mapper = new Mapper(configuation);
        }

        public void Dispose()
        {
            mockRepo = null;
            realProfile = null;
            configuation = null;
            mapper = null;
        }
    }
}