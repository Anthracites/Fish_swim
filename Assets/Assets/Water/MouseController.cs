using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace SkyWater
{
    public class MouseController : ShallowWaterObject
    {
        public Camera ScenCam;
        private Vector3 point;
        public int i;
        public int j;
        public int displayIndex;
        public Vector3 mousePos;
        public Vector3 mousePoint;
        [SerializeField] ShallowWater _shallowWater;


        void OnMouseOver()

        {
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

        /*[DllImport("user.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(out MousePosition lpMousePosition);

        [StructLayout(LayoutKind.Sequential)]

        public struct MousePosition
        {
            public int x;
            public int y;
        }

        public static int GetHoveredDisplay()
        {
            MousePosition mp;
            GetCursorPos(out mp);
            // Get the relative mouse coordinates
            Vector3 r = Display.RelativeMouseAt(new Vector3(mp.x, mp.y));
            // Use the z coordinate
            int displayIndex = (int)r.z;
            return displayIndex;
        }

        /*void DetectDisplayIndex()
        {
            mousePos = ScenCam.ScreenToWorldPoint(Input.mousePosition);

            if (0f > mousePos.z)
            {
                i = 1;
            }
            else
                if (mousePos.z < -4f)
            {
                i = 2;
            }
        }*/
    }
}