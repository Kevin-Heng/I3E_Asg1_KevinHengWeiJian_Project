/*
 * Author: Kevin Heng
 * Date: 18/05/24
 * Description: MainPuzzleHint class is to show the hint for the puzzle level in the main area in order to collect the key
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainPuzzleHint : MonoBehaviour
{
    public TextMeshProUGUI hintText; //text to show hint
    public TextMeshProUGUI interactText; //text to show interact key
    [SerializeField] GameObject textBoxImage; //text box image for text

    //function to show hint on screen
    public void OpenHint()
    {
        hintText.text = "Push the coloured blocks to their respective coloured squares";
        interactText.text = null;
        textBoxImage.SetActive(true);
    }

    //function to reference the hint when player enters trigger area
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().OpenHint(this); //reference the object
            interactText.text = "Press E to get hint";
            textBoxImage.SetActive(true);
        }
    }
    //function to remove hint from screen when player exits area
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().OpenHint(null); //removes reference from object
            interactText.text = null;
            textBoxImage.SetActive(false);
            hintText.text = null;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        hintText.text = null; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
