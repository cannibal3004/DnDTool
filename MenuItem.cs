namespace DnDTool
{
    internal class MenuItem {
        public Menu ParentMenu;
        public string Name { get; set; }
        public bool IsSubmenu { get; set; }
        public MenuItem? PreviousItem;
        public MenuItem? NextItem;
        public MenuItem? Parent { get; set; }
        public List<MenuItem> Children = new List<MenuItem> ();
        public bool Selected { get; set; }
        public Func<object>? CallBack;
        public object Execute()
        {
            if (CallBack != null)
            {
                object retVal = CallBack();
                return retVal;
            }
            return false;
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
        public MenuItem(string name, MenuItem? parent, Menu menu, Func<object>? callBack)
        {
            this.Name = name;
            this.Parent = parent;
            this.Selected = false;
            this.CallBack = callBack;
            this.ParentMenu = menu;
        }
    }
}
