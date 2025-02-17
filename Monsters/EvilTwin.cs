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
    public class EvilTwin : Participant
    {
        public EvilTwin() : base()
        {
            icon = 'E';
            name = "Evil Twin";
            health = 75;
            damage = 5; 
            isDead = false;
        }

        public void SetETDamage(int playerDamage)
        {
            this.damage = damage;
        }
    }
}