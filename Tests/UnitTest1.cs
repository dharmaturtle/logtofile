using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Solution {
  static void Main(String[] args) {
    string inputData = "";
    string line;
    while ((line = Console.ReadLine()) != null) {
      inputData += line + "\n";
    }
    // Do not edit: Output solution to console
    Console.WriteLine(codeHere(inputData));
  }

  public static String codeHere(String inputData) {
    var lines = inputData.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
    var sentence = lines[0];
    var firstWord = lines[1];
    var secondWord = lines[2];

    // remove punctuation from words
    var onlyLetters = new Regex(@".*?(\w+).*?", RegexOptions.Compiled);
    var words = sentence.Split(' ').Select(word => onlyLetters.Match(word).Groups[1].Value).ToList();

    // check for bad input
    if (String.IsNullOrEmpty(sentence) || String.IsNullOrEmpty(firstWord) || string.IsNullOrEmpty(secondWord)) {
      return (-1).ToString();
    }

    var indexedWords = words.Select((word, i) => (word, i));
    var firstWords = indexedWords.Where(x => x.word == firstWord).ToList();
    var secondWords = indexedWords.Where(x => x.word == secondWord).ToList();

    // cartesian product between first and second words. Add to list positive index differences
    var diffs = new List<int>();
    for (int i = 0; i < firstWords.Count(); i++) {
      for (int k = 0; k < secondWords.Count(); k++) {
        var a = firstWords[i].;
        var b = secondWords.[k];
        var diff = b - a;
        if (diff > 0) {
          diffs.Add(diff);
        }
      }
    }

    return
        (diffs.Count > 0m
        ? diffs.Min()
        : -1
        ).ToString();
  }
}

