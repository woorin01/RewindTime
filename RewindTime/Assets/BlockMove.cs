using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    public float upForce = 1f;
    public float sideForce = 0.1f;

    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            float x = Random.Range(-sideForce - 2f, sideForce + 2f);
            float y = Random.Range(upForce, upForce);
            float z = Random.Range(-sideForce - 2f, sideForce + 2f);

            Vector3 v = new Vector3(x, y, z);
            GetComponent<Rigidbody>().AddForce(v, ForceMode.Impulse);
        }
        
    }
}
