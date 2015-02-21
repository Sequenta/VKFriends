using JetBrains.Annotations;
using VK.WindowsPhone.SDK.API;

namespace VKFriendsProject.Domain.Models
{
    public class VkErrorResult
    {
        [CanBeNull]
        public VKError Error { get; set; }
        public int ErrorCode { get; set; }
    }
}