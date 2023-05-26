using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player"){
            FindObjectOfType<SoundManager>().Play("PlayerHurt");
            FindObjectOfType<PlayerMotor>().TakeDamage(10f);
        }
        Destroy(gameObject);
        
    }
}
