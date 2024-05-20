/*
 * Author: Kevin Heng
 * Date: 11/05/24
 * Description: PurpleBox class is used for the pruple boxes such that if player has red and blue power up, he can push the purple box
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PurpleBox : MonoBehaviour
{
    public TextMeshProUGUI requiredText; //text to show if player does meet the requirements to push the box
    [SerializeField] GameObject textBoxImage; //text box image for text

    //function when player collides with purple box
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody Rigid = GetComponent<Rigidbody>(); //access Rigidbody component of box
        if (collision.gameObject.GetComponent<Player>().collectBluePowerUp && collision.gameObject.GetComponent<Player>().collectRedPowerUp) //check if player has picked up both power ups
        {
            
            Rigid.constraints = RigidbodyConstraints.FreezeRotation; //freeze rotation so box does not spin when pushed


        }
        else
        {
            Rigid.constraints = RigidbodyConstraints.FreezeAll; //freeze rotation and position so box does not move
            requiredText.text = "You are missing a power up to push this"; //text appears on screen
            textBoxImage.SetActive(true); //text box image appears
        }

    }

    //function when player stops colliding with box
    private void OnCollisionExit(Collision collision)
    {
        requiredText.text = null; //text becomes empty and disappears
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
