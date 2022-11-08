using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (CheckGameOver.reStart)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckGameOver.check == true||CheckGameOver.mute==true)
        {
            gameObject.SetActive(false);
        }
        
    }
}
