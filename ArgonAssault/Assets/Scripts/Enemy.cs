using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;
    [SerializeField] int pointsToIncrease = 1;
    [SerializeField] int hitPoints = 3;

    Scoreboard scoreBoard;

    private void Start()
    {
        scoreBoard = FindObjectOfType<Scoreboard>();
        NewMethod();

    }

    private void NewMethod()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }

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
           // EnemyHitFlash();
            hitPoints--;
        }
    }
}
