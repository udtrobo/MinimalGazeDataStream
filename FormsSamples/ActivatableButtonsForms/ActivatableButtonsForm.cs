//-----------------------------------------------------------------------
// Copyright 2014 Tobii Technology AB. All rights reserved.
//-----------------------------------------------------------------------

namespace ActivatableButtonsForms
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using EyeXFramework;
    using System.Runtime.InteropServices;
    using Tobii.EyeX.Framework;

    public partial class ActivatableButtonsForm : Form
    {

        public ActivatableButtonsForm()
        {
            KeyPreview = true;
            InitializeComponent();
            

            // Make the buttons on the form direct clickable using the Activatable behavior.
            Program.EyeXHost.Connect(behaviorMap1);
            behaviorMap1.Add(button2, new ActivatableBehavior(OnButtonActivated));
            behaviorMap1.Add(button1, new ActivatableBehavior(OnButtonActivated));
            behaviorMap1.Add(button3, new ActivatableBehavior(OnButtonActivated));


            KeyDown += OnKeyDown;
            KeyUp += OnKeyUp;
        }

        private void OnKeyUp(object sender, KeyEventArgs keyEventArgs)
        {
            Console.WriteLine("OnKeyUp: " + keyEventArgs.KeyCode);

            if (keyEventArgs.KeyCode == Keys.ShiftKey)
            {
                Console.WriteLine("TriggerActivation");
                Program.EyeXHost.TriggerActivation();
            }
            keyEventArgs.Handled = false;
        }

        private void OnKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            // See PannableForms sample for an example how to disregard repeated KeyDown events.
            // We don't bother to do it in this example since most users do not press and hold down
            // the key for long, when clicking.
            Console.WriteLine("OnKeyDown: " + keyEventArgs.KeyCode);
            if (keyEventArgs.KeyCode == Keys.ShiftKey)
            {
                Console.WriteLine("TriggerActivationModeOn");
                Program.EyeXHost.TriggerActivationModeOn();
                
            }
            keyEventArgs.Handled = false;
        }

        /// <summary>
        /// Event handler invoked when a button is activated.
        /// </summary>
        /// <param name="sender">The control that received the gaze click.</param>
        private void OnButtonActivated(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                Console.WriteLine("OnButtonActivated");
                button.PerformClick();
                
            }
        }

        
       

        private void buttonHueDown_Click(object sender, EventArgs e)
        {
            lblButtonClick.Text = "This is screen1";
        }

        private void buttonHueUp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lblButtonClick.Text = "This is screen2";
        }
    }
}
