using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject infoWindow;
    // Start is called before the first frame update
    private void Start()
    {
      
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            SetWindowVisibility();
        }
    }
    public void SetWindowVisibility()
    {
        if (infoWindow.activeInHierarchy)
        {

            infoWindow.SetActive(false);
        }
        else
        {
            infoWindow.SetActive(true);
        }
    }
}
