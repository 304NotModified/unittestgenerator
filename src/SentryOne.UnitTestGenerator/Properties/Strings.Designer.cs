﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SentryOne.UnitTestGenerator.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SentryOne.UnitTestGenerator.Properties.Strings", typeof(Strings).Assembly);
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
        ///   Looks up a localized string similar to Cannot not derive target project name, please check the test project naming setting..
        /// </summary>
        internal static string ProjectItemModel_ProjectItemModel_Cannot_not_derive_target_project_name__please_check_the_test_project_naming_setting_ {
            get {
                return ResourceManager.GetString("ProjectItemModel_ProjectItemModel_Cannot_not_derive_target_project_name__please_c" +
                        "heck_the_test_project_naming_setting_", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The VSLangProj.VSProject instance could not be found..
        /// </summary>
        internal static string ReferencesHelper_AddReferencesToProject_The_VSLangProj_VSProject_instance_could_not_be_found_ {
            get {
                return ResourceManager.GetString("ReferencesHelper_AddReferencesToProject_The_VSLangProj_VSProject_instance_could_n" +
                        "ot_be_found_", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot find source project location.
        /// </summary>
        internal static string SolutionUtilities_CreateTestProjectInCurrentSolution_Cannot_find_source_project_location {
            get {
                return ResourceManager.GetString("SolutionUtilities_CreateTestProjectInCurrentSolution_Cannot_find_source_project_l" +
                        "ocation", resourceCulture);
            }
        }
    }
}