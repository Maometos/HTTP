using System.Collections;

namespace Http.Message;

public class HeaderDictionary : IEnumerable<KeyValuePair<string, string>>
{
    private Dictionary<string, string> items = new();

    public HeaderDictionary() { }

    public HeaderDictionary(Dictionary<string, string> items)
    {
        this.items = items;
    }

    public void Add(string key, string value)
    {
        items.Add(key, value);
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
