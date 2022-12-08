using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI rocketCollectionUI;
 
    private int rocketsInInventory = 0;
    public int rocketWin = 4;

    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        rocketCollectionUI.text = rocketsInInventory + " out of " + rocketWin + " rocket pieces collected";

        if (rocketsInInventory >= rocketWin)
        {
            gameOver = true;
            rocketCollectionUI.text = "You Win, player!";
            SceneManager.LoadScene("WinScreen");
            Time.timeScale = 0.0f; //freezes everything literally
        }

        
    }

        
    public void RocketsCollected()
    {
        rocketsInInventory++;
    }

}
