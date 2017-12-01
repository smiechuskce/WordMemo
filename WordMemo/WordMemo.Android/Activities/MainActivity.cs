using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Support.V7.Widget;
using Android.Views.InputMethods;
using WordMemo.DataAccess.Contracts;
using WordMemo.DataAccess.Logic;
using WordMemo.DataAccess.Managers;
using WordMemo.Utils;
using WordMemo.ViewModels;
using WordMemo.ViewAdapters;
using WordMemo.ViewHolders;

namespace WordMemo
{
	[Activity(Label = "WordMemo", MainLauncher = true, Icon = "@mipmap/ic_launcher")]
	public class MainActivity : AppCompatActivity
    { 
        private DrawerLayout _mDrawerLayout;
        private NavigationView _mNavigationView;
        private RecyclerView _mRecyclerView;
        private RecyclerView.LayoutManager _mLayoutManager;
        private List<Word> _mWords;
        private WordsAdapter _mWordsAdapter;

	    private int bottomPosition = 0;

        public WordLogic WordLogic { get; private set; }

        protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

            Init();

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
            

            _mNavigationView.NavigationItemSelected += (sender, e) =>
            {
                e.MenuItem.SetChecked(true);
                _mDrawerLayout.CloseDrawers();
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

	    private async Task Init()
	    {
            WordLogic = new WordLogic(new PersistentWordManager<Word>(new FileHelper().GetLocalFilePath("WordMemo.db")));
            await WordLogic.UpdateWordList();
            _mWords = WordLogic.WordList;

            _mWordsAdapter = new WordsAdapter(this, ref _mWords);
            
            _mRecyclerView.SetAdapter(_mWordsAdapter);

	        _mRecyclerView.LayoutChange += (sender, args) =>
	        {
	            bottomPosition = args.Bottom;
	        };

            var fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += (sender, args) =>
            {
                Word newWord = new Word();
                _mWordsAdapter.AddWord(newWord);
                _mWordsAdapter.NotifyItemInserted(_mWordsAdapter.ItemCount - 1);

                HideKeyboard();

                _mRecyclerView.SmoothScrollToPosition(bottomPosition);

            };

	        _mRecyclerView.ChildViewAttachedToWindow += (sender, args) =>
	        {
	            View lastRow = _mRecyclerView.GetLayoutManager().GetChildAt(_mWordsAdapter.ItemCount - 1);

	            if (lastRow != null && args.View == lastRow)
	                lastRow.RequestFocus();
	        };

            _mRecyclerView.ClearFocus();
            HideKeyboard();
        }

	    private void HideKeyboard()
	    {
            InputMethodManager inputMethod = (InputMethodManager)this.GetSystemService(Context.InputMethodService);
            inputMethod.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.NotAlways);
        }
    }
}

