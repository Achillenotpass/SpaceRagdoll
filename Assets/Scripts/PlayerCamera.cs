﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField]
    bool m_UseOffset = false;
    [SerializeField]
    Vector3 m_Offset = new Vector3(0, -5, 10);
    [SerializeField]
    float m_RotateSpeed = 1;

    // Références
    Transform m_Player = null;
    PauseMenu m_PauseMenu = null;
    CatchArea m_CatchArea = null;

    void Start()
    {
        m_Player = FindObjectOfType<PlayerMovement>().transform;

        m_PauseMenu = FindObjectOfType<PauseMenu>();
        
        m_CatchArea = FindObjectOfType<CatchArea>();

        if (!m_UseOffset)
        {
            m_Offset = m_Player.position - transform.position;
        }

        // =Camoufler la souris
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        if (!m_PauseMenu.IsPauseDisplay && !m_CatchArea.IsGameEnding)
        {
            // Permet de rotate le player sur l'horizontale
            float horizontal = Input.GetAxis("Mouse X") * m_RotateSpeed;
            m_Player.Rotate(0, horizontal, 0);

            // Pareil pour la vertical
            float vertical = Input.GetAxis("Mouse Y") * m_RotateSpeed;
            m_Player.Rotate(-vertical, 0, 0);

            float desiredYAngle = m_Player.eulerAngles.y;
            float desiredXAngle = m_Player.eulerAngles.x;

            Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
            transform.position = m_Player.position - (rotation * m_Offset);

            transform.LookAt(m_Player);

            if (Input.GetMouseButton(1))
            {
                m_Player.transform.forward = transform.forward;
            }
        }
    }
}
