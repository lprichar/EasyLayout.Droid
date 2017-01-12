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
        private TextView _upperLeft;
        private TextView _lowerLeft;
        private TextView _lowerRight;
        private TextView _topTop;

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
            _topTop = _relativeLayout.AddTextView(this, "this.GetCenterX() == _layoutView.GetCenterX()", Colors.Gold, Colors.White);
            _center = _relativeLayout.AddTextView(this, "this.GetCenter() == \nrelativeLayout.GetCenter()", Colors.DarkGrey, Colors.White);
            _top = _relativeLayout.AddTextView(this, "this.Bottom == \n_center.Top - 20", Colors.Yellow, Colors.DarkGrey);
            _right = _relativeLayout.AddTextView(this, "this.Left == \n_center.Right + 20", Colors.Red, Colors.White);
            _left = _relativeLayout.AddTextView(this, "this.Right == \n_center.Left - 20", Colors.LightBlue, Colors.White);
            _bottom = _relativeLayout.AddTextView(this, "this.Top == \n_center.Bottom + 20", Colors.BluePurple, Colors.White);
            _upperRight = _relativeLayout.AddTextView(this, "this.Baseline ==\n_top.Baseline", Colors.Orange, Colors.White);
            _upperLeft = _relativeLayout.AddTextView(this, "this.Height == 40 &&\nthis.Width == 140", Colors.Green, Colors.White);
            _lowerLeft = _relativeLayout.AddTextView(this, "this.Right == _left.Right &&\nthis.Bottom == _bottom.Bottom", Colors.DarkBlue, Colors.White);
            _lowerRight = _relativeLayout.AddTextView(this, "this.Top == _bottom.Top &&\nthis.Left == _right.Left", Colors.Purple, Colors.White);
        }

        private void ConstrainLayout()
        {
            _relativeLayout.ConstrainLayout(() =>
                _center.GetCenter() == _relativeLayout.GetCenter() &&

                _topTop.GetCenterX() == _relativeLayout.GetCenterX() &&
                _topTop.Top == _relativeLayout.Top + 20 &&

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
                _upperRight.Baseline == _top.Baseline &&
                _upperRight.Height == 45 &&
                _upperRight.Width == 140 &&

                _upperLeft.Right == _center.Left - 20 &&
                _upperLeft.Bottom == _center.Top - 20 &&
                _upperLeft.Height == 40 &&
                _upperLeft.Width == 140 &&

                _lowerLeft.Right == _left.Right &&
                _lowerLeft.Bottom == _bottom.Bottom &&

                _lowerRight.Top == _bottom.Top &&
                _lowerRight.Left == _right.Left
                );
        }
    }
}

