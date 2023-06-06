using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beak : MonoBehaviour
{

private void OnTriggerEnter(Collider other)
{
    Player player = other.gameObject.GetComponent<Player>();
    if(player)
    {
        int damage = 10;
        player.TakeDamage(damage);
        player.hpBarUi.Attack(damage);
    }
}

}
