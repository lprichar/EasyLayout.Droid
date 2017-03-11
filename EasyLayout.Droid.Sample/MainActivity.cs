using System;
using Android.App;
using Android.Widget;
using Android.OS;
using EasyLayout.Droid.Sample.Views;

namespace EasyLayout.Droid.Sample
{
    [Activity(Label = "EasyLayout.Droid.Sample", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private RelativeLayout _relativeLayout;
        private Button _layoutExampleButton;
        private Button _listExampleButton;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            AddViews();
            ConstrainLayout();
            SetContentView(_relativeLayout);
        }

        protected override void OnStart()
        {
            base.OnStart();
            SubscribeEvents();
        }

        protected override void OnStop()
        {
            base.OnStop();
            UnsubscribeEvents();
        }

        private void SubscribeEvents()
        {
            _layoutExampleButton.Click += LayoutExampleButtonOnClick;
            _listExampleButton.Click += ListExampleButtonOnClick;
        }

        private void UnsubscribeEvents()
        {
            _layoutExampleButton.Click -= LayoutExampleButtonOnClick;
        }

        private void ListExampleButtonOnClick(object sender, EventArgs e)
        {
            StartActivity(typeof(ViewProductsActivity));
        }

        private void LayoutExampleButtonOnClick(object sender, EventArgs eventArgs)
        {
            StartActivity(typeof(LayoutExampleActivity));
        }

        private void AddViews()
        {
            _relativeLayout = ViewUtils.AddRelativeLayout(this);
            _layoutExampleButton = _relativeLayout.AddButton("Layout Examples");
            _listExampleButton = _relativeLayout.AddButton("List Example");
        }

        private void ConstrainLayout()
        {
            _relativeLayout.ConstrainLayout(() =>
                _layoutExampleButton.Top == _relativeLayout.Top + 20
                && _layoutExampleButton.Left == _relativeLayout.Left + 20
                && _layoutExampleButton.Right == _relativeLayout.Right - 20
                
                && _listExampleButton.Top == _layoutExampleButton.Bottom + 20
                && _listExampleButton.Left == _layoutExampleButton.Left
                && _listExampleButton.Right == _layoutExampleButton.Right
                );
        }
    }
}

