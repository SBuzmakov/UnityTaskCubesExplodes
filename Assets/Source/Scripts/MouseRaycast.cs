using System;
using UnityEngine;

namespace Source.Scripts
{
    public class MouseRaycast : MonoBehaviour
    {
        [SerializeField] private Camera _camera;

        public event Action<Cube> CubeClicked;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                TryInvokeCubeClick();
        }

        private void TryInvokeCubeClick()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit) == false) 
                return;
            
            if (hit.collider.TryGetComponent<Cube>(out Cube cube))
                CubeClicked?.Invoke(cube);
        }
    }
}