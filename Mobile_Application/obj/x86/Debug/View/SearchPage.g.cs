﻿#pragma checksum "D:\cours\ig3_cours\environnement de dévelopement logiciel\Mobile_Application\Mobile_Application\View\SearchPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "50191FB5B7C948DD6A2B2C04DF4E58DE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mobile_Application.View
{
    partial class SearchPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.appBar = (global::Windows.UI.Xaml.Controls.CommandBar)(target);
                }
                break;
            case 2:
                {
                    this.Account = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                }
                break;
            case 3:
                {
                    this.Favorite = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                }
                break;
            case 4:
                {
                    this.SearchPageGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 5:
                {
                    this.Search = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 6:
                {
                    this.rb_Name = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 42 "..\..\..\View\SearchPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.rb_Name).Checked += this.rb_Name_Checked;
                    #line default
                }
                break;
            case 7:
                {
                    this.rb_Email = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 43 "..\..\..\View\SearchPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.rb_Email).Checked += this.rb_Email_Checked;
                    #line default
                }
                break;
            case 8:
                {
                    this.rb_Company = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 44 "..\..\..\View\SearchPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.rb_Company).Checked += this.rb_Company_Checked;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

