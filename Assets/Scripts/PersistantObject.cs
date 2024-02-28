using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class PersistantObject : MonoBehaviour
{
    public Guid SessionID;

    private void Start()
    {
        SessionID = Level.GetInstance().SessionID;
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SessionID != Level.GetSessionID())
            Destroy(this);
        GetComponent<XRGrabInteractable>().interactionManager = FindAnyObjectByType<XRInteractionManager>();
    }
}
