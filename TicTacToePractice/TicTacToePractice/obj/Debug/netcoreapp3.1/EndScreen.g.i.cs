﻿#pragma checksum "..\..\..\EndScreen.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E364D645E353A6FBE38FF9BB2FF5B6BC08AB7953"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using TicTacToePractice;


namespace TicTacToePractice {
    
    
    /// <summary>
    /// EndScreen
    /// </summary>
    public partial class EndScreen : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\EndScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbTitle;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\EndScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNewGame;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\EndScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMenu;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\EndScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnExitGame;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.17.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TicTacToePractice;V1.0.0.0;component/endscreen.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\EndScreen.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.17.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.tbTitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.btnNewGame = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\EndScreen.xaml"
            this.btnNewGame.Click += new System.Windows.RoutedEventHandler(this.btnNewGame_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnMenu = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\EndScreen.xaml"
            this.btnMenu.Click += new System.Windows.RoutedEventHandler(this.btnMenu_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnExitGame = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\EndScreen.xaml"
            this.btnExitGame.Click += new System.Windows.RoutedEventHandler(this.btnExitGame_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

