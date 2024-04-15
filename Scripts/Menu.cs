using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject menu;

    public InputActionReference input_menu;

    public Button[] btn_items;

    public GameObject[] items;

    private void Start()
    {
        for (int i = 0; i < btn_items.Length; i++)
        {
            int d = i;
            btn_items[d].onClick.AddListener(() =>
            {
                foreach(var g in items)
                {
                    g.SetActive(false); 
                }

                items[d].SetActive(true);
            });
        }
    }

    private void OnEnable()
    {
        input_menu.action.performed += MenuClick;
    }
    private void MenuClick(InputAction.CallbackContext context)
    {
        menu.SetActive(!menu.activeSelf);
    }
    private void OnDisable()
    {
        input_menu.action.performed -= MenuClick;
    }
}
