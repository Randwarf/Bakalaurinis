using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DoppelgangerController : MonoBehaviour
{
    public GameObject DoppelgangerPrefab;
    public List<Material> Materials;

    private int WinCount = 0;
    private int SpawnLimit;
    private List<GameObject> Doppelgangers = new List<GameObject>();

    private List<Vector3> Locations = new List<Vector3>()
    {
        new Vector3(-1, 0, 0),
        new Vector3( 1, 0, 0),
        new Vector3(-2, 0, 0),
        new Vector3( 2, 0, 0),
    };

    // Start is called before the first frame update
    void Start()
    {
        SpawnDoppelgangers();
    }

    private void SpawnDoppelgangers()
    {
        Doppelgangers.Clear();
        SpawnLimit = Locations.Count;
        Materials = Materials.Shuffle().ToList();
        Locations = Locations.Shuffle().ToList();
        if (WinCount < 2) 
        {
            SpawnLimit = 4;
        }

        SpawnDoppelGanger();

        //for(int i = 0; i < SpawnLimit; i++)
        //{
        //    var doppelGanger = Instantiate(DoppelgangerPrefab, transform);
        //    doppelGanger.transform.localPosition = LOCATIONS[i];
        //    UTILS.LookAtCamera(doppelGanger);
        //    doppelGanger.GetComponentInChildren<Renderer>().material = Materials[i];

        //    Doppelgangers.Add(doppelGanger);
        //}
    }

    private void SpawnDoppelGanger()
    {
        int i = Doppelgangers.Count;
        if (i == SpawnLimit) 
            return;
        var doppelGanger =Instantiate(DoppelgangerPrefab, transform);
        doppelGanger.transform.localPosition = Locations[i];
        UTILS.LookAtCamera(doppelGanger);
        doppelGanger.GetComponentInChildren<Renderer>().material = Materials[i];
        Doppelgangers.Add(doppelGanger);

        doppelGanger.transform.LeanMoveLocalY(0.5f, 0.25f)
            .setEaseInOutSine()
            .setLoopPingPong()
            .setRepeat(2)
            .setOnComplete(SpawnDoppelGanger);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
