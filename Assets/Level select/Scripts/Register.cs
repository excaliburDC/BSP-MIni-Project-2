using System.Collections;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour
{

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

   

    

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void RegisterDialogue()
    {
        bool UN = false;
        bool EM = false;
        bool PW = false;
        bool CPW = false;

        if (UserName != "" &&  Email != "" && Password != "" && ConfirmPassword != "")
        {
            Debug.Log("Registeration success");
            if (UserName != "")
            {
                if (System.IO.File.Exists(@"E:\TestFiles/" + UserName + ".txt"))
                {
                    UN = true;
                }
                else
                {
                    Debug.LogWarning("Username Taken");
                }

            }else
            {
                Debug.LogWarning("Username field empty");
            }
            if(Email != "")
            {
                EmailValidation();
                if (EmailValid)
                {
                    if(Email.Contains("@"))
                    {
                        if(Email.Contains("."))
                        {
                            EM = true;
                        }else
                        {
                            Debug.LogWarning("Email is incorrect");
                        }
                    }
                    else
                    {
                        Debug.LogWarning("Email is incorrect");
                    }
                }
                else
                {
                    Debug.LogWarning("Email is incorrect");
                }
            }
            else
            {
                Debug.LogWarning("Email field Empty");
            }
            if(Password != "")
            {
                if(Password.Length >5)
                {
                    PW = true;
                }else
                {
                    Debug.LogWarning("Password must be atleast 6 character long");
                }
            }
            else
            {
                Debug.LogWarning("Password Field is Empty");
            }
            if(ConfirmPassword != "")
            {
                if(ConfirmPassword == Password)
                {
                    CPW = true;
                }else
                {
                    Debug.LogWarning("Password Dont match");
                }
            }else
            {
                Debug.LogWarning("Confirm Password Field is Empty");
            }

            if(UN == true && EM == true && PW ==true && CPW == true)
            {
                bool Clear = true;
                int i = 1;
                foreach(Char c in Password)
                {
                    if(Clear)
                    {
                        Password = "";
                        Clear = false;
                    }
                    i++;
                    Char Encrypted = (char)(c * i);
                    Password += Encrypted.ToString();
                }
                form = (UserName + "\n" + Email + "\n" + Password);
                System.IO.File.WriteAllText(@"E:\TestFiles/" + UserName + ".txt",form);
                userName.GetComponent<InputField>().text = "";
                email.GetComponent<InputField>().text = "";
                password.GetComponent<InputField>().text= "";
                confirmPassword.GetComponent<InputField>().text= "";
                Debug.Log("Registeration completed");
            }
        }
    }

    void EmailValidation()
    {

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
