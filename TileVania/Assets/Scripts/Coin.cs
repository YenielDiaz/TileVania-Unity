using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSFX;
    [SerializeField] int pointsWorth = 100;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameSession>().AddToScore(pointsWorth);
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);

    }
}
