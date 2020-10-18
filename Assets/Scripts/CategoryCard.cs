using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoryCard : MonoBehaviour
{
    public Text categoryName;
    public int categoryId;
    Category[] categories;
    void Start()
    {

        getData();

    }
    async void getData()
    {
        categories =await JSONInterface.Instance.getCategoryData();
        GameObject.Find("ProductList").GetComponent<DisplayProductList>().DeleteAllresultContainer(false, 1, categories[0].CategoryName);
    }
    public void OnClickOfCard()
    {
        PlayerPrefs.SetInt("CategoryID", categoryId);
        Debug.Log("Button clicked");
        GameObject.Find("ProductList").GetComponent<DisplayProductList>().DeleteAllresultContainer(false, categoryId,categoryName.text);
      
        
    }
   
}
