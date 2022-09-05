using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDTool
{
    internal class Quest
    {
        public string Problem = "";
        public string QuestType = "";
        public int QuestRoll;

        public override string ToString()
        {
            return "Roll: " + QuestRoll + "\n" + "Problem: " + Problem + "\n" + "Quest Type: " + QuestType;
        }

        public static Quest Generate()
        {
            string problem = "";
            string quest = "";
            int questRoll = (int)Dice.RollDie(Dice.Die.D100);
            if (questRoll <= 4)
            {
                problem = "Unjust killing.";
                quest = "Revenge";
            }
            else if (questRoll >= 5 && questRoll <= 8)
            {
                problem = "Crime committed, criminal disappeared.";
                quest = "Apprehend / Bounty Hunt";
            }
            else if (questRoll >= 9 && questRoll <= 12)
            {
                problem = "Item Lost";
                quest = "Retrieval";
            }
            else if (questRoll >= 13 && questRoll <= 16)
            {
                problem = "Tyrant(s) threaten town / business/ population.";
                quest = "Repel / Sabotage / Deceive / Extort / Entrap";
            }
            else if (questRoll >= 17 && questRoll <= 20)
            {
                problem = "Environmental disturbance / strange weather";
                quest = "Investigate / Solve";
            }
            else if (questRoll >= 21 && questRoll <= 24)
            {
                problem = "Magical chaos / Curse";
                quest = "Investigate / Lift curse / destroy magic";
            }
            else if (questRoll >= 25 && questRoll <= 28)
            {
                problem = "Kidnapping / Hostage situation";
                quest = "Rescue / Recover";
            }
            else if (questRoll >= 29 && questRoll <= 32)
            {
                problem = "Adventurer left some time ago, but is lost.";
                quest = "Rescue";
            }
            else if (questRoll >= 33 && questRoll <= 36)
            {
                problem = "Something is rumored, but undiscovered.";
                quest = "Explore / Discover";
            }
            else if (questRoll >= 37 && questRoll <= 40)
            {
                problem = "Riches rumored within secure, guarded place.";
                quest = "Loot";
            }
            else if (questRoll >= 41 && questRoll <= 44)
            {
                problem = "Invasion";
                quest = "Repel / Divert";
            }
            else if (questRoll >= 45 && questRoll <= 48)
            {
                problem = "Person suspected of something.";
                quest = "Spy / Gather information";
            }
            else if (questRoll >= 49 && questRoll <= 52)
            {
                problem = "Important item / message / person needs transporting.";
                quest = "Transport / smuggle / escort";
            }
            else if (questRoll >= 53 && questRoll <= 56)
            {
                problem = "Nefarious / Dangerous item being transported.";
                quest = "Waylay / Hijack";
            }
            else if (questRoll >= 57 && questRoll <= 60)
            {
                problem = "Dangerous item exposed / up for grabs.";
                quest = "Find / Destroy";
            }
            else if (questRoll >= 61 && questRoll <= 64)
            {
                problem = "Corrupt noble.";
                quest = "Investigate / Implicate / Incriminate / Expose";
            }
            else if (questRoll >= 65 && questRoll <= 68)
            {
                problem = "Commodity Shortage";
                quest = "Transport supplies";
            }
            else if (questRoll >= 69 && questRoll <= 72)
            {
                problem = "Mystery unresolved.";
                quest = "Research / Explore / Decode";
            }
            else if (questRoll >= 73 && questRoll <= 76)
            {
                problem = "Adventurer thrown into life-threating situation.";
                quest = "Survive";
            }
            else if (questRoll >= 77 && questRoll <= 80)
            {
                problem = "Worthy creature's life threatened";
                quest = "Protect / Eliminate Threat";
            }
            else if (questRoll >= 81 && questRoll <= 84)
            {
                problem = "Execution of innocent part planned";
                quest = "Prevent";
            }
            else if (questRoll >= 85 && questRoll <= 88)
            {
                problem = "Siege";
                quest = "Break";
            }
            else if (questRoll >= 89 && questRoll <= 92)
            {
                problem = "Huge battle about to erupt";
                quest = "Negotiate / Prepare / Meditate / Participate";
            }
            else if (questRoll >= 93 && questRoll <= 96)
            {
                problem = "Spiritually beneficial place rumored.";
                quest = "Visit / Gain boon";
            }
            else if (questRoll >= 97)
            {
                problem = "Foolish individual commmited innocent blunder.";
                quest = "PC hired to conceal evidence / Return item / Placate";
            }
            return new Quest() { Problem = problem, QuestType = quest, QuestRoll = questRoll };
        }
    }
}
