using System.Diagnostics;
using System.Text.Json;

namespace PW.MacroDeck.SoundPad.Models
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class PlayActionConfigModel : ISerializableConfiguration
    {
        public int AudioIndex { get; set; } = -1;
        public SoundpadSound Sound { get; set; }
        public SoundpadCategory Category { get; set; }

        public string Serialize()
        {
            return JsonSerializer.Serialize(this, ISerializableConfiguration.SerializerOptions);
        }

        public static PlayActionConfigModel Deserialize(string config)
        {
            return ISerializableConfiguration.Deserialize<PlayActionConfigModel>(config);
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }

        public override string ToString()
        {
            return Category is null ? Sound.Title : $"{Category.Name}: {Sound.Title}";
        }
    }
}
