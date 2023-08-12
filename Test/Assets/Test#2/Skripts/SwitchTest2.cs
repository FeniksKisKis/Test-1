using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTest2 : MonoBehaviour
{
    [SerializeField] private GameObject pistol;
    [SerializeField] private GameObject shotgun;
    [SerializeField] private GameObject rifle;
    [SerializeField] private GameObject grenadeLauncher;
    int level = 1;
    private Weapon weapon = Weapon.Pistol;

    enum Weapon
    {
        Pistol,
        Rifle,
        Shotgun,
        GrenadeLauncher
    }

    void Start()
    {
        switch (level)
        {
            case 1:
                ChooseWeapon(Weapon.Pistol);
                break;
            case 2:
                ChooseWeapon(Weapon.Shotgun);
                break;
            case 3:
                ChooseWeapon(Weapon.Rifle);
                break;
            case 4:
                ChooseWeapon(Weapon.GrenadeLauncher);
                break;
            default:
                print("Для этого уровня не подготовлено оружие");
                break;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            switch (weapon)
            {
                case Weapon.Pistol:
                    pistol.GetComponent<GunTest2>().Shoot();
                    break;

                case Weapon.Rifle:
                    rifle.GetComponent<GunTest2>().Shoot();
                    break;

                case Weapon.Shotgun:
                    shotgun.GetComponent<GunTest2>().Shoot();
                    break;

                case Weapon.GrenadeLauncher:
                    shotgun.GetComponent<GunTest2>().Shoot();
                    break;
            }
        }


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapon = Weapon.Pistol;
            ChooseWeapon(weapon);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weapon = Weapon.Shotgun;
            ChooseWeapon(weapon);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            weapon = Weapon.Rifle;
            ChooseWeapon(weapon);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            weapon = Weapon.GrenadeLauncher;
            ChooseWeapon(weapon);
        }
    }

    private void ChooseWeapon(Weapon weapon)
    {
        switch (weapon)
        {
            case Weapon.Pistol:
                pistol.SetActive(true);
                shotgun.SetActive(false);
                rifle.SetActive(false);
                grenadeLauncher.SetActive(false);
                break;
            case Weapon.Shotgun:
                pistol.SetActive(false);
                shotgun.SetActive(true);
                rifle.SetActive(false);
                grenadeLauncher.SetActive(false);
                break;
            case Weapon.Rifle:
                pistol.SetActive(false);
                shotgun.SetActive(false);
                rifle.SetActive(true);
                grenadeLauncher.SetActive(false);
                break;
            case Weapon.GrenadeLauncher:
                pistol.SetActive(false);
                shotgun.SetActive(false);
                rifle.SetActive(false);
                grenadeLauncher.SetActive(true);
                break;
            default:
                print("Такого оружия у вас нет");
                break;
        }
    }

    public void LevelUp()
    {
        level++;
        switch (level)
        {
            case 1:
                ChooseWeapon(Weapon.Pistol);
                break;
            case 2:
                ChooseWeapon(Weapon.Shotgun);
                break;
            case 3:
                ChooseWeapon(Weapon.Rifle);
                break;
            case 4:
                ChooseWeapon(Weapon.GrenadeLauncher);
                break;
            default:
                print("Для этого уровня не подготовлено оружие");
                break;
        }
    }
}
