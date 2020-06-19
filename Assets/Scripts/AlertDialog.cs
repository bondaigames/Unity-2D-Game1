using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AlertDialog : MonoBehaviour
{

    public TextMeshProUGUI messageText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ShowMessage(string message)
    {
        messageText.text = message;
        gameObject.SetActive(true);
    }

    public void CloseMessage()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
