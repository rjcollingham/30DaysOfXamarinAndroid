using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System;

namespace Project_02_CustomFont
{
	[Activity(Label = "Custom Font", Theme = "@android:style/Theme.Material",
	          MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		List<string> _sentences = new List<string>
		{
			"I wandered lonely as a cloud",
			"That floats on high o'er vales and hills,",
			"When all at once I saw a crowd,",
			"A host, of golden daffodils;",
			"Beside the lake, beneath the trees,",
			"Fluttering and dancing in the breeze."
		};

		List<string> _fonts = new List<string>
		{
			"PT-Sans-Web-Regular",
			"Raleway-Regular",
			"Ubuntu-Regular",
			"BebasNeueRegular",
			"Cabin-Regular",
			"Lato-Regular",
			"Montserrat-Regular",
			"OpenSans-Regular",
		};

		ListView lvSentences;
		FontListAdapter flaSentences;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			Button btnChange = FindViewById<Button>(Resource.Id.btnChange);
		 	lvSentences = FindViewById<ListView>(Resource.Id.lvSentences);

			flaSentences = new FontListAdapter(this, _sentences.ToArray(), _fonts.ToArray());
			lvSentences.Adapter = flaSentences;

			btnChange.Click += Change_Font;
			this.Title = _fonts[0];
		}

		void Change_Font(object sender, EventArgs e)
		{
			int ix = flaSentences.ChangeFont();
			this.Title = _fonts[ix];
			flaSentences.NotifyDataSetChanged();
		}
	}
}


