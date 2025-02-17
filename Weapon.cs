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
    public class Weapon
    {
        protected char weaponIcon;
        protected string weaponName;
        protected int weaponDamage;

        public Weapon()
        {
            weaponIcon = 'D';
            weaponName = "Developer Weapon";
            weaponDamage = 1;
        }

        public Weapon(char weaponIcon, string weaponName, int weaponDamage)
        {
            this.weaponIcon = weaponIcon;
            this.weaponName = weaponName;
            this.weaponDamage = weaponDamage;
        }

        public char GetWeaponIcon()
        {
            return weaponIcon;
        }

        public string GetWeaponName()
        {
            return weaponName;
        }

        public int GetWeaponDamage()
        {
            return weaponDamage;
        }
    }
}
