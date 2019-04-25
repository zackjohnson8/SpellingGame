using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Valve.VR;


public class EasyController : MonoBehaviour
{

    protected GameObject hitObject;
    protected RaycastHit rayHit;

    void FixedUpdate()
    {
        //Check if raycast hits anything
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out rayHit))
        {
            //If the object is the same as the one we hit last frame
            if (hitObject != null && hitObject == rayHit.transform.gameObject)
            {
                //Trigger "Stay" method on Interactable every frame we hit
                RayStay(rayHit);
            }
            //We're still hitting something, but it's a new object
            else
            {
                //Trigger the ray "Exit" method on Interactable
                RayExit();

                //Keep track of new objec that we're hitting, and trigger the ray "Enter" method on Interactable
                hitObject = rayHit.transform.gameObject;
                RayEnter(rayHit);
            }
        }
        else
        {
            //We aren't hitting anything. Trigger ray "Exit" on Interactable
            RayExit();
        }
    }

    protected void RayEnter(RaycastHit hit)
    {
        GameObject hitGameObject = hit.collider.gameObject;
        if (hitGameObject == null)
        {
            print("Hit games null");
        }
        else
        {
            StaticSettings.HitObject = hitGameObject;
        }
        print(hitGameObject.name + " Enter");
    }


    private GameObject stayGameObject = null;
    protected void RayStay(RaycastHit hit)
    {
        GameObject hitGameObject = hit.collider.gameObject;
        StaticSettings.StayGameObject = hitGameObject;
    }

    protected void RayExit()
    {
        StaticSettings.HitObject = null;
        hitObject = null;
        print("Exit");
    }

    void Start()
    {
        StaticSettings.HitObject = null;
    }
}

