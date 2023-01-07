using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContol : MonoBehaviour
{
    //trigger การชนกับสิ่งของเเล้วจบเกม//

    // Start is called before the first frame update
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "End")
        {
            PlayerManager.GameComplete = true;
            gameObject.SetActive(false);
            PlayerManager.lastCheckPointPos = new Vector2(10.51f, 202.61f);
            AudioManager.instance.Play("Complted");

        }
    }

}    
 
