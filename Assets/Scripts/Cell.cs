using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool alive;


    public SpriteRenderer spriteRenderer;
    public void Start()
    {
        
    }
    public void UpdateStatus()
    {
        spriteRenderer ??= GetComponent<SpriteRenderer>();



        spriteRenderer.enabled = alive;
    }

  
   
}

