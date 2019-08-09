using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject Tuts;

    public void OnClick()
    {
        Tuts.SetActive(true);
    }

    public void OnReturn()
    {
        Tuts.SetActive(false);
    }
}
