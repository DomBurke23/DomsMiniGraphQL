namespace DomsGraphQL.Responses
{
    public class GraphQLResponse
    {
        [JsonProperty("status")]
        public Status Status { get; set; }
    }
}
