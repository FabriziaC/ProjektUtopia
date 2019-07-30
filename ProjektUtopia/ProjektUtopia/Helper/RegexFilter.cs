using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjektUtopia
{


    public static class RegexString
    {
        #region common expressions


        /// <summary>
        /// Using System.Text.RegularExpressions; and similar stuff 
        /// </summary>
        public static readonly string usingDirectives = @"(using)[\s]+[\w]+([\.][\w]+)*[;]";
        
        /// <summary>
        /// Regex to splitt a text by new lines
        /// </summary>
        public static readonly string SplittColumns = @".+";

        /// <summary>
        /// Regex to represent a  // comment
        /// </summary>
        public static readonly string regularComments = @"[\/]{2}.*";

        /// <summary>
        /// Regex represent /*.......*/  comments
        /// </summary>
        public static readonly string comments = @"\*([^*]|[\r\n]|(\*+([^*/]|[\r\n])))*\*"; // taken from https://blog.ostermiller.org/find-comment
                                                    

        /// <summary>
        /// Regex represent XML-Comments -> /// and hope for the best
        /// </summary>
        public static readonly string xmlComments = @"[\/]{3}[\s]{1}<summary>[\s\S]+<[\/]summary>";

        /// <summary>
        /// Regex represent single-line string, taken from https://www.regular-expressions.info/examplesprogrammer.html
        /// </summary>
        public static readonly string singleLineString = @"""[^""\\\r\n]*(?:\\.[^""\\\r\n]*)*""";

        /// <summary>
        /// Regex represent multi-line string, taken from https://www.regular-expressions.info/examplesprogrammer.html
        /// </summary>
        public static readonly string multiLineString = @"@""[^""\\]*(?:\\.[^""\\]*)*""";

        /// <summary>
        /// Regex represent non-ascii characters, taken from https://stackoverflow.com/a/13450715
        /// </summary>
        public static readonly string nonAsciiChars = @"[^\x00-\x7F]";

        /// <summary>
        /// regex string representing acces modifiers
        /// </summary>
        public static readonly string accesModifier = @"^(public|private|sealed|protected|internal|private sealed|private internal)[\s]+";

        /// <summary>
        /// Expression representing the static modifier for Regex operations
        /// </summary>
        public static readonly string staticModifier = @"^static";

        /// <summary>
        /// regex representing the content between { ....} brackets
        /// </summary>
        public static readonly string curvedBracketContent = @"[{][\s\S]+[}]";

        /// <summary>
        /// regex representing the content between ( .... ) brackets
        /// </summary>
        public static readonly string roundBRacketContent = @"[(][\s\S]+[)]";

        #endregion

        #region Namespace Expressions

        /// <summary>
        /// string representing the Name of a name space as a regex
        /// </summary>
        public static readonly string namespacesHead = @" namespace[\s](([\w]+)([\.][\w]+)*)";

        /// <summary>
        /// string representing the whole namespace as a regex
        /// </summary>
        public static readonly string namespaces = @"namespace[\s](([\w]+)([\.][\w]+)*)[\s]+?[{][\S\s]*[}]";

        public static readonly string enums = @"(public|private|internal)?[\s]*enum[\s]+[\w]+[\s]*[{][\s\S]*[}]";

        #endregion

  
        

        #region Classes Expression
        /// <summary>
        /// Expresion representing a class for regex operations, without acces modifiers and others like public or abstract
        /// </summary>
        public static readonly string classWithOutModifiers = @"(class)([\s]{1,}?[\w]+[\s])([:][\s]{1,}?[\w]+(,[\w]+)?)?[\s]+?[{][\s\S]+[}]";

        /// <summary>
        /// regex representing the modifiers a class can have
        /// </summary>
        public static readonly string classModifiers = @"(public|private|sealed|internal)[\s]{1,}?(static|abstaract)?[\s]{1,}?";

        /// <summary>
        /// regex that matches a class-object
        /// </summary>
        public static readonly string classWithModifiers = @"((public|private|sealed|internal)[\s]{1,}?(static|abstaract)?[\s]{1,}?)?(partial[\s]+)?(class)([\s]{1,}?[\w]+[\s])([:][\s]{1,}?[\w]+(,[\w]+)?)?[\s]+?[{][\s\S]+[}]";

        /// <summary>
        /// Regex representing the partial modifier for a namspace
        /// </summary>
        public static readonly string classNamePartial = @"^(partial[\s]+)";

        /// <summary>
        /// regex that matches the class without the content inside the { ...brackets...}
        /// </summary>
        public static readonly string classHead = @"((public|private|sealed|internal)[\s]{1,}?(static|abstaract)?[\s]{1,}?)?(class)([\s]{1,}?[\w]+";
        #endregion

        #region Method expression
        /// <summary>
        /// Expression representing methods
        /// </summary>
        public static readonly string methods = @"(public|private|sealed|protected|internal){1}[\s]{1,}?(static)?[\s]?(\w)+[\s]+(\w)+[\s]*(\w)+[\s]*[(].{0,}?[)][\S\s]+?[\n]*[{][\S\s]{0,}?[}]";

        /// <summary>
        /// Expression representing the mehtods head
        /// </summary>
        public static readonly string methodHead = @"(public|private|sealed|protected|internal){1}[\s]{1,}?(static)?[\s]?(\w)+[\s]+(\w)+[\s]*(\w)+[\s]*";

        #endregion

    }
}
