using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int pointsToIncrease = 1;
    [SerializeField] int hitPoints = 3;

    Scoreboard scoreBoard;
    GameObject parentGameObject;

    private void Start()
    {
        scoreBoard = FindObjectOfType<Scoreboard>();
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
        AddRigidBody();

    }

    private void AddRigidBody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
    }

    private void HitEnemy()
    {
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
    }

    // doesn't work on the fancy spaceships cause of mesh renderer being at different levels. still good to konw.
    //private void EnemyHitFlash()
    //{
    //    GetComponent<MeshRenderer>().material.color = Color.red;
    //    StartCoroutine(TurnBackToWhite(.1f));
    //    IEnumerator TurnBackToWhite(float time){
    //        yield return new WaitForSeconds(time);
    //        GetComponent<MeshRenderer>().material.color = Color.white;
    //    }

    //}

    private void ProcessHit()
    {
        scoreBoard.IncreaseScore(pointsToIncrease);
        if (hitPoints == 0)
        {
            KillEnemy();
        }
        else
        {
           HitEnemy();
            hitPoints--;
        }
    }
}
