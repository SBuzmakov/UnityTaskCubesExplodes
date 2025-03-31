using UnityEngine;

public class Painter : MonoBehaviour
{
    public void Repaint(Cube cube)
    {
        Renderer cubeRenderer = cube.GetComponent<Renderer>();

        Color randomColor = new Color(Random.value, Random.value, Random.value);
        cubeRenderer.material.color = randomColor;
    }
}
