using System.Collections;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
  
    public GameObject LoginPanel;
    public GameObject RegisterPanel;
    
    public GameObject userName;
    public GameObject email;
    public GameObject password;
    public GameObject confirmPassword;

    private string UserName;
    private string Email;
    private string Password;
    private string ConfirmPassword;
    private string form;

    private bool EmailValid = false;

    private string[] Characters = 
        {"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z",
         "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
         "1","2","3","4","5","6","7","8","9","_","-"};




    void Start()
    {
       
        RegisterPanel.SetActive(true);
        LoginPanel.SetActive(true);
    }
    public void RegisterButton()
    {
        bool UN = false;
        bool EM = false;
        bool PW = false;
        bool CPW = false;

        if (Password != "" && Email != "" && Password != "" && ConfirmPassword != "")
        {          
            if (UserName != "")
            {
                if (!System.IO.File.Exists(@"E:\TestFiles/" + UserName + ".txt"))
                {
                    UN = true;
                }
                else
                {
                    Debug.Log("Username Taken");
                }

            }
            else
            {
                Debug.Log("Username field empty");
            }
            if (Email != "")
            {
                EmailValidation();
                if (EmailValid)
                {
                    if (Email.Contains("@"))
                    {
                        if (Email.Contains("."))
                        {
                            EM = true;
                        }
                        else
                        {
                            Debug.Log("Email is incorrect");
                        }
                    }
                    else
                    {
                        Debug.Log("Email is incorrect");
                    }
                }
                else
                {
                    Debug.Log("Email is incorrect");
                }
            }
            else
            {
                Debug.Log("Email field Empty");
            }

            if (Password != "")
            {
                if (Password.Length > 5)
                {
                    PW = true;
                }
                else
                {
                    Debug.Log("Password must be atleast 6 character long");
                }
            }
            else
            {
                Debug.Log("Password Field is Empty");
            }

            if (ConfirmPassword != "")
            {
                if (ConfirmPassword == Password)
                {
                    CPW = true;
                }
                else
                {
                    Debug.Log("Password Dont match");
                }
            }
            else
            {
                Debug.Log("Confirm Password Field is Empty");
            }

            if (UN == true && EM == true && PW == true && CPW == true)
            {
                bool Clear = true;
                int i = 1;
                foreach (Char c in Password)
                {
                    if (Clear)
                    {
                        Password = "";
                        Clear = false;
                    }
                    i++;
                    Char Encrypted = (char)(c * i);
                    Password += Encrypted.ToString();
                }

                form = (UserName + Environment.NewLine + Email + Environment.NewLine + Password);
                System.IO.File.WriteAllText(@"E:\TestFiles/" + UserName + ".txt", form);
                userName.GetComponent<InputField>().text = "";
                email.GetComponent<InputField>().text = "";
                password.GetComponent<InputField>().text = "";
                confirmPassword.GetComponent<InputField>().text = "";
                Debug.Log("Registeration completed");


               
                PlayerPrefs.SetInt("Coins", 0);

                for (i = 1; i <= 5; i++)
                {
                    PlayerPrefs.SetFloat("Progression" + i, 0f);
                    PlayerPrefs.SetInt("UpgradeLevel" + i, 1);
                    PlayerPrefs.SetInt("Price" + i, 10);
                }
                for (i = 1; i < 9; i++)
                {
                    PlayerPrefs.SetInt("Lv" + i, 0);
                }



                RegisterPanel.SetActive(false);
                LoginPanel.SetActive(true);
            }
        }
    }
    public void InitalizePlayerPrefs()
    {
       
       
    }
    void EmailValidation()
    {
        bool SW = false;
        bool EW = false;

        for (int i = 0; i < Characters.Length; i++)
        {
            if (Email.StartsWith(Characters[i]))
            {
                SW = true;
            }
        }
        for (int i = 0; i < Characters.Length; i++)
        {
            if (Email.EndsWith(Characters[i]))
            {
                EW = true;
            }
        }
        if (SW == true && EW == true)
        {
            EmailValid = true;
        }
        else
        {
            EmailValid = false;
        }
    }

    

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(userName.GetComponent<InputField>().isFocused)
            {
                email.GetComponent<InputField>().Select();
            }
            if (email.GetComponent<InputField>().isFocused)
            {
                password.GetComponent<InputField>().Select();
            }
            if (password.GetComponent<InputField>().isFocused)
            {
                confirmPassword.GetComponent<InputField>().Select();
            }
        }
            
        UserName = userName.GetComponent<InputField>().text;
        Email = email.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
        ConfirmPassword = confirmPassword.GetComponent<InputField>().text;

    }

}
