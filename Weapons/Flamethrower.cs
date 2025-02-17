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

//Created by Zoe
namespace Project5_Zork
{
    public class Flamethrower : Weapon
    {
        public Flamethrower() : base()
        {
            weaponIcon = 'F';
            weaponName = "Flamethrower";
            weaponDamage = 8;
        }

        public int GetFlamethrowerDamage()
        {
            return weaponDamage;
        }
    }
}
