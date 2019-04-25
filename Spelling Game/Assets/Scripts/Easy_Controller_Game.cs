using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Easy_Controller_Game : MonoBehaviour
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


    }

    protected void RayExit()
    {
        StaticSettings.HitObject = null;
        hitObject = null;
        print("Exit");
    }
}
/*
public SteamVR_Action_Single squeezeAction;
protected GameObject hitObject;
protected RaycastHit rayHit;
public GameObject controllerPrefab;

public GameObject dogCanvas;
public GameObject giraffeCanvas;
public GameObject hamsterCanvas;
public GameObject hippoCanvas;
public GameObject lionCanvas;
public GameObject lobsterCanvas;
public GameObject opossumCanvas;
public GameObject pterodactylCanvas;
public GameObject redCanvas;

private List<GameObject> beginnerArray;
private GameObject[] intermediateArray;
private GameObject[] advanceArray;

private Vector3 settingMenuPositionVec;
private Vector3 selectionMenuPositionVec;

private GameObject myHitTutorialButton;
private GameObject myHitSkipButton;
private GameObject justHit;

protected void RayEnter(RaycastHit hit)
{

    Collider thisColliderWith = hit.collider;
    GameObject thisGame;
    if (thisColliderWith.isTrigger)
    {
        thisGame = thisColliderWith.gameObject;
        if (thisGame.gameObject.name == "Tutorial")
        {
            GameObject.Find("Tutorial Text").gameObject.GetComponent<TextMesh>().color = Color.yellow;

            myHitTutorialButton = thisGame;
        }

        if (thisGame.gameObject.name == "Skip")
        {
            GameObject.Find("Skip Text").gameObject.GetComponent<TextMesh>().color = Color.yellow;

            myHitSkipButton = thisGame;
        }

        //if( thisGame.gameObject.name == )

    }


}

protected void RayStay(RaycastHit hit)
{


}

protected void RayExit()
{
    if (myHitTutorialButton != null)
    {
        myHitTutorialButton = null;
        GameObject.Find("Tutorial Text").gameObject.GetComponent<TextMesh>().color = Color.white;
    }

    if (myHitSkipButton != null)
    {
        myHitSkipButton = null;
        GameObject.Find("Skip Text").gameObject.GetComponent<TextMesh>().color = Color.white;
    }


}

void Awake()
{

}

private Transform myGameSelection;

void Start()
{
    beginnerArray = new List<GameObject>();
    beginnerArray.Add(dogCanvas);
    beginnerArray.Add(redCanvas);
    beginnerArray.Add(lionCanvas);
    myGameSelection = GameObject.Find("GameSelection").transform;
}

bool triggerPressed = false;
bool triggerReleased = false;
private List<int> index = new List<int>();
bool beginGameEasy = false;
bool beginGameIntermediate = false;
bool beginGameAdvanced = false;
GameObject chosenPrefab = null;
bool skipClicked = false;
bool tutorialClicked = false;
int count = 0;

// Update is called once per frame
void Update()
{


    float triggerValue = squeezeAction.GetAxis(SteamVR_Input_Sources.Any);

    if (triggerValue > 0.0f)
    {
        triggerPressed = true;
    }

    if (triggerValue <= 0.0f && triggerPressed)
    {
        triggerReleased = true;
        triggerPressed = false;
    }


    if (triggerReleased)
    {
        triggerReleased = false;

        if (myHitTutorialButton != null)
        {

            // TODO(zack): Start a tutorial for the user. Demonstrate that the user can select a letter with the trigger.
            // Not sure how to do this but we'll see.
            // Change the screen to have a prefab controllers and other items.
            // This can be a single screen just showing how the user can pick these.
            // Controller, Image, line to letter selection... 
            myHitTutorialButton = null;
            GameObject.Find("GameSelection").SetActive(false);

            // Poof there goes the menu
            // Begin tutorial building


        }

        if(beginGameEasy)
        {
            // Based on the difficulty of the game type we'll be shuffling through the three "easy", "med", or "hard" prefabs.

            // If the difficulty is beginner choose a string from the beginnerPrefabChoices

            if(count <= 3)
            {
                print("here");

                if(chosenPrefab != null)
                {
                    chosenPrefab.SetActive(false);
                }

                int prefabChoice;
                bool doWhile;
                do
                {
                    prefabChoice = Random.Range(0, 2);
                    if (index.Contains(prefabChoice))
                    {
                        doWhile = true;
                    }
                    else
                    {
                        doWhile = false;
                    }

                } while (doWhile);
                index.Add(prefabChoice);
                count++;
                // Load prefab to begin the game
                chosenPrefab = beginnerArray[prefabChoice];
                Instantiate(chosenPrefab, myGameSelection.position, myGameSelection.rotation);
            }else
            {
                beginGameEasy = false;
            }


        }

        if(beginGameIntermediate)
        {

        }

        if(beginGameAdvanced)
        {

        }

        if (myHitSkipButton != null && (skipClicked == false))
        {
            print("Here");
            // TODO(zack): Skip the tutorial and go straight to the game.
            myHitSkipButton = null;
            skipClicked = true;


            if (StaticSettings.Difficulty == StaticSettings.difficultySetting.Beginner)
            {
                beginGameEasy = true;
                GameObject.Find("GameSelection").SetActive(false);
            }

            if (StaticSettings.Difficulty == StaticSettings.difficultySetting.Intermediate)
            {
                beginGameIntermediate = true;
            }

            if (StaticSettings.Difficulty == StaticSettings.difficultySetting.Advanced)
            {
                beginGameAdvanced = true;
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
}

*/
