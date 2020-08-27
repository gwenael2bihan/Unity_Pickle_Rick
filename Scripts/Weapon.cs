using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float fireRate = 0;
    public float damage = 10;
    public LayerMask whatToHit;
    
    float timeToFire = 0;
    Transform firePoint;


    // Start is called before the first frame update
    void Awake()
    {
        firePoint = transform.Find("FirePoint");
        if (firePoint == null) {
            Debug.LogError("No fire point");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fireRate == 0) {
            if (Input.GetButtonDown("Fire1")) {
                Shoot();
            }
        } else {
            if (Input.GetButton("Fire1") && Time.time > timeToFire) {
                timeToFire = Time.time + 1/fireRate;
                Debug.Log("FIRE RATE: " + timeToFire);
                Shoot();
            }
        }
    }

    void Shoot() {
        Vector3 mousePosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector3 firePointPosition = new Vector3(firePoint.position.x, firePoint.position.y);
        //RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, whatToHit);

        FindObjectOfType<AudioManager>().Play("LaserShot");
        Debug.Log("MOUSE POSITION: " + mousePosition);
        Debug.Log("FIRE POS: " + firePointPosition);
        Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition)*100, Color.white, 2.5f);
        //if (hit.collider != null) {

           // Debug.Log("diff null");
           // Debug.DrawLine(firePointPosition, hit.point, Color.red);
            //Debug.Log("We hit " + hit.collider.name + " and did " + damage + " damage");
        //}
    }
}
