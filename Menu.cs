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
        private object ReturnValue = true;
        private bool IsExiting { get; set; } = false;
        private Timer? DrawTimer;
        private Timer? KeyTimer;
        private long Count = 0;
        private MenuItem CurrentDynamicMenu;
        private Dictionary<ConsoleKey, MenuItem> DynamicKeyMap;

        public MenuItem RootItem;
        public Menu(string title, int width = 32)
        {
            RootItem = new MenuItem("Root", null, this, null);
            BackItem = new MenuItem("Back", null, this, null);
            RootItem.ParentMenu = this;
            BackItem.ParentMenu = this;
            RootItem = new MenuItem(title, null, this, null);
            Items.Add(RootItem);
    }
        public void Print(string str, ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.Write(str);
            Console.ResetColor();
        }

        public void PrintLine(string str, ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
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
                string paddedTitle = CurrentMenu.Name.PadLeft((32 - CurrentMenu.Name.Length) / 2 + CurrentMenu.Name.Length).PadRight(32);
                PrintLine("|"+ paddedTitle + "|", ConsoleColor.Black, ConsoleColor.Gray);
                PrintLine("|--------------------------------|", ConsoleColor.Black, ConsoleColor.Gray);
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
                            break;
                        case 2:
                            DynamicKeyMap.Add(ConsoleKey.D2, item);
                            break;
                        case 3:
                            DynamicKeyMap.Add(ConsoleKey.D3, item);
                            break;
                        case 4:
                            DynamicKeyMap.Add(ConsoleKey.D4, item);
                            break;
                        case 5:
                            DynamicKeyMap.Add(ConsoleKey.D5, item);
                            break;
                        case 6:
                            DynamicKeyMap.Add(ConsoleKey.D6, item);
                            break;
                        case 7:
                            DynamicKeyMap.Add(ConsoleKey.D7, item);
                            break;
                        case 8:
                            DynamicKeyMap.Add(ConsoleKey.D8, item);
                            break;
                        case 9:
                            DynamicKeyMap.Add(ConsoleKey.D9, item);
                            break;
                        case 10:
                            DynamicKeyMap.Add(ConsoleKey.D0, item);
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
                        Print(" " + menuIndex + " " + item.Name.PadRight(32-menuIndex.ToString().Length-2), ConsoleColor.White, ConsoleColor.DarkGray);
                    } else
                    {
                        Print(" " + menuIndex + " " + item.Name.PadRight(32 - menuIndex.ToString().Length - 2));
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
                                break;
                            case 2:
                                DynamicKeyMap.Add(ConsoleKey.D2, BackItem);
                                break;
                            case 3:
                                DynamicKeyMap.Add(ConsoleKey.D3, BackItem);
                                break;
                            case 4:
                                DynamicKeyMap.Add(ConsoleKey.D4, BackItem);
                                break;
                            case 5:
                                DynamicKeyMap.Add(ConsoleKey.D5, BackItem);
                                break;
                            case 6:
                                DynamicKeyMap.Add(ConsoleKey.D6, BackItem);
                                break;
                            case 7:
                                DynamicKeyMap.Add(ConsoleKey.D7, BackItem);
                                break;
                            case 8:
                                DynamicKeyMap.Add(ConsoleKey.D8, BackItem);
                                break;
                            case 9:
                                DynamicKeyMap.Add(ConsoleKey.D9, BackItem);
                                break;
                            case 10:
                                DynamicKeyMap.Add(ConsoleKey.D0, BackItem);
                                break;
                        }
                    }
                    Print("|", ConsoleColor.Black, ConsoleColor.Gray);
                    if (BackItem.Selected)
                    {
                        Print(" " + menuIndex + " " + BackItem.Name.PadRight(32 - menuIndex.ToString().Length - 2), ConsoleColor.White, ConsoleColor.DarkGray);
                    } else
                    {
                        Print(" " + menuIndex + " " + BackItem.Name.PadRight(32 - menuIndex.ToString().Length - 2));
                    }
                    PrintLine("|", ConsoleColor.Black, ConsoleColor.Gray);
                }
                PrintLine("|________________________________|", ConsoleColor.Black, ConsoleColor.Gray);
                Drawing = false;
            }
        }

        public object ExecuteSelected()
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
                    object retVal = SelectedItem.Execute();
                    ReturnValue = retVal;
                    if (!this.IsExiting) this.Resume();
                    return retVal;
                }
            }
            return false;
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

        public object SelectAndExecute(MenuItem item)
        {
            SelectItem(item);
            return ExecuteSelected();
        }

        public void Back()
        {
            if (CurrentMenu != null && CurrentMenu.Parent != null) CurrentMenu = CurrentMenu.Parent;
            BackItem.Selected = false;
            if (SelectedItem != null) SelectedItem.Selected = false;
            SelectedItem = null;
        }

        public void Up()
        {
            if ( SelectedItem != null && SelectedItem.PreviousItem != null)
            {
                SelectItem(SelectedItem.PreviousItem);  
            }
        }

        public void Down()
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
                        Up();
                        break;
                    case ConsoleKey.DownArrow:
                        Down();
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

        public MenuItem AddItem(string name, MenuItem? parent, Func<object>? callBack, ConsoleKey? shortcutKey = null)
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
    }
}
