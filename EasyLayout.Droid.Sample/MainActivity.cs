using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Widget;
using Android.OS;
using Android.Views;

namespace EasyLayout.Droid.Sample
{
    [Activity(Label = "EasyLayout.Droid.Sample", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        private RelativeLayout _relativeLayout;
        private TextView _center;
        private TextView _top;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            AddViews();
            ConstrainLayout();

            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
            SetContentView(_relativeLayout);
        }

        private void AddViews()
        {
            _relativeLayout = ViewUtils.AddRelativeLayout(this);
            _center = _relativeLayout.AddTextView(this, "_center.GetCenter() == \nrelativeLayout.GetCenter()", Colors.DarkGrey, Colors.White);
            _top = _relativeLayout.AddTextView(this, "_top.Bottom == \n_center.Top + 20", Colors.Yellow, Colors.Black);
        }

        private void ConstrainLayout()
        {
            _relativeLayout.ConstrainLayout(() =>
                _center.GetCenter() == _relativeLayout.GetCenter() &&

                _top.Left == _center.Left &&
                _top.Right == _center.Right &&
                _top.Bottom == _center.Top + 20
                );
        }
    }

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
            return textView;
        }
    }

    public static class Colors
    {
        public static readonly Color White = Color.Rgb(255, 255, 255);
        public static readonly Color Red = Color.Rgb(227, 35, 34);
        public static readonly Color Orange = Color.Rgb(241, 142, 28);
        public static readonly Color Yellow = Color.Rgb(244, 229, 0);
        public static readonly Color Green = Color.Rgb(0, 142, 91);
        public static readonly Color Blue = Color.Rgb(42, 113, 176);
        public static readonly Color Purple = Color.Rgb(109, 57, 139);
        public static readonly Color DarkGrey = Color.Rgb(20, 20, 20);
        public static readonly Color Black = Color.Rgb(0, 0, 0);
    }
}

