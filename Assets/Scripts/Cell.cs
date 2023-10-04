using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cell : MonoBehaviour
{
    GameOfLife gm;
    public bool alive;
    float timer;

    public Color HexStringToChangeToColorRGB;
    string HexColorString;
    public SpriteRenderer spriteRenderer;
    public void Start()
    {
      
      
        gm = GetComponent<GameOfLife>();
      
    }
    public void UpdateStatus()
    {
        spriteRenderer ??= GetComponent<SpriteRenderer>();

       

        spriteRenderer.enabled = alive;
        if (alive)
        {

            spriteRenderer.color = HexStringToColor("#9C8D4F");
        }
        else
        {
            timer = 0;
        }
    }

    private Color32 HexStringToColor(string HexString)
    {
        UnityEngine.ColorUtility.TryParseHtmlString(HexString, out Color hexcolor);
        return hexcolor;
    }





}

