using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Ansari_Website.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ansari_Website.Infrastructure.Common;
public static class ExtensionMethods
{
    #region GetNullableValues

    public static short GetValue(this short? parameter)
    {
        return (short)(parameter.HasValue ? parameter.Value : 0);
    }

    public static int GetValue(this int? parameter)
    {
        return parameter.HasValue ? parameter.Value : 0;
    }

    public static decimal GetValue(this decimal? parameter)
    {
        return parameter.HasValue ? parameter.Value : 0;
    }
    public static decimal GetValue(this decimal parameter)
    {
        return parameter != null ? parameter : 0;
    }
    public static string GetValue(this DateTime? parameter)
    {
        if (parameter.HasValue)
        {
            if (parameter.Value.Year == DateTime.MaxValue.Year)
            {
                return string.Empty;
            }
            else
            {
                return parameter.Value.ToShortDateString();
            }
        }
        else
        {
            return string.Empty;
        }
    }

    #endregion GetNullableValues

    #region Get differnt data formats from Strings

    public static DateTime TryParseToDate(this string data)
    {
        DateTime parsedDate;
        var currentCulture = CultureInfo.CreateSpecificCulture("en-GB");

        if (DateTime.TryParse(data.Trim(), currentCulture, DateTimeStyles.None, out parsedDate))
        {
            return parsedDate;
        }
        return DateTime.MaxValue;
    }

    public static int TryParseToInt(this string data)
    {
        int parsedInt;
        if (int.TryParse(data.Trim(), out parsedInt))
            return parsedInt;
        return 0;
    }

    public static short TryParseToShort(this string data)
    {
        if (data != null)
        {
            short parsedShort;
            if (short.TryParse(data.Trim(), out parsedShort))
                return parsedShort;
        }
        return 0;
    }

    public static float TryParseToFloat(this string data)
    {
        float parsedFloat;
        if (float.TryParse(data.Trim(), out parsedFloat))
            return parsedFloat;
        return 0;
    }

    public static decimal TryParseToDecimal(this string data)
    {
        decimal parsedDecimal;
        if (decimal.TryParse(!string.IsNullOrEmpty(data) ? data.Trim() : "0", out parsedDecimal))
            return parsedDecimal;
        return 0;
    }

    public static double TryParseToDouble(this string data)
    {
        double parsedDouble;
        if (double.TryParse(data.Trim(), out parsedDouble))
            return parsedDouble;
        return 0;
    }

    public static TimeSpan TryParseToTimeSpan(this string data)
    {
        TimeSpan parsedTimeSpan;
        if (TimeSpan.TryParse(data.Trim(), out parsedTimeSpan))
            return parsedTimeSpan;
        return TimeSpan.MinValue;
    }


    #endregion Get differnt data formats from Strings


    #region Other

    public static bool Includes(this string mainString, string substring)
    {
        bool result = mainString.IndexOf(substring, StringComparison.InvariantCultureIgnoreCase) >= 0;
        return result;
    }

    public static bool CompareString(this string firstString, string secondString)
    {
        return string.Equals(firstString, secondString, StringComparison.InvariantCultureIgnoreCase);
    }

    public static DataTable ConvertToDataTable<T>(this IList<T> list)
    {
        DataTable table = CreateTable<T>();
        Type entityType = typeof(T);
        PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

        foreach (T item in list)
        {
            DataRow row = table.NewRow();

            foreach (PropertyDescriptor prop in properties)
            {
                row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
            }
            table.Rows.Add(row);
        }
        return table;
    }

    private static DataTable CreateTable<T>()
    {
        Type entityType = typeof(T);
        DataTable table = new DataTable(entityType.Name);
        PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

        foreach (PropertyDescriptor prop in properties)
        {
            // HERE IS WHERE THE ERROR IS THROWN FOR NULLABLE TYPES
            table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(
            prop.PropertyType) ?? prop.PropertyType);
        }

