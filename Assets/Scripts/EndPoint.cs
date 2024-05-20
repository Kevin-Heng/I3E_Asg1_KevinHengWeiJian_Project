/*
 * Author: Kevin Heng
 * Date: 18/05/24
 * Description: EndPoint class is to show the end screen when player meets completion requirements or tell the player that he did not meet the requirements
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndPoint : MonoBehaviour
{
    public TextMeshProUGUI winText; //text for win screen
    public TextMeshProUGUI requirementText; //text for requirements
    [SerializeField] GameObject winImage; //image for win screen
    [SerializeField] GameObject requirementImage; //text box image for requirements
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(other.gameObject.GetComponent<Player>().totalCoins == 50 && other.gameObject.GetComponent<Player>().totalPowerUps == 3) //check if player has met the completion requirements 
            {
                winText.text = "Level Completed";
                winImage.SetActive(true);
            }
            else
            {
                requirementText.text = "You have not met the requirements to complete the level";
                requirementImage.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            requirementText.text = null;
            requirementImage.SetActive(false);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        winImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
