using UnityEngine;

public class MapUI : MonoBehaviour
{
    public GameObject mapUI;
    public GameObject mainCamera;
    public GameObject inventoryUI;

    void Start()
    {
        //canvas = this.transform.parent.gameObject;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            mapUI.SetActive(!mapUI.activeSelf);
            Cursor.visible = mapUI.activeSelf;
            Cursor.lockState = mapUI.activeSelf ? CursorLockMode.None : CursorLockMode.Locked;
            mainCamera.GetComponent<thirdpersonCamera>().enabled = !mapUI.activeSelf;
            Time.timeScale = mapUI.activeSelf ? 0 : 1;
            inventoryUI.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && mapUI.activeSelf)
        {
            mapUI.SetActive(false);
            Cursor.visible = mapUI.activeSelf;
            Cursor.lockState = mapUI.activeSelf ? CursorLockMode.None : CursorLockMode.Locked;
            mainCamera.GetComponent<thirdpersonCamera>().enabled = !mapUI.activeSelf;
            Time.timeScale = mapUI.activeSelf ? 0 : 1;
        }

    }
}

