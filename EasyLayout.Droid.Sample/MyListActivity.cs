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
            List<Item> items = GetItems();
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

        private List<Item> GetItems()
        {
            var list = new List<Item>();
            for (int i = 0; i < 100; i++)
            {
                var item = new Item
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

    internal class MyAdapter : BaseAdapter<Item>
    {
        private readonly Context _context;
        private readonly List<Item> _items;

        public MyAdapter(Context context, List<Item> items)
        {
            _context = context;
            _items = items;
        }

        public override long GetItemId(int position) => _items[position].Id;

        public override int Count => _items.Count;

        public override Item this[int position] => _items[position];

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var textView = new TextView(_context)
            {
                Text = _items[position].Title
            };
            return textView;
        }

    }

    public class Item
    {
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public int Id { get; set; }
    }
}