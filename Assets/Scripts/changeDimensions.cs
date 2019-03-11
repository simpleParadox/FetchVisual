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
        int n = 3;
        float cube_scale = Random.Range(2, n) * 0.1f;
        /*
        float cube_1_scale = Random.Range(2, n) * 0.1f;
        float cube_2_scale = Random.Range(2, n) * 0.1f;
        float cube_3_scale = Random.Range(2, n) * 0.1f;
        float cube_4_scale = Random.Range(2, n) * 0.1f;
        */
        //Debug.Log(Time.time - t);
        if(Time.time - t > 1)
        {
            cube.transform.localScale = new Vector3(cube_scale, cube_scale, cube_scale);
            /*cube_1.transform.localScale = new Vector3(cube_1_scale, cube_1_scale, cube_1_scale);
            cube_2.transform.localScale = new Vector3(cube_2_scale, cube_2_scale, cube_2_scale);
            cube_3.transform.localScale = new Vector3(cube_3_scale, cube_3_scale, cube_3_scale);
            cube_4.transform.localScale = new Vector3(cube_4_scale, cube_4_scale, cube_4_scale);*/
            t = Time.time;
        }
            
    }
}
