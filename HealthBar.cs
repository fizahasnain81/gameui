//using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
 
public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public int score = 0;
    public UI snakeUI1;
    public Image fillBar;
    public float health;
    Animator animator1;
    //public int maxHealth;
    private void Awake()
    {
        animator1 = GetComponent<Animator>();
    }

    public void LoseHealth(int value)
    {
        if (health <= 0)
        {
            return;
        }
            health -= value;
      fillBar.fillAmount = health/100;
        if(health <= 0)
        {
            animator1.SetTrigger("dead");
            score = 0; // Reset score
            snakeUI1.UpdateScore(score);
            snakeUI1.ShowLosePanel1();
            //Debug.Log("die");
        }
         
    }
   public bool increaseHealth(int value)
    {
        if (health >= 100)
        {
            return true;
        }
        else
        {
            health += value;
            fillBar.fillAmount = health / 100;
            return false;
        }
       /* if (health <= 0)
        {
            animator1.SetTrigger("dead");
            //Debug.Log("die");
        }*/

    }
    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            LoseHealth(25);
        }
    }*/
}
