using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberOfPlayers : MonoBehaviour
{
    public int NumberPlayers;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
