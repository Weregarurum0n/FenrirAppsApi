using Microsoft.AspNetCore.Http;

namespace AnimeCharacterBirthdayApi.Shared
{
    public class RequestInfo : IRequestInfo
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RequestInfo(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int UserId => _httpContextAccessor.HttpContext.Request.Headers["UsernameId"].ToSafeInt32();
    }
}
