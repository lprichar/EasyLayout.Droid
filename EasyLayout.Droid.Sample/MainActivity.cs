using Android.App;
using Android.Widget;
using Android.OS;

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
            SetContentView(_relativeLayout);
        }

        private void AddViews()
        {
            _relativeLayout = ViewUtils.AddRelativeLayout(this);
            _center = _relativeLayout.AddTextView(this, "this.GetCenter() == \nrelativeLayout.GetCenter()", Colors.DarkGrey, Colors.White);
            _top = _relativeLayout.AddTextView(this, "this.Bottom == \n_center.Top - 20", Colors.Yellow, Colors.Black);
        }

        private void ConstrainLayout()
        {
            _relativeLayout.ConstrainLayout(() =>
                _center.GetCenter() == _relativeLayout.GetCenter() &&

                _top.Left == _center.Left &&
                _top.Right == _center.Right &&
                _top.Bottom == _center.Top - 20
                );
        }
    }
}

