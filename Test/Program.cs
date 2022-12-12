using Fluent.LibreTranslate;
using System.Data.SqlTypes;
using Test;

//GlobalLibreTranslateSettings.Server = LibreTranslateServer.Translate_terraprint_co;
//GlobalLibreTranslateSettings.ApiKey = null; // if need an apiKey 
//GlobalLibreTranslateSettings.UseRateLimitControl = true; //to avoid "429 Too Many Requests" exception
//GlobalLibreTranslateSettings.RateLimitTimeSpan = TimeSpan.FromSeconds(4); //depends on server configuration, default 4 seconds
////return await "Мир".TranslateAsync(LanguageCode.Russian);
////Console.WriteLine(await "Hello, World!".TranslateAsync(LanguageCode.Finnish));
//Console.WriteLine(await "Cat".TranslateAsync(LanguageCode.Russian));


Translator translator = new Translator();
TranslateRUtoEN translateRUtoEN = TranslateRUtoEN.getInstance();
var transstr = await translator.SetAPI(translateRUtoEN, "Hello");
Console.WriteLine(transstr);
