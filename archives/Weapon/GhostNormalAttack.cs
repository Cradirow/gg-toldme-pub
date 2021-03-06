﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TVNT
{
    public class GhostNormalAttack : WeaponController
    {

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                Debug.Log("ghost normal attack : " + damage);
                if (other.GetComponent<TVNTCharacterController>().lives >= 5)
                {
                    //Debug.Log("Normal attack.");
                    other.GetComponent<TVNTCharacterController>().lives -= damage;
                }
                else if (other.GetComponent<TVNTCharacterController>().lives < 5 && other.GetComponent<TVNTCharacterController>().lives > 2)
                {
                    other.GetComponent<TVNTCharacterController>().lives -= damage;
                    other.GetComponent<HeroController>().SetSituation(HeroController.Situation.HERODEAD);
                }
                else
                {
                    other.GetComponent<HeroController>().CharacterDead();
                    //other.gameObject.SetActive(false);
                }
            }
            GameObject.Destroy(gameObject);
        }
    }
}
