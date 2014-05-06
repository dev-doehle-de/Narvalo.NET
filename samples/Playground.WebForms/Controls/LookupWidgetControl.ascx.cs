﻿namespace Playground.WebForms.Controls
{
    using System;
    using Narvalo.Mvp.Web;
    using Playground.WebForms.Views;
    using Playground.WebForms.Views.Models;

    public partial class LookupWidgetControl : MvpUserControl<LookupWidgetModel>, ILookupWidgetView
    {
        public event EventHandler<FindingWidgetEventArgs> Finding;

        protected void Find_Click(object sender, EventArgs e)
        {
            var id = string.IsNullOrEmpty(widgetId.Text)
                ? (int?)null
                : Convert.ToInt32(widgetId.Text);

            OnFinding(id, widgetName.Text);
        }

        void OnFinding(int? id, string name)
        {
            var localHandler = Finding;

            if (localHandler != null) {
                localHandler(this, new FindingWidgetEventArgs { Id = id, Name = name });
            }
        }
    }
}