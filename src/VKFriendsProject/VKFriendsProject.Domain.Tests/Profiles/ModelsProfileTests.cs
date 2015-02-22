using AutoMapper;
using VKFriendsProject.Domain.Profiles;
using Xunit;

namespace VKFriendsProject.Domain.Tests.Profiles
{
    public class ModelsProfileTests
    {
        [Fact]
        public void TestProfiles()
        {
            Mapper.AddProfile<ModelsProfile>();
            Assert.DoesNotThrow(Mapper.AssertConfigurationIsValid); 
        }
    }
}