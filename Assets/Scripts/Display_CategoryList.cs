using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Display_CategoryList : MonoBehaviour
{
    public GameObject CategoryPrefab;
    public GameObject Container;
    Category[] categories;
    public static Display_CategoryList Instance;
    void Start()
    {
      getCategoryList();
    }
   public async void getCategoryList()
    {
        categories = await JSONInterface.Instance.getCategoryData();
        if(categories!=null)
        {
            for (int i = 0; i < categories.Length; i++)
            {
                GameObject obj = Instantiate(CategoryPrefab, Container.transform);
                CategoryCard categoryCard = obj.GetComponent<CategoryCard>();
                if(categoryCard!=null)
                {
                    categoryCard.categoryId = categories[i].CategoryId;
                    categoryCard.categoryName.text = categories[i].CategoryName;
                    Debug.Log(categories[i].CategoryName+" "+i);
                }
            }
        }
    }
 }
