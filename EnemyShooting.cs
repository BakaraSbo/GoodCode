using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public float firerate, count = 0, offsetX, offsetY, type;
    public GameObject Bullet, BulletL, BulletR, Rocket;
    
    void Update()
    {
        if (count >= firerate)
        {
            if (type == 0)
            {
                if (count >= firerate)
                {
                    GameObject bullet = (GameObject)Instantiate(Bullet);
                    bullet.transform.position = transform.position;
                    count %= firerate;
                }
            }
            else if (type == 1)
            {
                GameObject bullet = (GameObject)Instantiate(BulletL);
                bullet.transform.position = transform.position;
                GameObject bullet2 = (GameObject)Instantiate(BulletR);
                bullet2.transform.position = transform.position;
                count %= firerate;
            }
            else if (type == 2)
            {
                if (count >= firerate)
                {
                    GameObject rocket = (GameObject)Instantiate(Rocket);
                    rocket.transform.position = new Vector2(transform.position.x + offsetX, transform.position.y - offsetY);
                    GameObject rocket1 = (GameObject)Instantiate(Rocket);
                    rocket1.transform.position = new Vector2(transform.position.x - offsetX, transform.position.y - offsetY);
                    count %= firerate;
                }
            }
        }
        count += Time.deltaTime*5;

    }
}
