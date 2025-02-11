using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinishLineScript : MonoBehaviour
{
    private int position = 1;//Assume the player is in 1st position
    bool gameDone = false;
    public GameObject winPage;
    public GameObject winPosObj;
    TextMeshProUGUI winPosText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        winPage.SetActive(false);
        winPosText = winPosObj.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Player_Car" && !gameDone)
        {
            position++;
        }
        if (other.gameObject.name=="Player_Car")//The player has passed the finish line
        {
            switch(position)
            { 
                case 1: winPosText.text = "Congratulations! \nYou came 1st!";
                        break;
                case 2: winPosText.text = "Congratulations! \nYou came 2nd!";
                        break;
                case 3: winPosText.text = "Congratulations! \nYou came 3rd!";
                        break;
                case 4: winPosText.text = "Congratulations! \nYou came 4th!";
                        break;
            }
            gameDone = true;
            winPage.SetActive(true);
        }
    }
}
