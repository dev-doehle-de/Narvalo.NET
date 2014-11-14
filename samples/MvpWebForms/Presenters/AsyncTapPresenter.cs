﻿namespace MvpWebForms.Presenters
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Narvalo.Mvp;
    using Narvalo.Web.Mvp;
    using MvpWebForms.Views;

    public sealed class AsyncTapPresenter : HttpPresenterOf<AsyncModel>
    {
        static readonly Action Thunk_ = () => Thread.Sleep(10);

        public AsyncTapPresenter(IView<AsyncModel> view)
            : base(view)
        {
            View.Load += Load;
        }

        void Load(object sender, EventArgs e)
        {
            View.Model.RecordViewLoad();

            AsyncManager.RegisterAsyncTask(InvokeAsync);
        }

        async Task InvokeAsync()
        {
            View.Model.RecordAsyncStarted();

            await Task.Run(Thunk_);

            View.Model.RecordAsyncEnded();
        }
    }
}