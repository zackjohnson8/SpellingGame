using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Valve.VR;


public class CorrectButton_Pterodactyl : MonoBehaviour
{

    public SteamVR_Action_Boolean ButtonPressed;
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;

    public GameObject hardPrefab;

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
        GameObject oldView = GameObject.Find("PterodactylGrouping");
        GameObject newView = Instantiate(hardPrefab, new Vector3(14.52768f, 1.981849f, 2.996338f), new Quaternion(0f, 0f, 0f, 0f));
        newView.name = "HippoGrouping";
        oldView.SetActive(false);



    }


    void Update()
    {

    }
}