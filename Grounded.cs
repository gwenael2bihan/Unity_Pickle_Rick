using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Collision: " + collision.collider.tag);
        if (collision.collider.tag == "Tilemap") {
            Player.GetComponent<character_controller>().isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        Debug.Log("Collision2: " + collision.collider.tag);
        if (collision.collider.tag == "Tilemap") {
            Player.GetComponent<character_controller>().isGrounded = false;
        }
    }
}
