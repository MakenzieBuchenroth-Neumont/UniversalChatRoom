//using Google.Cloud.Translation.V2;
using DeepL;
using UniversalChatRoom.Controllers;

namespace UniversalChatRoom.Models
{
    public class TextTranslator
    {
        private const string authKey = "90336d39-a774-1a2f-dc15-a7632da9bf1d:fx"; // string object that keeps the authentication key
		private Translator translator = new Translator(authKey); // Translator object that performs the translations

		public async Task<string> newTextAsync(string? text)
        {
            // First checks if there is any text being passed in.
            if (string.IsNullOrEmpty(text)) return "";

            // translates the text sent in. await and having the file be async makes the pages load slower.
            var translatedText = await translator.TranslateTextAsync(text, null, "en-US", new TextTranslateOptions { PreserveFormatting = true });
            // var "text" is what we are wanting to translate. second pass in is a Language Code. You can also do either the string version of it,
            // or to null, which makes it auto-detect. third pass in is also a Language Code. Works the same as the second, but can't be auto detect.
            // fourth pass in is some of the extra details. included here is just something that says to keep the line breaks and symbols the same,
            // and only changing the translated words.
            return translatedText.Text;
            // returns the original text after translated. anything it cant translate will just be sent back how it originally was.

        }
        
		// this is to do one where you pass in the language
		public async Task<string> translateToPassedIn(string? text, string? sourceCode, string languageCode)
		{
			if (string.IsNullOrEmpty(text)) return "";
			if (string.IsNullOrEmpty(languageCode)) return "";
			if (!string.IsNullOrEmpty(sourceCode)) sourceCode = LanguageCode.RemoveRegionalVariant(sourceCode);
			//if (sourceCode == "en-US" || sourceCode == "en-GB") sourceCode = "en";


			// try catch because that means it will catch if the language passed in isn't correct, returns the original text if language dont work
			try
			{
				var translatedText = await translator.TranslateTextAsync(text, sourceCode, languageCode, new TextTranslateOptions { PreserveFormatting = true });
				return translatedText.Text;
			}
			catch (Exception e)
			{
				return text;
			}
		}

		public async Task<string> translateToPassedIn(string? text, string languageCode) {
			return await translateToPassedIn(text, null, languageCode);
		}
	}
}
