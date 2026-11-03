using Gamekit3D;
using UnityEngine;

public class SurvivalMod : MonoBehaviour
{
    [SerializeField] private float thirstLevel = 100f;

    [SerializeField] private float thirstSpeed;

    [SerializeField] private bool thirsty;

    [SerializeField] private bool parched;

    [SerializeField] private GameObject playerObject;
    
   [SerializeField] private float timer = 10;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        /*Subtracting the current value of thirstLevel with thirstSpeed, thirstSpeed is normalized by using Time.deltaTime,
         so its frame rate independant. Mathf.Clamp restricts the thirstLevel between its current value and zero.
        */
        thirstLevel -= Mathf.Clamp(thirstSpeed*Time.deltaTime,0, thirstLevel);

        if (thirstLevel <= 50f && !thirsty)
        {
            Debug.Log("Getting Thirsty...");
            thirsty = true;
            
        }

        if (thirstLevel <= 0 && thirsty)
            {
                timer -= Time.deltaTime;
                
                Damageable.DamageMessage msg = new Damageable.DamageMessage()
                {
                    amount = 1,
                        damager = this,
                            damageSource = new Vector3(),
                                direction = new Vector3(),
                                    throwing = false,
                                        stopCamera = false
                };
                playerObject.GetComponent<Damageable>().ApplyDamage(msg);
            Debug.Log("Damage by Thirst");
            }
    }
}
