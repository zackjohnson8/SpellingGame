using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Valve.VR;


public class EasySettingButton : MonoBehaviour
{

    public SteamVR_Action_Boolean ButtonPressed;
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;


    public GameObject selectionMenuPrefab;
    private Vector3 settingMenuPositionVec;

    // Reference to this button
    public GameObject button;


    void Start()
    {
        ButtonPressed.AddOnStateUpListener(TriggerDown, inputSource);
        settingMenuPositionVec = new Vector3(1.810228f, 4.19337f, -8.116996f);

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
        GameObject oldView = GameObject.Find("SettingMenu(Clone)");
        if(oldView != null)
        {

            GameObject newItem = Instantiate(selectionMenuPrefab, settingMenuPositionVec, oldView.transform.rotation);
            newItem.name = "SelectionMenu";
            oldView.SetActive(false);
            StaticSettings.Difficulty = StaticSettings.difficultySetting.Beginner;

        }
        

    }


    void Update()
    {

    }
}
