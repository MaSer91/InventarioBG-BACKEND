namespace InventarioBackend.Models
{
    public class ErrorResponse
    {
        public string Title { get; set; }
        public string Details { get; set; }

        public ErrorResponse(string title, string details)
        {
            Title = title;
            Details = details;
        }
    }
}
