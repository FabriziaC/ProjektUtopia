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
    public static class RegexFilter
    {

        /// <summary>
        /// Regex to splitt a text by new lines
        /// </summary>
        public static readonly string SplittColumns = @"\n";

        /// <summary>
        /// Regex to represent a  // comment
        /// </summary>
        public static readonly string regularComments = @"[/]{2}.*";

        /// <summary>
        /// Regex represent /*.......*/  comments
        /// </summary>
        public static readonly string comments = @"?[/]{1}[*]{1}[\s\S]{0,}?[*]{1}[/]{1}";

        /// <summary>
        /// Regex represent XML-Comments -> /// and hope for the best
        /// </summary>
        public static readonly string xmlComments = @"[/]{3}[\s]{1}<summary>[\s\S]+<[/]summary>";

        /// <summary>
        /// Expression representing methods
        /// </summary>
        public static readonly string methods = @"(public|private|sealed|protected|internal){1}[\s]{1,}?(static)?[\s]?(\w)+[\s]+(\w)+[\s]*(\w)+[\s]*[(].+[)][\S\s]+?[\n]*[{][\S\s]*[}]}";


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
            code = FilterOutByRegex(code, xmlComments);

            code = FilterOutByRegex(code, comments);

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
            amount = CountByRegex(code, wrongplacement + xmlComments);
            code = FilterOutByRegex(code, xmlComments);
            amount = amount + CountByRegex(code, wrongplacement + comments);
            code = FilterOutByRegex(code, comments);
            amount = amount + CountByRegex(code, wrongplacement + regularComments);
            return amount;
        }

        public static long CountAllComments(string code)
        {
            long amount = 0;
            amount = CountByRegex(code,xmlComments);
            code = FilterOutByRegex(code, xmlComments);
            amount = amount + CountByRegex(code,comments);
            code = FilterOutByRegex(code, comments);
            amount = amount + CountByRegex(code,regularComments);
            return amount;
        }

        public static List<string> ReturnAllMatches(string text, string regexString)
        {
            List<string> matches = new List<string>();

            Regex regex = new Regex(regexString);

            MatchCollection collection = regex.Matches(text);

            for (int i = 0; i < collection.Count; i++)
            {
                matches.Add(collection[i].Value);
            }

            return matches;
        }

        /// <summary>
        /// Gets all the info from a method in a sring array 0 = public etc, 1 = static ? , 2 = returntype, 3 = name, 4 = paramter , 5 = content
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        internal static string[] GetMethodInfo(string method)
        {
            
            string[] methodInfo = new string[12];

            //beispiel
            methodInfo[5] = ReturnAllMatches(method, @"[{][\S\s]+[}]").First();

            methodInfo[0] = 
            methodInfo[1] =
            methodInfo[2] =
            methodInfo[3] =

            return methodInfo;
        }

    }
}
