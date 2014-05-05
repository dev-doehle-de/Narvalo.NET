﻿namespace Playground.WebForms.Views
{
    using System;
    using Narvalo.Mvp;
    using Playground.WebForms.Views.Models;

    public interface ILookupWidgetView : IView<LookupWidgetModel>
    {
        event EventHandler<FindingWidgetEventArgs> Finding;
    }

    public class FindingWidgetEventArgs : EventArgs
    {
        public int? Id { get; set; }
        public string Name { get; set; }

        public FindingWidgetEventArgs()
        { }

        public FindingWidgetEventArgs(int id, string name)
            : this()
        {
            Id = id;
            Name = name;
        }
    }
}