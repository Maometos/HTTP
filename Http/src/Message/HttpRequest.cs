namespace Http.Message;

public class HttpRequest
{
    public string Protocol { get; set; } = "HTTP/1.1";
    public string Method { get; set; }
    public Url Url { get; set; }
    public HeaderDictionary Headers { get; set; } = new HeaderDictionary();

    public HttpRequest(string method, Url url, string? protocol = null, HeaderDictionary? headers = null)
    {
        Method = method.ToUpper();
        Url = url;

        if (protocol != null)
        {
            Protocol = protocol;
        }

        if (headers != null)
        {
            Headers = headers;
        }
    }
}
