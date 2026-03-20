using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Net.NetworkInformation;

//To note, this is supposed to be the parent class of subsquent characters
//However, I am still unsure which specific fields they would all have

//As for now, here would be where I include I guess the basis for the
//GCD (global move cooldown) and CD (normal move cooldown)

//Then, it would be possible to just let the child
//objects set what the moves would do and here handle
//the greater, shared logic

//It still remains as an idea though,
//which is why I will leave it empty for now

public class Character : MonoBehaviour
{
    //Cooldown between moves
    public float globalCooldown = 0;//timer/tracker
    public float originalGCD = 5;   //stores cooldown numbers

    //Cooldown of specific move
    //{light, heavy, finisher}
    public float[] cooldowns =  //timer/tracker
    {
        0, 0, 0
    };
    public float[] originalCD = //stores cooldown numbers
    {
        10, 10, 10
    };

    //how fast cooldowns pass
    float cooldownRate = 1f;

    //This is used for testing and would be replaced by
    //the respective cooldown UI or animations to activate
    public Text displayGCD;
    public Text displayCD;

    //starts cooldown timers (global & of move used)
    public void StartCooldown(int moveIndex)
    {
        //Sets global cooldown
        globalCooldown = originalGCD;
        //Sets specific move cooldown
        cooldowns[moveIndex] = originalCD[moveIndex];

        //Starts reducing cooldowns/timer
        StartCoroutine(Cooldown(moveIndex));
    }

    //Does function of cooldown timer by continuously
    //reducing the cooldown by a rate per second
    IEnumerator Cooldown(int moveIndex)
    {
        //continously reduces cooldowns until they hit 0
        //and updates timer to showcase progress every second
        while (globalCooldown > 0 || cooldowns[moveIndex] > 0)
        {
            if (globalCooldown > 0)
            {
                globalCooldown -= cooldownRate * Time.deltaTime;
            }
            else
            {
                globalCooldown = 0;
            }
            if (cooldowns[moveIndex] > 0)
            {
                cooldowns[moveIndex] -= cooldownRate * Time.deltaTime;
            }

            UpdateCounters();
            yield return null;
        }

        //Sets counters to 0 when done to avoid
        //ending up with negative counters
        //(only serves cosmetic purposes)
        if(globalCooldown <= 0)
        {
            globalCooldown = 0;
        }
        cooldowns[moveIndex] = 0;

        UpdateCounters();
    }

    //Updates text counters in screen with up to 2 decimals
    void UpdateCounters()
    {
        displayGCD.text = globalCooldown.ToString("#.00");
        displayCD.text = cooldowns[0].ToString("#.00") + " " 
            + cooldowns[1].ToString("#.00") + " " 
            + cooldowns[2].ToString("#.00");
    }
}