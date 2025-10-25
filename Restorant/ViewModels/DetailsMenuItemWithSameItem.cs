using Restorant.Models;

namespace Restorant.ViewModels
{
    public class DetailsMenuItemWithSameItem
    {
        public List<MenuItem> SameItems { get; set; } = new List<MenuItem>();
        public  MenuItemWithCategoryModelView MenuItem { get; set;} = new MenuItemWithCategoryModelView();

    }
}
