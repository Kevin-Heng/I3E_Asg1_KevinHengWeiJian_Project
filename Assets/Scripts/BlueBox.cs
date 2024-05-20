/*
 * Author: Kevin Heng
 * Date: 11/05/24
 * Description: BlueBox class is used for the blue boxes such that if player has blue power up, he can push the blue box
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlueBox : MonoBehaviour
{
    public TextMeshProUGUI requiredText; //text to show if player does not have blue power up
    [SerializeField] GameObject textBoxImage; //text box image to show text

    //function when player collides with blue box
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody Rigid = GetComponent<Rigidbody>(); //access Rigidbody component of box
        if (collision.gameObject.GetComponent<Player>().collectBluePowerUp) //check if player has picked up the blue power up
        {
            
            Rigid.constraints = RigidbodyConstraints.FreezeRotation; //freeze rotation so box does not spin when pushed
        }
        else
        {
            Rigid.constraints = RigidbodyConstraints.FreezeAll; //freeze rotation and position so box does not move
            requiredText.text = "You require the blue power up to push this"; //text to tell player he needs the blue power up
            textBoxImage.SetActive(true); //text box image appears
        }

    }

    //function when player stops colliding with the blue box
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
