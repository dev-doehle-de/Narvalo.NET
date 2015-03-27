﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Narvalo.Resources {
    using System;
    using System.Reflection;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Strings_Core {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings_Core() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Narvalo.Resources.Strings_Core", typeof(Strings_Core).GetTypeInfo().Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can not explicitly cast a Maybe&lt;T&gt;.None to a value of type T..
        /// </summary>
        internal static string Maybe_CannotCastNoneToValue {
            get {
                return ResourceManager.GetString("Maybe_CannotCastNoneToValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can not explicitly cast an output failure of type Output&lt;T&gt; to a value of type T..
        /// </summary>
        internal static string Output_CannotCastFailureToValue {
            get {
                return ResourceManager.GetString("Output_CannotCastFailureToValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can not explicitly cast an output success of type Output&lt;T&gt; to an exception state..
        /// </summary>
        internal static string Output_CannotCastSuccessToException {
            get {
                return ResourceManager.GetString("Output_CannotCastSuccessToException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value of &apos;{0}&apos; is null..
        /// </summary>
        internal static string Require_ArgumentNull_Format {
            get {
                return ResourceManager.GetString("Require_ArgumentNull_Format", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value of &apos;{0}&apos; is null or empty..
        /// </summary>
        internal static string Require_ArgumentNullOrEmpty_Format {
            get {
                return ResourceManager.GetString("Require_ArgumentNullOrEmpty_Format", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value of &apos;{0}&apos; is null or empty, or contains only white-space characters..
        /// </summary>
        internal static string Require_ArgumentNullOrWhiteSpace_Format {
            get {
                return ResourceManager.GetString("Require_ArgumentNullOrWhiteSpace_Format", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value of the parameter &apos;minInclusive&apos; ({0}) must be greater than or equal to value of the parameter &apos;maxInclusive&apos; ({1})..
        /// </summary>
        internal static string Require_InvalidRange_Format {
            get {
                return ResourceManager.GetString("Require_InvalidRange_Format", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value of &apos;{0}&apos; is not greater than &apos;{1}&apos;..
        /// </summary>
        internal static string Require_NotGreaterThan_Format {
            get {
                return ResourceManager.GetString("Require_NotGreaterThan_Format", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value of &apos;{0}&apos; is not greater than or equal to &apos;{1}&apos;..
        /// </summary>
        internal static string Require_NotGreaterThanOrEqualTo_Format {
            get {
                return ResourceManager.GetString("Require_NotGreaterThanOrEqualTo_Format", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value of &apos;{0}&apos; is not in range [{1} - {2}]..
        /// </summary>
        internal static string Require_NotInRange_Format {
            get {
                return ResourceManager.GetString("Require_NotInRange_Format", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value of &apos;{0}&apos; is not less than &apos;{1}&apos;..
        /// </summary>
        internal static string Require_NotLessThan_Format {
            get {
                return ResourceManager.GetString("Require_NotLessThan_Format", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value of &apos;{0}&apos; is not less than or equal to &apos;{1}&apos;..
        /// </summary>
        internal static string Require_NotLessThanOrEqualTo_Format {
            get {
                return ResourceManager.GetString("Require_NotLessThanOrEqualTo_Format", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The object parameter is null..
        /// </summary>
        internal static string Require_ObjectNull {
            get {
                return ResourceManager.GetString("Require_ObjectNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The property value is null..
        /// </summary>
        internal static string Require_PropertyNull {
            get {
                return ResourceManager.GetString("Require_PropertyNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The property value is null or empty..
        /// </summary>
        internal static string Require_PropertyNullOrEmpty {
            get {
                return ResourceManager.GetString("Require_PropertyNullOrEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The property value is null or empty, or contains only white-space characters..
        /// </summary>
        internal static string Require_PropertyNullOrWhiteSpace {
            get {
                return ResourceManager.GetString("Require_PropertyNullOrWhiteSpace", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A successful outcome can not provide an error message. You must check the IsBreak value before accesssing this property..
        /// </summary>
        internal static string VoidOrBreak_BreakHasNoReason {
            get {
                return ResourceManager.GetString("VoidOrBreak_BreakHasNoReason", resourceCulture);
            }
        }
    }
}
