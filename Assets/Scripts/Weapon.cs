using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 20f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] ParticleSystem hitEffect;

    WFX_LightFlicker lightScript;

    Animator animator;


    void Start() {
        animator = GetComponent<Animator>();
        lightScript = this.GetComponentInChildren<WFX_LightFlicker>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    private void Shoot() {
        // StartCoroutine("PlayMuzzleFlash");
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range)) {
            HitImpact(hit);
            Debug.Log(hit.transform.name);
            if (hit.transform.name == "Enemy") {
                EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
                target.TakeDamage(damage);
            }
        } else {
            return;
        }
    }

    private void HitImpact(RaycastHit hit) {
        //ParticleSystem newHit = Instantiate(hitEffect, hit.transform.position, transform.rotation);
        Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
    }

    // IEnumerator PlayMuzzleFlash() {
    //     muzzleFlash.Play();
        // lightScript = GetComponent<Light>();
        // lightScript.enabled;
        // lightScript.enabled = true;
        // yield return new WaitForSeconds(0.5f);
        // lightScript.enabled = false;
    //}

    // private void PlayMuzzleFlash() {
    //     lightScript.enabled = true;
    //     muzzleFlash.Play();
    // }
}
