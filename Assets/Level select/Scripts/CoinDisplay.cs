using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinDisplay : MonoBehaviour
{
    private Text coinText;

    // Start is called before the first frame update
    void Start()
    {
        coinText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //string temp = coinText.text.Split(':');
        //coinText.text = PlayerPrefs.GetInt("Coins").ToString();
    }
}
