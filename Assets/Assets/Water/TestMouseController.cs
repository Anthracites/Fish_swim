using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace SkyWater
{
    public class TestMouseController : ShallowWaterObject
    {
        public Camera ScenCam;
        private Vector3 point;
        public GameObject GeneralCamera;
        public float y;
        public float yDispmin;
        public float yDispmax;
        public int i;
        public int j;
        public Vector3 mousePos;
        public Vector3 mousePointWorld;
        [SerializeField] ShallowWater _shallowWater;


        void Update()
        {
            //mousePos = ScenCam.ScreenToWorldPoint(Input.mousePosition);
            
        }


        void OnMouseOver()
        {
        y = GeneralCamera.GetComponent<TestGetMousePos>().mousePointWorld.y;

        if ((y > yDispmin) &(y < yDispmax))

           // mousePos = ScenCam.ScreenToWorldPoint(Input.mousePosition);

            {
                var ray = ScenCam.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;

               if (_shallowWater.meshCollider.Raycast(ray, out hit, Mathf.Infinity))
                {
                    _shallowWater.SetInputPosition(hit.textureCoord, _inputSize, _minInputSize, _inputPush);
                }
                else
                {
                    _shallowWater.ClearInput();
                }
            }
        }

        void OnMouseExit()
        {
            _shallowWater.ClearInput();
        }
    }
}