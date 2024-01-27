namespace Network
{
    public class Response
    {
        public bool Success { get; private set; }
        public string ErrorMessage { get; private set; }

        /// <summary> レスポンス成功 </summary>
        public static T Achievement<T>(T response) where T : Response
        {
            response.Success = true;
            response.ErrorMessage = "";

            return response;
        }

        /// <summary> レスポンス失敗 </summary>
        public static T Fail<T>(T response) where T : Response
        {
            response.Success = false;
            response.ErrorMessage = "";

            return response;
        }
    }
}
