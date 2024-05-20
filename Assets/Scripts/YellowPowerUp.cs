/*
 * Author: Kevin Heng
 * Date: 11/05/24
 * Description: YellowPowerUp class is used for the yellow power up to allow player to interact with it and pick it up
 */
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class YellowPowerUp : MonoBehaviour
{

    bool yellowPowerUp = false; //power up has not been collected
    int powerUpCount = 1; //increase power up count by 1
    [SerializeField] GameObject player; //reference player capsule

    public TextMeshProUGUI yellowPowerUpObtained; //text for when yellow power up is picked up
    [SerializeField] GameObject textBoxImage; //text box image to show text
    [SerializeField] GameObject yellowPowerUpImage; //image of blue power up 
    [SerializeField] GameObject powerUp; //reference the blue power up object

    //function to pick up the yellow power up
    public void PickUpPowerUp()
    {
        yellowPowerUp = true; //power up is collected
        player.GetComponent<Player>().CollectYellowPowerUp(yellowPowerUp); //access CollectPowerUp() function in Player.cs to change the boolean value for collectPowerUp to true
        player.GetComponent<Player>().TotalPowerUps(powerUpCount); //access TotalPowerUps() function in Player.cs to change value of totalPowerUps
        yellowPowerUpImage.SetActive(true); //image of yellow power up appears in inventory
        Destroy(powerUp); //destroy yellow power up object
        yellowPowerUpObtained.text = "You have picked up the blue power up"; //text appears on screen
    }

    //enter trigger area for interaction
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") //check for player
        {
            other.gameObject.GetComponent<Player>().PickUpYellowPowerUp(this); //reference the blue power up for interaction
            yellowPowerUpObtained.text = "Press E to pick up the power up"; //text appears on screen
            textBoxImage.SetActive(true); //text box image appears
        }
    }

    //leave trigger area
    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<Player>().PickUpYellowPowerUp(null); //removes reference of blue power up so it cannot be interacted outside the area
        yellowPowerUpObtained.text = null; //text is empty and disappears
        textBoxImage.SetActive(false); //text box image disppears
        if (player.gameObject.GetComponent<Player>().collectYellowPowerUp) //if yellow power up is picked up
        {
            Destroy(gameObject); //destroy trigger area for interaction
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        textBoxImage.SetActive(false); //text box image does not show
        yellowPowerUpImage.SetActive(false); //blue power up image does not show
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
