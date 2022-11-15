using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private GameObject gameManagerObject;
    private GameManager gameManager;

    void Start()
    {
        gameManagerObject =  GameObject.Find("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject);
        gameManager.RocketsCollected();
        Destroy(gameObject);

    }
}