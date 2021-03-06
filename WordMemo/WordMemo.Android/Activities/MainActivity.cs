﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Support.V7.Widget.Helper;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using WordMemo.Logic;
using WordMemo.Managers;
using WordMemo.Utils;
using WordMemo.ViewAdapters;
using WordMemo.ViewHelpers;
using WordMemo.ViewModels;

namespace WordMemo.Activities
{
	[Activity(Label = "WordMemo", MainLauncher = true, Icon = "@mipmap/ic_launcher")]
	public class MainActivity : AppCompatActivity, IRecyclerItemTouchHelperListener
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
                var menuItem = e.MenuItem;
                menuItem.SetChecked(true);

                switch (menuItem.ItemId)
                {
                    case Resource.Id.nav_import_words:
                        Intent intent = new Intent(Intent.ActionOpenDocument);
                        intent.AddCategory(Intent.CategoryOpenable);
                        intent.SetType("text/*");
                        intent.SetFlags(ActivityFlags.GrantReadUriPermission);
                        StartActivityForResult(intent, 1);
                        break;
                    default:
                        Toast.MakeText(Application.Context, "Something Wrong", ToastLength.Long).Show();
                        break;
                }

                _mDrawerLayout.CloseDrawers();
            };		 

            Window.SetSoftInputMode(SoftInput.AdjustPan);
		}

	    protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
	    {
	        base.OnActivityResult(requestCode, resultCode, data);

	        if (resultCode == Result.Ok && data != null && requestCode == 1)
	        {
                FileHelper fh = new FileHelper();

                ContentResolver cr = this.ApplicationContext.ContentResolver;

                WordLogic.ImportFromCsv(fh.ReadFileContent(cr.OpenInputStream(data.Data)));

                _mRecyclerView.SmoothScrollToPosition(bottomPosition);
	            //Toast.MakeText(Application.Context, "The CSV file content is: " + fh.ReadFileContent(cr.OpenInputStream(data.Data)), ToastLength.Long).Show();
	        }
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

            _mWordsAdapter = new WordsAdapter(this, _mWords);
            
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

            _mRecyclerView.SetItemAnimator(new DefaultItemAnimator());

            ItemTouchHelper.Callback callback = new RecyclerItemTouchHelper(this);
            ItemTouchHelper itemTouchHelper = new ItemTouchHelper(callback);
            itemTouchHelper.AttachToRecyclerView(_mRecyclerView);

            _mRecyclerView.ClearFocus();
            HideKeyboard();
        }

	    private void HideKeyboard()
	    {
            InputMethodManager inputMethod = (InputMethodManager)this.GetSystemService(Context.InputMethodService);
            inputMethod.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.NotAlways);
        }

        public void OnSwiped(RecyclerView.ViewHolder viewHolder, int direction, int position)
        {
            _mWordsAdapter.NotifyItemRemoved(position);
            _mWordsAdapter.DeleteWord(position);           
        }
    }
}

