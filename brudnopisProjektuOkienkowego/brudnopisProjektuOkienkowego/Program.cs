using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static brudnopisProjektuOkienkowego.Program;

namespace brudnopisProjektuOkienkowego
{
    internal class Program
    {
        //kontener
        public static class Container
        {

            public static string beginning;
            public static string moves;
            public static string targets;
            public static string beingInjured;
            public static string continuingTheFight;
            public static string avoids;
            public static string retreat;
            //plik ze statystykami gracza
            public static string Plik = "save.csv";
            //plik z historią walk gracza
            public static string Plik2 = "fightStory.csv";
            //do zapisu progresu gracza
            public static string GenerateLine(Puncher i, int skillPoints, int wins, int loses, int draws)
            {
                return $"{i.name};{i.strenght};{i.condition};{i.speed};{i.attack};{i.defense};{skillPoints};{wins};{loses};{draws}";
            }
            public static string GenerateEnemyLine(Boxer i, string result)
            {
                return $"{i.name};{result}";
            }
            //zapisanie stanu
            public static void SaveGame(Puncher i, int skillPoints, int wins, int loses, int draws)
            {
                string text = GenerateLine(i, skillPoints, wins, loses, draws);
                sw = new StreamWriter(Plik, true);
                sw.WriteLine(text);
                sw.Close();
            }
            //zapis walk gracza
            public static void SaveFights(Boxer i, string result)
            {
                string text = GenerateEnemyLine(i, result);
                sw = new StreamWriter(Plik2, true);
                sw.WriteLine(text);
                sw.Close();
            }
            //wczytanie statystyk postaci
            public static void LoadGame(ref Puncher i, ref int skillPoints, ref int wins, ref int loses, ref int draws)
            {
                sr = new StreamReader(Plik);
                var line = sr.ReadLine();
                var table = line.Split(';');
                string name = table[0];
                float strenght = float.Parse(table[1]);
                float condition = float.Parse(table[2]);
                float speed = float.Parse(table[3]);
                float attack = float.Parse(table[4]);
                float defense = float.Parse(table[5]);
                skillPoints = int.Parse(table[6]);
                wins = int.Parse(table[7]);
                loses = int.Parse(table[8]);
                draws = int.Parse(table[9]);
                i.name = name;
                i.strenght = strenght;
                i.condition = condition;
                i.speed = speed;
                i.attack = attack;
                i.defense = defense;
                sr.Close();
            }
            public static void LoadFightHistory()
            {
                if (!File.Exists(Plik2))
                {
                    Console.WriteLine("\nNie stoczono zadnych walk\n");
                }
                else
                {
                    List<string> fightList = new List<string>();
                    sr = new StreamReader(Plik2);
                    fightList.Clear();
                    while (sr.EndOfStream == false)
                    {
                        var line = sr.ReadLine();
                        var table = line.Split(';');
                        string lineInList = $"{table[0]}          {table[1]}\n";
                        fightList.Add(lineInList);
                    }
                    sr.Close();
                    Console.WriteLine($"\nBuster Douglas rekord {wins} - {loses} - {draws}\n");
                    Console.WriteLine("IMIE PRZECIWNIKA             WYNIK\n");
                    foreach (string rival in fightList)
                    {
                        Console.WriteLine(rival);
                    }
                }
            }
            //zapis do pliku statystyk postaci
            static StreamWriter sw;
            //odczyt z pliku statystyk postaci
            static StreamReader sr;
            //punkty umiejętności
            public static int skillPoints = 0;
            //liczba wygranych
            public static int wins = 0;
            public static int loses = 0;
            public static int draws = 0;
            //obiekt random
            public static Random rand = new Random();
            //losowy string
            public static string RandomString(string[] tab)
            {
                int i = rand.Next(0, tab.Length);
                return tab[i];
            }
            public static void Taunting(Boxer fighter1, Boxer fighter2, int playerPoints, int aIPoints)
            {
                string taunt = RandomString(StringLists.taunts);
                if (playerPoints > aIPoints)
                {
                    Console.WriteLine($"\n{fighter1.name} {taunt}\n");
                }
                else if (aIPoints > playerPoints)
                {
                    Console.WriteLine($"\n{fighter2.name} {taunt}\n");
                }
                else
                {
                    string draw = RandomString(StringLists.draw);
                    Console.WriteLine($"\n{draw}\n");
                }

            }
            public static void Offensive(Boxer p)
            {
                beginning = RandomString(StringLists.beginning);
                moves = RandomString(StringLists.moves);
                targets = RandomString(StringLists.targets);
                Console.WriteLine($"{p.name} {beginning} {moves} {targets}");
            }
            public static void BeInjured(Boxer p)
            {
                beingInjured = RandomString(StringLists.beingInjured);
                continuingTheFight = RandomString(StringLists.continuingTheFight);
                Console.WriteLine($"{p.name} {beingInjured} {continuingTheFight}\n");
            }
            public static void CounterAttack(Boxer p)
            {
                avoids = RandomString(StringLists.avoids);
                moves = RandomString(StringLists.moves);
                Console.WriteLine($"Ale {p.name} {avoids} i wykonał {moves}");
            }
            public static void LackOfOxygen(Boxer p)
            {
                retreat = RandomString(StringLists.retreat);
                Console.WriteLine($"{p.name} {retreat}\n");
            }
            public static Boxer NewBoxer(string[] tab, int min, int max)
            {
                int typeOfBoxer = rand.Next(1, 4);
                string name = RandomString(tab);
                float strenght = rand.Next(min, max);
                float condition = rand.Next(min, max);
                float speed = rand.Next(min, max);
                float attack = rand.Next(min, max);
                float defense = rand.Next(min, max);
               if(typeOfBoxer == 1)
                {
                    Puncher enemy = new Puncher(name, strenght, condition, speed, attack, defense);
                    return enemy;
                }
               else if(typeOfBoxer == 2)
                {
                    Swammer enemy = new Swammer(name, strenght, condition, speed, attack, defense);
                    return enemy;
                }
               else if(typeOfBoxer == 3)
                {
                    Slugger enemy = new Slugger(name, strenght, condition, speed, attack, defense);
                    return enemy;
                }
                else
                {
                    Slugger enemy = new Slugger(name, strenght, condition, speed, attack, defense);
                    return enemy;
                }
                
            }
            //trening
            public static void Training(ref Puncher i, ref int skillPoints, int skillProgress)
            {

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine($"Zwiększono szybkość o {skillProgress}");
                        i.speed += skillProgress;
                        skillPoints -= skillProgress;
                        break;
                    case ConsoleKey.D2:
                        double potentialStrenght = (i.strenght + skillProgress) * 1.5;
                        if (potentialStrenght >= (i.condition * 100))
                        {
                            Console.WriteLine("Nie możesz przesadzać z treningiem siłowym, bo nie będziesz w stanie udeżyć");
                        }
                        else
                        {
                            Console.WriteLine($"Zwiększono siłę o {skillProgress}");
                            i.strenght += skillProgress;
                            skillPoints -= skillProgress;
                        }
                        break;

                    case ConsoleKey.D3:
                        Console.WriteLine($"Zwiększono wytrzymałość o {skillProgress}");
                        i.condition += skillProgress;
                        skillPoints -= skillProgress;
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine($"Zwiększono atak o {skillProgress}");
                        i.attack += skillProgress;
                        skillPoints -= skillProgress;
                        break;
                    case ConsoleKey.D5:
                        Console.WriteLine($"Zwiększono obronę o {skillProgress}");
                        i.defense += skillProgress;
                        skillPoints -= skillProgress;
                        break;
                }
            }
            //turbotrening
            public static void TurboTraining(ref Puncher i, ref int skillPoints)
            {
                bool end = true;
                while (skillPoints > 0 && end == true)
                {
                    Console.WriteLine("Co chcesz trenować?");
                    Console.WriteLine("1 - szybkość\n2 - siłę\n3 - wytrzymałość\n4 - atak\n5 - obronę");
                    if (skillPoints < 100)
                    {
                        Training(ref i, ref skillPoints, 1);
                        Console.WriteLine("Trenować dalej?\n1 - Tak\n2 - nie");
                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.D1:
                                break;
                            case ConsoleKey.D2:
                                end = false;
                                break;
                        }
                    }
                    else if (skillPoints > 100 && skillPoints < 1000)
                    {
                        Training(ref i, ref skillPoints, 10);
                        Console.WriteLine("Trenować dalej?\n1 - Tak\n2 - nie");
                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.D1:
                                break;
                            case ConsoleKey.D2:
                                end = false;
                                break;
                        }
                    }
                    else if (skillPoints > 1000)
                    {
                        Training(ref i, ref skillPoints, 100);
                        Console.WriteLine("Trenować dalej?\n1 - Tak\n2 - nie");
                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.D1:
                                break;
                            case ConsoleKey.D2:
                                end = false;
                                break;
                        }
                    }
                }
                if (skillPoints == 0)
                {
                    Console.WriteLine("Brakuje Ci punktów umiejętności, wygraj więcej walk by je zdobyć");
                    Console.WriteLine("Zakończono trening");
                }
                else
                {
                    Console.WriteLine("Zakończono trening");
                }

            }
            // nowa walka
            public static void NewFight(Boxer i)
            {
                bool end = false;
                while (end == false)
                {
                    Console.WriteLine("Wybierz poziom trudności");
                    Console.WriteLine("1 - łatwy\n2 - średni\n3 - trudny\n4 - legendarny\n5 - wróć");
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.D1:
                            Boxer EasyBoxer;
                            EasyBoxer = Container.NewBoxer(StringLists.easyBoxersNames, 4, 7);
                            Fight.Duel(i, EasyBoxer, ref Container.skillPoints, 1, ref Container.wins, ref Container.loses, ref Container.draws);
                            end = true;
                            break;
                        case ConsoleKey.D2:
                            Boxer MediumBoxer;
                            MediumBoxer = Container.NewBoxer(StringLists.mediumBoxersName, 8, 19);
                            Fight.Duel(i, MediumBoxer, ref skillPoints, 2, ref wins, ref Container.loses, ref Container.draws);
                            end = true;
                            break;
                        case ConsoleKey.D3:
                            Boxer HardBoxer;
                            HardBoxer = Container.NewBoxer(StringLists.hardBoxersNames, 20, 40);
                            Fight.Duel(i, HardBoxer, ref skillPoints, 3, ref wins, ref Container.loses, ref Container.draws);
                            end = true;
                            break;
                        case ConsoleKey.D4:
                            Boxer LegendBoxer;
                            LegendBoxer = Container.NewBoxer(StringLists.legendBoxersNames, 40, 80);
                            Fight.Duel(i, LegendBoxer, ref skillPoints, 4, ref wins, ref Container.loses, ref Container.draws);
                            end = true;
                            break;
                        case ConsoleKey.D5:
                            end = true;
                            break;
                    }
                }
                if (wins == 50)
                {
                    Console.WriteLine(StringLists.after50Wins);
                }
                else if (wins == 100)
                {
                    Console.WriteLine(StringLists.after100Wins);
                }
                else if (wins == 150)
                {
                    Console.WriteLine(StringLists.after150Wins);
                }
            }
            //rozgrywka
            public static void Game(Puncher i)
            {
                Puncher Mike = new Puncher("Mike Tyson", 180, 480, 270, 390, 430);
                bool end = false;
                while (end == false)
                {
                    Console.WriteLine($"Wygrałeś {wins} walk. Przed następną walką możesz zrobić {skillPoints} jednostek treningowych, co chcesz zrobić?");
                    Console.WriteLine("1 - Walcz\n2 - Trenuj\n3 - Przejrzyj historię walk\n4 - Zapisz i wyjdź");
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.D1:
                            if (wins == 200)
                            {
                                Console.WriteLine("Walczysz z mistrzem Mikiem Tysonem?\n1 - Tak\n2 - Nie");
                                switch (Console.ReadKey(true).Key)
                                {
                                    case ConsoleKey.D1:
                                        Console.WriteLine(StringLists.beforFightWithTyson);
                                        Fight.Duel(i, Mike, ref skillPoints, 10, ref Container.wins, ref Container.loses, ref Container.draws);
                                        if (wins == 201)
                                        {
                                            Console.WriteLine(StringLists.winWithTyson);
                                        }
                                        else
                                        {
                                            Console.WriteLine(StringLists.defeatWithTyson);
                                        }
                                        break;
                                    case ConsoleKey.D2:
                                        Console.WriteLine(StringLists.rejectionOfTheFight);
                                        break;
                                }
                            }
                            else
                            {
                                NewFight(i);
                            }
                            break;

                        case ConsoleKey.D2:
                            Container.TurboTraining(ref i, ref skillPoints);
                            break;

                        case ConsoleKey.D3:
                            Container.LoadFightHistory();
                            break;

                        case ConsoleKey.D4:


                            if (File.Exists(Plik))
                            {
                                File.Delete(Plik);
                            }
                            SaveGame(i, skillPoints, wins, loses, draws);
                            Console.WriteLine("Żegnam");
                            end = true;

                            break;
                    }
                }
            }
            //1
            public static void NewGame()
            {
                File.Delete(Plik);
                File.Delete(Plik2);
                Console.WriteLine("Nazywasz się Buster Douglas i jesteś bokserem wagi ciężkiej.\nTwoim zadaniem jest zdetronizowanie obecnego mistrze Mika Tysona.");
                Console.WriteLine("Zdobądź mistrzostwo pokonując to coraz silniejszych rywali a w pewnym momencie mistrz sam się o Ciebie upomni");
                Puncher Buster = new Puncher("Buster Douglas", 3, 4, 4, 4, 3);
                Game(Buster);
            }
            //2
            public static void ContinueGame()
            {
                Puncher Buster = new Puncher("Buster Douglas", 3, 4, 4, 4, 3);
                LoadGame(ref Buster, ref skillPoints, ref wins, ref loses, ref draws);
                Game(Buster);
            }
            public static void Meat()
            {
                Console.WriteLine("BUSTER DOUGLAS SIMULATOR");
                bool end = true;
                while (end == true)
                {
                    Console.WriteLine("1 - nowa gra\n2 - kontynuuj grę\n3 - autorzy\n4 - wyjdź z programu");
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.D1:
                            if (File.Exists(Plik))
                            {
                                Console.WriteLine("Wybranie tej opcji usunie aktualny stan gry. Czy jesteś pewien?\n1 - Tak\n2 - Nie");
                                switch (Console.ReadKey(true).Key)
                                {
                                    case ConsoleKey.D1:
                                        NewGame();
                                        break;
                                    case ConsoleKey.D2:
                                        break;
                                }
                            }
                            else
                            {
                                NewGame();
                            }
                            break;
                        case ConsoleKey.D2:
                            ContinueGame();
                            break;
                        case ConsoleKey.D3:
                            Console.WriteLine(StringLists.authors);
                            break;
                        case ConsoleKey.D4:
                            Console.WriteLine("Jesteś pewien?\n1 - Tak   2 - Nie");
                            switch (Console.ReadKey(true).Key)
                            {
                                case ConsoleKey.D1:
                                    end = false;
                                    Console.WriteLine("Żegnam");
                                    Console.ReadLine();
                                    break;
                                case ConsoleKey.D2:
                                    break;
                            }
                            break;
                    }
                }
            }

        }
        //do stestów
        public static void ShowMe(Boxer i)
        {
            Console.WriteLine($"{i.name} siła {i.strenght} szybkość {i.speed} kondycja {i.condition} atak {i.attack} obrona {i.defense}");
        }
        //abstrakcyjna klasa Boxer
        public abstract class Boxer
        {
            //Konstruktor
            public Boxer(string name, double strenght, double condition, double speed, double attack, double defense)
            {
                this.name = name;
                this.strenght = strenght;
                this.condition = condition;
                this.speed = speed;
                this.attack = attack;
                this.defense = defense;
                
            }
            public string name;
            public double strenght;
            public double condition;
            public double speed;
            public double attack;
            public double defense;   
        }
        //dokładne ciosy i solidna kondycja
        public class Puncher : Boxer
        {
            public Puncher(string name, double strenght, double condition, double speed, double attack, double defense) : base(name, strenght, condition, speed, attack, defense)
            {
                this.attack *= 1.15;
                this.condition *= 1.3;
            }
        }

        //skraca dystans szybkie ataki, dokładne i bolesne ciosy
        public class Swammer : Boxer
        {
            public Swammer(string name, double strenght, double condition, double speed, double attack, double defense) : base(name, strenght, condition, speed, attack, defense)
            {
                this.speed *= 1.2;
                this.attack *= 1.1;
                this.strenght *= 1.1;
            }
        }
        //ogromna siła i agresja, słaba kondycja i szybkość
        public class Slugger : Boxer
        {
            public Slugger(string name, double strenght, double condition, double speed, double attack, double defense) : base(name, strenght, condition, speed, attack, defense)
            {
                this.strenght *= 1.5;
                this.attack *= 1.6;
                this.condition *= 0.9;
                this.speed *= 0.95;
            }
        }
        static void Main(string[] args)
        {
            Container.
                Meat();
        }
    }
}
