using Http.Server;

namespace Http.Test.Server;

public class HttpRequestParserTest
{
    [Fact]
    public void TestParsingHttpGetRequest()
    {
        var requestMessage = "GET /path?id=1 HTTP/1.1\r\nHost: localhost:8080\r\nUser-Agent: Mozilla/5.0\r\nAccept-Language: fr\r\n\r\n";
        var httpRequest = HttpRequestParser.Parse(requestMessage);

        Assert.Equal("HTTP/1.1", httpRequest.Protocol);
        Assert.Equal("GET", httpRequest.Method);
        Assert.Equal("http", httpRequest.Url.Scheme);
        Assert.Equal("localhost", httpRequest.Url.Host);
        Assert.Equal(8080, httpRequest.Url.Port);
        Assert.Equal("/path", httpRequest.Url.Path);
        Assert.Equal("1", httpRequest.Url.Query.GetValue("id"));
        Assert.Equal("Mozilla/5.0", httpRequest.Headers.GetValue("User-Agent"));
        Assert.Equal("fr", httpRequest.Headers.GetValue("Accept-Language"));
    }
}
