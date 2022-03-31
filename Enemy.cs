using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed, random;
    bool alive = true;
    public GameObject Explosion, AttackSpeed, ScoreUp, ExtraLife;
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - speed*Time.deltaTime);
        if (transform.position.y < -20)
        {
            transform.position = new Vector2(Random.Range(-18, 18), 33);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "PlayerBulletTag") || (collision.tag == "PlayerShipTag") || (collision.tag == "Shield"))
        {
            if (alive == true)
                GameObject.Find("Level").GetComponent<LevelText>().enemiesAlive -= 1;
            alive = false;
            GameObject explosion = (GameObject)Instantiate(Explosion);
            explosion.transform.position = transform.position;
            random = Random.Range(1, 100);
            if (random <= 5 && random >= 1)
            {
                GameObject attackSpeed = (GameObject)Instantiate(AttackSpeed);
                attackSpeed.transform.position = transform.position;
            }
            if (random <= 10 && random >= 6)
            {
                GameObject scoreUp = (GameObject)Instantiate(ScoreUp);
                scoreUp.transform.position = transform.position;
            }
            if (random <= 13 && random >= 11)
            {
                GameObject extralife = (GameObject)Instantiate(ExtraLife);
                extralife.transform.position = transform.position;
            }
            if (GameObject.Find("Player").GetComponent<Player>().DoubleScore == true)
                GameObject.Find("Player").GetComponent<Player>().Score += 40;
            else
                GameObject.Find("Player").GetComponent<Player>().Score += 20;
            Destroy(gameObject);
        }
    }
}
