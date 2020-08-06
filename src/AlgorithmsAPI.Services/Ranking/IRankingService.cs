using System.Collections.Generic;
using AlgorithmsAPI.Core.Dto;

namespace AlgorithmsAPI.Services.Ranking
{
    public interface IRankingService
    {
        string[] GetRanking(RankingDto dto);
    }
}