using UnityEngine;

public class CubeFactory : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    public Cube Create(Vector3 parentPosition, Quaternion parentRotation)
    {
        return Instantiate(_cubePrefab, parentPosition, parentRotation);
    }
}
