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
using WordMemo.ViewAdapters;
using WordMemo.ViewHolders;

namespace WordMemo.ViewHelpers
{
    public class RecyclerItemTouchHelper : ItemTouchHelper.Callback
    {
        private IRecyclerItemTouchHelperListener _listener;

        public RecyclerItemTouchHelper(IRecyclerItemTouchHelperListener listener)
        {
            _listener = listener;
        }

        public override int GetMovementFlags(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder)
        {
            return MakeMovementFlags(0, ItemTouchHelper.Left);
        }

        public override bool OnMove(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder, RecyclerView.ViewHolder target)
        {
            return false;
        }

        public override void OnSwiped(RecyclerView.ViewHolder viewHolder, int direction)
        {
            _listener.OnSwiped(viewHolder, direction, viewHolder.AdapterPosition);
        }
    }

    public interface IRecyclerItemTouchHelperListener
    {
        void OnSwiped(RecyclerView.ViewHolder viewHolder, int direction, int position);
    }
}