/*
    public SteamVR_Action_Single squeezeAction;
    protected GameObject hitObject;
    protected RaycastHit rayHit;
    public GameObject settingMenuPrefab;
    public GameObject selectionMenuPrefab;

    private Vector3 settingMenuPositionVec;
    private Vector3 selectionMenuPositionVec;

    private GameObject myHitPlayButton = null;
    private GameObject myHitSettingButton = null;
    private GameObject myHitQuitButton = null;
    private GameObject myHitEasyButton = null;
    private GameObject myHitMediumButton = null;
    private GameObject myHitHardButton = null;
    private GameObject justHit;

    protected void RayEnter(RaycastHit hit)
    {
        print("enter something");
        Collider thisColliderWith = hit.collider;
        GameObject thisGame;
        if (thisColliderWith.isTrigger)
        {
            thisGame = thisColliderWith.gameObject;
            if (thisGame.gameObject.name == "Play Cube")
            {
                GameObject.Find("Play Text").gameObject.GetComponent<TextMesh>().color = Color.yellow;

                myHitPlayButton = thisGame;
                myHitSettingButton = null;
                myHitQuitButton = null;
            }

            if (thisGame.gameObject.name == "Setting Cube")
            {
                GameObject.Find("Difficult Text").gameObject.GetComponent<TextMesh>().color = Color.yellow;

                myHitSettingButton = thisGame;
                myHitQuitButton = null;
                myHitPlayButton = null;
            }

            if (thisGame.gameObject.name == "Quit Cube")
            {
                GameObject.Find("Exit Text").gameObject.GetComponent<TextMesh>().color = Color.yellow;

                myHitQuitButton = thisGame;
                myHitSettingButton = null;
                myHitPlayButton = null;
            }

            if (thisGame.gameObject.name == "Easy Cube")
            {
                GameObject.Find("Easy Text").gameObject.GetComponent<TextMesh>().color = Color.yellow;

                myHitEasyButton = thisGame;
                myHitMediumButton = null;
                myHitHardButton = null;
            }

            if (thisGame.gameObject.name == "Medium Cube")
            {
                GameObject.Find("Intermediate Text").gameObject.GetComponent<TextMesh>().color = Color.yellow;

                myHitMediumButton = thisGame;
                myHitEasyButton = null;
                myHitHardButton = null;
            }

            if (thisGame.gameObject.name == "Hard Cube")
            {
                GameObject.Find("Hard Text").gameObject.GetComponent<TextMesh>().color = Color.yellow;

                myHitHardButton = thisGame;
                myHitEasyButton = null;
                myHitMediumButton = null;
            }

        }

        
    }


    private GameObject stayGameObject = null;
    protected void RayStay(RaycastHit hit)
    {
        //print("stay something");
        Collider thisColliderWith = hit.collider;
        stayGameObject = thisColliderWith.gameObject;

    }

    protected void RayExit()
    {
        stayGameObject = null;
        if (myHitPlayButton != null)
        {
            myHitPlayButton = null;
            GameObject.Find("Play Text").gameObject.GetComponent<TextMesh>().color = Color.white;
        }

        if (myHitSettingButton != null)
        {
            myHitSettingButton = null;
            GameObject.Find("Difficult Text").gameObject.GetComponent<TextMesh>().color = Color.white;
        }

        if (myHitQuitButton != null)
        {
            myHitQuitButton = null;
            GameObject.Find("Exit Text").gameObject.GetComponent<TextMesh>().color = Color.white;
        }

        ////////////////

        if (myHitEasyButton != null)
        {
            myHitEasyButton = null;
            GameObject.Find("Easy Text").gameObject.GetComponent<TextMesh>().color = Color.white;
        }

        if (myHitMediumButton != null)
        {
            myHitMediumButton = null;
            GameObject.Find("Intermediate Text").gameObject.GetComponent<TextMesh>().color = Color.white;
        }

        if (myHitHardButton != null)
        {
            myHitHardButton = null;
            GameObject.Find("Hard Text").gameObject.GetComponent<TextMesh>().color = Color.white;
        }

    }

    void Awake()
    {
 
    }

    void Start()
    {
        selectionMenuPositionVec = GameObject.Find("SelectionMenu").transform.position;
        settingMenuPositionVec = new Vector3(1.810228f, 2.02f, -0.05f);

    }

    bool triggerPressed = false;
    bool triggerReleased = false;
    bool canSqueeze = true;
    float triggerValue;
    // Update is called once per frame
    void FixedUpdate()
    {
 
        triggerValue = squeezeAction.GetAxis(SteamVR_Input_Sources.Any);
        

        // Push button
        if(triggerValue > 0.0f)
        {
            triggerPressed = true;
        }

        // Release button
        if(triggerValue <= 0.0f && triggerPressed)
        {
            triggerReleased = true;
            triggerPressed = false;
        }

        // Button been released
        if(triggerReleased && (stayGameObject != null))
        { 

            // set false to keep from re-entering
            triggerReleased = false;

            // On which object are we staying?
            // Only when the object is enter do we have access to each button
            if (myHitPlayButton != null && stayGameObject != null)
            {
                StartGame();
            }else
            if (myHitSettingButton != null && stayGameObject != null)
            {
                OpenSettings();
            }else
            if (myHitQuitButton != null && stayGameObject != null)
            {
                QuitGame();
            }else
            if (myHitEasyButton != null && stayGameObject != null)
            {
                if (stayGameObject.name == myHitEasyButton.name)
                {
                    RayExit();

                    print("Trigger on myHitEasyButton");
                    GameObject oldView = GameObject.Find("SettingMenu(Clone)");
                    GameObject newItem = Instantiate(selectionMenuPrefab, selectionMenuPositionVec, oldView.transform.rotation);
                    newItem.name = "SelectionMenu";
                    oldView.SetActive(false);
                    StaticSettings.Difficulty = StaticSettings.difficultySetting.Beginner;
                    return;

                }
            }else
            if (myHitMediumButton != null && stayGameObject != null)
            {
                if (stayGameObject.name == myHitMediumButton.name)
                {
                    RayExit();

                    print("Trigger on myHitMediumButton");
                    GameObject oldView = GameObject.Find("SettingMenu(Clone)");
                    GameObject newItem = Instantiate(selectionMenuPrefab, selectionMenuPositionVec, oldView.transform.rotation);
                    newItem.name = "SelectionMenu";
                    oldView.SetActive(false);
                    StaticSettings.Difficulty = StaticSettings.difficultySetting.Intermediate;
                    return;
                }
            }else
            if (myHitHardButton != null && stayGameObject != null)
            {
                if (stayGameObject.name == myHitHardButton.name)
                {
                    RayExit();

                    print("Trigger on myHitHardButton");
                    GameObject oldView = GameObject.Find("SettingMenu(Clone)");
                    GameObject newItem = Instantiate(selectionMenuPrefab, selectionMenuPositionVec, oldView.transform.rotation);
                    newItem.name = "SelectionMenu";
                    oldView.SetActive(false);
                    StaticSettings.Difficulty = StaticSettings.difficultySetting.Advanced;
                    return;

                }
            }
        }


        //Check if raycast hits anything
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out rayHit))
        {
            //If the object is the same as the one we hit last frame
            if (hitObject != null && hitObject == rayHit.transform.gameObject)
            {
                //Trigger "Stay" method on Interactable every frame we hit
                RayStay(rayHit);
            }
            //We're still hitting something, but it's a new object
            else
            {
                //Trigger the ray "Exit" method on Interactable
                RayExit();

                //Keep track of new objec that we're hitting, and trigger the ray "Enter" method on Interactable
                hitObject = rayHit.transform.gameObject;
                RayEnter(rayHit);
            }
        }
        else
        {
            //We aren't hitting anything. Trigger ray "Exit" on Interactable
            RayExit();
        }

    }

    private void StartGame()
    {
        if (stayGameObject.name == myHitPlayButton.name)
        {
            RayExit();

            print("Trigger on myHitPlayButton");
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);

        }
    }

    private void OpenSettings()
    {
        if (stayGameObject.name == myHitSettingButton.name)
        {
            RayExit();

            print("Trigger on myHitSettingButton");
            try
            {
                GameObject oldView = GameObject.Find("SelectionMenu");
                Instantiate(settingMenuPrefab, settingMenuPositionVec, oldView.transform.rotation);
                oldView.SetActive(false);
            }
            catch
            {
                print("Old View doesn't exist");
            }

        }
    }

    private void QuitGame()
    {
        if (stayGameObject.name == myHitQuitButton.name)
        {
            RayExit();

            print("Trigger on myHitQuitButton");
            Application.Quit();

        }
    }
    */
