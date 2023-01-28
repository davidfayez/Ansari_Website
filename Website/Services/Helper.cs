using System.Collections;
using Ansari_Website.Application.Common.Resources;
using Ansari_Website.Domain.Enums;

namespace Website.Services;

public static class Helper
{
    public static int GenerateOTP(int Size = 4)
    {
        // Generates a random number within a range.      
        string min = "1";
        string max = "9";
        for (int i = 1; i < Size; i++)
        {
            min = min + "0";
            max = max + "9";
        }
        Random _random = new Random();
        return _random.Next(Convert.ToInt32(min), Convert.ToInt32(max));
    }


    public static List<int> GetYears()
    {
        return Enumerable.Range(1970, (DateTime.Now.Year + 3) - 1970).Reverse().ToList();
    }

    public static string GetLocalization(string Key, int Lang)
    {
        global::System.Resources.ResourceManager _resourceManager = new global::System.Resources.ResourceManager("Watan.Recruting.Resources.Resources.Language", typeof(Global).Assembly);
        return _resourceManager.GetString(Key, new System.Globalization.CultureInfo((Lang == (int)ELanguages.AR ? "ar-EG" : "en")));
    }

    public static dynamic GetallLocalizationByLang(int Lang = (int)ELanguages.EN)
    {
        global::System.Resources.ResourceManager MyResourceClass = new global::System.Resources.ResourceManager("Watan.Recruting.Resources.Resources.Language", typeof(Global).Assembly);
        var lang = ((ELanguages)Lang).ToString().ToLower();
        global::System.Resources.ResourceSet resourceSet =
           MyResourceClass.GetResourceSet(new System.Globalization.CultureInfo((Lang == (int)ELanguages.AR ? "ar-EG" : "en")), true, true);

        return resourceSet.Cast<DictionaryEntry>().Select(x => new
        {
            Key = x.Key.ToString(),
            Value = x.Value.ToString()
        }).ToList();
    }

    public static bool IsArabic
    {
        get { return (Thread.CurrentThread.CurrentCulture.Name == "ar-EG" ? true : false); }
        set { IsArabic = (Thread.CurrentThread.CurrentCulture.Name == "ar-EG" ? true : false); }
    }
    
}
