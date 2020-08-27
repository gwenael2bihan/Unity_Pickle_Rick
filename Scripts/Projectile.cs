using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
   public float speed;

   private Transform player;
   private Vector2 target;

   void Start() {
      player = GameObject.FindWithTag("PlayerBody").transform;
      target = new Vector2(player.position.x, player.position.y);

    }

    private void Update() {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        //Debug.Log("UPDATE POSITION TARGET: " + target + " transform position: " + transform.position);
        //if (transform.position.x == target.x && transform.position.y == target.y) {
        //    DestroyProjectile();
        //    Debug.Log("TOUCHE1: ", gameObject);
        //}

    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            //DestroyProjectile();
            //Destroy(other.gameObject);
            Debug.Log("Collision Projetcil Player");
            other.gameObject.GetComponent<Renderer>().material.color = Color.red;

            FindObjectOfType<AudioManager>().Play("Death");

        }
    }

    void DestroyProjectile() {
        Destroy(gameObject);
    }

}
