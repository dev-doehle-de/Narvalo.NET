﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Web.Configuration
{
    using System;
    using System.Configuration;

    public sealed class OptimizationSection : ConfigurationSection
    {
        public const string DefaultName = "optimization";

        public static readonly string SectionName = NarvaloWebSectionGroup.GroupName + "/" + DefaultName;

        internal const string InternalEnableWhiteSpaceBustingPropertyName = "enableWhiteSpaceBusting";

        private static ConfigurationProperty s_EnableWhiteSpaceBusting
            = new ConfigurationProperty(
                InternalEnableWhiteSpaceBustingPropertyName,
                typeof(Boolean),
                true,
                ConfigurationPropertyOptions.IsRequired);

        private readonly ConfigurationPropertyCollection _properties = new ConfigurationPropertyCollection();

        private bool _enableWhiteSpaceBusting;
        private bool _enableWhiteSpaceBustingSet = false;

        public OptimizationSection()
        {
            _properties.Add(s_EnableWhiteSpaceBusting);
        }

        public bool EnableWhiteSpaceBusting
        {
            get
            {
                return _enableWhiteSpaceBustingSet ? _enableWhiteSpaceBusting : (bool)base[s_EnableWhiteSpaceBusting];
            }

            set
            {
                _enableWhiteSpaceBusting = value;
                _enableWhiteSpaceBustingSet = true;
            }
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get { return _properties; }
        }
    }
}
