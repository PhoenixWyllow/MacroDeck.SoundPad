using SuchByte.MacroDeck.Plugins;
using System.Collections.Generic;
using System.Drawing;
using PW.MacroDeck.SoundPad.Services;
using PW.MacroDeck.SoundPad.Models;

namespace PW.MacroDeck.SoundPad
{
    public class Main : MacroDeckPlugin
    {
        private static MacroDeckPlugin Instance { get; set; }

        /// <summary>
        /// Short description what the plugin can do
        /// </summary>
        public override string Description => LocalizationManager.Instance.PluginDescription;

        /// <summary>
        /// Icon for the plugin
        /// </summary>
        public override Image Icon => Properties.Resources.MacroDeckSoundPad;

        /// <summary>
        /// Can the plugin be configured? E.g. accounts
        /// </summary>
        public override bool CanConfigure => false;

        /// <summary>
        /// Gets called when Macro Deck enables the plugin
        /// </summary>
        public override void Enable()
        {
            LocalizationManager.CreateInstance();
            Instance = this;

            Actions = new List<PluginAction>
            {
            };
        }

        /// <summary>
        /// Gets called when the user wants to configure the plugin
        /// </summary>
        public override void OpenConfigurator()
        {
        }
    }
}
