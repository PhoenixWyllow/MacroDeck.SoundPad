using PW.MacroDeck.SoundPad.Services;
using System.Diagnostics;
using System.Text.Json;

namespace PW.MacroDeck.SoundPad.Models
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class RecordActionConfigModel : ISerializableConfiguration
    {
        public RecordingDevice RecordingDevice { get; set; }

        public string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }

        public static RecordActionConfigModel Deserialize(string config)
        {
            return ISerializableConfiguration.Deserialize<RecordActionConfigModel>(config);
        }

        public override string ToString()
        {
            return $"{LocalizationManager.Instance.RecordingDeviceSelection}: {RecordingDevice.AsDisplayString()}";
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
