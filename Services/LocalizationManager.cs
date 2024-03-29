﻿/* Created on 2021/10/03 by @PhoenixWyllow (pw.dev@outlook.com) https://github.com/PhoenixWyllow/Soundboard4MacroDeck2
 * 
 * This file is provided "AS-IS".
 * You may reuse this file as you wish, but please keep this attribution notice as long as the code is substantially the same. 
 * Thank you.
 */

using System;
using PW.MacroDeck.SoundPad.Models;
using SuchByte.MacroDeck.Language;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace PW.MacroDeck.SoundPad.Services
{
    internal sealed class LocalizationManager
    {
        private static readonly object key = new object();

        internal static Localization Instance { get; private set; }

        internal static void CreateInstance()
        {
            if (Instance is null)
            {
                GetLocalization();
            }
        }

        private LocalizationManager() { }


        private static void GetLocalization()
        {
            lock (key)
            {
                string languageName = LanguageManager.GetLanguageName();
                if (Instance != null)
                {
                    LanguageManager.LanguageChanged -= OnLanguageChanged;
                }
                try
                {
                    Instance = JsonSerializer.Deserialize<Localization>(GetJsonLanguageResource(languageName));
                }
                catch
                {
                    //fallback - should never occur if things are done properly
                    Instance = new Localization();
                }
                finally
                {
                    LanguageManager.LanguageChanged += OnLanguageChanged;
                }
            }
        }

        private static void OnLanguageChanged(object sender, EventArgs e) => GetLocalization();

        private static string GetJsonLanguageResource(string languageName)
        {
            var assembly = typeof(Localization).Assembly;
            if (string.IsNullOrEmpty(languageName)
                || !assembly.GetManifestResourceNames().Any(name => name.EndsWith($"{languageName}.json")))
            {
                languageName = "English"; //This should always be present as default, otherwise the code goes to fallback implementation.
            }

            string languageFileName = $"PW.MacroDeck.SoundPad.Languages.{languageName}.json";

            using var resourceStream = assembly.GetManifestResourceStream(languageFileName);
            using var streamReader = new StreamReader(resourceStream);
            return streamReader.ReadToEnd();
        }
    }
}
