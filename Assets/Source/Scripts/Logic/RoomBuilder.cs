using System.Collections.Generic;
using Scripts.Camera;
using Scripts.Creator;
using Scripts.Interactive.Ore;
using Scripts.Obstacle;
using Scripts.Sound;
using Scripts.Trap;
using Scripts.Utils;
using UnityEngine;

namespace Scripts.Logic
{
    public class RoomBuilder : MonoBehaviour
    {
        [SerializeField] private int _oreCount;
        [SerializeField] private int _trapCount;
        [SerializeField] private List<Blockage> _obstacles;
        [SerializeField] private List<Ore> _ores;
        [SerializeField] private List<ScratchTrap> _traps;

        public void Init(
            SoundPlayer soundPlayer,
            EndGameTimer endGameTimer,
            CameraShaker cameraShaker,
            ResourceSpawner resourceSpawner)
        {
            InitializeObstacles();
            InitializeOres(resourceSpawner);
            InitializeTraps(soundPlayer, endGameTimer, cameraShaker);
        }

        private void InitializeTraps(SoundPlayer soundPlayer, EndGameTimer endGameTimer, CameraShaker cameraShaker)
        {
            List<ScratchTrap> traps = new List<ScratchTrap>(_traps);
            float maxDegrees = 360F;

            for (int i = 0; i < _trapCount; i++)
            {
                ScratchTrap trap = traps[RandomHelper.GetRandomInt(0, traps.Count)];
                trap.Init(soundPlayer, endGameTimer, cameraShaker);
                trap.transform.rotation = Quaternion.Euler(0, Random.Range(0, maxDegrees), 0);
                trap.gameObject.SetActive(true);
                traps.Remove(trap);
            }
        }

        private void InitializeObstacles()
        {
            List<Blockage> obstacles = new List<Blockage>(_obstacles);
            obstacles.RemoveAt(RandomHelper.GetRandomInt(0, obstacles.Count));

            foreach (Blockage obstacle in obstacles)
                obstacle.gameObject.SetActive(true);
        }

        private void InitializeOres(ResourceSpawner resourceSpawner)
        {
            List<Ore> ores = new List<Ore>(_ores);

            for (int i = 0; i < _oreCount; i++)
            {
                Ore ore = ores[RandomHelper.GetRandomInt(0, ores.Count)];
                ore.Init(resourceSpawner);
                ore.gameObject.SetActive(true);
                ores.Remove(ore);
            }
        }
    }
}