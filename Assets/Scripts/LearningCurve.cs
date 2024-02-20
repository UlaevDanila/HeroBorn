using System.Collections.Generic;
using UnityEngine;

namespace SelimPidor
{
    public class LearningCurve : MonoBehaviour
    {
        private Transform camTransform;

        private GameObject directionalLight;

        private Transform lightTransform;
        /*[SerializeField] private bool pureOfHeart = true;

        [SerializeField] private bool hasSecretIncantation = false;

        [SerializeField] private string rareItem = "Dog Jonson 48 cm";*/

        [SerializeField]

        private void Start()
        {
            directionalLight = GameObject.Find("Directional Light");

            lightTransform = directionalLight.GetComponent<Transform>();
            
            Debug.Log(lightTransform.localPosition);

            /*Weapon bigDildo = new Weapon("Dildo", 1999);
            bigDildo.PrintWeaponStats();
            
            Character hero = new Character("Selim pidor", 100);
            hero.PrintStatusInfo();

            Character hero1 = new Character(hero);

            hero.name = "test";

            Weapon middleSizeDildo = bigDildo;

            bigDildo.name = "Big dildo";
            bigDildo.damage = 500;
            
            bigDildo.PrintWeaponStats();
            middleSizeDildo.PrintWeaponStats();*/

            /*camTransform = this.GetComponent<Transform>();
            Debug.Log(camTransform.localPosition);
            
            Paladin knight = new Paladin(new Weapon("GigaSword", 200), "Sir Peodr");
            knight.PrintStatusInfo();*/

            /*hero.PrintStatusInfo();
            hero1.PrintStatusInfo();*/

        }
    }

}
