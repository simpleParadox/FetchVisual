using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class changeDimensions : MonoBehaviour
{
    Rigidbody cube;
    // Start is called before the first frame update
    public GameObject cube_1;
    public GameObject cube_2;
    public GameObject cube_3;
    public GameObject cube_4;

    float t;  
    void Start()
    {
        cube = GetComponent<Rigidbody>();
        t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Random random = new Random();
        int cube_scale = Random.Range(2, 5);
        int cube_1_scale = Random.Range(2, 5);
        int cube_2_scale = Random.Range(2, 5);
        int cube_3_scale = Random.Range(2, 5);
        int cube_4_scale = Random.Range(2, 5);
        Debug.Log(Time.time - t);
        if(Time.time - t > 1)
        {
            cube.transform.localScale = new Vector3(1, cube_scale, 0.2f);
            cube_1.transform.localScale = new Vector3(1, cube_1_scale, 0.2f);
            cube_2.transform.localScale = new Vector3(1, cube_2_scale, 0.2f);
            cube_3.transform.localScale = new Vector3(1, cube_3_scale, 0.2f);
            cube_4.transform.localScale = new Vector3(1, cube_4_scale, 0.2f);
            t = Time.time;
        }
            
    }
}
