using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bshoot : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    void Start()
    {
        Destroy(gameObject, 6);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
