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


//Fair Warning: There is most likely a lot of redundancy throughout this program that we missed/forgot to delete
using Project5_Zork;

ZorkWelcome();
ZorkDescription();


//We each contributed to the "main method", emailing code back and forth, slightly editing each others. 
Player player = new Player();

Mummy mummy = new Mummy();
Zombie zombie = new Zombie();
Troll troll = new Troll();
Werewolf werewolf = new Werewolf();
EvilTwin evilTwin = new EvilTwin();
Dragon dragon = new Dragon();
Rancor rancor = new Rancor();

Club club = new Club();
Sword sword = new Sword();
Flamethrower flamethrower = new Flamethrower();
Lightsaber lightsaber = new Lightsaber();
PetRock petRock = new PetRock();

Random rand = new Random();
char[] levelLayout = new char[rand.Next(99)];

while (levelLayout.Count() < 50 || levelLayout.Count() % 10 != 0)
{
    levelLayout = new char[rand.Next(99)];
}

for (int i = 0; i < levelLayout.Count(); i++)
{
    if (i % 10 == 0)
    {
        levelLayout[i] = '|';
    }
    else if (i % 10 != 0)
    {
        levelLayout[i] = '_';
    }
}

levelLayout[player.GetCurrentPosition()] = player.GetPlayerIcon();

MonsterGeneration(levelLayout);
WeaponGeneration(levelLayout);

foreach (char value in levelLayout)
{
    Console.Write($"{value}");
}
Console.WriteLine("|\n");


while (player.GetWinner() == false && player.GetGameOver() == false)
{
    Console.WriteLine($"Remaining Health Points: {player.GetHealth()}");
    Console.Write("\nWould you like to go east or west?: ");
    string answer = Convert.ToString(Console.ReadLine().ToLower());

    if (answer == "east" || answer == "e" || answer == "right" || answer == "r")
    {
        player.MoveRight(levelLayout, player);

        Console.WriteLine("\n");

        if (levelLayout[player.GetCurrentPosition() + 4] != '_')
        {
            WeaponPickup();

            if (levelLayout[player.GetCurrentPosition() + 8] != '_')
            {
                Fight();
            }
        }
        else if (levelLayout[player.GetCurrentPosition() + 8] != '_')
        {
            Fight();
        }
        else if (player.GetWinner() == false)
        {
            foreach (char value in levelLayout)
            {
                Console.Write($"{value}");
            }
            Console.WriteLine("|\n");
        }
        else if (player.GetWinner() == true)
        {
            Console.WriteLine("You win!");
        }
    }
    else if ((answer == "west" || answer == "w" || answer == "left" || answer == "l") && levelLayout[1] == player.GetPlayerIcon())
    {
        Console.WriteLine("\nThe entrance is sealed shut!\n");
    }
    else if (answer == "west" || answer == "w" || answer == "left" || answer == "l")
    {
        player.MoveLeft(levelLayout, player);
        Console.WriteLine("\n");

        if (player.GetWinner() == false)
        {
            foreach (char value in levelLayout)
            {
                Console.Write($"{value}");
            }
            Console.WriteLine("|\n");
        }
    }
    else if (answer == "north" || answer == "n" || answer == "south" || answer == "s" || answer == "up" || answer == "u" || answer == "down" || answer == "d")
    {
        Console.WriteLine("\nYou have hit a wall!\n");
    }

    else
    {
        Console.WriteLine("\nPlease enter a valid direction to travel.\n");
    }
}

ZorkEnd();

//All speical text created by Daniel
//    |
//    V
static void ZorkWelcome()
{
    string intro1 = "Welcome to the Zork Game!";
    string intro2 = "----";
    string intro3 = "Created by Daniel Foister, Zoe Johnson, & Ryan Peters";

    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (intro1.Length / 2)) + "}", intro1));
    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (intro2.Length / 2)) + "}", intro2));
    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (intro3.Length / 2)) + "}", intro3));
    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
}

static void ZorkDescription()
{
    string desc1 = "You must escape the Dungeon!";
    string desc2 = "----";
    string desc3 = "The Hero can move East & West while trying to escape at the end of dungeon!";
    string desc4 = "Monsters will appear throughout the dungeon and must be fought off!";
    string desc5 = "Find items that can help you slay the monsters!";

    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (desc1.Length / 2)) + "}", desc1));
    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (desc2.Length / 2)) + "}", desc2));
    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (desc3.Length / 2)) + "}", desc3));
    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (desc4.Length / 2)) + "}", desc4));
    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (desc5.Length / 2)) + "}", desc5));
    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
}

