using Assets.Custom_Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PillarManager : RelayManager
{
    public MuskratController muskratController;

    private List<char> Symbols = new List<char>() {'A', 'B', 'C', 'D' };
    private int correctIndex;
    [SerializeField]
    public Transform startingY;

    LTDescr currentAnimation;

    // Start is called before the first frame update
    void Start()
    {
        Symbols = Symbols.Shuffle().ToList();
        correctIndex = Random.Range(0, Symbols.Count - 1);
        muskratController.setSymbol(Symbols[correctIndex]);
        SetPillars();
        
    }

    private void SetPillars()
    {
        for(int i = 0; i < Relays.Count; i++)
        {
            ((HitablePillar)Relays[i]).setData(i, Symbols[i].ToString());
        }
    }

    public override void Hit(int relayIndex, int damage, Element element, bool stun)
    {
        if (relayIndex == correctIndex)
        {
            muskratController.Stun(5f);
        }
    }

    //TODO: Fix animations - if one animation cancels out the other, pillars end up in wrong positions
    internal void EnablePillars()
    {
        Start();
        if(currentAnimation!= null) 
        {
            LeanTween.cancel(currentAnimation.id);
        }
        gameObject.transform.LeanMoveLocalY(startingY.position.y + 1, 2f);
        Relays.ForEach(p => ((HitablePillar)p).particles.Play());
    }

    internal void DisablePillars()
    {
        Relays.ForEach(p => ((HitablePillar)p).particles.Play());
        if(currentAnimation!= null)
        {
            LeanTween.cancel(currentAnimation.id);
        }
        currentAnimation = gameObject.transform.LeanMoveLocalY(startingY.position.y, 2f);
    }
}
