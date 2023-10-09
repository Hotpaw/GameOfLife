using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startImage : MonoBehaviour
{
    private void Update()
    {
        //  transform.localScale += new Vector3(Time.deltaTime,Time.deltaTime,0f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Cell>().alive = true;
        Invoke("DestroyMe", 0.1f);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        OnCollisionEnter2D(collision);
    }
    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}

