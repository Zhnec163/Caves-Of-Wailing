using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LeaderboardView : MonoBehaviour
{
    [SerializeField] private RectTransform _container;
    [SerializeField] private LeaderboardElement _leaderboardElementPrefab;

    private List<LeaderboardElement> _spawnedElements = new();
    
    public void ConstructLeaderboard(List<LeaderboardPlayer> leaderboardPlayers)
    {
        CleanLeaderboard();
        
        foreach (LeaderboardPlayer player in leaderboardPlayers.OrderByDescending(player => player.Score))
        {
            LeaderboardElement leaderboardElementInstance = Instantiate(_leaderboardElementPrefab, _container);
            leaderboardElementInstance.Init(player.Name, player.Rank, player.Score);
            _spawnedElements.Add(leaderboardElementInstance);
        }
    }

    private void CleanLeaderboard()
    {
        foreach (LeaderboardElement leaderboardElement in _spawnedElements)
            Destroy(leaderboardElement.gameObject);

        _spawnedElements = new List<LeaderboardElement>();
    }
}