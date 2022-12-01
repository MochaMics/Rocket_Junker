using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float damage;
    public float projectileStart = 0f;
    public float projectileRate = 1f;

    public float projectileLifeTime = 10f;

    // Update is called once per frame
    void Start()
    {
        InvokeRepeating("projectileStuff", projectileStart, projectileRate);
    }

    void projectileStuff()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if(projectileLifeTime > 0.0f)
        {
            projectileLifeTime--;
        }
        else if (projectileLifeTime <= 0.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
        }
    }
}