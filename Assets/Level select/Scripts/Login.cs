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
    //private string Coins;
    //private string[] LevelVal;
    //private string formInLogin;

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
                //Coins = Lines[3].ToString();
                //PlayerPrefs.SetInt("Coins", int.Parse(Coins));
                //for(int m =1; m<=8 ;m++)
                //{
                //    LevelVal[m] = Lines[m + 3].ToString();
                //    PlayerPrefs.SetInt("Lv" + m, int.Parse(LevelVal[m]));
                //}
                Debug.Log("Login success" + PlayerPrefs.GetInt("Coins"));
                LoginPanel.SetActive(false);
                DialoguePanel.SetActive(true);
            }
        }
    }
    //void WriteUpdateInFile()
    //{
    //    for (int m = 1; m <= 8; m++)
    //    {
    //        Lines[m + 3] = PlayerPrefs.GetInt("lv" + m).ToString();
    //    }
    //    formInLogin = (UserName + Environment.NewLine + " " + Environment.NewLine + Password + Environment.NewLine + Coins + Environment.NewLine + Lines[4] + Environment.NewLine + Lines[5] + Environment.NewLine + Lines[6] + Environment.NewLine + Lines[7] + Environment.NewLine + Lines[8] + Environment.NewLine + Lines[9] + Environment.NewLine + Lines[10] + Environment.NewLine + Lines[11]);
    //    System.IO.File.WriteAllText(@"E:\TestFiles/" + UserName + ".txt", formInLogin);
       
    //}
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
