namespace TaskList.Dto.Response
{
    public class Result
    {
        public object Content { get; }
        public ResponseStatus Code { get; }

        public Result(object content, ResponseStatus status)
        {
            Content = content;
            Code = status;
        }
    }
}
