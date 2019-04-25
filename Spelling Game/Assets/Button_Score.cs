using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Score : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject myGameObject = GameObject.Find("Score Text");

        myGameObject.GetComponent<TextMesh>().text = "Score: " + StaticSettings.Score + "/3";


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
