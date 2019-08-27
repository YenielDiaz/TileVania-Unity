using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalScroll : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 0.05f;

    void Update()
    {
        float yMove = scrollSpeed;//* Time.deltaTime;
        transform.Translate(new Vector2(0, yMove));
    }
}
