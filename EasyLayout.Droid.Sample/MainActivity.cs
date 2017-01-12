using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Views;

namespace EasyLayout.Droid.Sample
{
    [Activity(Label = "EasyLayout.Droid.Sample", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private RelativeLayout _relativeLayout;
        private TextView _centerText;

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
            _centerText = _relativeLayout.Add<TextView>(this);
            _centerText.Text = "Hello World";
        }

        private void ConstrainLayout()
        {
            _relativeLayout.ConstrainLayout(() =>
                _centerText.GetCenter() == _relativeLayout.GetCenter()
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
    }
}

