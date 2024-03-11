using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour
{
    [SerializeField] private GameObject Credits;
    public void ShowCreddits()
    {
        Credits.SetActive(!Credits.activeSelf);
    }
    public void QuitGame()
    {
        Application.Quit();

    }
}
