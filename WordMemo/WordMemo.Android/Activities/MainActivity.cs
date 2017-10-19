using System.Collections.Generic;
using System.Linq;
using Android;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Support.V7.Widget;
using WordMemo.DataAccess.Contracts;
using WordMemo.ViewModels;
using WordMemo.ViewAdapters;

namespace WordMemo
{
	[Activity(Label = "WordMemo", MainLauncher = true, Icon = "@mipmap/ic_launcher")]
	public class MainActivity : AppCompatActivity
	{
        private DrawerLayout _mDrawerLayout;
        private NavigationView _mNavigationView;
        private RecyclerView _mRecyclerView;
        private RecyclerView.LayoutManager _mLayoutManager;
        private Word[] _mWords;
        private WordsAdapter _mWordsAdapter;
	    private IWordManager _wordManager;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

            _wordManager = new WordManager();
            _wordManager.Init();
		    _mWords = _wordManager.GetAll().ToArray();
            _mWordsAdapter = new WordsAdapter(_mWords);
            
			SetContentView(Resource.Layout.Main);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu_white_36dp);
		    SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            _mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.main_drawer_layout);
            _mNavigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            _mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recycler_view_main_list);
            _mLayoutManager = new LinearLayoutManager(this);
            
            _mRecyclerView.SetLayoutManager(_mLayoutManager);
            _mRecyclerView.SetAdapter(_mWordsAdapter);

            _mNavigationView.NavigationItemSelected += (sender, e) =>
            {
                e.MenuItem.SetChecked(true);
                _mDrawerLayout.CloseDrawers();
            };

		    var fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
		    fab.Click += (sender, args) =>
		    {
		        Toast.MakeText(this.BaseContext, "Add new word button clicked!", ToastLength.Short).Show();
		    };

		}

        // Capture and handle click event on FloatingActionButton
        // If keyboard is being shown hide the FloatingActionButton

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch(item.ItemId)
            {
                case Android.Resource.Id.Home:
                    _mDrawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
                    return true;
            }

            return base.OnOptionsItemSelected(item);
        }

    }
}

