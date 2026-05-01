using UnityEngine;

[CreateAssetMenu(fileName = "ReputationTracking", menuName = "Scriptable Objects/ReputationTracking")]
public class ReputationTracking : ScriptableObject
{
    public float reputation = 50;
    public float minReputation = 0f;
    public float maxReputation = 100f;

    public void ChangeReputationAdditive(float change)
    {
        reputation = Mathf.Clamp(reputation + change, minReputation, maxReputation);
        // to subtract add a negative
    }

    public void ChangeReputationMultiplicative(float change)
    {
        reputation = Mathf.Clamp(reputation * change, minReputation, maxReputation);
        // to divide multiply by a decimal
    }
}
