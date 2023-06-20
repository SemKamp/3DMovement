using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject Bullet;
    float Power = 150;
    public Transform bulletTransform;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject b = Instantiate(Bullet, bulletTransform.position, bulletTransform.rotation);
            b.GetComponent<Rigidbody>().AddForce(Vector3.forward * Power, ForceMode.Impulse);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(Bullet);
    }
}
