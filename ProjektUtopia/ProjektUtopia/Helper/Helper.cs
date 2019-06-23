using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ProjektUtopia
{
    public static class Helper
    {
        /// <summary>
        /// Counts all lines in a txt-file
        /// </summary>
        /// <param name="code">text with lines to count</param>
        /// <param name="ignoreEmptyLine">ignore empty lines during counting</param>
        /// <returns></returns>
        public static int CountAllLines(string code, bool ignoreEmptyLine = true)
        {
            string filter = ignoreEmptyLine ? @"[^\n|\t|\r]+" : @".+";
            Regex regex = new Regex(filter);
            MatchCollection matches = regex.Matches(code);
            return matches.Count();
        }

        /// <summary>
        /// Returns all classes represented as a list of strings 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static List<string> GetAllClassesAsText(string code)
        {
            List<string> classes = new List<string>();

            classes = ReturnAllMatches(code, Utilities.RegexString.classWithModifiers);

            return classes;
        }




        public static List<Class> GetAllClasses(string code)
        {
            List<Class> classes = new List<Class>();
            List<string> txtclass = GetAllClassesAsText(code);
            int start = 0;
            int lenght = 0;
            string body = string.Empty;
            string name = string.Empty;
            string leftover = string.Empty;
            foreach (var item in txtclass)
            {
                start = GetStartPosition(code, item);
                lenght = CountAllLines(item, false);
                body = ReturnMatch(item, RegexString.curvedBracketContent);

                //Signatur der Klasse aus der die restlichen infos gefiltert werden
                leftover = FilterOutByRegex(item, RegexString.curvedBracketContent);

               // classes.Add(new Class(leftover, body, start, lenght));

            }


            return classes;
        }

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
            code = FilterOutByRegex(code, RegexString.xmlComments);

            code = FilterOutByRegex(code, RegexString.comments);

            code = FilterOutByRegex(code, RegexString.regularComments);

            Regex regex = new Regex(RegexString.SplittColumns);

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
        /// returns a string without the specidfied regex
        /// </summary>
        /// <param name="code"></param>
        /// <param name="RegexString"></param>
        /// <returns></returns>
        public static string FilterOutByRegex(string code, string RegexString)
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
            amount = CountByRegex(code, wrongplacement + RegexString.xmlComments);
            code = FilterOutByRegex(code, RegexString.xmlComments);
            amount = amount + CountByRegex(code, wrongplacement + RegexString.comments);
            code = FilterOutByRegex(code, RegexString.comments);
            amount = amount + CountByRegex(code, wrongplacement + RegexString.regularComments);
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
            amount = CountByRegex(code, RegexString.xmlComments);
            code = FilterOutByRegex(code, RegexString.xmlComments);
            amount = amount + CountByRegex(code, RegexString.comments);
            code = FilterOutByRegex(code, RegexString.comments);
            amount = amount + CountByRegex(code, RegexString.regularComments);
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

        public static string ReturnMatch(string text, string regexString)
        {
            Regex regex = new Regex(regexString);
            Match match = regex.Match(text);
            return match.Value;
        }


        /// <summary>
        /// returns the acces modifiers to a method or anything really that has the same name
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public static AccessModifiers GetAccesModifier(string text)
        {
            Regex regex = new Regex(RegexString.accesModifier);

            Match match = regex.Match(text);

            return match.Success ? ParseEnum<AccessModifiers>(match.Value) : AccessModifiers.None;

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

            return match.Success ? ParseEnum<Modifiers>(match.Value) : Modifiers.None;
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
        /// returns the start line of a given string
        /// </summary>
        /// <param name="text"></param>
        /// <param name="regexString"></param>
        /// <returns></returns>
        public static int GetStartPosition(string text, string stringToFind)
        {
            int start = 0;

            start = text.IndexOf(stringToFind);

            text = text.Remove(start);

            Regex regex = new Regex(@".+");
            MatchCollection matches = regex.Matches(text);

            return matches.Count;
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
            return regex.Replace(text, string.Empty);
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
