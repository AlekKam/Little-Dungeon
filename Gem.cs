using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public static int Gems;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Gems++;
        Destroy(gameObject);
    }


}
