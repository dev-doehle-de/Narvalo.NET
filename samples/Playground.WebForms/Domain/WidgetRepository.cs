﻿namespace Playground.WebForms.Domain
{
    using System;
    using System.Collections.Generic;

    public class WidgetRepository : IWidgetRepository
    {
        public Widget Find(int id)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginFind(int id, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public Widget EndFind(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Widget> FindAll()
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginFindAll(AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Widget> EndFindAll(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public Widget FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginFindByName(string name, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public Widget EndFindByName(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public void Save(Widget widget, Widget originalWidget)
        {
            throw new NotImplementedException();
        }
    }
}