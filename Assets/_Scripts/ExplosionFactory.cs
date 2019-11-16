using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionFactory : MonoBehaviour
{
    private static GameObject explosion;
    private GameController gameController;

    private static ExplosionFactory _instance;

    private ExplosionFactory()
    {

    }

    // singleton instance
    public static ExplosionFactory GetInstance()
    {
        if (_instance == null)
        {
            _instance = new ExplosionFactory();
            return _instance;
        }

        return _instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameController = gameObject.GetComponent<GameController>();
        explosion = gameController.explosion;
    }

    public GameObject CreateRandomExplosion()
    {
        var randomColour = new Color(Random.Range(0.1f, 1.0f), Random.Range(0.1f, 1.0f), Random.Range(0.1f, 1.0f), 0.8f);
        var newExplosion = Instantiate(explosion);
        newExplosion.SetActive(false);
        newExplosion.GetComponent<SpriteRenderer>().material.color = randomColour;
        return newExplosion;
    }
}
