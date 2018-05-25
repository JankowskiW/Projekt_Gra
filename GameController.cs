using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Camera secondCamera;
    //public bool anyCursorUsingScreenVisible = false;
	// Use this for initialization
	void Start () {
        //   anyCursorUsingScreenVisible = false;
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        // Only if Inventory, skills and other screens are visible.
        //if(true)
        //{
        //    Cursor.lockState = CursorLockMode.None;
        //    Cursor.visible = true;
       // }
    }

}
