using System;
using Android.App;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;

namespace Project_02_CustomFont
{
	public class FontListAdapter : BaseAdapter<string>
	{
		string[] fonts;
		string[] items;
		int FontIndex = 0;
		Activity context;

		public FontListAdapter(Activity context, string[] items, string[] fonts) : base()
		{
			this.context = context;
			this.items = items;
			this.fonts = fonts;
		}

		public int ChangeFont()
		{
			FontIndex = (FontIndex + 1) % fonts.Length;
			return FontIndex;
		}

		public override string this[int position]
		{
			get
			{
				return items[position];
			}
		}

		public override int Count
		{
			get
			{
				return items.Length;
			}
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView;
			if (view == null)
			{
				view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
			}

			var cell = view.FindViewById<TextView>(Android.Resource.Id.Text1);
			cell.Text = items[position];
			cell.SetBackgroundColor(Color.Black);
			cell.SetTextColor(Color.White);
			cell.SetTypeface(Typeface.CreateFromAsset(context.Assets, fonts[FontIndex] + ".ttf"), TypefaceStyle.Normal);

			return view;
		}
	}
}

