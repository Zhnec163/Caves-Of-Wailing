using System;
using System.Collections.Generic;
using Agava.YandexGames;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class YandexLeaderboard : MonoBehaviour
{
    private const string LeaderBoardName = "MainLeaderboard";
    private const string AnonymousName = "Anonymous";

    [SerializeField] private LeaderboardView _leaderboardView;

    public void SetPlayerScore(int score)
    {
        if (PlayerAccount.IsAuthorized == false)
            return;
        
        Leaderboard.GetPlayerEntry(LeaderBoardName, result =>
        {
            if (result == null || result.score < score)
                Leaderboard.SetScore(LeaderBoardName, score);
        });
    }

    public void Fill()
    {
        if (PlayerAccount.IsAuthorized == false)
            return;

        List<LeaderboardPlayer> leaderboardPlayers = new List<LeaderboardPlayer>();
        
        Leaderboard.GetEntries(LeaderBoardName, result =>
        {
            foreach (var entry in result.entries)
            {
                int rank = entry.rank;
                int score = entry.score;
                string name = entry.player.publicName;
        
                if (string.IsNullOrEmpty(name))
                    name = AnonymousName;
                
                leaderboardPlayers.Add(new LeaderboardPlayer(rank, name, score));
            }
            
            _leaderboardView.ConstructLeaderboard(leaderboardPlayers);
        });
        
        _leaderboardView.gameObject.SetActive(true);
    }
}
