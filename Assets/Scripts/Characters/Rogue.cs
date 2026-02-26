using UnityEngine;

public class Rogue : MonoBehaviour
{
    [SerializeField]int knivesCount = 2;
    [SerializeField] int maxKnives = 2;

    //Right now this is temporary, it should be
    //able to be removed once i incorporate
    //the global move cooldown
    bool attacking = false;

    private void Awake()
    {
        maxKnives = knivesCount;
    }
    // Update is called once per frame
    void Update()
    {
        //TODO:
        //if(globalCooldown <= 0) allow continuation of logic

        //For convenience sake, ignoring that it is
        //not the easiest to test, ill leave the original
        //parameters as L for light, H for heavy, and F for
        //finisher, you are free to change it as you see fit
        //in your respective branch, just give a heads up
        //before merging to main if you decide so
        if (attacking == true) return;

        if(knivesCount > 0)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                attacking = true;
                //Do a light attack
                attacking = false;
            }
            else if (Input.GetKeyDown(KeyCode.H))
            {
                attacking = true;
                //Do a heavy attack

                knivesCount -= 1;
                attacking = false;
            }
        }
        else
        {
            //this is very much so up to question
            //since player would have to be close
            //to do the finisher and animation
            //would take some time, so feel free
            //to play around with the attacking = false
            //and put it into an animation or whatever
            if (Input.GetKeyDown(KeyCode.F)) 
            {
                attacking = true;
                //Do a finisher

                knivesCount = maxKnives;
                attacking = false;
            }

            //This has only been passively confirmed
            //& not explicitly, Ill talk thursday about
            //it with yammy or the person in charge of
            //this section could talk it out with 
            //level design, either way, I trust
            //the judgement of the one in charge of this
            //so treat the following as however you wish
            if (Input.GetKeyDown(KeyCode.L))
            {
                attacking = true;
                //Do an *Alternative* light attack

                //Attack with crossbow or similar
                //Fast/Medium speed, medium range, low damage

                attacking = false;
            }
            else if (Input.GetKeyDown(KeyCode.H))
            {
                attacking = true;
                //Do an *Alternative* heavy attack

                //Supposedly attack with crossbow's
                //integradted bayonet
                //Slow speed, low range, medium/heavy damage
                attacking = false;
            }
        }
    }
    public void LightAttack()
    {

    }
    public void HeavyAttack()
    {

    }
    public void Finisher()
    {

    }
    public void AltLightAttack()
    {

    }
    public void AltHeavyAttack()
    {

    }
}