static void ZorkEnd()
{
    string end = "Thanks for Playing!";

    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (end.Length / 2)) + "}", end));
    Console.WriteLine("\n------------------------------------------------------------------------------------------------------------------------");
}

//Created by Ryan and Daniel
void WeaponPickup()
{
    if (levelLayout[player.GetCurrentPosition() + 4] == 'C')
    {
        Console.WriteLine("You have found a CLUB. Damage has been permanently increased!\n\n");
        player.SetPlayerDamage(player.GetPlayerDamage() + club.GetClubDamage());
        levelLayout[player.GetCurrentPosition() + 4] = '_';
        if (levelLayout[player.GetCurrentPosition() + 8] == '_')
        {
            foreach (char value in levelLayout)
            {
                Console.Write($"{value}");
            }
            Console.WriteLine("|\n");
        }
    }
    else if (levelLayout[player.GetCurrentPosition() + 4] == 'S')
    {
        Console.WriteLine("You have found a SWORD. Damage has been permanently increased!\n\n");
        player.SetPlayerDamage(player.GetPlayerDamage() + sword.GetSwordDamage());
        levelLayout[player.GetCurrentPosition() + 4] = '_';
        if (levelLayout[player.GetCurrentPosition() + 8] == '_')
        {
            foreach (char value in levelLayout)
            {
                Console.Write($"{value}");
            }
            Console.WriteLine("|\n");
        }
    }
    else if (levelLayout[player.GetCurrentPosition() + 4] == 'F')
    {
        Console.WriteLine("You have found a FLAMETHROWER. Damage has been permanently increased!\n\n");
        player.SetPlayerDamage(player.GetPlayerDamage() + flamethrower.GetFlamethrowerDamage());
        levelLayout[player.GetCurrentPosition() + 4] = '_';
        if (levelLayout[player.GetCurrentPosition() + 8] == '_')
        {
            foreach (char value in levelLayout)
            {
                Console.Write($"{value}");
            }
            Console.WriteLine("|\n");
        }
    }
    else if (levelLayout[player.GetCurrentPosition() + 4] == 'L')
    {
        Console.WriteLine("You have found a LIGHTSABER. Damage has been permanently increased!\n\n");
        player.SetPlayerDamage(player.GetPlayerDamage() + lightsaber.GetLightsaberDamage());
        levelLayout[player.GetCurrentPosition() + 4] = '_';
        if (levelLayout[player.GetCurrentPosition() + 8] == '_')
        {
            foreach (char value in levelLayout)
            {
                Console.Write($"{value}");
            }
            Console.WriteLine("|\n");
        }
    }
    else if (levelLayout[player.GetCurrentPosition() + 4] == 'H')
    {
        Console.WriteLine("You have found HUBERT the pet rock. Damage has been permanently increased!\n\n");
        player.SetPlayerDamage(player.GetPlayerDamage() + petRock.GetPetRockDamage());
        levelLayout[player.GetCurrentPosition() + 4] = '_';
        if (levelLayout[player.GetCurrentPosition() + 8] == '_')
        {
            foreach (char value in levelLayout)
            {
                Console.Write($"{value}");
            }
            Console.WriteLine("|\n");
        }
    }
}

