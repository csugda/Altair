using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.Interface
{
    public class MouseWorldTracker : MonoBehaviour
    {
        public Camera mainCamera;

        private void OnMouseDown()
        {
            
        }

        private void OnMouseOver()
        {
            
        }

        void Update()
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;

            }
        }
    }
}