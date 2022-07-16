using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_manager : MonoBehaviour
{
    public GameObject pistol;
    public Transform meeple;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("input");

            gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
