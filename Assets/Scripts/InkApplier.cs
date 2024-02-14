using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class InkApplier : MonoBehaviour
{
    public PostProcessProfile inkProfile;
    private PostProcessVolume postProcessVolume;

    // Start is called before the first frame update
    void Start()
    {
        postProcessVolume = gameObject.AddComponent<PostProcessVolume>();
        postProcessVolume.profile = Instantiate(inkProfile);
        postProcessVolume.isGlobal = true;
        postProcessVolume.enabled = false;
    }

    public void ActivateInkEffect()
    {
        StartCoroutine(ActivateAndDeactivateEffect());
    }

    IEnumerator ActivateAndDeactivateEffect()
    {
        postProcessVolume.enabled = true;
        yield return new WaitForSeconds(2f);
        postProcessVolume.enabled = false;
    }
}
