using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoxUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    public void SetText(string text)
    {
        this.text.text = text;
    }
}
