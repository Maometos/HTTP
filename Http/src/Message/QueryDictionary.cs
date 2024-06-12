using System.Collections;

namespace Http.Message;

public class QueryDictionary : IEnumerable<KeyValuePair<string, string>>
{
    private Dictionary<string, string> items = new();

    public QueryDictionary(Dictionary<string, string> items)
    {
        this.items = items;
    }

    public bool ContainsKey(string key)
    {
        return items.ContainsKey(key);
    }

    public string? GetValue(string key)
    {
        if (!ContainsKey(key))
        {
            return null;
        }

        return items[key];
    }

    public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
    {
        return items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
