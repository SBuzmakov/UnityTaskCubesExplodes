using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Source.Scripts
{
    public class CubeSpawner : MonoBehaviour
    {
        private readonly int _minCubeCount = 2;
        private readonly int _maxCubeCount = 6;
        
        [SerializeField] private MouseRaycast _mouseRaycast;
        [SerializeField] private CubeFactory _cubeFactory ;
        [SerializeField] private List<Cube> _originalCubes ;

        private List<Rigidbody> _spawnedCubes = new();

        public event Action<List<Rigidbody>> CubesSpawned;

        private void OnEnable()
        {
            _mouseRaycast.CubeClicked += SpawnCubes;
        }

        private void OnDisable()
        {
            _mouseRaycast.CubeClicked -= SpawnCubes;
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
            
            parentCube.Destroy();
        }

        private void SpawnCube(Cube parentCube)
        {
            Cube cube = _cubeFactory.Create(parentCube);
                
            cube.Destroyed += OnCubeDestroy;
                
            if (cube.GetComponent<Rigidbody>() == null)
                throw new NullReferenceException("Component Rigidbody is missing");
            
            _spawnedCubes.Add(cube.GetComponent<Rigidbody>());
        }

        private void OnCubeDestroy(Cube cube)
        {
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