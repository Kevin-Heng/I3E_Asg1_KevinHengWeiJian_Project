/*
 * Author: Kevin Heng
 * Date: 11/05/24
 * Description: Key class is used for player to interact and pick up key to unlock a locked door
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Key : MonoBehaviour
{
    bool key = false; //key is not collected

    [SerializeField] GameObject player; //reference player capsule
    [SerializeField] GameObject collectedKey; //reference key object

    public TextMeshProUGUI keyObtained; //text to show if key is picked up
    [SerializeField] GameObject textBoxImage; //text box image for text
    [SerializeField] GameObject keyImage; //image of key to show when key is picked up

    //function to collect key
    public void CollectKey()
    {
        if (player.gameObject.tag == "Player") //checks if player collides with key
        {
            key = true; //key is collected
            player.gameObject.GetComponent<Player>().CollectKey(key); //access CollectKey() function from Player.cs to change boolean value of collectKey to true
            keyObtained.text = "You picked up a key"; //text to appear on screen
            textBoxImage.SetActive(true); //text box image appears
            keyImage.SetActive(true); //image of key appears in inventory
            Destroy(collectedKey); //remove key from game
            
        }
    }

    //function when player enters trigger area
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") //checks if player enters the area
        {
            other.gameObject.GetComponent<Player>().PickUpKey(this); //reference key into Player.cs for interaction
            textBoxImage.SetActive(true); //text box image appears
            keyObtained.text = "Press E to pick up the key"; //text appears on screen

        }
    }

    //function when player exits trigger area
    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<Player>().PickUpKey(null); //prevents key from being picked up outside trigger, removes key reference for interaction
        keyObtained.text = null; //text disappears
        textBoxImage.SetActive(false); //image disappears
        if (key) //if key is picked up 
        {
            Destroy(gameObject); //destroy trigger area
        }
    }






    // Start is called before the first frame update
    void Start()
    {
        textBoxImage.SetActive(false); //text box image does not show 
        keyImage.SetActive(false); //key image does not show
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
