using Platformer.Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_Coint : MonoBehaviour
{
    [SerializeField] private Text text_count_coints;
    private void Update()
    {
        text_count_coints.text = GlobalStringVars.global_count_coints.ToString();
    }
}
