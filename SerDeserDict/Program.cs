using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace SerDeserDict
{
    class Program
    {
        static void Main()
        {
            var dict_1 = new SerializableDictionary<int, List<Value>>
            {
                { 1, new List<Value>() { new Value { Id = 1, Text = "text 1" } } }
            };

            var type = typeof(SerializableDictionary<int, List<Value>>);
            var ser = new XmlSerializer(type);
            string str;
            SerializableDictionary<int, List<Value>> dict_2;

            using (var stream = new MemoryStream())
            {
                ser.Serialize(stream, dict_1);
                stream.Position = 0;
                str = System.Text.Encoding.Default.GetString(stream.ToArray());
                dict_2 = (SerializableDictionary<int, List<Value>>)ser.Deserialize(stream);
            }

            Console.WriteLine(str + '\n');
            Console.WriteLine(dict_2[1][0].Text);
        }
    }
}
