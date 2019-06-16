using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjektUtopia
{
    /// <summary>
    /// Collection of diffrent filters currently for removing comments
    /// </summary>
    public class RegexFilter
    {

        /// <summary>
        /// Regex to splitt a text by new lines
        /// </summary>
        public static readonly string SplittColumns = @"\n";

        /// <summary>
        /// Regex to Filter out a simple // comment
        /// </summary>
        public static readonly string regularComments = @"[/]{2}.*";

        /// <summary>
        /// Regex to Filter out /*.......*/  comments
        /// </summary>
        public static readonly string Comments = @"?[/]{1}[*]{1}[\s\S]{0,}?[*]{1}[/]{1}";

        /// <summary>
        /// Regex to Filter out XML-Comments -> /// and hope for the best
        /// </summary>
        public static readonly string XMLComments = @"[/]{3}[\s]{1}<summary>[\s\S]+<[/]summary>";

        /// <summary>
        /// Filters out all Comments for strings, Lists of strings or string arrays
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="text"></param>
        /// <returns></returns>
        public static List<string> FilterOutCommentsAdapter<T>(T text) where T : class
        {
            string code = null;
            if (typeof(T) != typeof(string) && typeof(T) != typeof(string[]) && typeof(T) != typeof(List<string>))
            {
                throw new Exception("The function requires a string,string[] or List<string> variable");
            }
            if (typeof(T) == typeof(string[]))
            {
                string[] textStrArr = text as string[];
                if (textStrArr != null)
                {
                    code = ChangeStrArrayIntoStr(textStrArr, true);
                }
            }

            else if (typeof(T) == typeof(List<string>))
            {
                List<string> stringAsList = text as List<string>;
                if (stringAsList != null)
                {
                    foreach (var item in stringAsList)
                    {
                        code = code + item + "\n";
                    }
                }
            }
            return FilterComments(code);
        }

        /// <summary>
        /// Filters comments out of a string starting with XML 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static List<string> FilterComments(string code)
        {
            code = FilterOutByRegex(code, XMLComments);

            code = FilterOutByRegex(code, Comments);

            code = FilterOutByRegex(code, regularComments);

            Regex regex = new Regex(SplittColumns);

            return regex.Split(code).ToList();
        }

        /// <summary>
        /// Combines all elements of a string array into one string, also a new line each time it adds a string-element as default
        /// </summary>
        /// <param name="array">string array</param>
        /// <param name="newline"> adds a new line of the end of each string</param>
        /// <returns></returns>
        public static string ChangeStrArrayIntoStr(string[] array, bool newline = false)
        {
            string code = null;
            string newlineStr = string.Empty;
            if (newline)
            {
                newlineStr = "\n";
            }

            foreach (var item in array)
            {
                code = code + item + newlineStr;
            }

            return code;
        }

        /// <summary>
        /// returns a string with the 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="RegexString"></param>
        /// <returns></returns>
        internal static string FilterOutByRegex(string code, string RegexString)
        {
            string[] filtered = null;
            Regex regex = new Regex(RegexString);
            filtered = regex.Split(code);
            return ChangeStrArrayIntoStr(filtered);

        }

        /// <summary>
        /// returns the amount of matches to a given regex
        /// </summary>
        /// <param name="code"></param>
        /// <param name="RegexString"></param>
        /// <returns></returns>
        internal static long CountByRegex(string code, string RegexString)
        {
            Regex regex = new Regex(RegexString);
            MatchCollection match = regex.Matches(code);
            return match.Count;
        }

        /// <summary>
        /// returns the amount of wrongly placed comments
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static long CountAllWronglyPlacedComments(string code)
        {
            string wrongplacement = @".{1}";
            long amount = 0;
            amount = CountByRegex(code, wrongplacement + XMLComments);
            code = FilterOutByRegex(code, XMLComments);
            amount = amount + CountByRegex(code, wrongplacement + Comments);
            code = FilterOutByRegex(code, Comments);
            amount = amount + CountByRegex(code, wrongplacement + regularComments);
            return amount;
        }

        public static long CountAllComments(string code)
        {
            long amount = 0;
            amount = CountByRegex(code,XMLComments);
            code = FilterOutByRegex(code, XMLComments);
            amount = amount + CountByRegex(code,Comments);
            code = FilterOutByRegex(code, Comments);
            amount = amount + CountByRegex(code,regularComments);
            return amount;
        }
    }
}
