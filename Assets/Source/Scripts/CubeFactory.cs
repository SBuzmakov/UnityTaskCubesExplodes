using UnityEngine;

namespace Source.Scripts
{
    public class CubeFactory : MonoBehaviour
    {
        [SerializeField] private Cube _cubePrefab;
        [SerializeField] private Painter _painter;

        private readonly float _scaleRate = 0.5f;
    
        private float _spawnRateFactor = 0.5f;
    
        public Cube Create(Cube parentCube)
        {
            Cube cube = Instantiate(_cubePrefab, parentCube.transform.position, parentCube.transform.rotation);
        
            ChangeScale(cube, parentCube.transform);
        
            _painter.Repaint(cube);
        
            cube.DecreaseSpawnRate(parentCube.SpawnRate * _spawnRateFactor);
        
            return cube;
        }
    
        private void ChangeScale(Cube cube, Transform parentTransform)
        {
            cube.transform.localScale = parentTransform.localScale * _scaleRate;
        }
    }
}
