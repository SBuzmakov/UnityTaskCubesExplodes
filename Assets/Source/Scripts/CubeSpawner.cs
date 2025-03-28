using UnityEngine;

namespace Source.Scripts
{
    public class CubeSpawner : MonoBehaviour
    {
        [SerializeField] private CubeFactory _cubeFactory;

        private readonly float _scaleRate = 0.5f;
        private readonly float _spawnRateDecrease = 0.5f;
        private readonly int _minCubeCount = 2;
        private readonly int _maxCubeCount = 6;

        private float _spawnRate = 1.0f;

        public void Construct(CubeFactory cubeFactory, float spawnRate)
        {
            _cubeFactory = cubeFactory;
            _spawnRate = spawnRate;
        }

        public void SpawnCubes(Transform parentTransform)
        {
            if (WillCubesBeSpawned())
            {
                for (int i = 0; i < GetCubesCount(); i++)
                {
                    Cube cube = _cubeFactory.Create(parentTransform.position, parentTransform.rotation);

                    CubeSpawner cubeSpawner = cube.GetComponentInChildren<CubeSpawner>();

                    cubeSpawner.Construct(_cubeFactory, _spawnRate * _spawnRateDecrease);

                    ChangeScale(cube, parentTransform);

                    ChangeColor(cube);
                }
            }
        }

        private bool WillCubesBeSpawned()
        {
            return Random.value <= _spawnRate; 
        }

        private void ChangeScale(Cube cube, Transform parentTransform)
        {
            cube.transform.localScale = parentTransform.localScale * _scaleRate;
        }

        private void ChangeColor(Cube cube)
        {
            Renderer cubeRenderer = cube.GetComponent<Renderer>();

            Color randomColor = new Color(Random.value, Random.value, Random.value);
            cubeRenderer.material.color = randomColor;
        }

        private int GetCubesCount()
        {
            return Random.Range(_minCubeCount, _maxCubeCount + 1);
        }
    }
}