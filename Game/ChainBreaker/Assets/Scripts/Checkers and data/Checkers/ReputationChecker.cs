using UnityEngine;

public class ReputationChecker : MonoBehaviour
{
    public ReputationTracking reputationData;

    void Start()
    {
        //Debug.Log("Current Reputation: " + reputationData.reputation);
    }

    void Update()
    {
        // Example: check if reputation is high
        if (reputationData.reputation >= 80f)
        {
            Debug.Log("You're well liked!");
        }
    }
}
