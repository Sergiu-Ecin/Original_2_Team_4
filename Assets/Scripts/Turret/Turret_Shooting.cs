//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Turret_Shooting : MonoBehaviour
//{
//    [Header("Objects")]
//    [SerializeField] Transform Muzzle;
//    [SerializeField] GameObject proiettile;

//    [Header("Variables")]
//    [SerializeField] float fwdVelocity;
//    [SerializeField] float upVelocity;
//    [Range(0.0f, 5f)] public float timer;
//    float timeElapsed = 10f;

//    void Update()
//    {
//        timeElapsed += Time.deltaTime;
//        if (timeElapsed >= timer)
//        {
//            if (Input.GetKeyDown(KeyCode.Mouse0))
//            {
//                Shoot();
//            }
//        }
//    }

//    void Shoot()
//    {
//        timer += Time.deltaTime;

//        var bullet = Instantiate(proiettile, Muzzle.position, Muzzle.rotation);
//        bullet.GetComponent<Rigidbody>().velocity = Muzzle.forward * fwdVelocity;
//        timeElapsed = 0;
//    }
//}
