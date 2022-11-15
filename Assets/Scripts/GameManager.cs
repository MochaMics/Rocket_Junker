using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int rocketsInInventory = 0;
    public int rocketWin = 4;

    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (rocketsInInventory >= rocketWin)
        {
            gameOver = true;
        }
    }

    public void RocketsCollected()
    {
        rocketsInInventory++;
    }
}
