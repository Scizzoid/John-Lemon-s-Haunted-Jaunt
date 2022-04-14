using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearEnemy : MonoBehaviour
{
    public Transform Enemies;

    bool m_Lerped;
    float m_Distance;
    float m_Counter = 0f;
    Vector3 m_ToPlayer;
    Transform m_Enemy;
    Renderer m_PlayerRenderer;
    Color m_DefPlayerColor;
    Color m_LerpedColor;

    void Start()
    {
        m_PlayerRenderer = transform.GetChild(0).GetComponent<Renderer>();
        m_DefPlayerColor = m_PlayerRenderer.material.color;
    }

    // Is the player near any children of the Enemies GameObject?
    bool IsPlayerNearEnemy()
    {
        for (int i = 0; i < Enemies.childCount; i++)
        {
            if (Enemies.GetChild(i).transform != null)
            {
                m_Enemy = Enemies.GetChild(i);
                m_Distance = Vector3.Distance(transform.position, m_Enemy.position);

                if (m_Distance < 3.5f)
                {
                    return true;
                }
            }
        }
        return false;
    }

    // Player's material flashes red when not behind enemy
    void PlayerNearEnemy(Transform enemy)
    {
        m_ToPlayer = Vector3.Normalize(transform.position - enemy.position);

        if (Vector3.Dot(enemy.forward, m_ToPlayer) > -0.45f)
        {
            m_Counter += 0.01f;
            m_LerpedColor = Color.Lerp(m_DefPlayerColor, Color.red, Mathf.PingPong(m_Counter, 1));
            m_PlayerRenderer.material.color = m_LerpedColor;
            m_Lerped = true;
        }
    }

    void Update()
    {               
        if (IsPlayerNearEnemy())
        {
            PlayerNearEnemy(m_Enemy);
        }
        else
        {
            if (Mathf.PingPong(m_Counter, 1) > 0.1f)
            {
                // If player's material has been altered & is different from the default player material
                if (m_Lerped)
                {
                    m_Counter += 0.01f;
                    // Lerp back to defualt player material.
                    m_PlayerRenderer.material.color = Color.Lerp(m_DefPlayerColor, Color.red, Mathf.PingPong(m_Counter, 1));
                }
                
            }
            else
            {
                m_Lerped = false;
            }
        }
    }
}
        

        