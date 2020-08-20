using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coins : MonoBehaviour
{
    int countCoins = 0;
    void OnCollisionEnter2D(Collision2D collision) {
        countCoins += 1;
        Destroy(gameObject);
        print("Coins" + countCoins);
    }
}
