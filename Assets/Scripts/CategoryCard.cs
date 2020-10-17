using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoryCard : MonoBehaviour
{
    public Text categoryName;
    public Image CategoryImage;
    public int categoryId;
    void Start()
    {
        GameObject.Find("ProductList").GetComponent<DisplayProductList>().DeleteAllresultContainer(false, 1);

    }
    public void OnClickOfCard()
    {
    
        PlayerPrefs.SetInt("CategoryID", categoryId);
        Debug.Log("Button clicked");
        GameObject.Find("ProductList").GetComponent<DisplayProductList>().DeleteAllresultContainer(false, categoryId);
      
        
    }
   
}
