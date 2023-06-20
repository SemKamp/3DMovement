using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //start Destory zelf wanneer een gameobject spawnt
        StartCoroutine(DestroySelf());
    }
    void OnCollisionEnter(Collision col)
    {
        Destroy(gameObject);
    }
    //verniel zelf na 5 seconden
    IEnumerator DestroySelf()
    {
        //verniel na 5 sec het gameobject aka de bullet
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
