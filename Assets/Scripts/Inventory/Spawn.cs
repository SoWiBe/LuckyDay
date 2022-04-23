using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject item;
    private Transform player;
    private Material material;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void SpawnDroppedItem()
    {
        Vector2 playerPos = new Vector2(player.position.x + 2, player.position.y - 1);
        GameObject game = (GameObject)Instantiate(item, playerPos, Quaternion.identity);
        game.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
        game.GetComponent<SpriteRenderer>().sortingOrder = 2;
        game.GetComponent<SpriteRenderer>().material = Resources.Load("Light") as Material;
    }
}
