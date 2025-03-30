using System.Collections.Generic;
using Source.Scripts;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private CubeSpawner _spawner;

    private void OnMouseUpAsButton()
    {
        _spawner.SpawnCubes(transform);
        
        Explode(_spawner.SpawnedCubes);
        
        Destroy(gameObject);
    }

    private void Explode(List<Rigidbody> explodableCubes)
    {
        foreach (Rigidbody explodableCube in explodableCubes)
        {
            explodableCube.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }    
    }
}
