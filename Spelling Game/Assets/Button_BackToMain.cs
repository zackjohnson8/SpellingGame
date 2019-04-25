using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Valve.VR;


public class Button_BackToMain : MonoBehaviour
{

    public SteamVR_Action_Boolean ButtonPressed;
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;

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

        SceneManager.LoadScene(0);
        StaticSettings.Score = 0;

    }


    void Update()
    {

    }
}