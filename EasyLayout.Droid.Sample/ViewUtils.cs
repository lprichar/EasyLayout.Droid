using System;
using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace EasyLayout.Droid.Sample
{
    public static class ViewUtils
    {
        public static int DpToPx(Context context, float dp)
        {
            DisplayMetrics displayMetrics = context.Resources.DisplayMetrics;
            return (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, dp, displayMetrics);
        }

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

        public static T Add<T>(this ViewGroup parent) where T : View
        {
            var child = (T)Activator.CreateInstance(typeof(T), parent.Context);
            parent.AddView(child);
            return child;
        }

        public static Button AddButton(this ViewGroup parent, string text)
        {
            var button = parent.Add<Button>();
            button.Text = text;
            return button;
        }

        public static TextView AddTextView(this ViewGroup parent, string text, Color background, Color textColor)
        {
            var textView = parent.Add<TextView>();
            textView.Text = text;
            textView.SetBackgroundColor(background);
            textView.SetTextColor(textColor);
            textView.Gravity = GravityFlags.CenterHorizontal;
            return textView;
        }
    }
}