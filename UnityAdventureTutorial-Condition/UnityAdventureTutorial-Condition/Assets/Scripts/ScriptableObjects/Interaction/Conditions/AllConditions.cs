using System;
using UnityEngine;

// This script works as a singleton asset.  That means that
// it is globally accessible through a static instance
// reference.  
public class AllConditions :ResettableScriptableObject//多型
{
    public Condition[] conditions;
    private static AllConditions instance;
    public static AllConditions Instance//外部靠這個變數找到實體
    {
        get
        {
            if (!instance)
                instance = FindObjectOfType<AllConditions>();
            if (!instance)
                instance = Resources.Load<AllConditions>("AllConditions");
            if (!instance)
                Debug.LogError("AllConditions has not created yet");
            return instance;
        }
    }
    public override void Reset()
    {
        throw new NotImplementedException();
    }
}
