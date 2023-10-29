using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class UiOrb : MonoBehaviour
{
    public GameObject ActionOrbPrefab;
    public XRInteractionManager InteractionManager;
    public GameObject tooltip;
    public Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        InteractionManager = FindObjectOfType<XRInteractionManager>();
        transform.rotation = Random.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.parent.position;
        transform.rotation = transform.parent.rotation;
    }

    public void OnUiOrbGrab(SelectEnterEventArgs args)
    {
        if (args.interactorObject is XRBaseControllerInteractor interactor && interactor != null)
        {
            var newItem = Instantiate(ActionOrbPrefab, transform.position, transform.rotation);
            InteractionManager.SelectEnter(interactor, newItem.GetComponent<XRGrabInteractable>());

            var spawner = FindAnyObjectByType<AttackSpawner>();
            spawner.Spawn(parent);
            Destroy(this.gameObject);
        } 
    }

    public void OnUiOrbHoverEnter()
    {
        tooltip.SetActive(true);
    }

    public void OnUiOrbHoverExit()
    {
        tooltip.SetActive(false);
    }
}
