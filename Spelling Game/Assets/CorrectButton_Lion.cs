using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Valve.VR;


public class CorrectButton_Lion : MonoBehaviour
{

    public SteamVR_Action_Boolean ButtonPressed;
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;

    public GameObject Lightning;
    public GameObject Boom1;
    public GameObject Boom2;
    public GameObject endMenu;

    // Reference to this button
    public GameObject button;


    void Start()
    {
        ButtonPressed.AddOnStateUpListener(TriggerDown, inputSource);

    }

    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {

        if (StaticSettings.StayGameObject == button)
        {
            ButtonAction();
        }
    }

    private void ButtonAction()
    {

        // Load Difficulty Level's Process
        // Correct answer so add 1 to score
        if (StaticSettings.StayGameObject == GameObject.Find("Correct"))
        {
            StaticSettings.Score = 1;
        }

        print("Clicked Correct");
        // Just go with a static choice route with the game.
        GameObject oldView = GameObject.Find("LionGrouping");
        GameObject newView = Instantiate(Lightning, new Vector3(13.85109f, 3.922909f, 4.456849f), new Quaternion(0f, 0f, 0f, 0f));
        GameObject newView1 = Instantiate(Boom1, new Vector3(13.85109f, 3.922909f, 4.456849f), new Quaternion(0f, 0f, 0f, 0f));
        GameObject newView2 = Instantiate(Boom2, new Vector3(13.85109f, 3.922909f, 4.456849f), new Quaternion(0f, 0f, 0f, 0f));

        GameObject endMenuGO = Instantiate(endMenu, new Vector3(6.12f, 1.68f, 4.94f), endMenu.transform.rotation);

        newView.name = "Particle1";
        newView1.name = "Particle2";
        newView2.name = "Particle3";
        oldView.SetActive(false);

    }


    void Update()
    {

    }
}