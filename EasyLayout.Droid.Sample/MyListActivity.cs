using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace EasyLayout.Droid.Sample
{
    [Activity]
    public class MyListActivity : Activity
    {
        private RelativeLayout _relativeLayout;
        private ListView _listView;
        private MyAdapter _adapter;

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
            _listView = _relativeLayout.Add<ListView>();
            List<Product> items = GetItems();
            _adapter = new MyAdapter(this, items);
            _listView.Adapter = _adapter;
        }

        private void ConstrainLayout()
        {
            _relativeLayout.ConstrainLayout(() =>
                _listView.Top == _relativeLayout.Top &&
                _listView.Right == _relativeLayout.Right &&
                _listView.Left == _relativeLayout.Left &&
                _listView.Bottom == _relativeLayout.Bottom
                );
        }

        private List<Product> GetItems()
        {
            var list = new List<Product>();
            for (int i = 0; i < 100; i++)
            {
                var item = new Product
                {
                    Id = i,
                    Title = $"Item #{i}",
                    Amount = 500.99M + i * .01M
                };
                list.Add(item);
            }
            return list;
        }

    }

    internal class MyAdapter : BaseAdapter<Product>
    {
        private readonly Context _context;
        private readonly List<Product> _items;

        public MyAdapter(Context context, List<Product> items)
        {
            _context = context;
            _items = items;
        }

        public override long GetItemId(int position) => _items[position].Id;

        public override int Count => _items.Count;

        public override Product this[int position] => _items[position];

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                convertView = new ProductRowView(_context);
            }
            var product = _items[position];
            ((ProductRowView) convertView).Update(product);
            return convertView;
        }

    }

    public class ProductRowView : RelativeLayout
    {
        private TextView _titleText;
        private TextView _dollarText;
        private TextView _amountText;

        public ProductRowView(Context context) : base(context)
        {
            AddViews();
            ConstrainLayout(this);
        }

        private void AddViews()
        {
            _titleText = this.Add<TextView>();
            _dollarText = AddDollarText(this);
            _amountText = this.Add<TextView>();
        }

        private static TextView AddDollarText(ViewGroup parent)
        {
            var dollarText = parent.Add<TextView>();
            dollarText.Text = "$";
            dollarText.TextSize = 8;
            return dollarText;
        }

        private void ConstrainLayout(RelativeLayout relativeLayout)
        {
            relativeLayout.ConstrainLayout(() =>
                _titleText.Left == relativeLayout.Left
                && _titleText.Top == relativeLayout.Top
                && _titleText.Bottom == relativeLayout.Bottom

                && _amountText.Right == relativeLayout.Right
                && _amountText.Top == relativeLayout.Top
                && _amountText.Bottom == relativeLayout.Bottom

                && _dollarText.Right == _amountText.Left
                && _dollarText.Top == _amountText.Top
            );
        }

        public void Update(Product product)
        {
            _titleText.Text = product.Title;
            _amountText.Text = product.Amount.ToString("0.00");
        }
    }

    public class Product
    {
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public int Id { get; set; }
    }
}