using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace API.Models
{
    public abstract class LanguageParser<TModel> : WebViewPage<TModel>
    {

        private const string _PATTERN = ">(.*?)<\\/";


        //Load all dictionaries from BD (caching in redis or runtime)
        private Dictionary<string, Dictionary<string, string>> allTranslations = new Dictionary<string, Dictionary<string, string>>
        {
            {"CAT", new Dictionary<string, string>
                {
                    { "Application name", "Nombre aplicación" },
                    {"Home", "casa" },
                    {"Get more libraries", "Conseguir más librerías" },
                    {"Esta es la opción 3", "aquesta es la opció 3" }
                }
            },
            {"FR", new Dictionary<string, string>
                {
                    { "Application name", "Madamme" },
                    {"Home", "bound jorno" },
                    {"Get more libraries", "rivenderg" },
                    {"Esta es la opción 3", "egsta es la opcioneg 3" }
                }
            }
        };
        //*

        private Dictionary<string, string> CurrentSpecificLanguageTranslations
        {
            get
            {
                return allTranslations[TranslateCode];
            }
        }

        private bool Translate
        {
            get
            {
                bool translateEnabled = false;
                bool.TryParse(HttpContext.Current.Request.QueryString["translate"], out translateEnabled);
                return translateEnabled;
            }
        }

        private string TranslateCode
        {
            get
            {
                if (HttpContext.Current.Request.QueryString["translateCode"] != null)
                    return HttpContext.Current.Request.QueryString["translateCode"].ToString().ToUpper();

                return string.Empty;
            }
        }


        //#if(!DEBUG)

        public override void Write(object value)
        {

            if (value != null && Translate)
            {

                string toAdd = HtmlTranslated(value.ToString());
                if (!string.IsNullOrEmpty(toAdd))
                    value = new MvcHtmlString(toAdd);  
            }

            base.Write(value);
        }

        public override void WriteLiteral(object value)
        {

            if (value != null && Translate)
            {

                string toAdd = HtmlTranslated(value.ToString());
                if (!string.IsNullOrEmpty(toAdd))
                    value = HtmlTranslated(value.ToString());
            }

            base.WriteLiteral(value);

        }

        private string HtmlTranslated(string input)
        {
            var c = ExtractTextAndTryGetTranslation(input);

            foreach(KeyValuePair<string, string> valueTranslated in c)
            {
                input = input.Replace(valueTranslated.Key, valueTranslated.Value);
            }

            return input;
        }
        
        private Dictionary<string, string> ExtractTextAndTryGetTranslation(string input)
        {
            MatchCollection matches = Regex.Matches(input, _PATTERN);

            Dictionary<string, string> textExtracted = new Dictionary<string, string>();

            if (matches.Count > 0)
            {
                foreach (Match m in matches)
                {
                    string translationKey = m.Groups[1].ToString();
                    if (!string.IsNullOrWhiteSpace(translationKey) && !textExtracted.ContainsKey(translationKey))
                    {
                        string keyTranslated = string.Empty;

                        CurrentSpecificLanguageTranslations.TryGetValue(translationKey, out keyTranslated);

                        if (string.IsNullOrEmpty(keyTranslated))
                        {
                            //No translation Save in BD key for translate if not exists
                        }                        
                        else
                            textExtracted.Add(translationKey, keyTranslated);
                    }
                        
                }
            }

            return textExtracted;

        }

        //#endif
    }
}


