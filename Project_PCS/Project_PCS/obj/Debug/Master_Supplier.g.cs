﻿#pragma checksum "..\..\Master_Supplier.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "360BC6CDC6D8F4E3631198CBFE98A3F0DB7E1BE70F4ABA322A7767D6F9FC0F74"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Project_PCS;
using RootLibrary.WPF.Localization;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Project_PCS {
    
    
    /// <summary>
    /// Master_Supplier
    /// </summary>
    public partial class Master_Supplier : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\Master_Supplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid viewer;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Master_Supplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbnama;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Master_Supplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUpdate;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\Master_Supplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbxStatus;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Master_Supplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbalamat;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Master_Supplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_notelepon;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Master_Supplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Back;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Master_Supplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbSearch;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Project_PCS;component/master_supplier.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Master_Supplier.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.viewer = ((System.Windows.Controls.DataGrid)(target));
            
            #line 11 "..\..\Master_Supplier.xaml"
            this.viewer.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Viewer_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tbnama = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            
            #line 14 "..\..\Master_Supplier.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnUpdate = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\Master_Supplier.xaml"
            this.btnUpdate.Click += new System.Windows.RoutedEventHandler(this.BtnUpdate_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cbxStatus = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 6:
            this.tbalamat = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.tb_notelepon = ((System.Windows.Controls.TextBox)(target));
            
            #line 21 "..\..\Master_Supplier.xaml"
            this.tb_notelepon.KeyDown += new System.Windows.Input.KeyEventHandler(this.Tb_notelepon_KeyDown);
            
            #line default
            #line hidden
            
            #line 21 "..\..\Master_Supplier.xaml"
            this.tb_notelepon.KeyUp += new System.Windows.Input.KeyEventHandler(this.Tb_notelepon_KeyUp);
            
            #line default
            #line hidden
            
            #line 21 "..\..\Master_Supplier.xaml"
            this.tb_notelepon.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Tb_notelepon_TextChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btn_Back = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\Master_Supplier.xaml"
            this.btn_Back.Click += new System.Windows.RoutedEventHandler(this.Btn_Back_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.tbSearch = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            
            #line 29 "..\..\Master_Supplier.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

