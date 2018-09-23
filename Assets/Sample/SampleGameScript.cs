using System.Collections;
using System.Collections.Generic;
using ScopeExtensions;
using UnityEngine;

namespace Sample
{
    public class SampleGameScript : MonoBehaviour
    {
        void Start()
        {
            // Case: Not for use scope functions.
            // Need 2 variables declaration in function scope for Rotation set to Transform.
            Transform t1 = GetComponent<Transform>();
            Quaternion q1 = new Quaternion();
            q1.x = 0;
            q1.y = 0;
            q1.x = 0;
            t1.rotation = q1;

            // Case: Use scope functions.
            // Function scope is clean without used variables.
            Transform t2 = GetComponent<Transform>().Also((it) =>
            {
                it.rotation = new Quaternion().Also((that) =>
                {
                    that.x = 0;
                    that.y = 0;
                    that.z = 0;
                });
            });

            // Calculation code scope is so clarity.
            // 'Let' can use for like LINQ's 'Select'.
            float distanceXFromGrandParent = GetComponent<Transform>()?.Let((it) =>
            {
                return (it.parent?.transform?.localPosition.x ?? 0) + it.localPosition.x;
            }) ?? 0;
        }
    }
}