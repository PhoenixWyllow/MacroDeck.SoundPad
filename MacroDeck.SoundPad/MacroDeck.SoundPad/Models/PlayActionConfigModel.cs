using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace PW.MacroDeck.SoundPad.Models
{
    public class PlayActionConfigModel : ISerializableConfiguration
    {
        public int AudioIndex { get; set; }

        public string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }

        public static PlayActionConfigModel Deserialize(string config)
        {
            return ISerializableConfiguration.Deserialize<PlayActionConfigModel>(config);
        }
    }
}
