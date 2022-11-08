using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PoliceMove : MonoBehaviour
{


    // Start is called before the first frame update

    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = ScoreScript.instance.level + 5;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
        if (transform.position.y <= -5)
        {
            ScoreScript.scoreValue += 1;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bshoot") {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
