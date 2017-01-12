using System;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;

namespace EasyLayout.Droid.Sample
{
    public static class ViewUtils
    {
        public static RelativeLayout AddRelativeLayout(Context context)
        {
            var relativeLayout = new RelativeLayout(context)
            {
                LayoutParameters = new RelativeLayout.LayoutParams(
                    ViewGroup.LayoutParams.MatchParent,
                    ViewGroup.LayoutParams.MatchParent)
            };
            return relativeLayout;
        }

        public static T Add<T>(this ViewGroup parent, Context context) where T : View
        {
            var child = (T)Activator.CreateInstance(typeof(T), context);
            parent.AddView(child);
            return child;
        }

        public static TextView AddTextView(this ViewGroup parent, Context context, string text, Color background, Color textColor)
        {
            var textView = parent.Add<TextView>(context);
            textView.Text = text;
            textView.SetBackgroundColor(background);
            textView.SetTextColor(textColor);
            textView.Gravity = GravityFlags.CenterHorizontal;
            return textView;
        }
    }
}