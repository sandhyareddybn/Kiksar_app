using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public InputField userName;
    public GameObject validInput;
    public void OnClickLogin()
    {
        string name = userName.text;
        if(!string.IsNullOrEmpty(name))
        {
            SceneManager.LoadScene("AppScene");
        }
        else
        {
            Debug.Log("Please enter the name");
            validInput.SetActive(true);
        }
    }

}
