﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayProductList : MonoBehaviour
{
    public GameObject productPrefab;
    public GameObject Container;
    Category[] categories;
    Products[] products;
    public static DisplayProductList Instance;

    void Start()
    {

    }
    public async void getProductList(int id)
    {
        categories = await JSONInterface.Instance.getCategoryData();
        for (int i = 0; i < categories.Length; i++)
        {
            if (categories[i].CategoryId == id)
            {
                products = categories[i].Products;
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
                }
            }
        }
    }
}