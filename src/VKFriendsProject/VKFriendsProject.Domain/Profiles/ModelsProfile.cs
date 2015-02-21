using AutoMapper;
using VK.WindowsPhone.SDK.API;
using VK.WindowsPhone.SDK.API.Model;
using VKFriendsProject.Domain.Models;

namespace VKFriendsProject.Domain.Profiles
{
    public class ModelsProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<VKUser, FriendViewModel>()
              .ForMember(x => x.Image, x => x.MapFrom(z => z.photo_max))
              .ForMember(x => x.FullName, x => x.MapFrom(z => string.Format("{0} {1}", z.first_name, z.last_name)))
              .ForMember(x => x.Online, x => x.MapFrom(z => z.online == 1))
              .ForMember(x => x.Url, x => x.MapFrom(z => string.Format("https://vk.com/{0}", z.domain)));

            CreateMap<VKBackendResult<object>, VkErrorResult>()
                .ForMember(x => x.Error, x => x.MapFrom(z => z.Error))
                .ForMember(x => x.ErrorCode, x => x.MapFrom(z => z.ResultCode));
        }
    }
}