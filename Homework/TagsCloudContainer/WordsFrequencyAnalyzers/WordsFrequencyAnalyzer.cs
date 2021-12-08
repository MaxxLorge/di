﻿using System.Collections.Generic;

namespace TagsCloudContainer.WordsFrequencyAnalyzers
{
    public class WordsFrequencyAnalyzer : IWordsFrequencyAnalyzer
    {
        public Dictionary<string, int> GetWordsFrequency(IEnumerable<string> words)
        {
            var freqDict = new Dictionary<string, int>();
            foreach (var word in words)
                if (!freqDict.ContainsKey(word))
                    freqDict[word] = 1;
                else
                    freqDict[word] += 1;

            return freqDict;
        }
    }
}