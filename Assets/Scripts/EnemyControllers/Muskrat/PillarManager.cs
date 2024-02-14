using Assets.Custom_Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PillarManager : MonoBehaviour
{
    public List<HitablePillar> pillars = new List<HitablePillar>();
    public MuskratController muskratController;

    private List<char> Symbols = new List<char>() {'A', 'B', 'C', 'D' };
    private int correctIndex;

    // Start is called before the first frame update
    void Start()
    {
        Shuffle();
        correctIndex = Random.Range(0, Symbols.Count - 1);
        muskratController.setSymbol(Symbols[correctIndex]);
        SetPillars();
        
    }

    private void SetPillars()
    {
        for(int i = 0; i < pillars.Count; i++)
        {
            pillars[i].setData(i, Symbols[i].ToString());
        }
    }

    private void Shuffle()
    {
        Symbols = Symbols.OrderBy(_ => Random.value).ToList();
    }

    public void OnHit(int hitIndex)
    {
        if (hitIndex == correctIndex)
        {
            muskratController.DisableShields();
        }
    }

    internal void EnablePillars()
    {
        Start();
        pillars.ForEach(p => p.gameObject.SetActive(true));
    }

    internal void DisablePillars()
    {
        pillars.ForEach(p => p.gameObject.SetActive(false));
    }
}
