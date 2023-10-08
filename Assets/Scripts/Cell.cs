using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public GameOfLife gm;
    public bool alive;
    int generationsLived;

    public Color HexStringToChangeToColorRGB;

    public SpriteRenderer spriteRenderer;
    public void Start()
    {




    }
    public void UpdateStatus()
    {
       
        spriteRenderer ??= GetComponent<SpriteRenderer>();



        spriteRenderer.enabled = alive;
        if (alive)
        {

            if (generationsLived > 50 && generationsLived < 99)
            {

                spriteRenderer.color = HexStringToColor("#FFE67F");
            }
            else if (generationsLived > 100 && generationsLived < 199)
            {
                spriteRenderer.color = HexStringToColor("#9C8D4F");
            }
            else if (generationsLived > 200 && generationsLived < 299)
            {
                spriteRenderer.color = HexStringToColor("#9C8D4F");
            }
            generationsLived++;
        }
        else
        {
           
            generationsLived = 0;
        }

    }


    private Color32 HexStringToColor(string HexString)
    {
        UnityEngine.ColorUtility.TryParseHtmlString(HexString, out Color hexcolor);
        return hexcolor;
    }





}

