/*
 * Author: Kevin Heng
 * Date: 18/05/24
 * Description: YellowLvlHint class is to show the hint for the level to earn the yellow power up
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class YellowLvlHint : MonoBehaviour
{
    public TextMeshProUGUI interactText; //text to show interact key
    [SerializeField] GameObject textBoxImage; //text box image for text

    //function to show hint on screen
    public void OpenHint()
    {
        interactText.text = "Which two colours give purple?";
        textBoxImage.SetActive(true);
    }

    //function to reference the hint when player enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().OpenYellowHint(this); //reference the object
            interactText.text = "Press E to get hint";
            textBoxImage.SetActive(true);
        }
    }

    //function to remove hint from screen when player exits area
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().OpenYellowHint(null); //removes reference from object
            interactText.text = null;
            textBoxImage.SetActive(false);
        }
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
