using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float timeSinceStart = 0f;
    SpriteMask mask;
    SpriteRenderer renderer;

    LTDescr spriteColorTween;
    LTDescr maskTween;

    // Start is called before the first frame update
    void Start()
    {
        mask = GetComponent<SpriteMask>();
        renderer = GetComponent<SpriteRenderer>();
        TurnOn(Level.GetInstance().TimeLimit());
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceStart += Time.deltaTime;
    }

    public void TurnOn(float time)
    {
        if (time < 0) return;
        spriteColorTween = LeanTween.value(gameObject, SetSpriteColor, Color.green, Color.red, time).setEaseOutQuad();
        maskTween = LeanTween.value(gameObject, SetMaskCutoff, 1, 0, time).setEaseOutQuad().setOnComplete(TimeOut);
    }

    public void TurnOff()
    {
        var statManager = FindAnyObjectByType<StatManager>();
        statManager.UpdateMatchTime(timeSinceStart);

        if (spriteColorTween == null || maskTween == null) return;

        spriteColorTween.pause();
        maskTween.pause();

    }

    public void SetSpriteColor(Color color)
    {
        renderer.color = color;
    }

    public void SetMaskCutoff(float cutoff)
    {
        mask.alphaCutoff = cutoff;
    }

    public void TimeOut()
    {
        FindAnyObjectByType<MonsterController>().Lose();
    }
}
