using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Valve.VR;


public class Skip_Button : MonoBehaviour
{

    public SteamVR_Action_Boolean ButtonPressed;
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;

    public GameObject easyPrefab;
    public GameObject medPrefab;
    public GameObject hardPrefab;

    // Reference to this button
    public GameObject button;


    void Start()
    {
        ButtonPressed.AddOnStateUpListener(TriggerDown, inputSource);

    }

    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {

        if (StaticSettings.HitObject == button)
        {
            ButtonAction();
        }
    }

    private void ButtonAction()
    {

        if (StaticSettings.HitObject == button)
        {
            // Load Difficulty Level's Process
            if (StaticSettings.Difficulty == StaticSettings.difficultySetting.Beginner)
            {
                // Just go with a static choice route with the game.
                GameObject oldView = GameObject.Find("GameSelection");
                GameObject newView = Instantiate(easyPrefab, new Vector3(16.46215f, 9.898539f, 1.229087f), new Quaternion(0f, 0f, 0f, 0f));
                newView.name = "DogGrouping";
                oldView.SetActive(false);

            }

            if (StaticSettings.Difficulty == StaticSettings.difficultySetting.Intermediate)
            {

                GameObject oldView = GameObject.Find("GameSelection");
                GameObject newView = Instantiate(medPrefab, new Vector3(12.44765f, 4.692985f, 4.416859f), new Quaternion(0f,0f,0f,0f));
                newView.name = "LobsterGrouping";
                oldView.SetActive(false);

            }

            if (StaticSettings.Difficulty == StaticSettings.difficultySetting.Advanced)
            {
                GameObject oldView = GameObject.Find("GameSelection");
                GameObject newView = Instantiate(hardPrefab, new Vector3(10.99472f, 4.695132f, 5.471913f), new Quaternion(0f, 0f, 0f, 0f));
                newView.name = "OpossumGrouping";
                oldView.SetActive(false);
            }
        }
    }


    void Update()
    {

    }
}