//Created by Ryan, edited partially(very, very little) by Daniel and Zoe
void Fight()
{
    if (levelLayout[player.GetCurrentPosition() + 8] == 'M')
    {
        Console.WriteLine("You have encountered a MUMMY and now it is time for a fight!\n");
        Mummy mummy = new Mummy();
        Random random = new Random();
        while (player.GetHealth() > 0 && mummy.GetHealth() > 0 && player.GetGameOver() == false)
        {
            int playerAccuracy = random.Next(1, 101);
            int mummyAccuracy = random.Next(1, 101);
            int mummyRemainingHealth = mummy.GetHealth() - player.GetDamage();
            int playerRemainingHealth = player.GetHealth() - mummy.GetDamage();


            if (playerAccuracy >= 11)
            {
                if (mummy.GetHealth() > 0)
                {
                    if (mummyRemainingHealth > 0)
                    {
                        Console.WriteLine($"The MUMMY was hit for {player.GetDamage()} damage and has {mummyRemainingHealth} health points remaining.");
                        mummy.SetHealth(mummyRemainingHealth);
                    }

                    if (mummyRemainingHealth <= 0)
                    {
                        Console.WriteLine($"The MUMMY was hit for {player.GetDamage()} damage and has 0 health points remaining.");
                        mummy.SetHealth(mummyRemainingHealth);
                    }
                }

                if (mummy.GetHealth() <= 0)
                {
                    Console.WriteLine("\nCongratulations, you have slain the MUMMY!\n\n");
                    levelLayout[player.GetCurrentPosition() + 8] = '_';
                    foreach (char value in levelLayout)
                    {
                        Console.Write($"{value}");
                    }
                    Console.WriteLine("|\n");
                }
            }

            if (playerAccuracy < 11 && player.GetHealth() > 0)
            {
                Console.WriteLine("You missed the MUMMY with your attack!");
            }

            if (mummyAccuracy >= 21)
            {
                if (playerRemainingHealth > 0 && mummy.GetHealth()! > 0)
                {
                    Console.WriteLine($"The PLAYER was hit for {mummy.GetDamage()} damage and has {playerRemainingHealth} health points remaining.");
                    player.SetHealth(playerRemainingHealth);
                }

                if (playerRemainingHealth <= 0)
                {
                    Console.WriteLine($"The PLAYER was hit for {mummy.GetDamage()} damage and has 0 health points remaining.");
                    Console.WriteLine("\nYou fought courageously but have died an honorable death!\n");
                    player.SetGameOver(true);
                }
            }

            if (mummyAccuracy < 21 && mummy.GetHealth() > 0)
            {
                Console.WriteLine("The MUMMY missed it's attack!");
            }
        }
    }

    if (levelLayout[player.GetCurrentPosition() + 8] == 'Z')
    {
        Console.WriteLine("You have encountered a ZOMBIE and now it is time for a fight!\n");
        Zombie zombie = new Zombie();
        Random random = new Random();
        while (player.GetHealth() > 0 && zombie.GetHealth() > 0 && player.GetGameOver() == false)
        {
            int playerAccuracy = random.Next(1, 101);
            int zombieAccuracy = random.Next(1, 101);
            int zombieRemainingHealth = zombie.GetHealth() - player.GetDamage();
            int playerRemainingHealth = player.GetHealth() - zombie.GetDamage();


            if (playerAccuracy >= 11)
            {
                if (zombie.GetHealth() > 0)
                {
                    if (zombieRemainingHealth > 0)
                    {
                        Console.WriteLine($"The ZOMBIE was hit for {player.GetDamage()} damage and has {zombieRemainingHealth} health points remaining.");
                        zombie.SetHealth(zombieRemainingHealth);
                    }

                    if (zombieRemainingHealth <= 0)
                    {
                        Console.WriteLine($"The ZOMBIE was hit for {player.GetDamage()} damage and has 0 health points remaining.");
                        zombie.SetHealth(zombieRemainingHealth);
                    }
                }

                if (zombie.GetHealth() <= 0)
                {
                    Console.WriteLine("\nCongratulations, you have slain the ZOMBIE!\n\n");
                    levelLayout[player.GetCurrentPosition() + 8] = '_';
                    foreach (char value in levelLayout)
                    {
                        Console.Write($"{value}");
                    }
                    Console.WriteLine("|\n");
                }
            }

            if (playerAccuracy < 11 && player.GetHealth() > 0)
            {
                Console.WriteLine("You missed the ZOMBIE with your attack!");
            }

            if (zombieAccuracy >= 21)
            {
                if (playerRemainingHealth > 0 && zombie.GetHealth()! > 0)
                {
                    Console.WriteLine($"The PLAYER was hit for {zombie.GetDamage()} damage and has {playerRemainingHealth} health points remaining.");
                    player.SetHealth(playerRemainingHealth);
                }

                if (playerRemainingHealth <= 0)
                {
                    Console.WriteLine($"The PLAYER was hit for {zombie.GetDamage()} damage and has 0 health points remaining.");
                    Console.WriteLine("\nYou fought courageously but have died an honorable death!\n");
                    player.SetGameOver(true);
                }
            }

            if (zombieAccuracy < 21 && zombie.GetHealth() > 0)
            {
                Console.WriteLine("The ZOMBIE missed it's attack!");
            }
        }
    }


    if (levelLayout[player.GetCurrentPosition() + 8] == 'R')
    {
        Console.WriteLine("You have encountered a RANCOR and now it is time for a fight!\n");
        Rancor rancor = new Rancor();
        Random random = new Random();
        while (player.GetHealth() > 0 && rancor.GetHealth() > 0 && player.GetGameOver() == false)
        {
            int playerAccuracy = random.Next(1, 101);
            int rancorAccuracy = random.Next(1, 101);
            int rancorRemainingHealth = rancor.GetHealth() - player.GetDamage();
            int playerRemainingHealth = player.GetHealth() - rancor.GetDamage();


            if (playerAccuracy >= 11)
            {
                if (rancor.GetHealth() > 0)
                {
                    if (rancorRemainingHealth > 0)
                    {
                        Console.WriteLine($"The RANCOR was hit for {player.GetDamage()} damage and has {rancorRemainingHealth} health points remaining.");
                        rancor.SetHealth(rancorRemainingHealth);
                    }

                    if (rancorRemainingHealth <= 0)
                    {
                        Console.WriteLine($"The RANCOR was hit for {player.GetDamage()} damage and has 0 health points remaining.");
                        rancor.SetHealth(rancorRemainingHealth);
                    }
                }

                if (rancor.GetHealth() <= 0)
                {
                    Console.WriteLine("\nCongratulations, you have slain the RANCOR!\n\n");
                    levelLayout[player.GetCurrentPosition() + 8] = '_';
                    foreach (char value in levelLayout)
                    {
                        Console.Write($"{value}");
                    }
                    Console.WriteLine("|\n");
                }
            }

            if (playerAccuracy < 11 && player.GetHealth() > 0)
            {
                Console.WriteLine("You missed the RANCOR with your attack!");
            }

            if (rancorAccuracy >= 51)
            {
                if (playerRemainingHealth > 0 && rancor.GetHealth()! > 0)
                {
                    Console.WriteLine($"The PLAYER was hit for {rancor.GetDamage()} damage and has {playerRemainingHealth} health points remaining.");
                    player.SetHealth(playerRemainingHealth);
                }

                if (player.GetHealth() <= 0)
                {
                    Console.WriteLine($"The PLAYER was hit for {rancor.GetDamage()} damage and has 0 health points remaining.");
                    Console.WriteLine("\nYou fought courageously but have died an honorable death!\n");
                    player.SetGameOver(true);
                }
            }

            if (rancorAccuracy < 51 && rancor.GetHealth() > 0)
            {
                Console.WriteLine("The RANCOR missed it's attack!");
            }
        }
    }

    if (levelLayout[player.GetCurrentPosition() + 8] == 'T')
    {
        Console.WriteLine("You have encountered a TROLL and now it is time for a fight!\n");
        Troll troll = new Troll();
        Random random = new Random();
        while (player.GetHealth() > 0 && troll.GetHealth() > 0 && player.GetGameOver() == false)
        {
            int playerAccuracy = random.Next(1, 101);
            int trollAccuracy = random.Next(1, 101);
            int trollRemainingHealth = troll.GetHealth() - player.GetDamage();
            int playerRemainingHealth = player.GetHealth() - troll.GetDamage();


            if (playerAccuracy >= 11)
            {
                if (troll.GetHealth() > 0)
                {
                    if (trollRemainingHealth > 0)
                    {
                        Console.WriteLine($"The TROLL was hit for {player.GetDamage()} damage and has {trollRemainingHealth} health points remaining.");
                        troll.SetHealth(trollRemainingHealth);
                    }

                    if (trollRemainingHealth <= 0)
                    {
                        Console.WriteLine($"The TROLL was hit for {player.GetDamage()} damage and has 0 health points remaining.");
                        troll.SetHealth(trollRemainingHealth);
                    }
                }

                if (troll.GetHealth() <= 0)
                {
                    Console.WriteLine("\nCongratulations, you have slain the TROLL!\n\n");
                    levelLayout[player.GetCurrentPosition() + 8] = '_';
                    foreach (char value in levelLayout)
                    {
                        Console.Write($"{value}");
                    }
                    Console.WriteLine("|\n");
                }
            }

            if (playerAccuracy < 11 && player.GetHealth() > 0)
            {
                Console.WriteLine("You missed the TROLL with your attack!");
            }

            if (trollAccuracy >= 31)
            {
                if (playerRemainingHealth > 0 && troll.GetHealth()! > 0)
                {
                    Console.WriteLine($"The PLAYER was hit for {troll.GetDamage()} damage and has {playerRemainingHealth} health points remaining.");
                    player.SetHealth(playerRemainingHealth);
                }

                if (playerRemainingHealth <= 0)
                {
                    Console.WriteLine($"The PLAYER was hit for {troll.GetDamage()} damage and has 0 health points remaining.");
                    Console.WriteLine("\nYou fought courageously but have died an honorable death!\n");
                    player.SetGameOver(true);
                }

            }

            if (trollAccuracy < 31 && troll.GetHealth() > 0)
            {
                Console.WriteLine("The TROLL missed it's attack!");
            }
        }
    }

    if (levelLayout[player.GetCurrentPosition() + 8] == 'D')
    {
        Console.WriteLine("You have encountered a DRAGON and now it is time for a fight!\n");
        Dragon dragon = new Dragon();
        Random random = new Random();
        while (player.GetHealth() > 0 && dragon.GetHealth() > 0 && player.GetGameOver() == false)
        {
            int playerAccuracy = random.Next(1, 101);
            int dragonAccuracy = random.Next(1, 101);
            int dragonRemainingHealth = dragon.GetHealth() - player.GetDamage();
            int playerRemainingHealth = player.GetHealth() - dragon.GetDamage();


            if (playerAccuracy >= 11)
            {
                if (dragon.GetHealth() > 0)
                {
                    if (dragonRemainingHealth > 0)
                    {
                        Console.WriteLine($"The DRAGON was hit for {player.GetDamage()} damage and has {dragonRemainingHealth} health points remaining.");
                        dragon.SetHealth(dragonRemainingHealth);
                    }

                    if (dragonRemainingHealth <= 0)
                    {
                        Console.WriteLine($"The DRAGON was hit for {player.GetDamage()} damage and has 0 health points remaining.");
                        dragon.SetHealth(dragonRemainingHealth);
                    }
                }

                if (dragon.GetHealth() <= 0)
                {
                    Console.WriteLine("\nCongratulations, you have slain the DRAGON!\n\n");
                    levelLayout[player.GetCurrentPosition() + 8] = '_';
                    foreach (char value in levelLayout)
                    {
                        Console.Write($"{value}");
                    }
                    Console.WriteLine("|\n");
                }
            }

            if (playerAccuracy < 11 && player.GetHealth() > 0)
            {
                Console.WriteLine("You missed the DRAGON with your attack!");
            }

            if (dragonAccuracy >= 41)
            {
                if (playerRemainingHealth > 0 && dragon.GetHealth()! > 0)
                {
                    Console.WriteLine($"The PLAYER was hit for {dragon.GetDamage()} damage and has {playerRemainingHealth} health points remaining.");
                    player.SetHealth(playerRemainingHealth);
                }

                if (playerRemainingHealth <= 0)
                {
                    Console.WriteLine($"The PLAYER was hit for {dragon.GetDamage()} damage and has 0 health points remaining.");
                    Console.WriteLine("\nYou fought courageously but have died an honorable death!\n");
                    player.SetGameOver(true);
                }
            }

            if (dragonAccuracy < 41 && dragon.GetHealth() > 0)
            {
                Console.WriteLine("The DRAGON missed it's attack!");
            }
        }
    }

    if (levelLayout[player.GetCurrentPosition() + 8] == 'E')
    {
        Console.WriteLine("You have encountered your EVIL TWIN and now it is time for a fight!\n");
        EvilTwin evilTwin = new EvilTwin();
        Random random = new Random();
        while (player.GetHealth() > 0 && evilTwin.GetHealth() > 0 && player.GetGameOver() == false)
        {
            int playerAccuracy = random.Next(1, 101);
            int evilTwinAccuracy = random.Next(1, 101);
            int evilTwinRemainingHealth = evilTwin.GetHealth() - player.GetDamage();
            int playerRemainingHealth = player.GetHealth() - evilTwin.GetDamage();


            if (playerAccuracy >= 11)
            {
                if (evilTwin.GetHealth() > 0)
                {
                    if (evilTwinRemainingHealth > 0)
                    {
                        Console.WriteLine($"Your EVIL TWIN was hit for {player.GetDamage()} damage and has {evilTwinRemainingHealth} health points remaining.");
                        evilTwin.SetHealth(evilTwinRemainingHealth);
                    }

                    if (evilTwinRemainingHealth <= 0)
                    {
                        Console.WriteLine($"Your EVIL TWIN was hit for {player.GetDamage()} damage and has 0 health points remaining.");
                        evilTwin.SetHealth(evilTwinRemainingHealth);
                    }
                }

                if (evilTwin.GetHealth() <= 0)
                {
                    Console.WriteLine("\nCongratulations, you have slain your EVIL TWIN!\n\n");
                    levelLayout[player.GetCurrentPosition() + 8] = '_';
                    foreach (char value in levelLayout)
                    {
                        Console.Write($"{value}");
                    }
                    Console.WriteLine("|\n");
                }
            }

            if (playerAccuracy < 11 && player.GetHealth() > 0)
            {
                Console.WriteLine("You missed your EVIL TWIN with your attack!");
            }

            if (evilTwinAccuracy >= 35)
            {
                if (playerRemainingHealth > 0 && evilTwin.GetHealth()! > 0)
                {
                    Console.WriteLine($"The PLAYER was hit for {evilTwin.GetDamage()} damage and has {playerRemainingHealth} health points remaining.");
                    player.SetHealth(playerRemainingHealth);
                }

                if (playerRemainingHealth <= 0)
                {
                    Console.WriteLine($"The PLAYER was hit for {evilTwin.GetDamage()} damage and has 0 health points remaining.");
                    Console.WriteLine("\nYou fought courageously but have died an honorable death!\n");
                    player.SetGameOver(true);
                }
            }

            if (evilTwinAccuracy < 35 && evilTwin.GetHealth() > 0)
            {
                Console.WriteLine("Your EVIL TWIN missed it's attack!");
            }
        }
    }

    if (levelLayout[player.GetCurrentPosition() + 8] == 'W')
    {
        Console.WriteLine("You have encountered a WEREWOLF and now it is time for a fight!\n");
        Werewolf werewolf = new Werewolf();
        Random random = new Random();
        while (player.GetHealth() > 0 && werewolf.GetHealth() > 0 && player.GetGameOver() == false)
        {
            int playerAccuracy = random.Next(1, 101);
            int werewolfAccuracy = random.Next(1, 101);
            int werewolfRemainingHealth = werewolf.GetHealth() - player.GetDamage();
            int playerRemainingHealth = player.GetHealth() - werewolf.GetDamage();


            if (playerAccuracy >= 11)
            {
                if (werewolf.GetHealth() > 0)
                {
                    if (werewolfRemainingHealth > 0)
                    {
                        Console.WriteLine($"The WEREWOLF was hit for {player.GetDamage()} damage and has {werewolfRemainingHealth} health points remaining.");
                        werewolf.SetHealth(werewolfRemainingHealth);
                    }

                    if (werewolfRemainingHealth <= 0)
                    {
                        Console.WriteLine($"The WEREWOLF was hit for {player.GetDamage()} damage and has 0 health points remaining.");
                        werewolf.SetHealth(werewolfRemainingHealth);
                    }
                }

                if (werewolf.GetHealth() <= 0)
                {
                    Console.WriteLine("\nCongratulations, you have slain the WEREWOLF!\n\n");
                    levelLayout[player.GetCurrentPosition() + 8] = '_';
                    foreach (char value in levelLayout)
                    {
                        Console.Write($"{value}");
                    }
                    Console.WriteLine("|\n");
                }
            }

            if (playerAccuracy < 11 && player.GetHealth() > 0)
            {
                Console.WriteLine("You missed the WEREWOLF with your attack!");
            }

            if (werewolfAccuracy >= 31)
            {
                if (playerRemainingHealth > 0 && werewolf.GetHealth()! > 0)
                {
                    Console.WriteLine($"The PLAYER was hit for {werewolf.GetDamage()} damage and has {playerRemainingHealth} health points remaining.");
                    player.SetHealth(playerRemainingHealth);
                }

                if (playerRemainingHealth <= 0)
                {
                    Console.WriteLine($"The PLAYER was hit for {werewolf.GetDamage()} damage and has 0 health points remaining.");
                    Console.WriteLine("\nYou fought courageously but have died an honorable death!\n");
                    player.SetGameOver(true);
                }
            }

            if (werewolfAccuracy < 31 && werewolf.GetHealth() > 0)
            {
                Console.WriteLine("The WEREWOLF missed it's attack!");
            }
        }
    }
}

