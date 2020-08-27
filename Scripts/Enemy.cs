using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    private Transform player;
    public Animator animator;
    private Vector2 target;
    public Transform firePoint;

    public float bulletForce = 20f;

     void Start() {
        player = GameObject.FindWithTag("PlayerBody").transform;
        target = new Vector2(player.position.x, player.position.y);
        timeBtwShots = startTimeBtwShots;

    }

    void Update() {
        //if (Vector2.Distance(transform.position, player.position) > stoppingDistance) {
            //transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance) {
          //  transform.position = this.transform.position;
            Shoot();
        }
    }

    void Shoot() {
        if (timeBtwShots == 5) {
            animator.SetBool("isShooting", true);
            timeBtwShots -= Time.deltaTime;

        } else if (timeBtwShots <= 3 && timeBtwShots >= 2){
            GameObject bullet = Instantiate(projectile, firePoint.position, firePoint.rotation);
            //Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            Debug.Log("FIREPOINT : " + firePoint.position + " transform: " + transform.position);
            timeBtwShots = startTimeBtwShots;
            FindObjectOfType<AudioManager>().Play("GunShot");
            animator.SetBool("isShooting", false);

        } else {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
