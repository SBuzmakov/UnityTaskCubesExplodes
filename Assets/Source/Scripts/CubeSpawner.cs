using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Source.Scripts
{
    public class CubeSpawner : MonoBehaviour
    {
        [SerializeField] private CubeFactory _cubeFactory ;

        private List<Rigidbody> _spawnedCubes = new();

        private readonly int _minCubeCount = 2;
        private readonly int _maxCubeCount = 6;

        public event Action<List<Rigidbody>> CubesSpawned;

        private void OnEnable()
        {
            foreach (Cube cube in FindObjectsOfType<Cube>())
                cube.MouseClicked += SpawnCubes;
        }

        private void OnDisable()
        {
            foreach (Cube cube in FindObjectsOfType<Cube>())
                cube.MouseClicked -= SpawnCubes;
        }

        private void SpawnCubes(Cube parentCube)
        {
            if (WillCubesBeSpawned(parentCube))
            {
                for (int i = 0; i < GetRandomCubesCount(); i++)
                {
                    SpawnCube(parentCube);
                }
            
                CubesSpawned?.Invoke(_spawnedCubes);
            
                _spawnedCubes.Clear();
            }
        }

        private void SpawnCube(Cube parentCube)
        {
            Cube cube = _cubeFactory.Create(parentCube);
                
            cube.MouseClicked += SpawnCubes;

            cube.Destroyed += OnCubeDestroy;
                
            _spawnedCubes.Add(cube.GetComponent<Rigidbody>());
        }

        private void OnCubeDestroy(Cube cube)
        {
            cube.MouseClicked -= SpawnCubes;

            cube.Destroyed -= OnCubeDestroy;
        }

        private bool WillCubesBeSpawned(Cube cube)
        {
            return Random.value <= cube.SpawnRate;
        }

        private int GetRandomCubesCount()
        {
            return Random.Range(_minCubeCount, _maxCubeCount + 1);
        }
    }
}