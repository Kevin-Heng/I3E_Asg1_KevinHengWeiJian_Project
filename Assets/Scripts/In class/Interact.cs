using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public void UpdatePlayerInteractable(Player player) //update which item i want to interact with
    {
        player.UpdateInteractable(this); //reference player
    }

    public void RemovePlayerInteractable(Player player)
    {
        player.UpdateInteractable(null);
    } 
        
    public virtual void Interacted() //press E
    {
        Debug.Log(gameObject.name + " was interacted with");
    }
    
}
