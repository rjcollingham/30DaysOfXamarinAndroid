using Android.App;
using Android.Widget;
using Android.OS;
using System.Timers;
using System;
using Android.Graphics;
using Android.Content;

namespace Project_01_SimpleStopWatch
{
	[Activity(Theme = "@android:style/Theme.Material.Light", Label = "Project_01_SimpleStopWatch", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		Button btnReset;
		Button btnPlay;
		Button btnPause;
		TextView lblTime;
		Timer timer;

		double Counter = 0.0;

		protected override void OnCreate(Bundle savedInstanceState)
		{

			Typeface font = Typeface.CreateFromAsset(Application.Context.Assets, "fontawesome.ttf");

			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Main);
			timer = new Timer(100);
			timer.Elapsed += Time_Trigger;

			btnReset = FindViewById<Button>(Resource.Id.btnReset);
			btnPlay = FindViewById<Button>(Resource.Id.btnPlay);
			btnPause = FindViewById<Button>(Resource.Id.btnPause);
			lblTime = FindViewById<TextView>(Resource.Id.lblTime);

			btnPlay.SetTypeface(font, TypefaceStyle.Normal);
			btnPause.SetTypeface(font, TypefaceStyle.Normal);

			btnReset.Enabled = false;
			btnPause.Enabled = false;
			UpdateDisplay();

			btnReset.Click += Reset_Clicked;
			btnPause.Click += Pause_Clicked;
			btnPlay.Click += Play_Clicked;
		}

		void Pause_Clicked(object sender, EventArgs e)
		{
			btnReset.Enabled = true;
			btnPlay.Enabled = true;
			btnPause.Enabled = false;
			timer.Stop();
		}

		void Play_Clicked(object sender, EventArgs e)
		{
			btnPlay.Enabled = false;
			btnPause.Enabled = true;
			btnReset.Enabled = false;
			timer.Start();
		}

		void Reset_Clicked(object sender, EventArgs e)
		{
			btnReset.Enabled = false;
			btnPlay.Enabled = true;
			btnPause.Enabled = false;
			Counter = 0.0;
			UpdateDisplay();
		}

		void Time_Trigger(object sender, ElapsedEventArgs e)
		{
			UpdateTimer();
		}

		private void UpdateDisplay()
		{
			RunOnUiThread(() =>
			{
				lblTime.Text = Counter.ToString("F1");
			});
		}

		private void UpdateTimer()
		{
			Counter += 0.1;
			UpdateDisplay();
		}
	}
}


