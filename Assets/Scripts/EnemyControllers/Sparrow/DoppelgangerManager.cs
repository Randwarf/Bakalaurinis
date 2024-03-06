using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DoppelgangerManager : RelayManager
{
    public SparrowController sparrowController;
    public HitableRelay DoppelgangerPrefab;
    public List<Material> Materials;

    private int WinCount = 0;
    private int CorrectHits = 0;
    private int SpawnLimit;

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
    }

    public void SpawnDoppelgangers()
    {
        Relays.ForEach(r => { Destroy(r); });
        Relays.Clear();
        CorrectHits = 0;

        Materials = Materials.Shuffle().ToList();
        Locations = Locations.Shuffle().ToList();

        SpawnLimit = Locations.Count;
        if (WinCount < 2) 
        {
            SpawnLimit = 3;
        }
        if(WinCount < 1)
        {
            SpawnLimit = 2;
        }

        SpawnDoppelganger();
    }

    private void SpawnDoppelganger()
    {
        int index = Relays.Count;
        if (index == SpawnLimit)
            return;

        var doppelganger = SetupDoppelganger(index);
        JumpDoppelganger(doppelganger);
    }

    private HitableRelay SetupDoppelganger(int index)
    {
        var doppelganger = Instantiate(DoppelgangerPrefab, transform);
        doppelganger.transform.localPosition = Locations[index];
        UTILS.LookAtCamera(doppelganger.gameObject);
        doppelganger.GetComponentInChildren<Renderer>().material = Materials[index];

        doppelganger.RelayIndex = index;
        Relays.Add(doppelganger);

        return doppelganger;
    }

    private void JumpDoppelganger(HitableRelay doppelganger)
    {
        doppelganger.transform.LeanMoveLocalY(0.5f, 0.25f)
                    .setEaseInOutSine()
                    .setLoopPingPong()
                    .setRepeat(2)
                    .setOnComplete(SpawnDoppelganger);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Hit(int relayIndex, int damage, Element element, bool stun)
    {
        if (relayIndex == Relays[CorrectHits].RelayIndex)
        {
            HideDoppelganger();
            CorrectHits++;
            if(CorrectHits == SpawnLimit)
            {
                sparrowController.Stun(5f);
                WinCount++;
            }
        }
        else
        {
            ResetDoppelgangers();
        }
    }

    private void ResetDoppelgangers()
    {
        Relays.ForEach(doppelganger => { doppelganger.gameObject.SetActive(false); });
        SpawnDoppelgangers();
    }

    private void HideDoppelganger()
    {
        var doppel = ((HitableDoppelganger)Relays[CorrectHits]);
        doppel.gameObject.SetActive(false);
    }

    public void HideAllDoppelgangers()
    {
        Relays.ForEach(doppelganger => { doppelganger.gameObject.SetActive(false); });
    }
}
