/*
 * Author: Kevin Heng
 * Date: 11/05/24
 * Description: RedBox class is used for the red boxes such that if player has red power up, he can push the red box
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RedBox : MonoBehaviour
{
    public TextMeshProUGUI requiredText; //text to show if player does not have red power up
    [SerializeField] GameObject textBoxImage; //text box image to show text

    //function when player collides with red box
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody Rigid = GetComponent<Rigidbody>(); //access Rigidbody component of box
        if (collision.gameObject.GetComponent<Player>().collectRedPowerUp) //check if player has picked up the power up
        {
            
            Rigid.constraints = RigidbodyConstraints.FreezeRotation; //freeze rotation so box does not spin when pushed


        }
        else
        {
            Rigid.constraints = RigidbodyConstraints.FreezeAll; //freeze rotation and position so box does not move
            requiredText.text = "You require the red power up to push this"; //text to tell player he needs the blue power up
            textBoxImage.SetActive(true); //text box image appears
        }

    }
    //function when player stops colliding with the red box
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
