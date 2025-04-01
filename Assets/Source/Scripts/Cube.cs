using System;
using UnityEngine;

namespace Source.Scripts
{
    [RequireComponent(typeof(Rigidbody))]

    public class Cube : MonoBehaviour
    {
        public float SpawnRate { get; private set; } = 1.0f;
    
        public event Action<Cube> Destroyed;

        private void OnDestroy()
        {
            Destroyed?.Invoke(this);
        }

        public void DecreaseSpawnRate(float spawnRateFactor)
        {
            SpawnRate *= spawnRateFactor;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
