using MessagePack;
using System.Collections.Generic;

namespace MessagePackV1
{
    [MessagePackObject]
    public class Data
    {
        [Key(0)]
        public string Id { get; set; } = string.Empty;

        [Key(1)]
        public Dictionary<string, object> ValuePerKey { get; set; } = new Dictionary<string, object>();
    }
}
