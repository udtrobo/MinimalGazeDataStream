﻿//-----------------------------------------------------------------------
// Copyright 2014 Tobii Technology AB. All rights reserved.
//-----------------------------------------------------------------------

namespace ActivatableButtonsForms
{
    using EyeXFramework.Forms;
    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using Tobii.EyeX.Framework;
    using EyeXFramework;

    static class Program
    {
        private static FormsEyeXHost _eyeXHost = new FormsEyeXHost();

        /// <summary>
        /// Gets the singleton EyeX host instance.
        /// </summary>
        public static FormsEyeXHost EyeXHost
        {
            get { return _eyeXHost; }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            
            _eyeXHost.Start();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ActivatableButtonsForm());
           

        }
    }
}
