using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sadalmelik.FitApp.Architecture
{
    [ExecuteInEditMode]
    public class PinTransform : MonoBehaviour
    {
        public bool pin = true;

        void Update()
        {
            if (pin)
                transform.position = Vector3.zero;
        }
    }
}