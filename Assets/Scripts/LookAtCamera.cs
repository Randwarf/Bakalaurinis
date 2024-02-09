using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Camera _camera;
    public bool lockYAxis = false;
    // Start is called before the first frame update
    void Start()
    {
        _camera = FindAnyObjectByType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        var position = 2 * transform.position - _camera.transform.position;

        if (lockYAxis)
            position.y = 0;

        transform.LookAt(position);

    }
}
