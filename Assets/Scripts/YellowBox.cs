/*
 * Author: Kevin Heng
 * Date: 11/05/24
 * Description: YellowBox class is used for the yellow boxes such that if player has yellow power up, he can push the yellow box
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class YellowBox : MonoBehaviour
{
    public TextMeshProUGUI requiredText; //text to show if player does not have yellow power up
    [SerializeField] GameObject textBoxImage; //text box image to show text

    //function when player collides with yellow box
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody Rigid = GetComponent<Rigidbody>(); //access Rigidbody component of box
        if (collision.gameObject.GetComponent<Player>().collectYellowPowerUp) //check if player has picked up the power up
        {

            Rigid.constraints = RigidbodyConstraints.FreezeRotation; //freeze rotation so box does not spin when pushed
        }
        else
        {
            Rigid.constraints = RigidbodyConstraints.FreezeAll; //freeze rotation and position so box does not move
            requiredText.text = "You require the yellow power up to push this"; //text to tell player he needs the yellow power up
            textBoxImage.SetActive(true);//text box image appears
        }

    }

    //function when player stops colliding with the yellow box
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
