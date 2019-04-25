using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Valve.VR;


public class CorrectButton_Lobster : MonoBehaviour
{

    public SteamVR_Action_Boolean ButtonPressed;
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;

    public GameObject medPrefab;

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
        GameObject oldView = GameObject.Find("LobsterGrouping");
        GameObject newView = Instantiate(medPrefab, new Vector3(6.812615f, 1.675369f, 9.935381f), new Quaternion(0f, 0f, 0f, 0f));
        newView.name = "HamsterGrouping";
        oldView.SetActive(false);



    }


    void Update()
    {

    }
}

