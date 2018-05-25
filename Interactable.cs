using UnityEngine;


public class Interactable : MonoBehaviour
{
    public Transform interactionTransform; 
    
    Transform player;   
    

    public virtual void Interact()
    {
    }

    void Update()
    {
        Interact();
    }
    



}
