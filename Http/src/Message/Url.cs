namespace Http.Message;

public class Url
{
    public string urlString { get; set; }
    public string Scheme { get; set; }
    public string Host { get; set; }
    public int Port { get; set; }
    public string Path { get; set; }
    public QueryDictionary Query { get; set; }

    public Url(string urlString)
    {
        this.urlString = urlString;
        var uri = new Uri(urlString);

        Scheme = uri.Scheme;
        Host = uri.Host;
        Port = uri.Port;
        Path = uri.AbsolutePath;

        var query = new Dictionary<string, string>();
        var pairs = uri.Query.TrimStart('?').Split('&');

        foreach (var pair in pairs)
        {
            var keyValue = pair.Split('=');
            if (keyValue.Length == 2)
            {
                var key = keyValue[0];
                var value = keyValue[1];
                query.Add(key.ToLower(), value);
            }
        }

        Query = new QueryDictionary(query);
    }

    public override string ToString()
    {
        return this.urlString;
    }
}
