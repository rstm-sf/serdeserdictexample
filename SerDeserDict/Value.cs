using System;

namespace SerDeserDict
{
    [Serializable]
    public class Value
    {
        public int Id { set; get; }

        public string Text { set; get; }
    }
}
