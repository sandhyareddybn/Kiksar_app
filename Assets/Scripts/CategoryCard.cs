using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoryCard : MonoBehaviour
{
    public Text categoryName;
    public int categoryId;
    public void OnClickOfCard()
    {
        Debug.Log("Button clicked");
        GameObject.Find("ProductList").GetComponent<DisplayProductList>().getProductList(categoryId);
      //  DisplayProductList.Instance.getProductList(categoryId);
        PlayerPrefs.SetInt("CategoryID", categoryId);
    }
   
}
