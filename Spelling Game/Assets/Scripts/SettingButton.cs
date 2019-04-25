using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Valve.VR;


public class SettingButton : MonoBehaviour
{

    public SteamVR_Action_Boolean ButtonPressed;
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;
    public GameObject controllerLeft;
    public GameObject controllerRight;

    public GameObject settingMenuPrefab;

    private Vector3 settingMenuPositionVec;

    // Reference to this button
    public GameObject button;


    void Start()
    {
        ButtonPressed.AddOnStateUpListener(TriggerDown, inputSource);
        settingMenuPositionVec = new Vector3(1.810228f, 2.02f, -0.05f);

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
        if (settingMenuPrefab != null)
        {
            GameObject oldView = GameObject.Find("SelectionMenu");
            if (oldView != null)
            {
                Instantiate(settingMenuPrefab, settingMenuPositionVec, oldView.transform.rotation);
                oldView.SetActive(false);
            }
        }
    }


    void Update()
    {

    }
}
