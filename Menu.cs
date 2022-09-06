namespace DnDTool
{
    internal class Menu
    {
        private List<MenuItem> Items = new List<MenuItem>();
        private MenuItem BackItem;
        private MenuItem? CurrentMenu;
        private MenuItem? SelectedItem;
        private bool Drawing = false;
        private bool Polling = false;
        private bool IsExiting { get; set; } = false;
        private Timer? DrawTimer;
        private Timer? KeyTimer;
        private long Count = 0;
        private MenuItem? CurrentDynamicMenu;
        private Dictionary<ConsoleKey, MenuItem> DynamicKeyMap;
        private int Width;
        public MenuItem RootItem;

        public Menu(string title, int width = 32)
        {
            Width = width;
            RootItem = new MenuItem("Root", null, this, null);
            BackItem = new MenuItem("Back", null, this, null);
            RootItem.ParentMenu = this;
            BackItem.ParentMenu = this;
            RootItem = new MenuItem(title, null, this, null);
            Items.Add(RootItem);
            DynamicKeyMap = new Dictionary<ConsoleKey, MenuItem>();

    }

        public static void Print(string str, ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.Write(str);
            Console.ResetColor();
        }

        public static void PrintLine(string str, ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine(str);
            Console.ResetColor();
        }

        private void TDraw(object? stateInfo)
        {
            Draw();
        }

        private void Draw()
        {
            if (Drawing) { return; }
            if (CurrentMenu != null)
            {
                Drawing = true;
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Width = Console.WindowWidth-2;
                string paddedTitle = CurrentMenu.Name.PadLeft((Width - CurrentMenu.Name.Length) / 2 + CurrentMenu.Name.Length).PadRight(Width);
                PrintLine("|"+ paddedTitle + "|", ConsoleColor.Black, ConsoleColor.Gray);
                string seperator = "";
                for (int i = 0; i < Width; i++)
                {
                    seperator += "-";
                }
                PrintLine("|"+seperator+"|", ConsoleColor.Black, ConsoleColor.Gray);
                int menuIndex = 1;
                foreach (MenuItem item in CurrentMenu.Children)
                {
                    if (CurrentMenu != null && CurrentDynamicMenu != CurrentMenu)
                    {
                        CurrentDynamicMenu = CurrentMenu;
                    }
                    switch (menuIndex)
                    {
                        case 1:
                            DynamicKeyMap = new Dictionary<ConsoleKey, MenuItem>();
                            DynamicKeyMap.Add(ConsoleKey.D1, item);
                            DynamicKeyMap.Add(ConsoleKey.NumPad1, item);
                            break;
                        case 2:
                            DynamicKeyMap.Add(ConsoleKey.D2, item);
                            DynamicKeyMap.Add(ConsoleKey.NumPad2, item);
                            break;
                        case 3:
                            DynamicKeyMap.Add(ConsoleKey.D3, item);
                            DynamicKeyMap.Add(ConsoleKey.NumPad3, item);
                            break;
                        case 4:
                            DynamicKeyMap.Add(ConsoleKey.D4, item);
                            DynamicKeyMap.Add(ConsoleKey.NumPad4, item);
                            break;
                        case 5:
                            DynamicKeyMap.Add(ConsoleKey.D5, item);
                            DynamicKeyMap.Add(ConsoleKey.NumPad5, item);
                            break;
                        case 6:
                            DynamicKeyMap.Add(ConsoleKey.D6, item);
                            DynamicKeyMap.Add(ConsoleKey.NumPad6, item);
                            break;
                        case 7:
                            DynamicKeyMap.Add(ConsoleKey.D7, item);
                            DynamicKeyMap.Add(ConsoleKey.NumPad7, item);
                            break;
                        case 8:
                            DynamicKeyMap.Add(ConsoleKey.D8, item);
                            DynamicKeyMap.Add(ConsoleKey.NumPad8, item);
                            break;
                        case 9:
                            DynamicKeyMap.Add(ConsoleKey.D9, item);
                            DynamicKeyMap.Add(ConsoleKey.NumPad9, item);
                            break;
                        case 10:
                            DynamicKeyMap.Add(ConsoleKey.D0, item);
                            DynamicKeyMap.Add(ConsoleKey.NumPad0, item);
                            break;
                    }
                    Print("|", ConsoleColor.Black, ConsoleColor.Gray);
                    if (this.SelectedItem == null)
                    {
                        item.Selected = true;
                    }
                    if (item.Selected)
                    {
                        this.SelectedItem = item;
                        Print(" " + menuIndex + " " + item.Name.PadRight(Width-menuIndex.ToString().Length-2), ConsoleColor.White, ConsoleColor.DarkGray);
                    } else
                    {
                        Print(" " + menuIndex + " " + item.Name.PadRight(Width - menuIndex.ToString().Length - 2));
                    }
                    PrintLine("|", ConsoleColor.Black, ConsoleColor.Gray);
                    menuIndex++;
                }
                if (CurrentMenu.Parent != null)
                {
                    if (menuIndex < 10)
                    {
                        switch (menuIndex)
                        {
                            case 1:
                                DynamicKeyMap = new Dictionary<ConsoleKey, MenuItem>();
                                DynamicKeyMap.Add(ConsoleKey.D1, BackItem);
                                DynamicKeyMap.Add(ConsoleKey.NumPad1, BackItem);
                                break;
                            case 2:
                                DynamicKeyMap.Add(ConsoleKey.D2, BackItem);
                                DynamicKeyMap.Add(ConsoleKey.NumPad2, BackItem);
                                break;
                            case 3:
                                DynamicKeyMap.Add(ConsoleKey.D3, BackItem);
                                DynamicKeyMap.Add(ConsoleKey.NumPad3, BackItem);
                                break;
                            case 4:
                                DynamicKeyMap.Add(ConsoleKey.D4, BackItem);
                                DynamicKeyMap.Add(ConsoleKey.NumPad4, BackItem);
                                break;
                            case 5:
                                DynamicKeyMap.Add(ConsoleKey.D5, BackItem);
                                DynamicKeyMap.Add(ConsoleKey.NumPad5, BackItem);
                                break;
                            case 6:
                                DynamicKeyMap.Add(ConsoleKey.D6, BackItem);
                                DynamicKeyMap.Add(ConsoleKey.NumPad6, BackItem);
                                break;
                            case 7:
                                DynamicKeyMap.Add(ConsoleKey.D7, BackItem);
                                DynamicKeyMap.Add(ConsoleKey.NumPad7, BackItem);
                                break;
                            case 8:
                                DynamicKeyMap.Add(ConsoleKey.D8, BackItem);
                                DynamicKeyMap.Add(ConsoleKey.NumPad8, BackItem);
                                break;
                            case 9:
                                DynamicKeyMap.Add(ConsoleKey.D9, BackItem);
                                DynamicKeyMap.Add(ConsoleKey.NumPad9, BackItem);
                                break;
                            case 10:
                                DynamicKeyMap.Add(ConsoleKey.D0, BackItem);
                                DynamicKeyMap.Add(ConsoleKey.NumPad0, BackItem);
                                break;
                        }
                    }
                    Print("|", ConsoleColor.Black, ConsoleColor.Gray);
                    if (BackItem.Selected)
                    {
                        Print(" " + menuIndex + " " + BackItem.Name.PadRight(Width - menuIndex.ToString().Length - 2), ConsoleColor.White, ConsoleColor.DarkGray);
                    } else
                    {
                        Print(" " + menuIndex + " " + BackItem.Name.PadRight(Width - menuIndex.ToString().Length - 2));
                    }
                    PrintLine("|", ConsoleColor.Black, ConsoleColor.Gray);
                }
                string bottomLine = "";
                for (int i = 0; i < Width; i++)
                {
                    bottomLine += "_";
                }
                PrintLine("|"+bottomLine+"|", ConsoleColor.Black, ConsoleColor.Gray);
                Drawing = false;
            }
        }

        public void ExecuteSelected()
        {
            if (SelectedItem != null)
            {
                if (SelectedItem.IsSubmenu)
                {
                    BackItem.Parent = SelectedItem.Parent;
                    CurrentMenu = SelectedItem;
                    SelectedItem.Selected = false;
                    SelectedItem = null;
                } else if (BackItem.Selected) {
                    Back();
                }
                else
                {
                    this.Pause();
                    SelectedItem.Execute();
                    if (!this.IsExiting) this.Resume();
                }
            }
        }

        public void SelectItem(MenuItem item)
        {
            if (SelectedItem != null && SelectedItem.Selected)
            {
                SelectedItem.Selected = false;
            }
            SelectedItem = item;
            //foreach ( MenuItem it in Items)
            //{
            //    if (it.Selected && it.Parent == item.Parent)
            //    {
            //        it.Selected = false;
            //    }
            //}
            item.Selected = true;
            Draw();
        }

        public void SelectAndExecute(MenuItem item)
        {
            SelectItem(item);
            ExecuteSelected();
        }

        public void Back()
        {
            if (CurrentMenu != null && CurrentMenu.Parent != null) CurrentMenu = CurrentMenu.Parent;
            BackItem.Selected = false;
            if (SelectedItem != null) SelectedItem.Selected = false;
            SelectedItem = null;
        }

        public void Previous()
        {
            if ( SelectedItem != null && SelectedItem.PreviousItem != null)
            {
                SelectItem(SelectedItem.PreviousItem);  
            }
        }

        public void Next()
        {
            if (SelectedItem != null && SelectedItem.NextItem != null)
            {
                SelectItem(SelectedItem.NextItem);
            } else if (SelectedItem != null 
                && SelectedItem != BackItem 
                && SelectedItem.NextItem == null 
                && CurrentMenu != RootItem){
                BackItem.PreviousItem = SelectedItem;
                SelectedItem.Selected = false;
                SelectItem(BackItem);
            }
        }

        public void Start()
        {
            CurrentMenu = RootItem;
            //SelectedItem = RootItem.Children[0];
            //SelectedItem.Selected = true;
            DrawTimer = new Timer(TDraw, null, 0, 50);
            KeyTimer = new Timer(KeyPoll, null, 0, 50);
            while (!IsExiting) { continue; }
        }

        private void KeyPoll(object? state)
        {
            if (Polling) { return; }
            if (Console.KeyAvailable)
            {
                Polling = true;
                while (Drawing) { continue; }
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        ExecuteSelected();
                        break;
                    case ConsoleKey.UpArrow:
                        Previous();
                        break;
                    case ConsoleKey.DownArrow:
                        Next();
                        break;
                    case ConsoleKey.Q:
                    case ConsoleKey.Escape:
                        Back();
                        break;
                }
                if (DynamicKeyMap.ContainsKey(key.Key))
                {
                    SelectAndExecute(DynamicKeyMap[key.Key]);
                }
                Polling = false;
            }
        }

        public void Stop()
        {
            Pause();
            IsExiting = true;
            while (Drawing) { continue; }
            Thread.Sleep(50);
            if (DrawTimer != null) DrawTimer.Dispose();
            if (KeyTimer != null) KeyTimer.Dispose();
            //CurrentMenu = null;
            //SelectedItem = null;
        }

        public void Pause()
        {
            if (this.DrawTimer != null) this.DrawTimer.Change(Timeout.Infinite, Timeout.Infinite);
            if (this.KeyTimer != null) this.KeyTimer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        public void Resume()
        {
            if (this.DrawTimer != null) this.DrawTimer.Change(0,100);
            if (this.KeyTimer != null) this.KeyTimer.Change(0, 100);
        }

        public void AddItem(MenuItem item)
        {
            if (item.Parent != null)
            {
                item.Parent.AddChild(item);
            } else
            {
                RootItem.AddChild(item);
            }
            if (item.ShortcutKey != null)
            {
                if (DynamicKeyMap.ContainsKey((ConsoleKey)item.ShortcutKey))
                {
                    throw new InvalidOperationException("Cannot assign shortcut key, already in use.");
                }
                else
                {
                    DynamicKeyMap.Add((ConsoleKey)item.ShortcutKey, item);
                }
            }
            Count++;
        }

        public MenuItem AddItem(string name, MenuItem? parent, Action? callBack, ConsoleKey? shortcutKey = null)
        {
            MenuItem item = new MenuItem(name, parent == null ? RootItem : parent, this, callBack);
            if (parent != null)
            {
                parent.AddChild(item);
            } else {
                RootItem.AddChild(item);
            }
            if (shortcutKey != null)
            {
                if (DynamicKeyMap.ContainsKey((ConsoleKey)shortcutKey))
                {
                    throw new InvalidOperationException("Cannot assign shortcut key, already in use.");
                } else
                {
                    DynamicKeyMap.Add((ConsoleKey)shortcutKey, item);
                }
            }
            Count++;
            return item;
        }

        public void RemoveItem(MenuItem item)
        {
            Items.Remove(item);
            Count--;
        }

        public static bool Prompt(string title)
        {
            bool retVal = false;
            Menu promptMenu = new Menu(title);
            promptMenu.AddItem("Yes", null, () => { retVal = true; promptMenu.Stop(); });
            promptMenu.AddItem("No", null, () => { retVal = false; promptMenu.Stop(); });
            promptMenu.Start();
            return retVal;
        }

        public static bool Prompt(string title, Dictionary<string, bool> items)
        {
            bool retVal = false;
            Menu promptMenu = new Menu(title);
            foreach (KeyValuePair<string, bool> item in items)
            {
                Type type = item.Value.GetType();
                promptMenu.AddItem(item.Key, null, () => { retVal = item.Value; promptMenu.Stop(); });
            }
            promptMenu.Start();
            return retVal;
        }

        public static string Prompt(string title, Dictionary<string, string> items)
        {
            string retVal = "";
            Menu promptMenu = new Menu(title);
            foreach (KeyValuePair<string, string> item in items)
            {
                Type type = item.Value.GetType();
                promptMenu.AddItem(item.Key, null, () => { retVal = item.Value; promptMenu.Stop(); });
            }
            promptMenu.Start();
            return retVal;
        }

        public static int Prompt(string title, Dictionary<string, int> items)
        {
            int retVal = -1;
            Menu promptMenu = new Menu(title);
            foreach (KeyValuePair<string, int> item in items)
            {
                Type type = item.Value.GetType();
                promptMenu.AddItem(item.Key, null, () => { retVal = item.Value; promptMenu.Stop(); });
            }
            promptMenu.Start();
            return retVal;
        }

        public static decimal Prompt(string title, Dictionary<string, decimal> items)
        {
            decimal retVal = -1;
            Menu promptMenu = new Menu(title);
            foreach (KeyValuePair<string, decimal> item in items)
            {
                Type type = item.Value.GetType();
                promptMenu.AddItem(item.Key, null, () => { retVal = item.Value; promptMenu.Stop(); });
            }
            promptMenu.Start();
            return retVal;
        }

        public string Input(string title)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Width = Console.WindowWidth - 2;
            string paddedTitle = title.PadLeft((Width - title.Length) / 2 + title.Length).PadRight(Width);
            PrintLine("|" + paddedTitle + "|", ConsoleColor.Black, ConsoleColor.Gray);
            string inputLine = "";
            string bottomLine = "";
            for (int i = 0; i < Width; i++)
            {
                bottomLine += "_";
                inputLine += " ";
            }
            Print("|", ConsoleColor.Black, ConsoleColor.Gray);
            Print(inputLine);
            PrintLine("|", ConsoleColor.Black, ConsoleColor.Gray);
            PrintLine("|" + bottomLine + "|", ConsoleColor.Black, ConsoleColor.Gray);
            Console.SetCursorPosition(2, 1);
            string? input = Console.ReadLine();
            if (input != null)
            {
                return input;
            }
            return "";
        }
        internal class MenuItem
        {
            public Menu ParentMenu;
            public string Name { get; set; }
            public bool IsSubmenu { get; set; }
            public MenuItem? PreviousItem;
            public MenuItem? NextItem;
            public MenuItem? Parent { get; set; }
            public List<MenuItem> Children = new();
            public bool Selected { get; set; }
            public Action? CallBack;
            public ConsoleKey? ShortcutKey { get; set; }
            public void Execute()
            {
                if (CallBack != null)
                {
                    CallBack();
                }
            }
            public void AddChild(MenuItem child)
            {
                if (!this.IsSubmenu) this.IsSubmenu = true;
                MenuItem newItem = child;
                if (Children.Count > 0)
                {
                    newItem.PreviousItem = Children.Last();
                    Children.Last().NextItem = newItem;
                }
                newItem.NextItem = null;
                Children.Add(newItem);
            }
            public MenuItem(string name, MenuItem? parent, Menu menu, Action? callBack)
            {
                this.Name = name;
                this.Parent = parent;
                this.Selected = false;
                this.CallBack = callBack;
                this.ParentMenu = menu;
            }
        }
    }
}
