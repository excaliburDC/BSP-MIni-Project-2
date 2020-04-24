using System.Collections;
using System;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public GameObject LoginPanel;
    public GameObject RegisterPanel;
    public GameObject DialoguePanel;

    public GameObject userName; 
    public GameObject password;

    private string UserName;
    private string Password;
    private String[] Lines;
    private string DecryptedPassword;

    void Start()
    {
        LoginPanel.SetActive(true);
        RegisterPanel.SetActive(false);
        DialoguePanel.SetActive(false);
    }
    public void RegisterButtonMain()
    {
        LoginPanel.SetActive(false);
        RegisterPanel.SetActive(true);
    }
    public void LoginButton()
    {
        bool UN = false;
        bool PW = false;

        if (Password != "" && Password != "")
        {
            if (UserName != "")
            {
                if (System.IO.File.Exists(@"E:\TestFiles/" + UserName + ".txt"))
                {
                    UN = true;
                    Lines = System.IO.File.ReadAllLines(@"E:\TestFiles/" + UserName + ".txt");
                }
                else
                {
                    Debug.Log("Username invalid");
                }
            }
            else
            {
                Debug.Log("Username is empty");

            }
            if (Password != "")
            {
                if (System.IO.File.Exists(@"E:\TestFiles/" + UserName + ".txt"))
                {

                    int i = 1;
                    foreach (Char c in Lines[2])
                    {
                        i++;
                        Char Decrypted = (char)(c / i);
                        DecryptedPassword += Decrypted.ToString();
                    }
                    if (Password == DecryptedPassword)
                    {
                        PW = true;
                    }
                    else
                    {
                        Debug.Log("Password invalid");
                    }

                }
                else
                {
                    Debug.Log("Password invalid");
                }
            }
            else
            {
                Debug.Log("Password empty");
            }
            if (UN == true && PW == true)
            {
                userName.GetComponent<InputField>().text = "";
                password.GetComponent<InputField>().text = "";
                Debug.Log("Login success");
                LoginPanel.SetActive(false);
                DialoguePanel.SetActive(true);
            }
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (userName.GetComponent<InputField>().isFocused)
            {
                password.GetComponent<InputField>().Select();
            }
        }

        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    if (Password != "" && Password != "" )
        //    {
        //        LoginButton();
        //    }
        //}

        UserName = userName.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
    }
}
