using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;     
    public TextMeshProUGUI text;
    int score;
 
    // Start is called before the first frame update


    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("coin")) 
        {
            Destroy(collision.gameObject);
            score += coinValue;
            text.text = score.ToString();
        }


    }
    
        
    

}
