using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Support.V7.Widget.Helper;
using Android.Views;
using Android.Widget;

namespace WordMemo.ViewHelpers
{
    public class RecyclerItemTouchHelper : ItemTouchHelper.SimpleCallback
    {
        public RecyclerItemTouchHelper(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public RecyclerItemTouchHelper(int dragDirs, int swipeDirs) : base(dragDirs, swipeDirs)
        {
        }

        public override bool OnMove(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder, RecyclerView.ViewHolder target)
        {
            throw new NotImplementedException();
        }

        public override void OnSwiped(RecyclerView.ViewHolder viewHolder, int direction)
        {
            throw new NotImplementedException();
        }
    }

    public interface IRecyclerItemTouchHelperListener
    {
        void OnSwiped(RecyclerView.ViewHolder viewHolder, int direction, int position);
    }
}