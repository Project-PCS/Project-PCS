﻿#pragma checksum "..\..\MasterBarang.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "04DA8709C14377B9088F6C8EDB6349E987EF9797"
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
    /// MasterBarang
    /// </summary>
    public partial class MasterBarang : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\MasterBarang.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid viewer;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\MasterBarang.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_nama;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\MasterBarang.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbHargaEceran;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\MasterBarang.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbHargaGrosir;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\MasterBarang.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbMinJum;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\MasterBarang.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbJumBarang;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\MasterBarang.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbJumMinGrosir;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\MasterBarang.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbxStatus;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\MasterBarang.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Insert;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\MasterBarang.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Update;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\MasterBarang.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbSupplier;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\MasterBarang.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbKategori;
        
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
            System.Uri resourceLocater = new System.Uri("/Project_PCS;component/masterbarang.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MasterBarang.xaml"
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
            
            #line 12 "..\..\MasterBarang.xaml"
            this.viewer.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Viewer_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tb_nama = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.tbHargaEceran = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tbHargaGrosir = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.tbMinJum = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.tbJumBarang = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.tbJumMinGrosir = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.cbxStatus = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 9:
            this.btn_Insert = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\MasterBarang.xaml"
            this.btn_Insert.Click += new System.Windows.RoutedEventHandler(this.Btn_Insert_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btn_Update = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\MasterBarang.xaml"
            this.btn_Update.Click += new System.Windows.RoutedEventHandler(this.Btn_Update_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.cbSupplier = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 12:
            this.cbKategori = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

