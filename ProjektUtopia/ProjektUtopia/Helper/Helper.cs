using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ProjektUtopia.Codemetrik.Classes
{
    public static class Helper
    {
        /// <summary>
        /// Generic version to fetch objects derived from the CodeAsText class
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="code"></param>
        /// <param name="regex"></param>
        /// <param name="startInString"></param>
        /// <returns></returns>
        public static List<T> GetObjects<T>(string code,string regex,int startInString =0) where T : CodeAsText,new()
        {
            List <T> textObjects = new List<T>();
            List<string> text = ReturnAllMatches(code, regex);
            text.ForEach(t => {
                int startAt = GetPosition(code, t);
                T listValue = new T();
                listValue.InitialiseFromCode(t,startAt);
                textObjects.Add(listValue);
                }) ;
            return textObjects;
        }

        /// <summary>
        /// Counts all lines in a txt-file
        /// </summary>
        /// <param name="code">text with lines to count</param>
        /// <param name="ignoreEmptyLine">ignore empty lines during counting</param>
        /// <returns></returns>
        public static int CountAllLines(string code, bool ignoreEmptyLine = true)
        {
            if (code == null) return 0;
            string filter = ignoreEmptyLine ? @"[^\n|\t|\r]+" : @".+";
            Regex regex = new Regex(filter);
            MatchCollection matches = regex.Matches(code);
            return matches.Count;
        }
        
        /// <summary>
        /// Finds non-ascii characters in code (except strings and comments)
        /// </summary>
        /// <param name="code">text with lines to count</param>
        /// <returns></returns>
        public static int CountNonAsciiChars(string code)
        {
            if (code == null) return 0;
            //the order in witch you filter out needs to be clear , as regular comments can return a match for parts of an xml - comments  
            //remove comments and string from code
            code = Regex.Replace(code, RegexString.regularComments, "");
            code = Regex.Replace(code, RegexString.comments, "");
            code = Regex.Replace(code, RegexString.multiLineString, "");
            code = Regex.Replace(code, RegexString.singleLineString, "");
            // now look for non-ascii characters
            Regex regex = new Regex(RegexString.nonAsciiChars);
            MatchCollection matches = regex.Matches(code);
            return matches.Count;

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
        /// <param name="regexAsString"></param>
        /// <returns></returns>
        public static string FilterOutByRegex(string code, string regexAsString)
        {
            if (code == null) return null;
            Regex regex = new Regex(regexAsString);
            string[] filtered = regex.Split(code);
            return ChangeStrArrayIntoStr(filtered);
        }

        /// <summary>
        /// returns the amount of matches to a given regex
        /// </summary>
        /// <param name="code"></param>
        /// <param name="regexAsString"></param>
        /// <returns></returns>
        internal static long CountByRegex(string code, string regexAsString)
        {
            Regex regex = new Regex(regexAsString);
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
            long amount = CountByRegex(code, wrongplacement + RegexString.xmlComments);
            code = FilterOutByRegex(code, RegexString.xmlComments);
            amount += CountByRegex(code, wrongplacement + RegexString.comments);
            code = FilterOutByRegex(code, RegexString.comments);
            amount += CountByRegex(code, wrongplacement + RegexString.regularComments);
            return amount;
        }

        /// <summary>
        /// returns all comments in a text
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static long CountAllComments(string code)
        {
            long amount = CountByRegex(code, RegexString.xmlComments);
            code = FilterOutByRegex(code, RegexString.xmlComments);
            amount += CountByRegex(code, RegexString.comments);
            code = FilterOutByRegex(code, RegexString.comments);
            amount += CountByRegex(code, RegexString.regularComments);
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

            if (text != null) { 

                Regex regex = new Regex(regexString);

                MatchCollection collection = regex.Matches(text);

                for (int i = 0; i < collection.Count; i++)
                {
                    matches.Add(collection[i].Value);
                }
            }

            return matches;
        }

        /// <summary>
        /// returns the first occurence of a regex as a string found inside another string
        /// </summary>
        /// <param name="text">the string to search through</param>
        /// <param name="regexString">regex to search by</param>
        /// <returns></returns>
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
        /// returns the start line of a given string or -1 if given an invalid string
        /// </summary>
        /// <param name="text"></param>
        /// <param name="regexString"></param>
        /// <returns></returns>
        public static int GetPosition(string text, string stringToFind)
        {
            try
            {
                int startIndex = text.IndexOf(stringToFind);
                text = text.Remove(startIndex);
                Regex regex = new Regex(@".+");
                MatchCollection matches = regex.Matches(text);

                return matches.Count;
            }
            catch (Exception)
            {
                return -1;
            }         
        }

        /// <summary>
        /// replace a text-snippet matching the regex with an emtpy string
        /// </summary>
        /// <param name="text"></param>
        /// <param name="regexAsString"></param>
        /// <returns></returns>
        public static string ReplaceRegex(string text, string regexAsString)
        {
            Regex regex = new Regex(regexAsString);
            return regex.Replace(text, string.Empty);
        }

        /// <summary>
        /// replace a text-snippet matching the regex with the replacment string
        /// </summary>
        /// <param name="text"></param>
        /// <param name="regexAsString"></param>
        /// <param name="replacment"></param>
        /// <returns></returns>
        public static string ReplaceRegex(string text, string regexAsString, string replacment)
        {
            Regex regex = new Regex(regexAsString); 
            return regex.Replace(text, replacment);
        }

        public static IEnumerable<txtComments> GetAllComments(string temp, string code, int startline = 0)
        {
            List<txtComments> commentNodes = new List<txtComments>();
            commentNodes.AddRange(GetComments(temp, code, RegexString.xmlComments, CommentNodeType.Xml, startline));
            commentNodes.AddRange(GetComments(temp, code, RegexString.comments, CommentNodeType.Regular, startline));
            commentNodes.AddRange(GetComments(temp, code, RegexString.regularComments, CommentNodeType.Generic, startline));
            return commentNodes;
        }

        private static IEnumerable<txtComments> GetComments(string temp, string code, string commentType, CommentNodeType nodeType, int startLine)
        {
            var commentnodes = Helper.GetObjects<txtComments>(temp, commentType);
            commentnodes.ForEach(node => {
                node.StartLine = Helper.GetPosition(code, node.Code) + startLine;
                node.CommentType = nodeType;
            });
            return commentnodes;
        }
    }
}
