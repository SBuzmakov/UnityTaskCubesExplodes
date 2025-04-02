using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Source.Scripts
{
    public class Painter : MonoBehaviour
    {
        public static void Repaint(Renderer objectRenderer)
        {
            if (objectRenderer == null)
                throw new NullReferenceException("Component Renderer is missing");

            Color randomColor = new Color(Random.value, Random.value, Random.value);
            objectRenderer.material.color = randomColor;
        }
    }
}
