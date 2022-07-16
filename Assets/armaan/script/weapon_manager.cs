using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_manager : MonoBehaviour
{
    public GameObject pistol;
    public Transform meeple;
    public GameObject sheild;
    public Transform meeple2;
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.E))
        {
            index = Random.Range(0, 2);
            gameObject.transform.GetChild(index).gameObject.SetActive(true);
            
        }
    }
}
