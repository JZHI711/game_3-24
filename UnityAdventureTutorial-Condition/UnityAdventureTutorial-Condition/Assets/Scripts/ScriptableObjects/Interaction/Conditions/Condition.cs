using UnityEngine;

// This class is used to determine whether or not Reactions
// should happen.  Instances of Condition exist in two places:
// as assets which are part of the AllConditions asset and as
// part of ConditionCollections.  The Conditions that are part
// of the AllConditions asset are those that are set by
// Reactions and reflect the state of the game.  Those that
// are on ConditionCollections are compared to the
// AllConditions asset to determine whether other Reactions
// should happen.
[System.Serializable]
public class Condition
{
    public enum ConditionName//列舉
    {
        PickedUpCoin,
        HasCoin,
        PickedUpFish,
        PickedUpCoffee,
        HasCoffee,
        BirdDisturbed,
        PickedUpGlasses,
        HasGlasses,
        LaserDeactived
    }
    public ConditionName description;
    public bool satisfied;
}