using System;
using System.Collections.Generic;
using System.Linq;
using AlgorithmsAPI.Core.Dto;

namespace AlgorithmsAPI.Services.Ranking
{
    public class RankingService : IRankingService
    {
        public string[] GetRanking(RankingDto dto)
        {
            switch (dto.RankingMethod)
            {
                case RankingMethod.Standard:
                    return GetStandardRanking(dto.Scores).ToArray();
                case RankingMethod.Modified:
                    return GetModifiedRanking(dto.Scores).ToArray();
                case RankingMethod.Dense:
                    return GetDenseRanking(dto.Scores).ToArray();
                case RankingMethod.Ordinal:
                    return GetOrdinalRanking(dto.Scores).ToArray();
                default:
                    return null;
            }
        }


        private static IEnumerable<string> GetStandardRanking(Dictionary<string, int> scores)
        {
            List<int> list = scores.Values.Distinct().ToList();
            list.Sort((a, b) => b.CompareTo(a));

            var rank = 1;
            foreach (int value in list)
            {
                int temp = rank;
                foreach (string k in scores.Keys.Where(k => scores[k] == value))
                {
                    rank++;
                    yield return $"{temp} {value} {k}";
                }
            }
        }

        private static IEnumerable<string> GetModifiedRanking(Dictionary<string, int> scores)
        {
            List<int> list = scores.Values.Distinct().ToList();
            list.Sort((a, b) => b.CompareTo(a));

            var rank = 0;
            foreach (int value in list)
            {
                rank += scores.Keys.Count(k => scores[k] == value);

                foreach (string k in scores.Keys.Where(k => scores[k] == value))
                    yield return $"{rank} {scores[k]} {k}";
            }
        }

        private static IEnumerable<string> GetDenseRanking(Dictionary<string, int> scores)
        {
            List<int> list = scores.Values.Distinct().ToList();
            list.Sort((a, b) => b.CompareTo(a));

            var rank = 1;
            foreach (int value in list)
            {
                foreach (string k in scores.Keys.Where(k => scores[k] == value))
                    yield return $"{rank} {scores[k]} {k}";
                rank++;
            }
        }

        private static IEnumerable<string> GetOrdinalRanking(Dictionary<string, int> scores)
        {
            List<int> list = scores.Values.Distinct().ToList();
            list.Sort((a, b) => b.CompareTo(a));

            var rank = 1;
            foreach (string k in list.SelectMany(value => scores.Keys.Where(k => scores[k] == value)))
            {
                yield return $"{rank} {scores[k]} {k}";
                rank++;
            }
        }
    }
}