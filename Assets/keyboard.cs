using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class keyboard : MonoBehaviour
{
    public TMP_Text text;
    public TMP_InputField text2;
    private TouchScreenKeyboard keyboardptr;
    public GameObject gazeIcon;
    public GameObject pointerLine;

    public void ShowKeyboard()
    {
        keyboardptr = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }

    // Start is called before the first frame update
    void Start()
    {
        //ShowKeyboard();
        OVRManager.InputFocusLost += KeyboardActive;
        OVRManager.InputFocusAcquired += SetTextNow;
    }

    public void SetTextNow()
    {
        text.text = "Anastasis said " + text2.text;
        gazeIcon.SetActive(true);
        pointerLine.SetActive(true);
    }

    private void OnDestroy()
    {
        OVRManager.InputFocusLost -= SetTextNow;
    }

    public void KeyboardActive()
    {
        gazeIcon.SetActive(false);
        pointerLine.SetActive(false);
    }
}
