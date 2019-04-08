using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace ArcTouch.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        public static string Language
        {
            get => AppSettings.GetValueOrDefault(nameof(Language), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(Language), value);

        }

    }
}
