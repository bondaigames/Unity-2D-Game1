using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private RectTransform menuContainer;

    [Header("Smooth")]
    [SerializeField] private bool smooth;
    [SerializeField] private float smoothSpeed = 0.1f;
    [SerializeField] private Vector3 desiredPosition;

    [Header("Logic")]
    private Vector3[] menuPositions;


    // Start is called before the first frame update
    void Start()
    {
        menuPositions = new Vector3[menuContainer.childCount];
        //Vector3 halfScreen = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        for (int i = 0; i < menuPositions.Length; i++)
        {
            menuPositions[i] = menuContainer.GetChild(i).localPosition;
            Debug.Log(menuPositions[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (smooth)
        {
            menuContainer.anchoredPosition = Vector3.Lerp(menuContainer.anchoredPosition, desiredPosition, smoothSpeed);
        }
        else
        {
            menuContainer.anchoredPosition = desiredPosition;
        }
    }

    public void MoveMenu(int id)
    {
        desiredPosition = -menuPositions[id];
    }
}
