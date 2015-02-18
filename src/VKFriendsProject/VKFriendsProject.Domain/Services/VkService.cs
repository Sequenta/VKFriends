using System;
using System.Collections.Generic;
using System.Diagnostics;
using VK.WindowsPhone.SDK;
using VK.WindowsPhone.SDK.API;
using VK.WindowsPhone.SDK.API.Model;

namespace VKFriendsProject.Domain.Services
{
    public class VkService : IVkService
    {
        private const string APPID = "4788986";
        public VkService()
        {
            VKSDK.Initialize(APPID);
        }
        public void GetFriendsInfo(int userId)
        {
            var requestParameters = new VKRequestParameters("friends.get", new Dictionary<string, string>
            {
                 {"user_id",userId.ToString()},
                 {"count","9"},
                 {"fields","online,photo_max"},
                 {"name_case","nom"}
            });
            VKRequest.Dispatch<VKList<VKUser>>(requestParameters, (result) =>
            {
                if (result.ResultCode == VKResultCode.Succeeded)
                {
                    var data = result.Data;
                    data.items.ForEach(x => Debug.WriteLine("{0} {1} {2} {3}", x.photo_max, x.first_name, x.last_name, x.online));
                }
                else
                {
                    var error = result.Error;
                    var failureCode = result.ResultCode;
                    Debug.WriteLine("{0} {1}", error != null ? error.error_msg : "Something went wrong", failureCode);
                } 
            });
        }
    }
}