using System.Collections.Generic;
using AlgorithmsAPI.Core.Dto;
using AlgorithmsAPI.Services.Ranking;
using NUnit.Framework;

namespace AlgorithmsAPI.Tests
{
    [TestFixture]
    public class RankingTests
    {
        private static readonly Dictionary<string, int> Scores = new Dictionary<string, int>
        {
            ["Solomon"] = 44,
            ["Jason"] = 42,
            ["Errol"] = 42,
            ["Gary"] = 41,
            ["Bernard"] = 41,
            ["Barry"] = 41,
            ["Stephen"] = 39
        };

        [TestCase(RankingMethod.Standard,
            new[]
            {
                "1 44 Solomon", "2 42 Jason", "2 42 Errol", "4 41 Gary", "4 41 Bernard", "4 41 Barry", "7 39 Stephen"
            })]
        [TestCase(RankingMethod.Modified,
            new[]
            {
                "1 44 Solomon", "3 42 Jason", "3 42 Errol", "6 41 Gary", "6 41 Bernard", "6 41 Barry", "7 39 Stephen"
            })]
        [TestCase(RankingMethod.Dense,
            new[]
            {
                "1 44 Solomon", "2 42 Jason", "2 42 Errol", "3 41 Gary", "3 41 Bernard", "3 41 Barry", "4 39 Stephen"
            })]
        [TestCase(RankingMethod.Ordinal,
            new[]
            {
                "1 44 Solomon", "2 42 Jason", "3 42 Errol", "4 41 Gary", "5 41 Bernard", "6 41 Barry", "7 39 Stephen"
            })]
        [Test]
        public void CheckIfRankingWorksCorrectly(RankingMethod rankingMethod, string[] expectedRanking)
        {
            IRankingService service = new RankingService();
            string[] actual = service.GetRanking(new RankingDto
            {
                RankingMethod = rankingMethod,
                Scores = Scores
            });
            CollectionAssert.AreEqual(expectedRanking, actual);
        }
    }
}