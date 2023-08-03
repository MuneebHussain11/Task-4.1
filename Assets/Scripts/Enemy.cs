using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 3.0f;
    private Rigidbody EnemyRb;
    private GameObject player;
    private float scale = 10f;
    private Renderer playerRenderer;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        EnemyRb = GetComponent<Rigidbody>();
        if(player == null )
        {
            player = GameObject.Find("Player");
        }
        playerController = player.GetComponent<PlayerController>();
        //player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        EnemyRb.AddForce(lookDirection * speed);

        playerRenderer = player.GetComponent<Renderer>();

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
            
            player.transform.localScale += new Vector3(scale, scale, scale) * Time.deltaTime;
            playerRenderer.material = playerController.enemyKillMaterial;
        }

    }
}
