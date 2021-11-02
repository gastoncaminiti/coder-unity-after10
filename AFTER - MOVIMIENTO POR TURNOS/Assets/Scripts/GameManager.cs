using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject[] playerUnits;
    [SerializeField] private CinemachineVirtualCamera vcam;


    private int indexUnit = 0;

    void Start()
    {
        InvokeRepeating("turnPlayer", 2f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void turnPlayer()
    {
        indexUnit++; 
        if(indexUnit == playerUnits.Length)
        {
            indexUnit = 0;
        }

        //ACA FOR PARA RESETEAR TURNOS

        GameObject unit = playerUnits[indexUnit];
        playerUnits[indexUnit].GetComponent<PlayerController>().setTurn();
        vcam.Follow = unit.transform.GetChild(2).transform;

    }

}
