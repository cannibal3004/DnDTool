namespace DnDTool
{
    internal class Program
    {
        static Random rand = new Random();
        static void Main(string[] args)
        {
            Menu menu = new Menu("DnD Tools");
            Menu.MenuItem dice = menu.AddItem("Dice", null, null);
            Menu.MenuItem d4 = menu.AddItem("Roll D4", dice, () => { RollDice(Die.D4); });
            Menu.MenuItem d6 = menu.AddItem("Roll D6", dice, () => { RollDice(Die.D6); });
            Menu.MenuItem d8 = menu.AddItem("Roll D8", dice, () => { RollDice(Die.D8); });
            Menu.MenuItem d10 = menu.AddItem("Roll D10", dice, () => { RollDice(Die.D10); });
            Menu.MenuItem d12 = menu.AddItem("Roll D12", dice, () => { RollDice(Die.D12);});
            Menu.MenuItem d20 = menu.AddItem("Roll D20", dice, () => { RollDice(Die.D20); });
            Menu.MenuItem d100 = menu.AddItem("Roll D100", dice, () => { RollDice(Die.D100); });
            Menu.MenuItem questions = menu.AddItem("Questions", null, () => { Question(); });
            Menu.MenuItem travel = menu.AddItem("Travel", null, null);
            Menu.MenuItem travelOnFoot = menu.AddItem("On Foot", travel, () => { Travel(Mount.Foot); });
            Menu.MenuItem travelOnHorseBack = menu.AddItem("On horseback", travel, () => { Travel(Mount.Horse); });
            Menu.MenuItem travelOnDraftHorse = menu.AddItem("On draft horse", travel, () => { Travel(Mount.DraftHorse);});
            Menu.MenuItem travelOnWarHorse = menu.AddItem("On war horse", travel, () => { Travel(Mount.WarHorse); });
            Menu.MenuItem travelOnMule = menu.AddItem("On on mule", travel, () => { Travel(Mount.Mule); });
            Menu.MenuItem travelOnMastiff = menu.AddItem("On mastiff", travel, () => { Travel(Mount.Mastiff); });
            Menu.MenuItem camp = menu.AddItem("Camp", null, null);
            Menu.MenuItem findCamp = menu.AddItem("Find Campsite", camp, null);
            Menu.MenuItem encounters = menu.AddItem("Encounters", null, null);
            Menu.MenuItem areaGenerators = menu.AddItem("Area Genrator", null, null);
            Menu.MenuItem lootTables = menu.AddItem("Quest Generator", null, () => { GenerateQuest();});
            Menu.MenuItem exit = menu.AddItem("Exit", null, () => { menu.Stop();});
            menu.Start();
            Console.Clear();
        }

        static void GenerateQuest()
        {
            Quest quest = QuestGen();
            Console.ResetColor();
            Console.Clear();
            Console.WriteLine(quest.ToString());
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static Quest QuestGen()
        {
            string problem = "";
            string quest = "";
            int questRoll = RollDie(Die.D100);
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

        static void Question()
        {
            Console.Clear();
            Console.WriteLine("Enter a yes/no/maybe question, or just press enter:");
            string? questionStr = Console.ReadLine();
            if (questionStr != null)
            {
                Console.Clear();
                Console.WriteLine(questionStr);
            }
            Console.WriteLine("Enter likelihood modifier:");
            int dieRoll = RollDie(Die.D20);
            string? likelihoodString = Console.ReadLine();
            int.TryParse(likelihoodString, out int likelihood);
            if (dieRoll+likelihood < 7)
            {
                Console.WriteLine(dieRoll + likelihood + " No");
            } else if (dieRoll+likelihood > 6 && dieRoll+likelihood < 13)
            {
                Console.WriteLine(dieRoll+likelihood+" Maybe");
            } else
            {
                Console.WriteLine(dieRoll + likelihood + " Yes");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void RollDice(Die die)
        {
            Console.Clear();
            Console.WriteLine("Roll how many dice?");
            string? input = Console.ReadLine();
            if (input != null)
            {
                Console.Clear();
                Console.WriteLine("Enter advantage: (blank for none)");
                string? advantageStr = Console.ReadLine();
                int.TryParse(advantageStr, out int advantage);
                Console.Clear();
                int qty;
                if (int.TryParse(input, out qty))
                {
                    for (int i = 0; i < qty; i++)
                    {
                        Console.Write("D" + (int)die + " " + (i + 1) + " : ");
                        Console.WriteLine(RollDie(die, advantage));
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static int RollDie(Die die, int advantage = 0)
        {
            return rand.Next(1, (int)die) + advantage;
        }

        static string GenerateTavern()
        {
            return "";
        }

        static void Travel(Mount mount)
        {
            //int populationDensity = 0;
            //menu.Pause();
            Console.Clear();
            Console.WriteLine("Enter travel distance in miles:");
            decimal distance;
            string? distanceString = Console.ReadLine();
            if (distanceString != null && decimal.TryParse(distanceString, out decimal totalDistance))
            {
                
                if (decimal.TryParse(distanceString, out distance))
                {
                    int populationDensity = 1;
                    Menu populationMenu = new Menu("Population Density");
                    populationMenu.AddItem("Low", null, () => { populationMenu.Stop(); populationDensity = 1; });
                    populationMenu.AddItem("Medium", null, () => { populationMenu.Stop(); populationDensity = 2; });
                    populationMenu.AddItem("High", null, () => { populationMenu.Stop(); populationDensity = 3; });
                    //object populationDensity = 
                    populationMenu.Start();

                    int season = 1;
                    Menu seasonMenu = new Menu("Season");
                    seasonMenu.AddItem("Spring", null, () => { seasonMenu.Stop(); season = 1; });
                    seasonMenu.AddItem("Summer", null, () => { seasonMenu.Stop(); season = 2; });
                    seasonMenu.AddItem("Autumn", null, () => { seasonMenu.Stop(); season = 4; });
                    seasonMenu.AddItem("Winter", null, () => { seasonMenu.Stop(); season = 4; });
                    seasonMenu.Start();

                    string terrain = "";
                    Menu terrainMenu = new Menu("Terrain");
                    terrainMenu.AddItem("Forrest", null, () => { terrainMenu.Stop(); terrain = "Forrest"; });
                    terrainMenu.AddItem("Coastal", null, () => { terrainMenu.Stop(); terrain = "Coastal"; });
                    terrainMenu.AddItem("Desert", null, () => { terrainMenu.Stop(); terrain = "Desert"; });
                    terrainMenu.AddItem("Grassland", null, () => { terrainMenu.Stop(); terrain = "Grassland"; });
                    terrainMenu.AddItem("Hills", null, () => { terrainMenu.Stop(); terrain = "Hills"; });
                    terrainMenu.AddItem("Subterranean", null, () => { terrainMenu.Stop(); terrain = "Subterranean"; });
                    terrainMenu.AddItem("Swamp", null, () => { terrainMenu.Stop(); terrain = "Swamp"; });
                    terrainMenu.AddItem("Mountain", null, () => { terrainMenu.Stop(); terrain = "Mountain"; });
                    terrainMenu.Start();

                    bool day = true;
                    Menu timeOfDayMenu = new Menu("Time of day");
                    timeOfDayMenu.AddItem("Day", null, () => { timeOfDayMenu.Stop(); day = true; });
                    timeOfDayMenu.AddItem("Night", null, () => { timeOfDayMenu.Stop(); day = false; });
                    timeOfDayMenu.Start();

                    bool difficultTerrain = false;
                    Menu terrainDifficultyMenu = new Menu("Difficult Terrain?");
                    terrainDifficultyMenu.AddItem("Yes", null, () => { terrainDifficultyMenu.Stop(); difficultTerrain = true; });
                    terrainDifficultyMenu.AddItem("No", null, () => { terrainDifficultyMenu.Stop(); difficultTerrain = false; });
                    terrainDifficultyMenu.Start();

                    //Console.WriteLine("difficultTerrain = " + difficultTerrain);
                    decimal movementSpeed = ((decimal)mount) / 2;
                    if (difficultTerrain)
                    {
                        movementSpeed = ((decimal)mount) / 4;
                    }
                    decimal travelTimeDecimal = (totalDistance / (movementSpeed / 24));
                    int travelTimeHours = (int)decimal.Truncate(travelTimeDecimal);
                    int travelTimeMinutes = (int)decimal.Truncate((travelTimeDecimal - travelTimeHours)*60);

                    TimeSpan travelTimeSpan = new TimeSpan(travelTimeHours, travelTimeMinutes, 0);
                    int weatherRoll = RollDie(Die.D20);
                    string weather = "";
                    switch (season)
                    {
                        case 1:
                            //Spring
                            if (weatherRoll == 1)
                            {
                                weather = "Blizzard";

                            }
                            else if (weatherRoll > 1 && weatherRoll < 5)
                            {
                                weather = "Rain";
                            }
                            else if (weatherRoll > 4 && weatherRoll < 9)
                            {
                                weather = "Overcast";
                            }
                            else if (weatherRoll > 8 && weatherRoll < 12)
                            {
                                weather = "Clear Skies";
                            }
                            else if (weatherRoll > 12 && weatherRoll < 19)
                            {
                                weather = "Warm";
                            }
                            else
                            {
                                weather = "Hot";
                            }
                            break;
                        case 2:
                            //Summer
                            if (weatherRoll == 1)
                            {
                                weather = "Unseasonably cold";
                            }
                            else if (weatherRoll > 1 && weatherRoll < 5)
                            {
                                weather = "Rainy";
                            }
                            else if (weatherRoll > 4 && weatherRoll < 9)
                            {
                                weather = "Overcast";
                            }
                            else if (weatherRoll > 8 && weatherRoll < 12)
                            {
                                weather = "Clear, Warm";
                            }
                            else if (weatherRoll > 12 && weatherRoll < 19)
                            {
                                weather = "Clear, Hot";
                            }
                            else
                            {
                                weather = "Very Hot";
                            }
                            break;
                        case 3:
                            //Autumn
                            if (weatherRoll == 1)
                            {
                                weather = "Blizzard";
                            }
                            else if (weatherRoll > 1 && weatherRoll < 5)
                            {
                                weather = "Rainy";
                            }
                            else if (weatherRoll > 4 && weatherRoll < 9)
                            {
                                weather = "Light Rain";
                            }
                            else if (weatherRoll > 8 && weatherRoll < 12)
                            {
                                weather = "Overcast";
                            }
                            else if (weatherRoll > 12 && weatherRoll < 19)
                            {
                                weather = "Clear Skies";
                            }
                            else
                            {
                                weather = "Hot";
                            }
                            break;
                        case 4:
                            //Autumn
                            if (weatherRoll == 1)
                            {
                                weather = "Heavy snow";
                            }
                            else if (weatherRoll > 1 && weatherRoll < 5)
                            {
                                weather = "Snowstorm";
                            }
                            else if (weatherRoll > 4 && weatherRoll < 9)
                            {
                                weather = "Rain";
                            }
                            else if (weatherRoll > 8 && weatherRoll < 12)
                            {
                                weather = "Overcast";
                            }
                            else if (weatherRoll > 12 && weatherRoll < 19)
                            {
                                weather = "Clear Skies";
                            }
                            else
                            {
                                weather = "Unseasonably warm";
                            }
                            break;
                    }

                    int encounters = 0;
                    switch (populationDensity)
                    {
                        case 1:
                            if (day)
                            {
                                encounters = (int)Math.Ceiling(1 * (travelTimeDecimal / 12));
                            }
                            else
                            {
                                encounters = (int)Math.Ceiling(1 * (travelTimeDecimal / 12));
                            }
                            break;
                        case 2:
                            if ((bool)day)
                            {
                                encounters = (int)Math.Ceiling(4 * (travelTimeDecimal / 12));
                            }
                            else
                            {
                                encounters = (int)Math.Ceiling(2 * (travelTimeDecimal / 12));
                            }
                            break;
                        case 3:
                            if ((bool)day)
                            {
                                encounters = (int)Math.Ceiling(6 * (travelTimeDecimal / 12));
                            }
                            else
                            {
                                encounters = (int)Math.Ceiling(3 * (travelTimeDecimal / 12));
                            }
                            break;
                    }
                    
                    Console.ResetColor();
                    Console.Clear();
                    Console.WriteLine("Distance to Travel: " + totalDistance);
                    Console.WriteLine("Travel Time: "+ travelTimeSpan.ToString(@"dd\.hh\:mm\:ss"));
                    Console.WriteLine("Season: " + season);
                    Console.WriteLine("Weather: " + weather);
                    Console.WriteLine("Encounters: " + encounters);
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }
    }
    internal enum Die
    {
        D4 = 4,
        D6 = 6,
        D8 = 8,
        D10 = 10,
        D12 = 12,
        D20 = 20,
        D100 = 100
    }

    internal enum Mount
    {
        Foot = 24,
        Horse = 30,
        DraftHorse = 40,
        WarHorse = 60,
        Mule = 40,
        Cart = 30,
        Mastiff = 40
    }

    internal enum Season {
        Summer,
        Autumn,
        Winter,
        Spring
    }

    internal struct Quest
    {
        public string Problem;
        public string QuestType;
        public int QuestRoll;
        public override string ToString()
        {
            return "Roll: " + QuestRoll + "\n" + "Problem: " + Problem + "\n" + "Quest Type: " + QuestType;
        }
    }
}
