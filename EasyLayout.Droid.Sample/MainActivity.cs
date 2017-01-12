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
        private TextView _right;
        private TextView _left;
        private TextView _bottom;
        private TextView _upperRight;

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
            _right = _relativeLayout.AddTextView(this, "this.Left == \n_center.Right + 20", Colors.Red, Colors.White);
            _left = _relativeLayout.AddTextView(this, "this.Right == \n_center.Left - 20", Colors.Blue, Colors.White);
            _bottom = _relativeLayout.AddTextView(this, "this.Top == \n_center.Bottom + 20", Colors.Purple, Colors.White);
            _upperRight = _relativeLayout.AddTextView(this, "this.Height == 40 &&\nthis.Width == 140", Colors.Orange, Colors.White);
        }

        private void ConstrainLayout()
        {
            _relativeLayout.ConstrainLayout(() =>
                _center.GetCenter() == _relativeLayout.GetCenter() &&

                _top.Left == _center.Left &&
                _top.Right == _center.Right &&
                _top.Bottom == _center.Top - 20 &&

                _right.Left == _center.Right + 20 &&
                _right.Top == _center.Top &&
                _right.Bottom == _center.Bottom &&

                _left.Right == _center.Left - 20 &&
                _left.Top == _center.Top &&
                _left.Bottom == _center.Bottom &&

                _bottom.Left == _center.Left &&
                _bottom.Right == _center.Right &&
                _bottom.Top == _center.Bottom + 20 &&

                _upperRight.Left == _center.Right + 20 &&
                _upperRight.Bottom == _center.Top - 20 &&
                _upperRight.Height == 40 &&
                _upperRight.Width == 140
                );
        }
    }
}

