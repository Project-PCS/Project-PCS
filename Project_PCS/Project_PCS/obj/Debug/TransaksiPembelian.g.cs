﻿#pragma checksum "..\..\TransaksiPembelian.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FB0E5416F5F2D9A0D976268985104AC72097BCD496CD5369696A1861FBA1AC30"
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
    /// TransaksiPembelian
    /// </summary>
    public partial class TransaksiPembelian : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\TransaksiPembelian.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbSupplier;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\TransaksiPembelian.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbNomor;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\TransaksiPembelian.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpBayar;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\TransaksiPembelian.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgDaftar;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\TransaksiPembelian.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgKeranjang;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\TransaksiPembelian.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbbJum;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\TransaksiPembelian.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnTambah;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\TransaksiPembelian.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbIdBarang;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\TransaksiPembelian.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBeli;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\TransaksiPembelian.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReset;
        
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
            System.Uri resourceLocater = new System.Uri("/Project_PCS;component/transaksipembelian.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\TransaksiPembelian.xaml"
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
            this.cbSupplier = ((System.Windows.Controls.ComboBox)(target));
            
            #line 13 "..\..\TransaksiPembelian.xaml"
            this.cbSupplier.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbSupplier_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tbNomor = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.dpBayar = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.dgDaftar = ((System.Windows.Controls.DataGrid)(target));
            
            #line 17 "..\..\TransaksiPembelian.xaml"
            this.dgDaftar.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.dgDaftar_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.dgKeranjang = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.tbbJum = ((System.Windows.Controls.TextBox)(target));
            
            #line 20 "..\..\TransaksiPembelian.xaml"
            this.tbbJum.SelectionChanged += new System.Windows.RoutedEventHandler(this.tbbJum_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnTambah = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\TransaksiPembelian.xaml"
            this.btnTambah.Click += new System.Windows.RoutedEventHandler(this.btnTambah_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.tbIdBarang = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.btnBeli = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\TransaksiPembelian.xaml"
            this.btnBeli.Click += new System.Windows.RoutedEventHandler(this.btnBeli_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnReset = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

