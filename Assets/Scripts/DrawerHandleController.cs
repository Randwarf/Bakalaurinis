using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerHandleController : MonoBehaviour
{
    private float startDrawerLenght;
    public float drawerLenght = -0.7f;
    // Start is called before the first frame update
    void Start()
    {
        startDrawerLenght = transform.localPosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        // < ir > apsukti, nes stalèius neigiamoje koordinaèiø erdvëje
        if (transform.position.x < drawerLenght)
        {
            transform.position= new Vector3(drawerLenght, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > startDrawerLenght)
        {
            transform.position = new Vector3(startDrawerLenght, transform.position.y, transform.position.z);
        }
    }
}
