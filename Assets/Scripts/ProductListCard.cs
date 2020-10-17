using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductListCard : MonoBehaviour
{
    // Start is called before the first frame update
    public Text ProductName;
    public void OnClickproduct()
    {
        GameObject.Find("ProductName").GetComponent<Text>().text = ProductName.text;
    }
}
