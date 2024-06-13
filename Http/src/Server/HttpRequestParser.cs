using Http.Message;

namespace Http.Server;

public class HttpRequestParser
{
    public static HttpRequest Parse(string requestMessage)
    {
        var request = requestMessage.Split("\r\n\r\n");
        var requestHead = request[0];
        var requestBody = request[1];
        var requestLines = requestHead.Split("\r\n");
        var requestLine = requestLines[0].Split(" ");
        var headers = new HeaderDictionary();

        for (int i = 1; i < requestLines.Length; i++)
        {
            var header = requestLines[i];
            var headerKeyValue = header.Split(": ");
            headers.Add(headerKeyValue[0], headerKeyValue[1]);
        }

        var scheme = requestLine[2].Split("/")[0].ToLower();
        var host = headers.GetValue("Host");

        return new HttpRequest(requestLine[0], new Url(scheme + "://" + host + requestLine[1]), requestLine[2], headers);
    }
}
