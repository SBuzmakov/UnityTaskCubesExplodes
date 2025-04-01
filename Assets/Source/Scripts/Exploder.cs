using System.Collections.Generic;
using UnityEngine;

namespace Source.Scripts
{
    public class Exploder : MonoBehaviour
    {
        [SerializeField] private float _explosionForce;
        [SerializeField] private float _explosionRadius;
        [SerializeField] private CubeSpawner _cubeSpawner;

        private void OnEnable()
        {
            _cubeSpawner.CubesSpawned += Explode;
        }

        private void OnDisable()
        {
            _cubeSpawner.CubesSpawned -= Explode;
        }
    
        private void Explode(List<Rigidbody> explodableCubes)
        {
            foreach (Rigidbody explodableCube in explodableCubes)
            {
                explodableCube.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            }    
        }
    }
}
