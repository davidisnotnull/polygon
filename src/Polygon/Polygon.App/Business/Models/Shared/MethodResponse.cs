namespace Polygon.App.Business.Models.Shared
{
    public class MethodResponse(string message, bool error)
    {
        public string Message { get; set; } = message;

        public bool Error { get; set; } = error;

        public MethodResponse(string message) : this(message, false)
        {

        }
    }

    public class MethodResponse<T>
    {
        public T? Content { get; set; }

        public string? Message { get; set; }

        public bool Error { get; set; }

        public MethodResponse(T content)
        {
            Content = content;
        }

        public MethodResponse(T content, string message) : this(content)
        {
            Message = message;
        }

        public MethodResponse(bool error, string message)
        {
            Error = error;
            Message = message;
        }
    }
}
