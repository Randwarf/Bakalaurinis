using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageSource : MonoBehaviour
{
    public int damage = 40;
    public bool canStun = false;
    private Collider collider;

    [SerializeField]
    public Element element;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var isHitable = other.gameObject.TryGetComponent(out IHitableObject hitableObject);
        if (isHitable)
            Hit(hitableObject);
    }

    private void Hit(IHitableObject hitableObject)
    {
        hitableObject.Hit(damage, element, canStun);
        PlayHitAudio();
        Destroy(gameObject);
    }

    private void PlayHitAudio()
    {
        var gotAudio = TryGetComponent(out AudioSource audio);
        if (gotAudio)
        {
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
        }
    }
}
