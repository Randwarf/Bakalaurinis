using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    private AudioSource _audioSource;
    private CharacterController _characterController;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource= GetComponent<AudioSource>();
        _characterController = FindAnyObjectByType<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((_characterController.transform.position - transform.position).magnitude < 10)
        {
            _audioSource.Play();
        }
        else
        {
            _audioSource.Stop();
            _audioSource.time = 0;
        }
    }
}
