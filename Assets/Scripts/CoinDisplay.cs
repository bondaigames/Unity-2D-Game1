using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinDisplay : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    //public GameObject icon;
    GameSession gameSession;

    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        //coinText.text = gameSession.GetCoin().ToString();
        Construct(gameSession.GetCoin().ToString());
    }

    public void Construct(string text)
    {
        //coinText.fontSize = fontSize;
        coinText.autoSizeTextContainer = true;
        coinText.text = text;

        //Vector2 textSize = coinText.GetPreferredValues(text);
        
    }
}
