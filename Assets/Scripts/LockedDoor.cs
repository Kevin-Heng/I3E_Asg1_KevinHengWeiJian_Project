/*
 * Author: Kevin Heng
 * Date: 12/05/24
 * Description: LockedDoor class is used for the door that require the key to open
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LockedDoor : MonoBehaviour
{
    bool open = false; //door is closed
    public TextMeshProUGUI keyRequired; //text to say if player does not have key to open the door
    [SerializeField] GameObject textBoxImage; //text box image for text
    [SerializeField] GameObject keyImage; //image of key to disappear when door is opened (key is used)
    


    //function open door
    public void OpenDoor()
    {
        Vector3 currentRotation = transform.eulerAngles; //obtain current rotation values of door on x,y and z axis
        currentRotation.y -= 90; //change y rotation by -90 degrees to open door
        transform.eulerAngles = currentRotation; //set new rotation values to door
        open = true; //door is open
        keyImage.SetActive(false); //key image disappears
    }

    //function when player enters trigger area
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !open) //checks for player entering trigger area, check if door is closed and if key is collected
        {
            //!open(not false) must be true to open, door only opens once
            if (other.gameObject.GetComponent<Player>().collectKey)
            {
                other.gameObject.GetComponent<Player>().UpdateLockedDoor(this); //reference the locked door for interaction
                keyRequired.text = "Press E to open the door"; //text appears on screen
                textBoxImage.SetActive(true); //text box image appears

            }

            else
            {
                keyRequired.text = "You need the key to open the door"; //show text on screen
                textBoxImage.SetActive(true); //text box image appears
            }
        }
    }

    //function when player exits trigger area
    private void OnTriggerExit(Collider other) //turn off text
    {
        other.gameObject.GetComponent<Player>().UpdateLockedDoor(null); //null means no door, door cannot be opened outside trigger area
        keyRequired.text = null; //removes text from screen
        textBoxImage.SetActive(false); //text box image disappears
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
