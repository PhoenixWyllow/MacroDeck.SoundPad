using System.Text.Json;
using System.Text.Json.Serialization;

namespace PW.MacroDeck.SoundPad.Models
{
    public interface ISerializableConfiguration
    {
        public string Serialize();

        protected static T Deserialize<T>(string configuration) where T : ISerializableConfiguration, new() =>
            !string.IsNullOrWhiteSpace(configuration) ? JsonSerializer.Deserialize<T>(configuration, SerializerOptions) : new();

        protected static JsonSerializerOptions SerializerOptions { get; } = new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
    }
}