        return table;
    }
    #endregion Other

    #region Casting Different DataTypes

    public static bool TryParseToBoolean(this short data)
    {
        return Convert.ToBoolean(data);
    }

    public static bool TryParseToBoolean(this decimal data)
    {
        return Convert.ToBoolean(data);
    }
    #endregion

    #region New
    public static int GetUserId(this ClaimsPrincipal User)
    {
        return Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value);
    }
    public static string GetUserMobile(this ClaimsPrincipal User)
    {
        return User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.MobilePhone)?.Value;
    }

    public static string GetUserName(this ClaimsPrincipal User)
    {
        return User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
    }

    public static int GetUserType(this ClaimsPrincipal User)
    {
        return Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Type")?.Value);
    }

    public static string GetUserEmail(this ClaimsPrincipal User)
    {
        return User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
    }

    public static int GetLanguage(string Clanguage)
    {
        return Clanguage.Contains("ar") ? (int)ELanguages.AR : (int)ELanguages.EN;
    }


    public static bool IsValidEmail(this string Email)
    {
        try
        {
            MailAddress m = new MailAddress(Email);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }

    public static bool IsValidPhone(this string Phone)
    {
        try
        {
            // validate phone number agiainst regular expression 
            Regex regex = new Regex(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$");
            Match match = regex.Match(Phone);
            return match.Success;
        }
        catch (FormatException)
        {
            return false;
        }
    }
    public static bool IsValidURL(this string URL)
    {
        try
        {
            // validate phone number agiainst regular expression 
            Regex regex = new Regex(@"[(http(s)?):\/\/(www\.)?a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)");
            Match match = regex.Match(URL);
            return match.Success;
        }
        catch (FormatException)
        {
            return false;
        }
    }
    public static IHttpContextAccessor CheckIsNullOrContextNull(this IHttpContextAccessor httpContextAccessor)
    {
        try
        {
            if (httpContextAccessor == null || httpContextAccessor.HttpContext == null)

                return new HttpContextAccessor() { HttpContext = new DefaultHttpContext() };

            else
                return httpContextAccessor;
        }
        catch (FormatException)
        {
            return new HttpContextAccessor() { HttpContext = new DefaultHttpContext() };
        }
    }

    public static bool IsValidDocExtention(string docName)
    {
        try
        {
            string[] imageEndsWith = { ".PDF", ".DOC", ".DOCX", ".PPT", ".PPTX", ".JPG", ".PNG", ".JPEG" };
            if (!imageEndsWith.Any(x => docName.ToUpper().EndsWith(x)))
            {
                return false;
            }
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }
    public static string GetModelStateErrors(this ModelStateDictionary ModelState)
    {
        return string.Join(',', ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage));
    }

    public static int GetLangIdFromHeader(this HttpRequest Request)
    {
        var env = Request.Headers["Language"].FirstOrDefault();
        if (env == null)
        {
            env = Thread.CurrentThread.CurrentCulture.Name == "en-US" ? Enum.GetName((ELanguages)(int)ELanguages.EN) : Enum.GetName((ELanguages)(int)ELanguages.AR);
        }
        return (int)Enum.Parse(typeof(ELanguages), env?.ToUpper() ?? ELanguages.AR.ToString());
    }

    private static string CheckPassword(string password)
    {
        var ErrorMessage = string.Empty;
        var regx = new Regex("((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$");
        if (regx.IsMatch(password))
            ErrorMessage = "Password is success";
        else
            ErrorMessage = "(Password Must be 8 digits or more, should contain a capital letter, small letter, symbol, and number) one at least of each";


        return ErrorMessage;
    }
    private static string validateEmail(string Email)
    {
        var ErrorMessage = string.Empty;
        var regx = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        if (regx.IsMatch(Email))
            ErrorMessage = "E-mail address accepted";
        else
            ErrorMessage = "invalid Email";


        return ErrorMessage;
    }




    /// <summary>
    /// Extension method used to get from the entity all navigation properties by multiplicity
    /// </summary>
    /// <typeparam name="T">Entity from where the navigation properties are taken</typeparam>
    /// <param name="model">Context Model</param>
    /// <param name="multiplicity">Type of multiplicity to use</param>
    /// <returns>List of PropertyInfo of Navigation Properties</returns>
    public static IEnumerable<PropertyInfo> GetNavigationProperties<T>(this IModel model, RelationshipMultiplicity multiplicity = RelationshipMultiplicity.Many)
    {
        var navigations = model.GetEntityTypes().FirstOrDefault(m => m.ClrType == typeof(T))?.GetNavigations();
        var properties = new List<PropertyInfo>();

        switch (multiplicity)
        {
            case RelationshipMultiplicity.Many:
                return navigations?
                    .Where(nav => nav.IsCollection())
                    .Select(nav => nav.PropertyInfo);
            case RelationshipMultiplicity.One:
                return navigations?
                    .Where(nav => !nav.IsCollection() && nav.ForeignKey.IsRequired)
                    .Select(nav => nav.PropertyInfo);
            case RelationshipMultiplicity.ZeroOrOne:
                return navigations?
                    .Where(nav => !nav.IsCollection())
                    .Select(nav => nav.PropertyInfo);
            default:
                return null;
        }

        return properties;
    }
    public enum RelationshipMultiplicity
    {
        Many = 2,
        One = 1,
        ZeroOrOne = 0
    }
    #endregion
}
