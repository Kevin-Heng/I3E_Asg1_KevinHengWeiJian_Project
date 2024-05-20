/*
 * Author: Kevin Heng
 * Date: 11/05/24
 * Description: RedPowerUp class is used for the red power up to allow player to interact with it and pick it up
 */
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RedPowerUp : MonoBehaviour
{

    bool redPowerUp = false; //power up has not been collected
    int powerUpCount = 1; //increase power up count by 1
    [SerializeField] GameObject player; //reference player capsule

    public TextMeshProUGUI redPowerUpObtained; //text for when red power up is picked up
    [SerializeField] GameObject textBoxImage; //text box image to show text
    [SerializeField] GameObject redPowerUpImage; //image of blue power up 
    [SerializeField] GameObject powerUp; //reference the blue power up object

    //function to pick up the red power up
    public void PickUpPowerUp()
    {
        redPowerUp = true; //power up is collected
        player.GetComponent<Player>().CollectRedPowerUp(redPowerUp); //access CollectPowerUp() function in Player.cs to change the boolean value for collectPowerUp to true
        player.GetComponent<Player>().TotalPowerUps(powerUpCount); //access TotalPowerUps() function in Player.cs to change value of totalPowerUps
        redPowerUpImage.SetActive(true); //image of blue power up appears in inventory
        Destroy(powerUp);//destroy red power up object
        redPowerUpObtained.text = "You have picked up the red power up"; //text appears on screen


    }

    //enter trigger area for interaction
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().PickUpRedPowerUp(this); //reference the red power up for interaction
            redPowerUpObtained.text = "Press E to pick up the power up"; //text appears on screen
            textBoxImage.SetActive(true); //text box image appears

        }
    }
    //leave trigger area
    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<Player>().PickUpRedPowerUp(null); //removes reference of red power up so it cannot be interacted outside the area
        redPowerUpObtained.text = null; //text is empty and disappears
        textBoxImage.SetActive(false); //text box image disppears
        if (player.gameObject.GetComponent<Player>().collectRedPowerUp) //if red power up is picked up
        {
            
            Destroy(gameObject); //destroy trigger area for interaction
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        textBoxImage.SetActive(false); //text box image does not show
        redPowerUpImage.SetActive(false); //red power up image does not show

    }

    // Update is called once per frame
    void Update()
    {

    }
}
