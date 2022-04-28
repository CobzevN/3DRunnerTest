using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public float forwardMoveSpeed, swerveSpeed;
    private SwerveSystem swerveSystem;
    private void Awake()
    {
        swerveSystem = GetComponent<SwerveSystem>();
    }

    void Update()
    {
        float swerveAmount = Time.deltaTime * swerveSpeed * swerveSystem.MoveFactorX;
        transform.Translate(0, 0, forwardMoveSpeed * Time.deltaTime); //движение вперёд
        transform.Translate(swerveAmount, 0, 0); //перемещение куба влево, вправо


        if (MyCubeState.dead == true)
        {
            forwardMoveSpeed = 0;
            swerveSpeed = 0;
        }
    }
}




