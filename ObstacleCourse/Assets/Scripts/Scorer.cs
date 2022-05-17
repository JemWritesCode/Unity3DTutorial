using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    int playerScore = 0;
    private void OnCollisionEnter(Collision collision)
    {
        playerScore++;
        Debug.Log("Bump Score: " + playerScore);
    }
}
