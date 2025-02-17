﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float m_MoveSpeed = 1f;

    Rigidbody m_RbPlayer = null;

    Vector3 m_MoveDirection = Vector3.zero;

    void Start()
    {
        m_RbPlayer = GetComponent<Rigidbody>();
    }

    void Update()
    {
        m_MoveDirection = (transform.forward * Input.GetAxisRaw("Vertical") * m_MoveSpeed) + (transform.right * Input.GetAxisRaw("Horizontal") * m_MoveSpeed) + (transform.up * Input.GetAxisRaw("Altitude") * m_MoveSpeed);

        m_MoveDirection = m_MoveDirection.normalized * m_MoveSpeed;

        m_RbPlayer.velocity = m_MoveDirection * Time.fixedDeltaTime;
    }
}
