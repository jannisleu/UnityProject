using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Extension class for different tests
public static class Extensions
{
    //DotTest to compare Vectors
    public static bool DotTest(this Transform transform, Transform other, Vector2 testdirection)
    {
        Vector2 direction = other.position - transform.position;
        return Vector2.Dot(direction.normalized, testdirection) > 0.25f;
    }
}
