using System.Windows;
using System.Windows.Media;
namespace D2R.Helpers;

public class FindAncestor
{
    public static T? FindParent<T>(DependencyObject child) where T : DependencyObject
    {
        DependencyObject parentObject = VisualTreeHelper.GetParent(child);

        if (parentObject == null) return null;

        if (parentObject is T parent)
            return parent;
        else
            return FindParent<T>(parentObject);
    }
}