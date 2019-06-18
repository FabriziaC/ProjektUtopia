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
        public static readonly string methods = @"(public|private|sealed|protected|internal){1}[\s]{1,}?(static)?[\s]?(\w)+[\s]+(\w)+[\s]*(\w)+[\s]*[(].{0,}?[)][\S\s]+?[\n]*[{][\S\s]*[}]";

        /// <summary>
        /// regex string representing acces modifiers
        /// </summary>
        private static readonly string accesModifier = @"^(public|private|sealed|protected|internal)[\s]+";

        private static readonly string staticModifier = @"^static";
        
        /// <summary>
        /// regex representing the content between { ....} brackets
        /// </summary>
        private static readonly string curvedBracketContent = @"[{][\s\S]+?[}]";

        /// <summary>
        /// regex representing the content between ( .... ) brackets
        /// </summary>
        private static readonly string roundBRacketContent = @"[(].{0,}?[)]";

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

        /// <summary>
        /// returns all comments in a text
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns all text matching a given regex as a list of strings
        /// </summary>
        /// <param name="text"></param>
        /// <param name="regexString"></param>
        /// <returns></returns>
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
        /// returns the acces modifiers to a method or anything really that has the same name
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public static AccessModifiers GetAccesModifier(string text)
        {
            Regex regex = new Regex(accesModifier);

            Match match = regex.Match(text);

            return ParseEnum<AccessModifiers>(match.Value);

        }

        /// <summary>
        /// tries to identify a modifier inside the text, returns the first match  
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static Modifiers GetModifiers(string text)
        {
            string modifiers = @"(Abstract|Async|Const|Event|Extern|In|Out|Override|Readonly|Sealed|Static|Unsafe|Virtial|Volatile";
            Regex regex = new Regex(modifiers);
            Match match = regex.Match(text);

            return ParseEnum<Modifiers>(match.Value);
        }

        /// <summary>
        /// Compares an enum to a string and returns the corrispondig value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        /// <summary>
        /// returns the start as well as the end position of an expresion in the text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="regexString"></param>
        /// <returns></returns>
        public static int[] GetStartAndEndByRegex(string text, string regexString)
        {
            int[] values = new int[2];

            Regex regex = new Regex(regexString);

            //ToDo

            return values;
        }

        /// <summary>
        /// replace a text-snippet matching the regex with an emtpy string
        /// </summary>
        /// <param name="text"></param>
        /// <param name="regexString"></param>
        /// <returns></returns>
        public static string ReplaceRegex(string text, string regexString)
        {
            Regex regex = new Regex(regexString);
            return regex.Replace(text,string.Empty);
        }

        /// <summary>
        /// replace a text-snippet matching the regex with the replacment string
        /// </summary>
        /// <param name="text"></param>
        /// <param name="regexString"></param>
        /// <param name="replacment"></param>
        /// <returns></returns>
        public static string ReplaceRegex(string text, string regexString, string replacment)
        {
            Regex regex = new Regex(regexString);
            return regex.Replace(text, replacment);
        }



    }
}
