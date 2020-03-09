namespace ForceOfWillCube.Views
{
    using System;

    public class DrawerPageMasterMenuItem
    {
        public DrawerPageMasterMenuItem()
        {
            this.TargetType = typeof(DrawerPageMasterMenuItem);
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public Type TargetType { get; set; }

        public bool IsVisible { get; set; }
    }
}