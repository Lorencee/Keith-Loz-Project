
using UnityEngine;

public class GunScript : MonoBehaviour {

    public float damage = 10f;
    public float rateofFire = 15f;
    public float gunAccuracy = 0.25f;
    public int Ammo;
    public int MaxAmmo = 30;

    public Accuracy Acc;
    public Vector3 direction;
    public RaycastHit[] hits;

    public Camera Raycast;
    public AudioSource Audio;
    
    public ParticleSystem MuzzleFlash;
    public ParticleSystem MuzzleSmoke;
    public ParticleSystem MuzzleExplo;
    public GameObject ImpactEffect;
    public float impactForce = 10;
    public float NextFire = 0f;

    public bool isFiring;

	// Use this for initialization
	void Start () {

        Ammo = MaxAmmo;

    }
	
	// Update is called once per frame
	void Update () {

        if (!Input.GetButton("Fire3"))
        {
            isFiring = false;

        }
        if (Input.GetButton("Fire3") && Time.time >= NextFire)
        {
            if (Ammo > 0)
            {
                Ammo -= 1;
                Shoot();

            }
            else
            {
                Debug.Log("No Ammo");
                isFiring = false;

            }
            NextFire = Time.time + (1f / rateofFire);

        }
        else
        {
            isFiring = false;

        }
        if (Input.GetButtonDown("Reload"))
        {
            if (Ammo == 0) { Ammo = MaxAmmo; }
            else { Ammo = MaxAmmo +1; }
            
        }

    }

    void Shoot()
    {
        isFiring = true;

        Vector3 randomOffset;
        randomOffset.x = Random.Range(-(1 - Acc.AccuracyVal), 1 - Acc.AccuracyVal);
        randomOffset.y = 0;
        randomOffset.z = Random.Range(-(1 - Acc.AccuracyVal), 1 - Acc.AccuracyVal);

        direction = Raycast.transform.forward;

        direction.x += randomOffset.x;
        direction.y += randomOffset.y;
        direction.z += randomOffset.z;




        Audio.Play();
        MuzzleFlash.Play();
        MuzzleSmoke.Play();
        MuzzleExplo.Play();

        
        hits = Physics.RaycastAll(Raycast.transform.position, direction);
        

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            Debug.Log(hit.transform.name);
            Enemy target = hit.transform.GetComponent<Enemy>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject ImpactGO = Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(ImpactGO, 2.0f);
        }

           

        }
}
