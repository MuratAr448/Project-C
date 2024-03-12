using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;


public enum state{ revolver, rifle }

public class Guns : MonoBehaviour
{
    [SerializeField]
    public state _state = state.revolver;
    bool readyTofire = true;
    public float bulletSpeed = 10f;
    public float fireDelay = .5f;
    public float fireDelayRevolver = 0f;
    public int flurryAngle;
    public float spreadAngle = 5f;

    public int MaxAmmoRevolver = 12;
    public int currentRevolverAmmo = 12;
    public int MaxAmmoRifle = 8;
    public int currentRifleAmmo = 8;

    public float reloadTimeRifle = 5f;
    public float reloadTImeRevolver = 2f;

    public bool isReloading = false;
    public bool canBeReloaded = false;

    [Header("prefab")]
    public GameObject revolverObj, rifleObj;

    [Header("References")]
    public Transform attackPoint;
    void Start()
    {
        revolverObj.GetComponent<Bullets>().speed = bulletSpeed;
        rifleObj.GetComponent<Bullets>().speed = bulletSpeed;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _state = state.revolver;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2 ))
        {
            _state = state.rifle;
        }
        if(Input.GetKeyDown(KeyCode.Mouse0) && readyTofire == true && MaxAmmoRevolver > 0 && _state == state.revolver && isReloading == false)
        {
            currentRevolverAmmo--;
            UWS();
            Debug.Log("fireRevolver");
        }
        if (Input.GetKey(KeyCode.Mouse0) && readyTofire == true && MaxAmmoRifle > 0 && _state == state.rifle && isReloading == false){
            currentRifleAmmo--;
            UWS();
            Debug.Log("fireRifle");
        }
        if (currentRevolverAmmo == 0)
        {
            isReloading = true;
            Invoke(nameof(ReloadRevolver), reloadTImeRevolver);
        }
        if(currentRifleAmmo == 0)
        {
            isReloading = true;
            Invoke(nameof(ReloadRifle), reloadTimeRifle);
        }
    }
    void UWS()
    {
        switch(_state) 
        {
            case state.revolver:
                ProjectileRevolver(revolverObj, 0f, true);
                break; 
            case state.rifle:
                rifleObj.GetComponent <Bullets>().speed = bulletSpeed -3;
                Projectile(rifleObj, -spreadAngle, false);
                rifleObj.GetComponent<Bullets>().speed = bulletSpeed;
                Projectile(rifleObj, 0f, false);
                rifleObj.GetComponent<Bullets>().speed = bulletSpeed - 3;
                Projectile(rifleObj,spreadAngle, true);
                rifleObj.GetComponent<Bullets>().speed = bulletSpeed;
                break;
        }
    }

    private void ProjectileRevolver(GameObject obj, float rotate,bool reset)
    {
        readyTofire = false;
        attackPoint.Rotate(0f,rotate,0f);
        GameObject projectile = Instantiate(obj, attackPoint.position, attackPoint.rotation);
        Rigidbody projectileRB = projectile.GetComponent<Rigidbody>();
        Vector3 forceDirection = attackPoint.transform.forward;
        attackPoint.Rotate(0f, -(rotate), 0f);
        if (reset)
            Invoke(nameof(ResetShot), fireDelayRevolver);
    }
    private void Projectile(GameObject obj, float rotate, bool reset)
    {
        readyTofire = false;
        attackPoint.Rotate(0f, rotate, 0f);
        GameObject projectile = Instantiate(obj, attackPoint.position, attackPoint.rotation);
        Rigidbody projectileRB = projectile.GetComponent<Rigidbody>();
        Vector3 forceDirection = attackPoint.transform.forward;
        attackPoint.Rotate(0f, -(rotate), 0f);
        if (reset)
            Invoke(nameof(ResetShot), fireDelay);
    }




    private void ResetShot()
    {
        readyTofire = true;
    }
    private void ReloadRevolver()
    {
        currentRevolverAmmo = MaxAmmoRevolver;
        isReloading = false;
    }
    private void ReloadRifle()
    {
        currentRifleAmmo = MaxAmmoRifle;
        isReloading = false;
    }
}
