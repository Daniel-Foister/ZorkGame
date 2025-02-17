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

//Created by Ryan, edited by Daniel for inheritance
namespace Project5_Zork
{
    public class Player : Participant
    {
        private int currentPosition = 1;
        private bool winner = false;

        public Player() : base()
        {
            icon = 'P';
            name = "The Hero";
            health = 100;
            damage = 5;
            isDead = false;
            currentPosition = 1;
            winner = false;
            gameOver = false;
        }

        public char GetPlayerIcon()
        {
            return icon;
        }

        public string GetPlayerName()
        {
            return name;
        }

        public int GetPlayerHealth()
        {
            return health;
        }

        public int GetPlayerDamage()
        {
            return damage;
        }

        public int GetCurrentPosition()
        {
            return currentPosition;
        }

        public bool GetWinner()
        {
            return winner;
        }

        public bool GetGameOver()
        {
            return gameOver;
        }

        public void SetGameOver(bool gameOver)
        {
            this.gameOver = gameOver;
        }

        public void SetPlayerName(string playerName)
        {
            this.name = playerName;
        }

        public void SetHealth(int health)
        {
            this.health = health;
        }

        public void SetPlayerDamage(int damage)
        {
            this.damage = damage;
        }

        public void MoveRight(char[] level, Player player)
        {
            if (currentPosition != level.Count() - 9)
            {
                level[currentPosition] = '_';
                level[currentPosition + 10] = player.icon;
                currentPosition = currentPosition + 10;
            }
            else if (currentPosition == level.Count() - 9)
            {
                winner = true;
            }
        }

        public void MoveLeft(char[] level, Player player)
        {
            if (currentPosition != 1)
            {
                level[currentPosition] = '_';
                level[currentPosition - 10] = player.icon;
                currentPosition = currentPosition - 10;
            }

            else if (currentPosition == 1)
            {
                currentPosition = 1;
            }
        }
    }
}
