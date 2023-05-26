using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float damage =10f;
    public float range = 100f;
    public Camera fpsCam;
    public GameObject projectile;
    // public Transform crosshair;
    // public float fireRate = 0.5f;
    // private float nextTimeToFire = 0f;

    private void Update() {
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }

    void Shoot(){
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);
            EnemyController target = hit.transform.GetComponent<EnemyController>();
            if(target != null){
                target.TakeDamage(damage);
            }
        }
    }
}