//Created by Daniel, edited by Ryan
void MonsterGeneration(char[] levelLayout)
{
    for (int i = 19; i < levelLayout.Count(); i += 10)
    {
        bool monsterSuccess = false;
        while (!monsterSuccess)
        {
            Random randM = new Random();

            if (randM.Next(200) <= 100)
            {
                randM = new Random();
                int randInt = randM.Next(1, 101);

                if (randInt >= 1 && randInt <= 50)
                {
                    randInt = randM.Next(1, 101);

                    if (randInt >= 1 && randInt <= 50)
                    {
                        Mummy mummy = new Mummy();
                        char mumI = mummy.GetChar();
                        levelLayout[i] = mumI;
                    }
                    else
                    {
                        Zombie zombie = new Zombie();
                        char zomI = zombie.GetChar();
                        levelLayout[i] = zomI;
                    }
                }
                else if (randInt >= 51 && randInt <= 75)
                {
                    randInt = randM.Next(1, 101);

                    if (randInt >= 1 && randInt <= 50)
                    {
                        Troll troll = new Troll();
                        char trollI = troll.GetChar();
                        levelLayout[i] = trollI;
                    }
                    else
                    {
                        Werewolf werewolf = new Werewolf();
                        char wereI = werewolf.GetChar();
                        levelLayout[i] = wereI;
                    }
                }
                else if (randInt >= 76 && randInt <= 90)
                {
                    EvilTwin evilTwin = new EvilTwin();
                    evilTwin.SetETDamage(player.GetPlayerDamage());
                    char evilI = evilTwin.GetChar();
                    levelLayout[i] = evilI;
                }
                else if (randInt >= 91 && randInt <= 99)
                {
                    Dragon dragon = new Dragon();
                    char dragI = dragon.GetChar();
                    levelLayout[i] = dragI;
                }
                else if (randInt == 100)
                {
                    Rancor rancor = new Rancor();
                    char ranI = rancor.GetChar();
                    levelLayout[i] = ranI;
                }
            }
            else
            {
                monsterSuccess = true;
            }
        }
    }
}

