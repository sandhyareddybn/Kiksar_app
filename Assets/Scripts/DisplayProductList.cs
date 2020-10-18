using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayProductList : MonoBehaviour
{
    public GameObject productPrefab;
    public GameObject Container;
    public static DisplayProductList Instance;
    public GameObject[] Products = new GameObject[100];
    string categoryname;
    Category[] categories;
    Products[] products;
 
    void Start()
    {

    }
    public async void getProductList(int id,string categoryName)
    {
        categories = await JSONInterface.Instance.getCategoryData();
        for (int i = 0; i < categories.Length; i++)
        {
            if (categories[i].CategoryId == id)
            {
                products = categories[i].Products;
                categoryname = categories[i].CategoryName;
            }
        }
        if (products != null)
        {
            for (int j = 0; j < products.Length; j++)
            {
                GameObject obj = Instantiate(productPrefab, Container.transform);
                ProductListCard productListCard = obj.GetComponent<ProductListCard>();
                if (productListCard != null)
                { 
                    productListCard.ProductName.text = products[j].ProductName;
                    Debug.Log(products[j].ProductName + " " + j);
                    for(int k=0;k<Products.Length;k++)
                    {
                        if(Products[k].name==products[j].ProductName)
                        {
                            productListCard.Product = Products[k];
                           
                        }
                    }
                }
            }
        }
    }
    public async void DeleteAllresultContainer(bool fromsearch,int id,string categoryName)
    {
        int count = 0;
        foreach (Transform child in Container.transform)
        {
            GameObject.Destroy(child.gameObject);
            count++;
            Debug.Log("destory");
        }
        if (fromsearch)
        {
            if (Container.transform.childCount == count)
            {
                getProductList(id,categoryName);
            }
        }
        getProductList(id,categoryName);
    }

  

}
