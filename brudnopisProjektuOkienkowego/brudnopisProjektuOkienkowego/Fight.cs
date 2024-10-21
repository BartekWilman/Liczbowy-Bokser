using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static brudnopisProjektuOkienkowego.Program;

namespace brudnopisProjektuOkienkowego
{
    internal class Fight
    {
        //inicjatywa czyli kto uderza
        public static int InitiativeTest(Program.Boxer p1, Program.Boxer p2, double p1oxygen, double p2oxygen)
        {
            
                if (p1.speed * p1oxygen * 0.1 > p2.speed * p2oxygen * 0.1)
                {
                return 1;
                }
                else if (p1.speed * p1oxygen * 0.1 < p2.speed * p2oxygen * 0.1)
                {
                    return 2;
                }
                else
                {
                    return 3;
                }
            
        }
        //sprawdzenie czy bokser z inicjatywą jest w stanie uderzyć
        public static bool OxygenTest(Program.Boxer pWitithInitiative, int randomMultiplier, double oxygen)
        {
            if(oxygen - (pWitithInitiative.strenght * (randomMultiplier * 0.1)) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //przebieg akcji
        public static void RealAction(Program.Boxer p1, Program.Boxer p2, ref int p1points, ref int p2points, int randomMultiplier, bool p2Oxygen, ref double p1Health, ref double p2Health, ref double p1oxygen, ref double p2oxygen)
        {
            //opis akcji gracza
            Program.Container.Offensive(p1);

            //udany atak gracza
            if (p1.attack > p2.defense)
            {
                p2Health -= (p1.strenght * randomMultiplier * 0.1);
                p1oxygen -= (p1.strenght * randomMultiplier * 0.1);
                //reakcja na obrażenia
                if (p2Health > 0)
                {
                    Program.Container.BeInjured(p2);
                    //gracz zyskuje punkty
                    p1points += 2;
                    
                }
                else
                {
                    Console.WriteLine($"{p2.name} pada na deski, koniec walki\n");
                }
            }
            //nieudany atak i udana kontra przeciwnika
            else if (((p1.attack) <= (p2.defense)) && (p2Oxygen == true) && ((p1.defense + p1.speed)) < ((p2.attack + p2.speed)))
            {
                Program.Container.CounterAttack(p2);
                Program.Container.BeInjured(p1);

                //gracz zyskuje punkty za probe ataku
                p1points += 1;
                //przeciwnik zyskuje za udaną kontrę
                p2points += 3;
                p1Health -= (p2.strenght * randomMultiplier * 0.1);
                //obaj zawodnicy się męczą
                p1oxygen -= (p1.strenght * randomMultiplier * 0.1);
                p2oxygen -= (p2.strenght * randomMultiplier * 0.1);
            }
            //nieudany atak i obrona bez kontry
            else
            {
                Console.WriteLine($"{p2.name} {Program.Container.RandomString(StringLists.avoids)}");
                p1points += 1;
                p2points += 1;
                p1oxygen -= (p1.strenght * randomMultiplier * 0.1);
            }
        }
        //akcja
        public static void SingleAction(Program.Boxer p1, Program.Boxer p2, ref double p1Health, ref double p2Health, ref int p1points, ref int p2points, ref double p1oxygen, ref double p2oxygen)
        {
            
            //sprawdzenie kto może uderzyc pierwszy
            int initiative = InitiativeTest(p1, p2, p1oxygen, p2oxygen);

            //ewentualny mnoznik sily ciosu w tej akcji
            int randomMultiplier = Program.Container.rand.Next(1,4);
            //gracz ma inicjatywe
            if (initiative == 1)
            {
                bool p1Ox = OxygenTest(p1, randomMultiplier, p1oxygen);
                bool p2Ox = OxygenTest(p2, randomMultiplier, p2oxygen);
                //jest na tyle dotleniony bu uderzyc
                if(p1Ox == true)
                {
                    RealAction(p1, p2, ref p1points, ref p2points, randomMultiplier, p2Ox, ref p1Health, ref p2Health, ref p1oxygen, ref p2oxygen); //p2Ox jest do ewentualnej kontry
                }
                //zbyt zmeczony by uderzyc
                else
                {
                    Program.Container.LackOfOxygen(p1);
                    p1oxygen += (p1.condition * 0.1);
                }
            }
            //przeciwnik ma inicjatywe
            else if(initiative== 2)
            {
                bool p2Ox = OxygenTest(p2, randomMultiplier, p2oxygen);
                bool p1Ox = OxygenTest(p1, randomMultiplier, p1oxygen);
                // wystarczajaco dotleniony by uderzyc
                if(p2Ox==true)
                {
                    RealAction(p2, p1, ref p2points, ref p1points, randomMultiplier, p1Ox, ref p2Health, ref p1Health, ref p2oxygen, ref p1oxygen);
                }
                //zby zmeczony by uderzyc
                else
                {
                    Program.Container.LackOfOxygen(p2);
                    p2oxygen += (p2.condition * 0.1);
                }
            }
            else
            {
                Console.WriteLine(Program.Container.RandomString(StringLists.identicalInitiative));
                p1oxygen -=(p1.strenght * randomMultiplier * 0.1);
                p2oxygen -=(p2.strenght *randomMultiplier * 0.1);
            }
        }
        //runda
        public static void Round(Program.Boxer p1, Program.Boxer p2, ref double p1Oxygen, ref double p2Oxygen, ref double p1Health, ref double p2Health, ref int p1points, ref int p2points)
        {
            int actions = 0;
            while(p1Health > 0 && p2Health > 0 && actions < 20)
            {
                SingleAction(p1, p2, ref p1Health, ref p2Health, ref p1points, ref p2points, ref p1Oxygen, ref p2Oxygen); 
                actions++;
            }
        }
        //walka
        public static void Duel(Program.Boxer p1, Program.Boxer p2, ref int skillPoints, int difficult, ref int wins, ref int loses, ref int draws)
        {
            int p1points = 0;
            int p2points = 0;
            int rounds = 1;
            double p1Oxygen = p1.condition *100;
            double p2Oxygem = p2.condition *100;
            double p1Health = p1.condition *100;
            double p2Health = p2.condition *100;

            while(p1Health > 0 && p2Health > 0 && rounds < 13)
            {
                //odpoczynek miedzy rundami
                if(rounds%2 == 0)
                {
                    p1Oxygen += (p1.condition * 0.2);
                    p2Oxygem += (p2.condition * 0.2);
                }
                Console.WriteLine($"RUNDA {rounds}");
                Program.Container.Taunting(p1, p2, p1points, p2points);
                Round(p1, p2, ref p1Oxygen, ref p2Oxygem, ref p1Health, ref p2Health, ref p1points, ref p2points);
                rounds++;
            }
            //wynik walki
            //wygrana przez KO
            if(p1Health>0 && p2Health<=0) 
            {
                Program.Container.SaveFights(p2, "Wygrana przez KO");
                Console.WriteLine($"Walkę przez KO wygrywa {p1.name}\n\n");
                skillPoints += (3 * difficult);
                wins++;
            }
            //wygrana na punkty
            else if(p1Health > 0 && p2Health > 0 && p1points > p2points)
            {
                Program.Container.SaveFights(p2, $"Wygrana na punkty {p1points} do {p2points}");
                Console.WriteLine($"Walkę na punkty wygrywa {p1.name} {p1points}  {p2points}.\nTym razem {p2.name} wraca na tarczy.\n\n");
                skillPoints += (1 * difficult);
                wins++;
            }
            //przegrana przez KO
            else if (p1Health <= 0 && p2Health > 0)
            {
                Program.Container.SaveFights(p2, "Przegrana przez KO");
                Console.WriteLine($"Walkę przez KO wygrywa {p2.name}\n\n");
                loses++;
            }
            //przegrana na punkty
            else if (p1Health > 0 && p2Health > 0 && p1points < p2points)
            {
                Program.Container.SaveFights(p2, $"Przegrana na punkty {p2points} do {p1points}");
                Console.WriteLine($"Walkę na punkty wygrywa {p2.name} {p2points}  {p1points}.\nTym razem {p1.name} wraca na tarczy.\n\n");
                loses++;
            }
            //remis
            else
            {
                Program.Container.SaveFights(p2, "Remis");
                Console.WriteLine($"{p1points}  {p2points}");
                Console.WriteLine("Remis\n\n");
                skillPoints += 1;
                draws++;
            }
        }
    }
}
