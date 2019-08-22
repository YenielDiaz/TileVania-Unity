using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSFX;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);
    }
}