//Created by Daniel
static void WeaponGeneration(char[] levelLayout)
{
    int numCells = levelLayout.Count() / 10;

    Random randCell = new Random();
    int cellChoice = randCell.Next(2, numCells + 1) - 1;

    Random randW = new Random();
    int randInt = randW.Next(1, 101);

    if (randInt >= 1 && randInt <= 30)
    {
        Club club = new Club();
        char clubI = club.GetWeaponIcon();
        levelLayout[cellChoice * 10 + 5] = clubI;
    }
    else if (randInt >= 31 && randInt <= 61)
    {
        Sword sword = new Sword();
        char swordI = sword.GetWeaponIcon();
        levelLayout[cellChoice * 10 + 5] = swordI;
    }
    else if (randInt >= 62 && randInt <= 92)
    {
        Flamethrower flamethrower = new Flamethrower();
        char flamethrowerI = flamethrower.GetWeaponIcon();
        levelLayout[cellChoice * 10 + 5] = flamethrowerI;
    }
    else if (randInt >= 93 && randInt <= 99)
    {
        Lightsaber lightsaber = new Lightsaber();
        char lightsaberI = lightsaber.GetWeaponIcon();
        levelLayout[cellChoice * 10 + 5] = lightsaberI;
    }
    else if (randInt == 100)
    {
        PetRock petRock = new PetRock();
        char petRockI = petRock.GetWeaponIcon();
        levelLayout[cellChoice * 10 + 5] = petRockI;
    }
}