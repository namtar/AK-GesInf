using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using AK_GesInf.classes.utils;

namespace AK_GesInf.classes
{
    /**
     * Loader for the Icd10 Classifications ascii file.
     **/

    public class Icd10Loader
    {
        private List<Pair<String, String>> content = new List<Pair<String, String>>();

        private const int ERROR = -1;
        private readonly char WHITESPACE = ' ';

        public Icd10Loader()
        {
        }

        public List<Pair<String, String>> Content
        {
            get { return content; }
        }

        public void ReadIcdFromFile()
        {
            content.Clear();

            using (StreamReader sr = new StreamReader(Environment.CurrentDirectory + "/icd/icd10.txt"))
            {
                string line;

                Pair<String, String> pair = null;

                while ((line = sr.ReadLine()) != null)
                {
                    // only handle lines that have spaces
                    if (line.Count(char.IsWhiteSpace) < 2)
                    {
                        continue;
                    }
                    string code = ExtractCode(line);
                    string description = ExtractDescription(line);
                    if (code != null)
                    {
                        pair = new Pair<string, string>(code, description);
                        content.Add(pair);
                    }
                    else
                    {
                        // append 
                        if (pair == null)
                        {
                            // this case should not happen if import file is correct. But if there is a description without any previous code than ignore it.
                            continue;
                        }

                        string descriptionFromPair = pair.Value;
                        if (!descriptionFromPair.EndsWith(WHITESPACE.ToString()))
                        {
                            descriptionFromPair += WHITESPACE.ToString();
                        }
                        descriptionFromPair += description;
                        pair.Value = descriptionFromPair;
                    }
                }
            }
        }

        private string ExtractCode(string line)
        {
            int indexOfFirstSpace = line.IndexOf(WHITESPACE);
            int indexOfSecondSpace = line.IndexOf(WHITESPACE, indexOfFirstSpace + 1);
            // if the following check succeeds we have a line without any code but only description         
            if ((indexOfFirstSpace + 1) == indexOfSecondSpace)
            {
                return null;
            }
            return line.Substring(indexOfFirstSpace, (indexOfSecondSpace - indexOfFirstSpace)).Trim();
        }

        private string ExtractDescription(string line)
        {
            int indexOfFirstSpace = line.IndexOf(WHITESPACE);
            int indexOfSecondSpace = line.IndexOf(WHITESPACE, indexOfFirstSpace + 1);
            // start from second whitespace and get substring. then trim leading and ending whitespaces
            string substring = line.Substring(indexOfSecondSpace, line.Length - indexOfSecondSpace);
            return substring.Trim();
        }
    }
}