using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class changeDimensions : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update

    float t;  
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Random random = new Random();
        int y = Random.Range(2, 5);
        Debug.Log(Time.time - t);
        if(Time.time - t > 1)
        {
            rb.transform.localScale = new Vector3(1, y, 0.2f);
            t = Time.time;
        }
            
    }
}
