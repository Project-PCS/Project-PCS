﻿#pragma checksum "..\..\PendaftaranMember.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2C8D354C705B55DE48A10FE646423D18DB53985B"
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
    /// PendaftaranMember
    /// </summary>
    public partial class PendaftaranMember : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\PendaftaranMember.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbKode;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\PendaftaranMember.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbNama;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\PendaftaranMember.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbAlamat;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\PendaftaranMember.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbLaki;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\PendaftaranMember.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbPerempuan;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\PendaftaranMember.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDaftar;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\PendaftaranMember.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbTelp;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\PendaftaranMember.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBack;
        
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
            System.Uri resourceLocater = new System.Uri("/Project_PCS;component/pendaftaranmember.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PendaftaranMember.xaml"
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
            this.tbKode = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.tbNama = ((System.Windows.Controls.TextBox)(target));
            
            #line 16 "..\..\PendaftaranMember.xaml"
            this.tbNama.SelectionChanged += new System.Windows.RoutedEventHandler(this.tbNama_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tbAlamat = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.rbLaki = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 5:
            this.rbPerempuan = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 6:
            this.btnDaftar = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\PendaftaranMember.xaml"
            this.btnDaftar.Click += new System.Windows.RoutedEventHandler(this.btnDaftar_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.tbTelp = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.btnBack = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\PendaftaranMember.xaml"
            this.btnBack.Click += new System.Windows.RoutedEventHandler(this.btnBack_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

