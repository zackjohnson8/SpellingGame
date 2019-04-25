using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticSettings
{

    public enum difficultySetting {Beginner, Intermediate, Advanced};
    private static difficultySetting difficultyChoice = difficultySetting.Beginner;
    private static GameObject hitGameObject;
    private static GameObject stayGameObject;
    private static int score = 0;

    public static difficultySetting Difficulty
    {
        get
        {
            return difficultyChoice;
        }
        set
        {
            difficultyChoice = value;
        }
    }

    public static GameObject HitObject
    {

        get
        {
            return hitGameObject;
        }
        set
        {
            hitGameObject = value;
        }

    }

    public static GameObject StayGameObject
    {

        get
        {
            return stayGameObject;
        }
        set
        {
            stayGameObject = value;
        }

    }

    public static int Score
    {

        get
        {
            return score;
        }
        set
        {
            score += value;
        }

    }

}
