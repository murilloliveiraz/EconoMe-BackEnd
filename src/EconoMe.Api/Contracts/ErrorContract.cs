namespace EconoMe.Api.Contracts
{
    public class ErrorContract
    {
        public int StatusCode { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

    }
}