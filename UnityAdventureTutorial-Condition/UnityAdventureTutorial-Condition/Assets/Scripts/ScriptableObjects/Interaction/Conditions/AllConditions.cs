using System;
using UnityEngine;

// This script works as a singleton asset.  That means that
// it is globally accessible through a static instance
// reference.  
[CreateAssetMenu]
public class AllConditions :ResettableScriptableObject  //�h��
{
    public Condition[] conditions;
    private static AllConditions instance;
    public static AllConditions Instance   //�~���a�o���ܼƧ�����
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
            conditions[i].satisfied = false;//���m
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
            return globalCondition.satisfied == requiredCondition.satisfied;//��������A���U�@��

    }
    public static Condition GetCondition(Condition.ConditionName conditionName)
    {
      
        return Array.Find(Instance.conditions,x => x.description ==conditionName);//x>=x.description...  <<lambda�B�⦡
       /*�W���@�浥�P��
        for(int i=0;i<Instance.conditions.Length;i++)
        {
        if(Instance.conditions[i].description==conditions)
        return Instance.conditions[i];
        }
        */
    }
}
