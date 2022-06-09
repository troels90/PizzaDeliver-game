using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPizzaColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPizzaColor = new Color32(0, 1, 0, 1);
    bool hasPizza;
    SpriteRenderer spriteRenderer;

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    [SerializeField] float destroyDelay = 1.0f;
    void OnCollisionEnter2D(Collision2D other) 
    {
            Debug.Log("Arrrgghh");
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if(other.tag == "Pizza" && !hasPizza){
            Debug.Log("Package picked up");
            hasPizza = true;
            spriteRenderer.color = hasPizzaColor;
            Destroy(other.gameObject, destroyDelay);    
        }
        if(other.tag == "Customer" && hasPizza){
            Debug.Log("Pizza delivered!");
            hasPizza = false;
            spriteRenderer.color = noPizzaColor;
        }
    }
}
