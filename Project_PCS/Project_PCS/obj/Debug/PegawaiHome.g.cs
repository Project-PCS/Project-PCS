﻿#pragma checksum "..\..\PegawaiHome.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "35BA16580EA55DBBF6B2C412D5F7CCA465B40555D5E73C2C1FAE2EADD2379F59"
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
    /// PegawaiHome
    /// </summary>
    public partial class PegawaiHome : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\PegawaiHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPembelian;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\PegawaiHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPenjualan;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\PegawaiHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPendaftaran;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\PegawaiHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPenukaran;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\PegawaiHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button mainmenu;
        
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
            System.Uri resourceLocater = new System.Uri("/Project_PCS;component/pegawaihome.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PegawaiHome.xaml"
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
            this.btnPembelian = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\PegawaiHome.xaml"
            this.btnPembelian.Click += new System.Windows.RoutedEventHandler(this.btnPembelian_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnPenjualan = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\PegawaiHome.xaml"
            this.btnPenjualan.Click += new System.Windows.RoutedEventHandler(this.BtnPenjualan_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnPendaftaran = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\PegawaiHome.xaml"
            this.btnPendaftaran.Click += new System.Windows.RoutedEventHandler(this.btnPendaftaran_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnPenukaran = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\PegawaiHome.xaml"
            this.btnPenukaran.Click += new System.Windows.RoutedEventHandler(this.btnPenukaran_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.mainmenu = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\PegawaiHome.xaml"
            this.mainmenu.Click += new System.Windows.RoutedEventHandler(this.mainmenu_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

