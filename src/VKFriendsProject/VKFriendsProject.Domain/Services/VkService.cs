using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using VK.WindowsPhone.SDK;
using VK.WindowsPhone.SDK.API;
using VK.WindowsPhone.SDK.API.Model;
using VKFriendsProject.Domain.Models;

namespace VKFriendsProject.Domain.Services
{
    public class VkService : IVkService
    {
        private const string APPID = "4788986";
        public VkService()
        {
            VKSDK.Initialize(APPID);
        }
        public void GetFriendsInfo(int userId, Action<IEnumerable<FriendViewModel>> succcessCallbackFunction, Action<VkErrorResult> errorCallbackFunction)
        {
            var requestParameters = new VKRequestParameters("friends.get", new Dictionary<string, string>
            {
                 {"user_id",userId.ToString()},
                 {"fields","online,photo_max,domain"},
                 {"name_case","nom"}
            });
            VKRequest.Dispatch<VKList<VKUser>>(requestParameters, (result) =>
            {
               
                if (result.ResultCode == VKResultCode.Succeeded)
                {
                    var friendsData = result.Data.items;
                    if (friendsData != null)
                    {
                        var friends = friendsData.Select(Mapper.Map<FriendViewModel>);
                        succcessCallbackFunction(friends);
                    }
                    else
                    {
                        succcessCallbackFunction(new List<FriendViewModel>());
                    }
                }
                else
                {
                    var error = Mapper.Map<VkErrorResult>(result);
                    errorCallbackFunction(error);
                } 
            });
        }
    }
}