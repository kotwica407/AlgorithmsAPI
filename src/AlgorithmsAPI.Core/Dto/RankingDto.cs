using System.Collections.Generic;

namespace AlgorithmsAPI.Core.Dto
{
    public class RankingDto
    {
        public Dictionary<string, int> Scores { get; set; }
        public RankingMethod RankingMethod { get; set; }
    }

    public enum RankingMethod
    {
        Standard,
        Modified,
        Dense,
        Ordinal
    }
}