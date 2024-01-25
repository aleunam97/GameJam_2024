using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingSpot : MonoBehaviour
{
    public Player player;
    bool hidden;

    void Start()
    {
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !hidden)
        {
            Player.invisible = 1;
            hidden = true;

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" && hidden)
        {
            Player.invisible = 0;
            hidden = false;
        }
    }
}
