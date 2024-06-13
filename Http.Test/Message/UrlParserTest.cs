using Http.Message;

namespace Http.Test.Message;

public class UrlParserTest
{
    [Fact]
    public void TestParsingUrl()
    {
        string urlString = "https://localhost:8080/path?id=1";
        var url = new Url(urlString);

        Assert.Equal("https", url.Scheme);
        Assert.Equal("localhost", url.Host);
        Assert.Equal("/path", url.Path);
        Assert.Equal("/path", url.Path);
        Assert.Equal("1", url.Query.GetValue("id"));
    }
}
