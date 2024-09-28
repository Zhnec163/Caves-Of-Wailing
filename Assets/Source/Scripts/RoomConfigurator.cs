using System.Collections.Generic;
using UnityEngine;

public class RoomConfigurator : MonoBehaviour
{
    [SerializeField] private int _oreCount;
    [SerializeField] private int _trapCount;
    [SerializeField] private List<Obstacle> _obstacles;
    [SerializeField] private List<Ore> _ores;
    [SerializeField] private List<ScratchTrap> _traps;

    private void Awake()
    {
        InitializeObstacles();
        InitializeOres();
        InitializeTraps();
    }

    private void InitializeTraps()
    {
        List<ScratchTrap> traps = new List<ScratchTrap>(_traps);
        float maxDegrees = 360F;

        for (int i = 0; i < _trapCount; i++)
        {
            ScratchTrap trap = traps[RandomHelper.GetRandomInt(0, traps.Count)];
            trap.transform.rotation = Quaternion.Euler(0, Random.Range(0, maxDegrees), 0);
            trap.gameObject.SetActive(true);
            traps.Remove(trap);
        }
    }

    private void InitializeObstacles()
    {
        if (_obstacles.Count < 0)
            return;
        
        List<Obstacle> obstacles = new List<Obstacle>(_obstacles);
        obstacles.RemoveAt(RandomHelper.GetRandomInt(0, obstacles.Count));

        foreach (Obstacle obstacle in obstacles)
            obstacle.gameObject.SetActive(true);
    }

    private void InitializeOres()
    {
        List<Ore> ores = new List<Ore>(_ores);

        for (int i = 0; i < _oreCount; i++)
        {
            Ore ore = ores[RandomHelper.GetRandomInt(0, ores.Count)];
            ore.gameObject.SetActive(true);
            ores.Remove(ore);
        }
    }
}