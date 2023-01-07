using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameOver : MonoBehaviour 
{




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy") 
        {
            

            PlayerManager.isGameOver = true;
            gameObject.SetActive(false);
            AudioManager.instance.Play("GameOver");

        }
      
        

    }

    


}


