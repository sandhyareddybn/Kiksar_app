using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductListCard : MonoBehaviour
{
    // Start is called before the first frame update
    public Text ProductName;
    public GameObject Product;
    public GameObject Default_Object;
    private GameObject Models;
    GameObject Previousproduct=null;
    public static ProductListCard Instance;
    int count=0;

    void Start()
    {
        Models = GameObject.Find("3DModels");
     

    }
  
       public void OnClickproduct()
    {
      
        if (Product != null)
        {
            DeleteAllresultContainer(false);
            Previousproduct = Instantiate(Product, new Vector3(0, 0, 4), Quaternion.identity);
            Previousproduct.transform.parent = Models.transform;

            Debug.Log("instantiated 2");
        }
        else if(Product==null)
        {
            DeleteAllresultContainer(false);
            Previousproduct = Instantiate(Default_Object, new Vector3(0, 0, 4), Quaternion.identity);
            Previousproduct.transform.parent = Models.transform;

            Debug.Log("instantiated 2");
        }
       
      //  Previousproduct = Product;
        GameObject.Find("ProductName").GetComponent<Text>().text =ProductName.text;
    }
    public async void DeleteAllresultContainer(bool fromsearch)
    {
        int count = 0;
        foreach (Transform child in Models.transform)
        {
            GameObject.Destroy(child.gameObject);
            count++;
            Debug.Log("destory");
        }
        if (fromsearch)
        {
            if (Models.transform.childCount == count)
            {
             //   getData();
            }
        }

    }


}
