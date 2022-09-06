namespace DnDTool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu("DnD Tools", Console.WindowWidth-2);
            Menu.MenuItem dice = menu.AddItem("Dice", null, null);
            Menu.MenuItem d4 = menu.AddItem("Roll D4", dice, () => { RollDice(Dice.Die.D4, menu); });
            Menu.MenuItem d6 = menu.AddItem("Roll D6", dice, () => { RollDice(Dice.Die.D6, menu); });
            Menu.MenuItem d8 = menu.AddItem("Roll D8", dice, () => { RollDice(Dice.Die.D8, menu); });
            Menu.MenuItem d10 = menu.AddItem("Roll D10", dice, () => { RollDice(Dice.Die.D10, menu); });
            Menu.MenuItem d12 = menu.AddItem("Roll D12", dice, () => { RollDice(Dice.Die.D12, menu); });
            Menu.MenuItem d20 = menu.AddItem("Roll D20", dice, () => { RollDice(Dice.Die.D20, menu); });
            Menu.MenuItem d100 = menu.AddItem("Roll D100", dice, () => { RollDice(Dice.Die.D100, menu); });
            Menu.MenuItem questions = menu.AddItem("Questions", null, () => { Question(menu); });
            Menu.MenuItem travel = menu.AddItem("Travel", null, () => { Travel(menu); });
            Menu.MenuItem camp = menu.AddItem("Camp", null, null);
            Menu.MenuItem findCamp = menu.AddItem("Find Campsite", camp, null);
            Menu.MenuItem encounters = menu.AddItem("Encounters", null, null);
            Menu.MenuItem areaGenerators = menu.AddItem("Area Genrator", null, null);
            Menu.MenuItem lootTables = menu.AddItem("Quest Generator", null, () => { GenerateQuest(); });
            Menu.MenuItem exit = menu.AddItem("Exit", null, () => { menu.Stop(); });
            menu.Start();
            Console.Clear();
        }

        static void GenerateQuest()
        {
            Quest quest = Quest.Generate();
            Console.ResetColor();
            Console.Clear();
            Console.WriteLine(quest.ToString());
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        static void Question(Menu menu)
        {;
            string questionStr = menu.Input("Enter question");
            int dieRoll = Dice.RollDie(Dice.Die.D20);
            if (questionStr != null)
            {
                Console.Clear();
                Console.WriteLine(questionStr);
            }

            string? likelihoodString = menu.Input("Likelihood modifier");
            int.TryParse(likelihoodString, out int likelihood);
            if (dieRoll+likelihood < 7)
            {
                menu.Message("Answer", (dieRoll + likelihood) + " No");
            } else if (dieRoll+likelihood > 6 && dieRoll+likelihood < 13)
            {
                menu.Message("Answer", (dieRoll + likelihood) + " Maybe");
            } else
            {
                menu.Message("Answer", (dieRoll + likelihood) + " Yes");
            }
        }

        static string GenerateTavern()
        {
            return "";
        }

        static void Travel(Menu menu)
        {
            decimal distance;
            string? distanceString = menu.Input("Travel Distance");
            if (distanceString != null && decimal.TryParse(distanceString, out decimal totalDistance))
            {

                if (decimal.TryParse(distanceString, out distance))
                {
                    int travelMount = Menu.Prompt("Mount", new Dictionary<string, int>()
                    {
                        { "On foot", 24 },
                        { "On horseback", 30 },
                        { "On war horse", 60 },
                        { "On on mule" ,40 },
                        { "On mastiff" , 40 }
                    });

                    string populationDensity =  Menu.Prompt("Population Density", new Dictionary<string, string>() {
                        { "Low", "Low" },
                        { "Medium", "Medium"},
                        { "High", "High" }
                    });

                    string season = Menu.Prompt("Season", new Dictionary<string, string>()
                    {
                        { "Spring", "Spring" },
                        { "Summer", "Summer" },
                        { "Autumn", "Autumn" },
                        { "Winter", "Winter" }
                    });

                    string terrain = Menu.Prompt("Terrain", new Dictionary<string, string>()
                    {
                        { "Forrest", "Forrest" },
                        { "Coastal", "Coastal" },
                        { "Desert", "Desert" },
                        { "Grassland", "Grassland" },
                        { "Hills", "Hills" },
                        { "Subterranean", "Subterranean" },
                        { "Swamp", "Swamp" },
                        { "Mountain", "Mountain" }
                    });

                    bool day = Menu.Prompt("Time of day", new Dictionary<string, bool>() 
                    {
                        { "Day", true },
                        { "Night", false }
                    });

                    bool difficultTerrain = Menu.Prompt("Difficult Terrain");

                    decimal movementSpeed = ((decimal)travelMount);
                    if (difficultTerrain)
                    {
                        movementSpeed = ((decimal)travelMount) / 2;
                    }
                    decimal travelTimeDecimal = (totalDistance / movementSpeed)*24;
                    int travelTimeDays = (int)decimal.Truncate(travelTimeDecimal/24);
                    int travelTimeHours = (int)decimal.Truncate(travelTimeDecimal);
                    int travelTimeMinutes = (int)decimal.Truncate((travelTimeDecimal - travelTimeHours) * 60);
                    int travelTimeSeconds = (int)decimal.Truncate((travelTimeDecimal - travelTimeHours) * 360);

                    TimeSpan travelTimeSpan = new TimeSpan(travelTimeDays, travelTimeHours, travelTimeMinutes, travelTimeSeconds);
                    int weatherRoll = Dice.RollDie(Dice.Die.D20);
                    string weather = "";
                    switch (season)
                    {
                        case "Spring":
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
                        case "Summer":
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
                        case "Autumn":
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
                        case "Winter":
                            //Winter
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
                        case "Low":
                            if (day)
                            {
                                encounters = (int)Math.Ceiling(1 * (travelTimeDecimal / 12));
                            }
                            else
                            {
                                encounters = (int)Math.Ceiling(1 * (travelTimeDecimal / 12));
                            }
                            break;
                        case "Medium":
                            if ((bool)day)
                            {
                                encounters = (int)Math.Ceiling(4 * (travelTimeDecimal / 12));
                            }
                            else
                            {
                                encounters = (int)Math.Ceiling(2 * (travelTimeDecimal / 12));
                            }
                            break;
                        case "High":
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

        static void RollDice(Dice.Die die, Menu menu)
        {
            //Console.Clear();
            //Console.WriteLine("Roll how many dice?");
            string input = menu.Input("How many dice?");
            if (input != null)
            {
                //Console.Clear();
                //Console.WriteLine("Enter advantage: (blank for none)");
                string advantageStr = menu.Input("Advantage");
                int.TryParse(advantageStr, out int advantage);

                if (int.TryParse(input, out int qty))
                {
                    List<string> messageLines = new();
                    for (int i = 0; i < qty; i++)
                    {
                        //Console.Write("D" + (int)die + " " + (i + 1) + " : ");
                        //Console.WriteLine(Dice.RollDie(die, advantage));
                        int roll = Dice.RollDie(die, advantage);
                        messageLines.Add(("D" + (int)die).PadLeft(2) + (" #" + (i + 1) + ": ").PadLeft(6) + roll.ToString().PadRight(4) + ((int)die == roll ? "*" : ""));
                    }
                    menu.Message("Rolls",messageLines.ToArray());
                }
            }
        }
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

}
