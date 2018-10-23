using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Yungs.Unity.Mono.Test
{
    public class YungsUnityTest : MonoBehaviour
    {
        protected void Update()
        {
            if (Input .GetKeyDown(KeyCode.C))
            {
                KeyDown_C();
            }
            if (Input .GetKeyDown(KeyCode.V))
            {
                KeyDown_V();
            }
            if (Input .GetKeyDown(KeyCode.B))
            {
                KeyDown_B();
            }
        }

        public virtual void KeyDown_C() { }
        public virtual void KeyDown_V() { }
        public virtual void KeyDown_B() { }
    }
}
