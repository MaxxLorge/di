﻿using System.Linq;
using DeepMorphy;
using FluentAssertions;
using NUnit.Framework;
using TagsCloudContainer.WordsPreparator;

namespace TagsCloudContainer_Tests
{
    [TestFixture]
    public class RussianWordsPreparator_Should
    {
        private RussianWordsPreparator sut = new RussianWordsPreparator(new MorphAnalyzer());

        [Test]
        public void Trim()
        {
            var input = new[]
            {
                " пробел",
                "пробел ",
            };
            var expected = new[]
            {
                "пробел",
                "пробел",
            };

            AssertLemma(input, expected);
        }
        
        [Test]
        public void LowerWords()
        {
            var input = new[]
            {
                "Начало",
                "сеРедина",
                "конеЦ",
            };

            var expected = new[]
            {
                "начало",
                "середина",
                "конец",
            };
            AssertLemma(input, expected);
        }

        [TestCase("молоток", ExpectedResult = SpeechPart.Noun)]
        [TestCase("хороший", ExpectedResult = SpeechPart.Adjective)]
        [TestCase("понимаю", ExpectedResult = SpeechPart.Verb)]
        [TestCase("понимать", ExpectedResult = SpeechPart.Verb)]
        [TestCase("Он", ExpectedResult = SpeechPart.Pronoun)]
        [TestCase("два", ExpectedResult = SpeechPart.Num)]
        [TestCase("фыв", ExpectedResult = SpeechPart.Unknown)]
        public SpeechPart IdentifySpeechParts(string word)
        {
            var input = new[] {word};
            return sut.Prepare(input).First().SpeechPart;
        }

        [Test]
        public void TakeFirstWord_IfSeveralInLine()
        {
            var input = new[] {"он один"};
            sut.Prepare(input).Should().ContainSingle(wi => wi.Lemma == "он");
        }
        
        private void AssertLemma(string[] input, string[] expected)
        {
            sut.Prepare(input)
                .Select(wi => wi.Lemma)
                .Should().BeEquivalentTo(expected);
        }
    }
}