﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ingredient.Resource {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Validation {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Validation() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Ingredient.Resource.Validation", typeof(Validation).Assembly);
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
        ///   Looks up a localized string similar to مقدار فیلد {0} باید دقیقا {1} رقم باشد!.
        /// </summary>
        public static string FixLengthNumeric {
            get {
                return ResourceManager.GetString("FixLengthNumeric", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to مقدار فیلد {0} نمی تواند بیشتر از {1} باشد.
        /// </summary>
        public static string MaxLenValidation {
            get {
                return ResourceManager.GetString("MaxLenValidation", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to مقدار فیلد {0} نمی تواند کمتر از {1} باشد.
        /// </summary>
        public static string MinLenValidation {
            get {
                return ResourceManager.GetString("MinLenValidation", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to {0} مورد نظر یافت نشد.
        /// </summary>
        public static string NotExist {
            get {
                return ResourceManager.GetString("NotExist", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to مقدار فیلد {0} را بصورت صحیح وارد کنید!.
        /// </summary>
        public static string RegularExpression {
            get {
                return ResourceManager.GetString("RegularExpression", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to لطفا مقدار فیلد {0} را وارد کنید.
        /// </summary>
        public static string StringIsEmpty {
            get {
                return ResourceManager.GetString("StringIsEmpty", resourceCulture);
            }
        }
    }
}