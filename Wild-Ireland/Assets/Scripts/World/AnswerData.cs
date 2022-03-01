using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AnswerData : MonoBehaviour
{
    [Header("UI Elemeents")]
    [SerializeField] TextMeshProUGUI infoTextObject;
    [SerializeField] Image toggle;

    [Header("Texture")]
    [SerializeField] Sprite uncheckedToggle;
    [SerializeField] Sprite checkedToggle;

    private int _answerIndex = -1;
    public int AnswerIndex { get { return _answerIndex; } }
}
