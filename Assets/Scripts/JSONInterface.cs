using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Threading.Tasks;

[Serializable]
public class Category
{
    public int CategoryId;
    public string CategoryName;
    public Products[] Products;
}
[Serializable]
public class Products
{
    public string ProductName;
}
public class JsonHelper
{
    public static T[] getJsonArray<T>(string json)
    {
        string newJson = "{ \"array\": " + json + "}";
        Wrapper<T> wrapper = new Wrapper<T>();
#if ENABLE_WINMD_SUPPORT || WINDOW_MACRO
       // wrapper = Newtonsoft.Json.JsonConvert.DeserializeObject<Wrapper<T>>(newJson);
        wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
#endif

#if UNITY_ANDROID || UNITY_IOS
        wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);

#endif

        return wrapper.array;
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] array;
    }
}

public class JSONInterface : MonoBehaviour
{
    string path;
    string jsonString;
    public static JSONInterface Instance;
    void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }
        else if(Instance!=this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        DontDestroyOnLoad(Instance);
       
        if(Application.platform==RuntimePlatform.WindowsEditor)
        {
            path = Application.streamingAssetsPath + "/Category.json";
             jsonString = File.ReadAllText(path);
        }
        else if(Application.platform==RuntimePlatform.Android)
        {
            TextAsset txtAsset = Resources.Load("Category") as TextAsset;
            jsonString = txtAsset.ToString();
        }

       
        Debug.Log(jsonString);
       
     
    }
    public async Task<Category[]> getCategoryData()
    {
        Category[] categories = null;
         categories =JsonHelper.getJsonArray<Category>(jsonString);
        return categories;

    }
}
