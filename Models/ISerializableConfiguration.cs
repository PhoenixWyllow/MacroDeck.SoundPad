using System.Text.Json;

namespace PW.MacroDeck.SoundPad.Models
{
    public interface ISerializableConfiguration
    {
        public string Serialize();

        protected static T Deserialize<T>(string configuration) where T : ISerializableConfiguration, new() =>
            !string.IsNullOrWhiteSpace(configuration) ? JsonSerializer.Deserialize<T>(configuration, SerializerOptions) : new T();

        protected static JsonSerializerOptions SerializerOptions { get; } = new JsonSerializerOptions { IgnoreNullValues = true };
    }
}