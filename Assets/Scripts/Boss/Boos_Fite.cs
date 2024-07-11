using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boos_Fite : MonoBehaviour
{
    [SerializeField] private Collider2D trigger_fight;
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject door;
    [SerializeField] private CinemachineVirtualCamera player_cinemachine;
    [SerializeField] private CinemachineVirtualCamera ivent_cinemachine;

    [SerializeField] private float timer_ivent;
    private bool is_ivent = false;

    private void Awake()
    {
        boss.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D fight)
    {
        is_ivent = true;
    }
    private void FixedUpdate()
    {
        if (is_ivent)
        {
            timer_ivent -= Time.deltaTime;
            boss.SetActive(true);
            player.SetActive(false);
            door.SetActive(true);
            ivent_cinemachine.m_Priority = 10;
            player_cinemachine.m_Priority = 9;
            if (timer_ivent <= 0)
            {
                player.SetActive(true);
                ivent_cinemachine.m_Priority = 9;
                player_cinemachine.m_Priority = 10;
                is_ivent = false;
            }
            Destroy(trigger_fight);
        }
    }
}
