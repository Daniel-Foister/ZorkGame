/**
*--------------------------------------------------------------------
* File name: 1260-002-FoisterDaniel-PetersRyan-JohnsonZoe-Project5
* Project name: Project5-Zork
*--------------------------------------------------------------------
* Author’s names and emails: Daniel Foister, foisterda@etsu.edu | Zoe Johnson, johnsonz3@etsu.edu | Ryan Peters, petersrw@etsu.edu
* Course-Section: CSCI-1260-002
* Creation Date: 4/19/23
* -------------------------------------------------------------------
*/

//Created by Daniel
namespace Project5_Zork
{
    public class Participant
    {
        protected char icon;
        protected string name;
        protected int health;
        protected int damage;
        protected bool isDead;
        protected bool gameOver;

        public Participant()
        {
            icon = 'D';
            name = "Developer";
            health = 100;
            damage = 5;
            isDead = false;
        }

        public Participant(char icon, string name, int health, int damage, bool isDead)
        {
            this.icon = icon;
            this.name = name;
            this.health = health;
            this.damage = damage;
            this.isDead = isDead;
        }

        public char GetChar()
        {
            return icon;
        }

        public string GetName()
        {
            return name;
        }
        public int GetHealth()
        {
            return health;
        }

        public int GetDamage()
        {
            return damage;
        }

        public void SetHealth(int health)
        {
            this.health = health;
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
        }
    }
}
