/*
 * Author: Kevin Heng
 * Date: 11/05/24
 * Description: Door class is for player to open and close the door when interact with door (door can be opened more than once)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door2 : Interact
{

    public TextMeshProUGUI openDoorText; //text to tell player what key to press to open door
    [SerializeField] GameObject textBoxImage; //text box image for text 
    [SerializeField] GameObject door; //reference door object since this script is assigned to an empty gameObject

    //function open door
    public void OpenDoor()
    {
        Vector3 currentRotation = door.transform.eulerAngles; //obtain current rotation values of door on x,y and z axis
        currentRotation.y -= 90; //change y rotation by -90 degrees to open door
        door.transform.eulerAngles = currentRotation; //set new rotation values to door

    }

    //function close door
    public void CloseDoor()
    {
        Vector3 currentRotation = door.transform.eulerAngles; //obtain current rotation values of door on x,y and z axis
        currentRotation.y = 0; //change y rotation back to 0 degrees to close door
        door.transform.eulerAngles = currentRotation; //set new rotation values to door
    }

    //function when player enters trigger area
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") //checks for player entering trigger area and check if door is closed
        {
            //update player what door it is
            UpdatePlayerInteractable(other.gameObject.GetComponent<Player>()); //reference player for interaction
            openDoorText.text = "Press E to open the door"; //text appears on screen
            textBoxImage.SetActive(true); //text box image appears

        }
    }

    //function when player exits trigger area
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") //check for player
        {
            RemovePlayerInteractable(other.gameObject.GetComponent<Player>());
            openDoorText.text = null; //text disppears
            textBoxImage.SetActive(false); //text box image disappears
            CloseDoor(); //door closes once player leaves the trigger area
        }
    }

    public override void Interacted()
    {
        base.Interacted();
        OpenDoor();
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
