using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSphere : MonoBehaviour
{
    public GameObject Product;
    public bool toSpin = true;
    float spinspeed = 10;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void FixedUpdate()
    {
        if (toSpin)
        {
            Product.transform.Rotate(0,Time.deltaTime*10*spinspeed,0);
        }
    }
}
