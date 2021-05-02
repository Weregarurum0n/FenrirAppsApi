namespace AnimeCharacterBirthdayApi.Shared
{
    public class ApiResponse<T>
    {
        public ApiResponse()
        {
        }

        public ApiResponse(T content)
        {
            Content = content;

            var status = content as ReturnStatus;
            if (status != null)
            {
                Status = status;
            }
            else
            {
                Status = content == null ? new ReturnStatus(204, "No Content") : new ReturnStatus(200, "Ok");
            }
        }

        public T Content { get; set; }
        public ReturnStatus Status { get; set; }
    }
}
