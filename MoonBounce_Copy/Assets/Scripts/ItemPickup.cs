using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    //public AudioClip pickupClip;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Astronaut")
        {
            //AudioSource.PlayClipAtPoint(pickupClip, transform.position);
            Destroy(this.gameObject);
        }
    }
}
