using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// implements the Singleton Design Pattern

public class ExplosionManager : MonoBehaviour
{
    private GameObject explosion;
    public GameObject explosionContainer;

    private GameController gameController;

    public int explosionNumber = 10;
    private static Queue<GameObject> explosions;

    private static ExplosionManager _instance;

    public static ExplosionManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new ExplosionManager();
            return _instance;
        }

        return _instance;
    }


    private ExplosionManager()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        // make references to objects
        gameController = gameObject.GetComponent<GameController>();
        explosion = gameController.explosion;
        explosions = new Queue<GameObject>(); // instantiates an empty queue container

        BuildExplosionPool();
    }

    private void BuildExplosionPool()
    {
        for (int i = 0; i < explosionNumber; i++)
        {
            var newExplosion = Instantiate(explosion);
            newExplosion.SetActive(false);
            // set the new explosion to appear inside the explosion Container GO
            newExplosion.transform.parent = explosionContainer.transform;
            explosions.Enqueue(newExplosion);
        }
    }

    public GameObject GetExplosion()
    {
        var returnedExplosion = explosions.Dequeue();
        returnedExplosion.SetActive(true);
        returnedExplosion.GetComponent<Animator>().Play("explosion");
        return returnedExplosion;
    }

    public void ResetExplosion(GameObject explosion)
    {
        explosion.SetActive(false);
        explosions.Enqueue(explosion);
    }

}
