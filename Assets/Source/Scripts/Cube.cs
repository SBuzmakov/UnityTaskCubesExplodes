using Source.Scripts;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    [SerializeField] private CubeSpawner _spawner;

    private void OnMouseUpAsButton()
    {
        _spawner.SpawnCubes(transform);
        
        Destroy(gameObject);
    }
}
