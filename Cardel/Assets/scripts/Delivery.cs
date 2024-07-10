using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 defulltColor = new Color32(255, 255, 255, 255);
    [SerializeField] Color32 packageColor = new Color32(99,255,141,255);
    [SerializeField] float packageDestroyedDelay = 0.1f;
    bool isPickup;
    SpriteRenderer carSpriteRenderer;

    public Delivery()
    {
        isPickup = false;
    }

    private void Start()
    {
        carSpriteRenderer = GetComponent<SpriteRenderer>();
        carSpriteRenderer.color = defulltColor;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Package" && !isPickup)
        {
            Debug.Log("package picked up");
            carSpriteRenderer.color = packageColor;
            Destroy(collision.gameObject, packageDestroyedDelay);
            isPickup = true;
        }
        if(collision.tag == "Costumer" && isPickup)
        {
            Debug.Log("package Drop");
            carSpriteRenderer.color = defulltColor;
            isPickup = false;
        }
    }

}
