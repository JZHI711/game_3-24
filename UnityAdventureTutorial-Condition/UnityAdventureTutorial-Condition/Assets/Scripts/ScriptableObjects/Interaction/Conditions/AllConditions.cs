using System;
using UnityEngine;

// This script works as a singleton asset.  That means that
// it is globally accessible through a static instance
// reference.  
[CreateAssetMenu]
public class AllConditions :ResettableScriptableObject  //多型
{
    public Condition[] conditions;
    private static AllConditions instance;
    public static AllConditions Instance   //外部靠這個變數找到實體
    {
        get
        {
            if (!instance)
                instance = FindObjectOfType<AllConditions>();
            if (!instance)
                instance = Resources.Load<AllConditions>("AllConditions");
            if (!instance)
                Debug.LogError("AllConditions has not created yet!");
            return instance;
        }
    }
    public override void Reset()
    {
        if (conditions == null)
            return;
        for (int i = 0; i < conditions.Length; i++)
        {
            conditions[i].satisfied = false;//重置
        }
    }
    public static bool CheckCondition(Condition requiredCondition)
    {
        Condition[] allConditions = Instance.conditions;
        Condition globalCondition = null;
        if (allConditions != null && allConditions[0] != null)
        {
            for (int i = 0; i < allConditions.Length; i++)
            {
                if (allConditions[i].description == requiredCondition.description)
                    globalCondition = allConditions[i];
            }
            
        }
        if (globalCondition == null)
                return false;
            return globalCondition.satisfied == requiredCondition.satisfied;//滿足條件，接下一關

    }
    public static Condition GetCondition(Condition.ConditionName conditionName)
    {
      
        return Array.Find(Instance.conditions,x => x.description ==conditionName);//x>=x.description...  <<lambda運算式
       /*上面一行等同於
        for(int i=0;i<Instance.conditions.Length;i++)
        {
        if(Instance.conditions[i].description==conditions)
        return Instance.conditions[i];
        }
        */
    }
}
