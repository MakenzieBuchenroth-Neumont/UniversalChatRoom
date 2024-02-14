//using Google.Cloud.Translation.V2;
using DeepL;
using UniversalChatRoom.Controllers;

namespace UniversalChatRoom.Models
{
    public class TextTranslator
    {
        //public string newText(string? text)
        //{
        //    if (text == null) return "";
        //    TranslationClient client = TranslationClient.Create();
        //    TranslationResult result = client.TranslateText(text, LanguageCodes.French);
        //    //TranslationResult result = client.TranslateText(text, selected);
        //    //return result.ToString();
        //    return "hello";
        //    return $"Result: {result.TranslatedText}; detected language {result.DetectedSourceLanguage}";
        //    //Console.WriteLine($"Result: {result.TranslatedText}; detected language {result.DetectedSourceLanguage}");
        //}
        
        string authKey = "90336d39-a774-1a2f-dc15-a7632da9bf1d:fx"; // Replace with your key
        public async Task<string> newTextAsync(string? text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            var translator = new Translator(authKey);

            // Translate text into a target language, in this case, French:
            var translatedText = await translator.TranslateTextAsync(text, LanguageCode.English, "fr");
            return translatedText.Text; // "Bonjour, le monde !"
            // Note: printing or converting the result to a string uses the output text.
        }
    }
}
