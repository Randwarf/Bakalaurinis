using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public static class UTILS
{
    public static Camera _camera;

    public static void LookAtCamera(GameObject gameObject, bool lockYAxis = true)
    {
        if (_camera == null)
            _camera = Object.FindAnyObjectByType<Camera>();

        var position = 2 * _camera.transform.position - gameObject.transform.position;

        if (lockYAxis)
            position.y = 0;

        gameObject.transform.LookAt(position);
    }

    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> list)
    {
        return list.OrderBy(_ => Random.value);
    }

    public static IEnumerable<int> Shuffle(int startInclusive, int endInclusive, int stepSize = 1) 
    {
        return Enumerable.Range(startInclusive, endInclusive - startInclusive).Shuffle();
    }

    public static void DestroyAllChildren(this GameObject gameObject)
    {
        DestroyAllChildren(gameObject.transform);
    }

    public static void DestroyAllChildren(this Transform transform)
    {
        foreach(Transform child in transform)
        {
            UnityEngine.Object.Destroy(child.gameObject);
        }
    }
}
