using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace brudnopisProjektuOkienkowego
{
    internal class StringLists
    {
        //imiona łatwych bokserów
        public static string[] easyBoxersNames = { "Marcin Najman", "Dawid Haras", "Bonus Bgc", "Chorąży Torpeda", "Wrzód z Gothica", "Skarnsik" };
        //imiona średnich bokserów
        public static string[] mediumBoxersName = { "Samuraj Jack", "Kung Fu Panda", "Hulk Hogan", "Kapitan Bomba", "Rock Lee", "Marshal Law", "Felix Jeager"};
        //imiona trudnych bokserów
        public static string[] hardBoxersNames = { "George St. Pierre", "Son Goku", "Muhammad Ali", "Cassius Clay", "One Punch Man", "Evander Holyfield", "Gotrek Gurnisson" };
        //imiona legendarnych boxerów
        public static string[] legendBoxersNames = {"Kratos", "Stefan Batory", "Belakor", "Skarbrand", "Arthas", "Ilidian", "Geralt z Rivi", "Pitagoras z Samos"};
        //rozpoczęcie akcji
        public static string[] beginning = { "rozpoczął ofensywę wytaczająć swój", "zaczął akcję od", "idzie do przodu", "wyprowadza atak mocny", "próbuje trafić swoim"};

        //możliwe ataki
        public static string[] moves = { "Prawy prosty", "Lewy prosty", "Prawy sierpowy", "Lewy sierpowy", "Prawy podbródkowy", "Lewy podbródkowy" };

        //cel ataku
        public static string[] targets = { "na głowę przeciwnika", "na wątrobę", "w splot słoneczny", "na żebra", "prosto w nos", "na skroń", "w okolice pasa, ale nie złamał reguł"};

        //możliwe obrony
        public static string[] avoids = { "uchylił się", "wykonał unik rotacyjny", "zablokował", "zbił uderzenie", "przyjął na gardę" };

        //przyjęcia obrażeń
        public static string[] beingInjured = { "przyjął cios ale", "dał się zaskoczyć, a mimo to", "odsłonił się i dał wykorzystać szansę przeciwnikowi, jednak", "na pewno odczuł ten cios, chociaż", "uśmiechnął się, ale na pewno odczuł uderzenie, a mimo to", "dostał, a i tak", "widać wyraźny grymas bólu, a i tak", "wywrócił oczami, widać że po tym ciosie ma szum w głowie, ale" };

        //kontynuowanie walki
        public static string[] continuingTheFight = { "dalej walczy", "nie chce oddać pola", "walczy dalej", "pokazuje że wszystko OK i może kontynuować" };

        //koniec przez KO
        public static string[] fatality = { "zatoczył się i już nie wstaje", "leży nieprzytomny", "po tym uderzeniu nie jest w stanie się podnieść", "upadł jak długi i przegrywa przez nokaut", "pada na deski" };

        //niezdolność do akcji
        public static string[] lackOfOxygen = { "nie jest w stanie dokończyć tej akcji", "jest ewidentnie zmęczony, co wykorzystuje przeciwnik", "pomimo przewagi szybkości nie jest w stanie zaatakować co może się źle skończyć" };

        //wycofanie się
        public static string[] retreat = { "dystansuje się", "zbiera siły", "dobiera taktykę by wycelować idealnie"};

        //drwiny
        public static string[] taunts = { "macha do przeciwnika, wyśmiewa go, wie że ma przewagę i chce sprowokować przeciwnika", "jest w pełni skupiony, dobrze wie że wygrywa. Musi teraz utrzymać swoją przewagę", "pokazuje swoją pewność siebie, zachęca rywala by bardziej się postarał. Jak ten zareaguje na ten atak psychologiczny?" };

        //remis
        public static string[] draw = {"Zawodnicy mierzą się wzrokiem, żaden nie chce ustąpić", "Walka jest bardzo wyrównana, obaj wiedzą jak reagować na swoje akcje", "Nie zazdroszczę sędziom punktowym, mają ciężki orzech do zgryzienia przy tak wyrównanym pojedynku"};

        //identyczna inicjatywa
        public static string[] identicalInitiative = { "Bardzo chaotyczna wymiana ciosów,\ntrudno zauważyć kto zdobywa przewagę\n", "Pojedynek przybrał zbyt pasywny charakter dla obu stron,\nmożemy spodziewać się interwencji sędziego zaraz\n", "Zbyt dużo ciosów w powietrze,\nta szermierka na pięści musi nabrać bardziej cielesnego charakteru.\n" };
        // po 50 wygranych
        public static string after50Wins = "Gazety piszą o nowym talencie bokserskim. Buster Douglas bo o nim mowa ma na koncie już 50 wygranych z zawodnikami wagi ciężkiej.\n" +
            "Co prawda to dopiero początek drogi tego młodego wojownika,\nale z zaciekawieniem bukmacherzy, promotorzy a przedewszystkim potencjalni rywale obserwują tego młodego wojownika\n";
        
        // po 100 walkach
        public static string after100Wins = "Równe sto walk, sto skalpów zebrał Buster Douglas. Jego fenomen skomentówał również obecny niekwestionowany mistrz Iron Mike.\n" +
            "\"Będę bacznie przyglądał się młokosowi, ale jeszcze długo nie będzie dla mnie zagrożeniem\", czy to ogromna pewność siebie mistrza, czy też próba kamuflażu strachu?\n" +
            "czas pokaże\n";
        
        // po 150 walkach
        public static string after150Wins = "Niecodzienna sytuacja, mistrz rzuca wyzwanie pretendentowi. Pierwsza taka sytuacja w historii boksu nowożytnego.\n" +
            "\"Wygraj jeszcze 50 walk, a dam Ci szansę. Stoczymy walkę o tytuł niekwestionowanego mistrza świata wagi ciężkiej.\n" +
            "Odrzuć wyzwanie, szansa przepadnie. Przegraj, a długo następnej nie dostaniesz, kolejka o tytuł jest długa.\n";
        
        // odmowa walki
        public static string rejectionOfTheFight = "Słychać było tylko śmiech wielkiego mistrza.\nSport to przedewszystkim biznes. " +
            "Skoro Buster uznał to za bardziej dochodowe rozwiązanie, świat boksu może to tylko zaakceptować...\n" +
            "ale szany na walkę o mistrzostwo na pewno już nie dostanie";
        
        // przed walką z Tysonem
        public static string beforFightWithTyson = "Doczekaliśmy się Młoda krew czy Stara Gwardia\n" +
            "Ten pojedynek zakończy wszelkie spekulacje i za chwilę zobaczymy kto jest prwdziwym mistrzem...\n";

        // wygrana z Tysonem
        public static string winWithTyson = "AND THE NEEEW\n" +
            "Tak, zgadza się mamy nowego mistrza.\n" +
            "Legenda wraca na tarczy, a na naszych oczach rodzi się nowa Legenda.\n" +
            "James Buster Douglas nowym zunifikowanym Mistrzem Świata.";

        // przegrana z Tysonem
        public static string defeatWithTyson = "AND STIIILLLL\n" +
            "Pas pozostaje u Mike'a Tysona\n" +
            "Mistrz pomimo starań młodszego zawodnika utrzymał koronę na głowie.\n" +
            "\"Jeszcze nie teraz\" ~Mike Tyson";
        // autorzy XD
        public static string authors = "Game director: Bartłomiej Wilman\nProject technical director: Bartłomiej Wilman\nProject Art director:Bartłomiej Wilman\n" +
            "Project Development Director: Bartłomiej Wilman\nFight Designer: Bartłomiej Wilman\n StoryLine Designer: Bartłomiej Wilman\nSenior QA Technician: Bartłomiej Wilman";
    }
}
