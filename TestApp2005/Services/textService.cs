﻿using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace TestApp2005.Services
{
    internal class textService
    {
        string clearPunctuation(string text)
        {                   
            text = Regex.Replace(text, @"\p{P}", "");
            return text;
        }

        string clearStopWords(string text)
        {
            string[] stopWords = { "i", "me", "my", "myself", "we", "our", "ours", "ourselves", "you", "your", "yours", "yourself", "yourselves", "he", "him", "his", "himself", "she", "her", "hers", "herself", "it", "its", "itself", "they", "them", "their", "theirs", "themselves", "what", "which", "who", "whom", "this", "that", "these", "those", "am", "is", "are", "was", "were", "be", "been", "being", "have", "has", "had", "having", "do", "does", "did", "doing", "a", "an", "the", "and", "but", "if", "or", "because", "as", "until", "while", "of", "at", "by", "for", "with", "about", "against", "between", "into", "through", "during", "before", "after", "above", "below", "to", "from", "up", "down", "in", "out", "on", "off", "over", "under", "again", "further", "then", "once", "here", "there", "when", "where", "why", "how", "all", "any", "both", "each", "few", "more", "most", "other", "some", "such", "no", "nor", "not", "only", "own", "same", "so", "than", "too", "very", "s", "t", "can", "will", "just", "don", "should", "now" };
            string[] kelimeler = text.Split(' ');
            string temizMetin = string.Join(" ", kelimeler.Where(k => !stopWords.Contains(k.ToLower())));
            return temizMetin;
        }

        string tokenization(string text)
        {

            return text;
        }


    }
}
        