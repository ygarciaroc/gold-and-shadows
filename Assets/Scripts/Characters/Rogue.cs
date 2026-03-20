using UnityEngine;

public class Rogue : MonoBehaviour
{
    //current amount of knives carried
    [SerializeField] int knivesCount = 2;
    //total amount of knives possible to carry
    [SerializeField] int maxKnives = 2;

    //reference to cooldown counters
    Character character;

    private void Awake()
    {
        //sets knife amount to max
        knivesCount = maxKnives;
        //gets reference to cooldown counters
        character = FindFirstObjectByType<Character>();
    }

    //For convenience sake, ignoring that it is
    //not the easiest to test, ill leave the original
    //parameters as L for light, H for heavy, and F for
    //finisher, you are free to change it as you see fit
    //in your respective branch, just give a heads up
    //before merging to main if you decide so
    void Update()
    {
        //unable to act if cooldown between
        //moves is greater than 0
        if (character.globalCooldown > 0) return;

        //if there are knives, allow usage of normal moveset
        if (knivesCount > 0)
        {
            //if key to use light attack is pressed,
            if (Input.GetKeyDown(KeyCode.L))
            {
                //allow usage if its cooldown is not greater than 0
                if (character.cooldowns[0] > 0) return;

                //use a light attack and start its cooldown
                character.StartCooldown(0);
                LightAttack();
            }
            //if key to use heavy attack is pressed,
            else if (Input.GetKeyDown(KeyCode.H))
            {
                //allow usage if its cooldown is not greater than 0
                if (character.cooldowns[1] > 0) return;

                //use a heavy attack and start its cooldown
                character.StartCooldown(1);
                HeavyAttack();

                //reduce the ammount of knvies by 1
                knivesCount -= 1;

                //ONLY for testing purposes
                if (knivesCount == 0) print("run out of knives!");
            }
        }
        //when there are no more knives, use alternate moveset
        //and allow usage of finisher
        else
        {
            //this is very much so up to question
            //since player would have to be close
            //to do the finisher and animation
            //would take some time

            //if key to use finisher attack is pressed,
            if (Input.GetKeyDown(KeyCode.F))
            {
                //allow usage if its cooldown is not greater than 0
                if (character.cooldowns[2] > 0) return;

                //use a finisher attack and start its cooldown
                character.StartCooldown(2);
                Finisher();

                //recover all knife stacks
                knivesCount = maxKnives;
            }

            //if key to use light attack is pressed,
            if (Input.GetKeyDown(KeyCode.L))
            {
                //allow usage if its cooldown is not greater than 0
                if (character.cooldowns[0] > 0) return;

                //Start move cooldown
                character.StartCooldown(0);

                //Do an *Alternative* light attack
                //Attack with crossbow or similar
                //Fast/Medium speed, medium range, low damage
                AltLightAttack();
            }
            //if key to use heavy attack is pressed,
            else if (Input.GetKeyDown(KeyCode.H))
            {
                //allow usage if its cooldown is not greater than 0
                if (character.cooldowns[1] > 0) return;

                //Start move cooldown
                character.StartCooldown(1);

                //Do an *Alternative* heavy attack
                //Supposedly attack with crossbow's
                //integradted bayonet
                //Slow speed, low range, medium/heavy damage
                AltHeavyAttack();
            }
        }
    }
    //These methods have printing statements for testing purposes
    //however, move logic could easily be inputted here directly
    //at a later time
    public void LightAttack()
    {
        print("light attack");
    }
    public void HeavyAttack()
    {
        print("heavy attack");
    }
    public void Finisher()
    {
        print("finisher attack");
    }
    public void AltLightAttack()
    {
        print("alt - light attack");
    }
    public void AltHeavyAttack()
    {
        print("alt - heavy attack");
    }
}
