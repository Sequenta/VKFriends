using System;
using System.Collections.Generic;
using VKFriendsProject.Domain.Models;

namespace VKFriendsProject.Domain.Services
{
    public interface IVkService
    {
        void GetFriendsInfo(int userId, Action<IEnumerable<FriendViewModel>> callbackFunction, Action<VkErrorResult> errorCallbackFunction);
    }
}