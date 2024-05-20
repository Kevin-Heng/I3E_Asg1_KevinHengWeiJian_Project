using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.UIElements;

public class ShowHideText : MonoBehaviour
{
    public TextMeshProUGUI coinCollectedText; //UI text variable
    [SerializeField] GameObject textBoxImage; //UI text box image

    private void OnTriggerEnter(Collider other)
    {
        coinCollectedText.text = "Coin collected"; //show text on screen 
        textBoxImage.SetActive(true); //text box image appears
        
    }

    private void OnTriggerExit(Collider other)
    {
        coinCollectedText.text = null; //text disappears
        textBoxImage.SetActive(false); //image disappears
        Destroy(gameObject); //trigger area disappears
    }



    // Start is called before the first frame update
    void Start()
    {
        textBoxImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
