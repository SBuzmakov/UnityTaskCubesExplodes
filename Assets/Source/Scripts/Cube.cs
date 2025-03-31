using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    public float SpawnRate { get; private set; } = 1.0f;
    
    public event Action<Cube> MouseClicked;
    public event Action<Cube> Destroyed;

    private void OnDestroy()
    {
        Destroyed?.Invoke(this);
    }

    public void DecreaseSpawnRate(float spawnRateFactor)
    {
        SpawnRate *= spawnRateFactor;
    }
    
    private void OnMouseUpAsButton()
    {
        MouseClicked?.Invoke(this);
        
        Destroy(gameObject);
    }
}
