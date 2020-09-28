namespace Swagger.Gateway.Configuration.Dto
{
    public class Summary
    {
        public string SummaryName { get; set; }

        public Summary(string summary)
        {
            SummaryName = summary;
        }
    }
}