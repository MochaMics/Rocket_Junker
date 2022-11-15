using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private GameObject gameManagerObject;
    private GameManager gameManager;

    //Particles
    public ParticleSystem explosionSystem;

    void Start()
    {
        gameManagerObject =  GameObject.Find("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject);
        explosionSystem.Play();
        gameManager.RocketsCollected();
        Debug.Log("This should explode " + explosionSystem.name);
        //gameObject.SetActive(false);

        Destroy(gameObject, 0.5f);

    }
}