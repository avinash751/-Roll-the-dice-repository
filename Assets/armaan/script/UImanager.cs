using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UImanager : MonoBehaviour
{

    public TextMeshProUGUI textBox;

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        textBox.text = GameManager.instance.CurrentTime.ToString();
    }
}
