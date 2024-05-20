using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartArea : MonoBehaviour
{
    public TextMeshProUGUI findWayOutText;
    [SerializeField] GameObject textBoxImage;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            findWayOutText.text = "Find a way out of this room";
            textBoxImage.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            findWayOutText.text = "Find a way out of this room";
            textBoxImage.SetActive(true);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            findWayOutText.text = null;
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
