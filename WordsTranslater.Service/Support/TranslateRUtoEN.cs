using Fluent.LibreTranslate;


namespace WordsTranslater.Service.Support
{
    internal class TranslateRUtoEN
    {
        private static TranslateRUtoEN? instance;
        private TranslateRUtoEN()
        { }

        public static TranslateRUtoEN getInstance()
        {
            if (instance == null)
                instance = new TranslateRUtoEN();
            return instance;
        }
        public async Task<string> Translate(string srcString)
        {
            try
            {
                GlobalLibreTranslateSettings.Server = LibreTranslateServer.Translate_terraprint_co;
                GlobalLibreTranslateSettings.ApiKey = null; // if need an apiKey 
                GlobalLibreTranslateSettings.UseRateLimitControl = true; //to avoid "429 Too Many Requests" exception
                GlobalLibreTranslateSettings.RateLimitTimeSpan = TimeSpan.FromSeconds(4); //depends on server configuration, default 4 seconds
                return await srcString.TranslateAsync(LanguageCode.Russian);
            }
            catch (Exception)
            {
                return "Не работает сервер перевода";
            }
        }
    }
}
