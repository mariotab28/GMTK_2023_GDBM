using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MatchDefinition", order = 1)]
public class MatchDefinition : ScriptableObject
{
    public MatchType matchType;
    public float matchSecondsDuration;
}

public enum MatchType
{
    AI,
    Multiplayer1v1
}