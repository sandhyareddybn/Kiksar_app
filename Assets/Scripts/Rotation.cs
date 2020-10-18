using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public GameObject Product;
    public bool toSpin = true;
    public float spinspeed = 100;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void FixedUpdate()
    {
        if (toSpin)
        {
            Product.transform.Rotate(0, spinspeed * Time.deltaTime, 0);
        }
    }
}
