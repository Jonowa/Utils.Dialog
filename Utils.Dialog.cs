using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Utils.Dialog
{
    /// <summary>
    /// Message dialog buttons.
    /// </summary>
    public enum MessageButtons : byte
    {
        OK,
        OKCancel,
        RetryIgnoreCancel,
        RetryCancel,
        YesNo,
        YesNoCancel,
        Open,
        OpenCancel,
        Save,
        SaveCancel,
        Close,
        None
    };

    /// <summary>
    /// Message dialog icon.
    /// </summary>
    public enum MessageIcon : byte
    {
        Information, // blue circle with white "i"
        Success,     // green circle with white check
        Warning,     // yellow triangle with black exclamation mark
        Error,       // red circle with white "x"
        None
    };

    /// <summary>
    /// Message dialog result.
    /// </summary>
    public enum MessageResult : byte
    {
        OK,
        Cancel,
        Retry,
        Ignore,
        Yes,
        No,
        Open,
        Save,
        Close,
        None
    };

    /// <summary>
    /// This class contains functions to show and close a message dialog 
    /// with formatting options. It also supports an input dialog.
    /// </summary>
    public class MessageDialog
    {
        /// <summary>
        /// Enable or disable beep sound on creating the dialog.
        /// </summary>
        public static bool BeepOnShow = true;
        
        /// <summary>
        /// Font used in message dialogs (default: system messagebox font).
        /// </summary>
        public static Font Font = SystemFonts.MessageBoxFont;

        /// <summary>
        /// Language in two letter ISO format (English, German and Français are supported).
        /// </summary>
        public static string Language = System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

        /// <summary>
        /// Form property, needed for close function.
        /// </summary>
        private static Form _form;

        /// <summary>
        /// Internal timeout counter, needed for autoclose function.
        /// </summary>
        private static int _timeout;

        private const int DialogWidth = 350;

        /// <summary>
        /// Default dialog location (center of primary screen).
        /// </summary>
        private static Point _dialogLocation = new Point(
                (Screen.PrimaryScreen.Bounds.Width - DialogWidth) / 2,
                (Screen.PrimaryScreen.Bounds.Height - DialogWidth) / 2
            );


        /// <summary>
        /// Show a message dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static MessageResult Show(string message)
        {
            return Show(new string[] { message }, null, MessageButtons.OK, MessageIcon.None, 0);
        }

        /// <summary>
        /// Show a message dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static MessageResult Show(string message, int timeout)
        {
            return Show(new string[] { message }, null, MessageButtons.OK, MessageIcon.None, timeout);
        }

        /// <summary>
        /// Show a message dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="caption"></param>
        /// <returns></returns>
        public static MessageResult Show(string message, string caption)
        {
            return Show(new string[] { message }, caption, MessageButtons.OK, MessageIcon.None, 0);
        }

        /// <summary>
        /// Show a message dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="caption"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static MessageResult Show(string message, string caption, int timeout)
        {
            return Show(new string[] { message }, caption, MessageButtons.OK, MessageIcon.None, timeout);
        }

        /// <summary>
        /// Show a message dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public static MessageResult Show(string message, MessageButtons buttons)
        {
            return Show(new string[] { message }, null, buttons, MessageIcon.None, 0);
        }

        /// <summary>
        /// Show a message dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="buttons"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static MessageResult Show(string message, MessageButtons buttons, int timeout)
        {
            return Show(new string[] { message }, null, buttons, MessageIcon.None, timeout);
        }

        /// <summary>
        /// Show a message dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="caption"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public static MessageResult Show(string message, string caption, MessageButtons buttons)
        {
            return Show(new string[] { message }, caption, buttons, MessageIcon.None, 0);
        }

        /// <summary>
        /// Show a message dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="caption"></param>
        /// <param name="buttons"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static MessageResult Show(string message, string caption, MessageButtons buttons, int timeout)
        {
            return Show(new string[] { message }, caption, buttons, MessageIcon.None, timeout);
        }

        /// <summary>
        /// Show a message dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        public static MessageResult Show(string message, MessageIcon icon)
        {
            return Show(new string[] { message }, null, MessageButtons.OK, icon, 0);
        }

        /// <summary>
        /// Show a message dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="icon"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static MessageResult Show(string message, MessageIcon icon, int timeout)
        {
            return Show(new string[] { message }, null, MessageButtons.OK, icon, timeout);
        }

        /// <summary>
        /// Show a message dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="caption"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        public static MessageResult Show(string message, string caption, MessageIcon icon)
        {
            return Show(new string[] { message }, caption, MessageButtons.OK, icon, 0);
        }

        /// <summary>
        /// Show a message dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="caption"></param>
        /// <param name="icon"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static MessageResult Show(string message, string caption, MessageIcon icon, int timeout)
        {
            return Show(new string[] { message }, caption, MessageButtons.OK, icon, timeout);
        }

        /// <summary>
        /// Show a message dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="buttons"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        public static MessageResult Show(string message, MessageButtons buttons, MessageIcon icon)
        {
            return Show(new string[] { message }, null, buttons, icon, 0);
        }

        /// <summary>
        /// Show a message dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="buttons"></param>
        /// <param name="icon"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static MessageResult Show(string message, MessageButtons buttons, MessageIcon icon, int timeout)
        {
            return Show(new string[] { message }, null, buttons, icon, timeout);
        }

        /// <summary>
        /// Show a message dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="caption"></param>
        /// <param name="buttons"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        public static MessageResult Show(string message, string caption, MessageButtons buttons, MessageIcon icon)
        {
            return Show(new string[] { message }, caption, buttons, icon, 0);
        }

        /// <summary>
        /// Show a message dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="caption"></param>
        /// <param name="buttons"></param>
        /// <param name="icon"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static MessageResult Show(string message, string caption, MessageButtons buttons, MessageIcon icon, int timeout)
        {
            return Show(new string[] { message }, caption, buttons, icon, timeout);
        }

        /// <summary>
        /// Show a message dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static MessageResult Show(string[] message)
        {
            return Show(message, null, MessageButtons.OK, MessageIcon.None, 0);
        }

        /// <summary>
        /// Show a message dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static MessageResult Show(string[] message, int timeout)
        {
            return Show(message, null, MessageButtons.OK, MessageIcon.None, timeout);
        }

        /// <summary>
        /// Show a message dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="caption"></param>
        /// <returns></returns>
        public static MessageResult Show(string[] message, string caption)
        {
            return Show(message, caption, MessageButtons.OK, MessageIcon.None, 0);
        }

        /// <summary>
        /// Show a message dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="caption"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static MessageResult Show(string[] message, string caption, int timeout)
        {
            return Show(message, caption, MessageButtons.OK, MessageIcon.None, timeout);
        }

        /// <summary>
        /// Show a message dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public static MessageResult Show(string[] message, MessageButtons buttons)
        {
            return Show(message, null, buttons, MessageIcon.None, 0);
        }

        /// <summary>
        /// Show a message dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="buttons"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static MessageResult Show(string[] message, MessageButtons buttons, int timeout)
        {
            return Show(message, null, buttons, MessageIcon.None, timeout);
        }

        /// <summary>
        /// Show a message dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="caption"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public static MessageResult Show(string[] message, string caption, MessageButtons buttons)
        {
            return Show(message, caption, buttons, MessageIcon.None, 0);
        }

        /// <summary>
        /// Show a message dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="caption"></param>
        /// <param name="buttons"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static MessageResult Show(string[] message, string caption, MessageButtons buttons, int timeout)
        {
            return Show(message, caption, buttons, MessageIcon.None, timeout);
        }

        /// <summary>
        /// Show a message dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        public static MessageResult Show(string[] message, MessageIcon icon)
        {
            return Show(message, null, MessageButtons.OK, icon, 0);
        }

        /// <summary>
        /// Show a message dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="icon"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static MessageResult Show(string[] message, MessageIcon icon, int timeout)
        {
            return Show(message, null, MessageButtons.OK, icon, timeout);
        }

        /// <summary>
        /// Show a message dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="caption"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        public static MessageResult Show(string[] message, string caption, MessageIcon icon)
        {
            return Show(message, caption, MessageButtons.OK, icon, 0);
        }

        /// <summary>
        /// Show a message dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="caption"></param>
        /// <param name="icon"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static MessageResult Show(string[] message, string caption, MessageIcon icon, int timeout)
        {
            return Show(message, caption, MessageButtons.OK, icon, timeout);
        }

        /// <summary>
        /// Show a message dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="buttons"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        public static MessageResult Show(string[] message, MessageButtons buttons, MessageIcon icon)
        {
            return Show(message, null, buttons, icon, 0);
        }

        /// <summary>
        /// Show a message dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="buttons"></param>
        /// <param name="icon"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static MessageResult Show(string[] message, MessageButtons buttons, MessageIcon icon, int timeout)
        {
            return Show(message, null, buttons, icon, timeout);
        }

        /// <summary>
        /// Show a message dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="caption"></param>
        /// <param name="buttons"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        public static MessageResult Show(string[] message, string caption, MessageButtons buttons, MessageIcon icon)
        {
            return Show(message, caption, buttons, icon, 0);
        }

        /// <summary>
        /// Show a message dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="caption"></param>
        /// <param name="buttons"></param>
        /// <param name="icon"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static MessageResult Show(string[] message, string caption, MessageButtons buttons, MessageIcon icon, int timeout)
        {
            // close an eventually open message dialog
            Close();

            var owner = Form.ActiveForm;
            if (owner != null)
            {
                _dialogLocation = new Point(owner.Left + owner.Width / 2, owner.Top + owner.Height / 2);
            }

            // create dialog
            _form = createDialogForm(caption);
            // autoclose timeout
            _timeout = Math.Max(0, timeout);

            int width = _form.ClientSize.Width;
            int fontHeight = _form.Font.Height;
            int top = fontHeight * 2;
            int left = 15;
            int buttonPosX;
            bool open = false;

            // append form dependend on message length
            if (string.Join("", message).Length > 250 || fontHeight >= 18 || buttons == MessageButtons.RetryIgnoreCancel)
            {
                width = 450;
            }
            if (string.Join("", message).Length > 500 || fontHeight >= 20)
            {
                width = 550;
            }
            if (string.Join("", message).Length > 750 || fontHeight >= 22)
            {
                width = 650;
            }

            // create icon
            if (icon != MessageIcon.None)
            {
                PictureBox image = new PictureBox {
                    Name = "icon",
                    Image = getImageFromString(icon),
                    Width = 34,
                    Height = 34,
                    Location = new Point(left, top)
                };
                _form.Controls.Add(image);
                left += 42;
            }

            // create message in rich text format
            for (int i = 0; i < message.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(message[i]))
                {
                    continue;
                }

                RichTextBox msg = new RichTextBox {
                    Font = _form.Font,
                    Name = "msg" + i.ToString(),
                    Size = new Size(width - left - 15, 30),
                    Location = new Point(left, top),
                    Padding = new Padding(0),
                    BorderStyle = BorderStyle.None,
                    BackColor = SystemColors.Window,
                    ForeColor = SystemColors.ControlText,
                    ScrollBars = RichTextBoxScrollBars.None,
                    ReadOnly = true,
                    DetectUrls = true,
                    HideSelection = true,
                    Enabled = true,
                    Multiline = true,
                    TabStop = false,
                };

                msg.ContentsResized += (obj, e) => {
                    (obj as RichTextBox).Height = e.NewRectangle.Height;
                };

                msg.LinkClicked += (obj, e) => {
                    System.Diagnostics.Process.Start(e.LinkText);
                };

                _form.Controls.Add(msg);
                msg.Rtf = getRtfText(message[i].ToString());

                top += msg.Height + fontHeight / 2;
            }

            top += (int)(fontHeight * 1.5f);

            // minimal top value: top margin + 1 message line + bottom margin = 5 x fontHeight
            if (icon != MessageIcon.None && top < (5.5f * fontHeight))
            {
                top = (int)(5.3f * fontHeight);
                PictureBox image = _form.Controls.Find("icon", false)[0] as PictureBox;
                image.Location = new Point(image.Left, (top - image.Height) / 2);
            }

            _form.ClientSize = new Size(width, top);

            // no buttons -> skip creating button panel with buttons
            if (buttons == MessageButtons.None)
            {
                goto ButtonsEnd;
            }

            // buttons panel
            Panel panelButtons = new Panel {
                Name = "panel",
                BackColor = SystemColors.Control,
                Dock = DockStyle.Bottom,
                Size = new Size(width, fontHeight + 30),
                Padding = new Padding(10)
            };
            _form.Controls.Add(panelButtons);

            buttonPosX = _form.ClientSize.Width - 15;

            Button button;
            string actions = buttons.ToString();

            // Cancel
            if (actions.Contains("Cancel"))
            {
                button = createButton("Cancel", DialogResult.Cancel);
                button.Location = new Point(buttonPosX - button.Width, 10);
                panelButtons.Controls.Add(button);
                buttonPosX -= (button.Width + 10);
                _form.CancelButton = button;
            }
            // Ignore
            if (actions.Contains("Ignore"))
            {
                button = createButton("Ignore", DialogResult.Ignore);
                button.Location = new Point(buttonPosX - button.Width, 10);
                panelButtons.Controls.Add(button);
                buttonPosX -= (button.Width + 10);
            }
            // Retry
            if (actions.Contains("Retry"))
            {
                button = createButton("Retry", DialogResult.Retry);
                button.Location = new Point(buttonPosX - button.Width, 10);
                panelButtons.Controls.Add(button);
                buttonPosX -= (button.Width + 10);
                _form.AcceptButton = button;
                _form.ActiveControl = button;
            }
            // No
            if (actions.Contains("No"))
            {
                button = createButton("No", DialogResult.No);
                button.Location = new Point(buttonPosX - button.Width, 10);
                panelButtons.Controls.Add(button);
                buttonPosX -= (button.Width + 10);
                _form.CancelButton = button;
            }
            // Yes
            if (actions.Contains("Yes"))
            {
                button = createButton("Yes", DialogResult.Yes);
                button.Location = new Point(buttonPosX - button.Width, 10);
                panelButtons.Controls.Add(button);
                buttonPosX -= (button.Width + 10);
                _form.AcceptButton = button;
                _form.ActiveControl = button;
            }
            // Close
            if (actions.Contains("Close"))
            {
                button = createButton("Close", DialogResult.OK);
                button.Location = new Point(buttonPosX - button.Width, 10);
                panelButtons.Controls.Add(button);
                buttonPosX -= (button.Width + 10);
                _form.AcceptButton = button;
                _form.ActiveControl = button;
            }
            // OK
            if (actions.Contains("OK"))
            {
                button = createButton("OK", DialogResult.OK);
                button.Location = new Point(buttonPosX - button.Width, 10);
                panelButtons.Controls.Add(button);
                buttonPosX -= (button.Width + 10);
                _form.AcceptButton = button;
                _form.ActiveControl = button;
            }
            // Open
            if (actions.Contains("Open"))
            {
                button = createButton("Open", DialogResult.Abort);
                button.Location = new Point(buttonPosX - button.Width, 10);
                panelButtons.Controls.Add(button);
                buttonPosX -= (button.Width + 10);
                _form.AcceptButton = button;
                _form.ActiveControl = button;
                open = true;
            }
            // Save
            if (actions.Contains("Save"))
            {
                button = createButton("Save", DialogResult.Abort);
                button.Location = new Point(buttonPosX - button.Width, 10);
                panelButtons.Controls.Add(button);
                buttonPosX -= (button.Width + 10);
                _form.AcceptButton = button;
                _form.ActiveControl = button;
            }

            panelButtons.ResumeLayout(false);

            _form.ClientSize = new Size(width, _form.ClientSize.Height + panelButtons.Height);

            ButtonsEnd:

            _form.Location = new Point(_form.Location.X - _form.Width / 2, _form.Location.Y - _form.Height / 2);

            _form.ResumeLayout(false);
            _form.PerformLayout();

            // create timer for autoclose support
            Timer timer = new Timer() {
                Enabled = false
            };

            // set timer for autoclose
            if (_timeout > 0)
            {
                timer.Interval = 1000;
                timer.Enabled = true;
                timer.Tick += (obj, e) => {
                    _form.Text = $"{_form.Name} [{_timeout}]".Trim();
                    if (_timeout-- <= 0)
                    {
                        _form.DialogResult = DialogResult.OK;
                        Close();
                    }
                };
            }

            // enable/disable beep sound
            if (BeepOnShow)
            {
                System.Media.SystemSounds.Beep.Play();
            }

            // display dialog without buttons for remote closing
            if (buttons == MessageButtons.None)
            {
                _form.Show();
                Application.DoEvents();
                _form.Focus();
                return MessageResult.None;
            }

            // display dialog
            DialogResult result = _form.ShowDialog();

            // convert dialog result to message result (with additional result values)
            try
            {
                _form.Dispose();

                switch (result)
                {
                    case DialogResult.Cancel:
                        return MessageResult.Cancel;

                    case DialogResult.Ignore:
                        return MessageResult.Ignore;

                    case DialogResult.Retry:
                        return MessageResult.Retry;

                    case DialogResult.Yes:
                        return MessageResult.Yes;

                    case DialogResult.No:
                        return MessageResult.No;

                    case DialogResult.Abort:
                        return open ? MessageResult.Open : MessageResult.Save;

                    default:
                        return MessageResult.OK;
                }
            }
            finally
            {
                // disable timer
                timer.Enabled = false;
            }
        }

        /// <summary>
        /// Close an open message dialog.
        /// </summary>
        public static void Close()
        {
            if (_form == null) return;

            _form.DialogResult = DialogResult.OK;
            _form.Close();
            _form.Dispose();
        }

        /// <summary>
        /// Show an input dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string Input(string message)
        {
            return Input(message, null, null, false, MessageButtons.OK);
        }

        /// <summary>
        /// Show an input dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="multiline"></param>
        /// <returns></returns>
        public static string Input(string message, bool multiline)
        {
            return Input(message, null, null, multiline, MessageButtons.OK);
        }

        /// <summary>
        /// Show an input dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Input(string message, string value)
        {
            return Input(message, value, null, false, MessageButtons.OK);
        }

        /// <summary>
        /// Show an input dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="value"></param>
        /// <param name="multiline"></param>
        /// <returns></returns>
        public static string Input(string message, string value, bool multiline)
        {
            return Input(message, value, null, multiline, MessageButtons.OK);
        }

        /// <summary>
        /// Show an input dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="value"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public static string Input(string message, string value, MessageButtons buttons)
        {
            return Input(message, value, null, false, buttons);
        }

        /// <summary>
        /// Show an input dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="value"></param>
        /// <param name="multiline"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public static string Input(string message, string value, bool multiline, MessageButtons buttons)
        {
            return Input(message, value, null, multiline, buttons);
        }

        /// <summary>
        /// Show an input dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public static string Input(string message, MessageButtons buttons)
        {
            return Input(message, null, null, false, buttons);
        }

        /// <summary>
        /// Show an input dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="multiline"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public static string Input(string message, bool multiline, MessageButtons buttons)
        {
            return Input(message, null, null, multiline, buttons);
        }

        /// <summary>
        /// Show an input dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="value"></param>
        /// <param name="caption"></param>
        /// <returns></returns>
        public static string Input(string message, string value, string caption)
        {
            return Input(message, value, caption, false, MessageButtons.OK);
        }

        /// <summary>
        /// Show an input dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="value"></param>
        /// <param name="caption"></param>
        /// <param name="multiline"></param>
        /// <returns></returns>
        public static string Input(string message, string value, string caption, bool multiline)
        {
            return Input(message, value, caption, multiline, MessageButtons.OK);
        }

        /// <summary>
        /// Show an input dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="value"></param>
        /// <param name="caption"></param>
        /// <param name="multiline"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public static string Input(string message, string value, string caption, bool multiline, MessageButtons buttons)
        {
            var owner = Form.ActiveForm;
            if (owner != null)
            {
                _dialogLocation = new Point(owner.Left + owner.Width / 2, owner.Top + owner.Height / 2);
            }

            // create dialog
            Form form = createDialogForm(caption);

            int width = form.Width;
            int fontHeight = form.Font.Height;
            int top = fontHeight * 2;
            int left = 15;
            string result = null;
            int buttonPosX;

            // create message in rich text format
            if (!string.IsNullOrWhiteSpace(message))
            {
                RichTextBox labelText = new RichTextBox {
                    Font = form.Font,
                    Name = "label",
                    Size = new Size(width - left *2, 30),
                    Location = new Point(left, top),
                    Padding = new Padding(0),
                    BorderStyle = BorderStyle.None,
                    BackColor = SystemColors.Window,
                    ForeColor = SystemColors.ControlText,
                    ScrollBars = RichTextBoxScrollBars.None,
                    ReadOnly = true,
                    DetectUrls = true,
                    HideSelection = true,
                    Enabled = true,
                    Multiline = true,
                    TabStop = false,
                };

                labelText.ContentsResized += (obj, e) => {
                    (obj as RichTextBox).Height = e.NewRectangle.Height;
                };

                labelText.LinkClicked += (obj, e) => {
                    System.Diagnostics.Process.Start(e.LinkText);
                };

                form.Controls.Add(labelText);
                labelText.Rtf = getRtfText(message);

                top += labelText.Height + fontHeight / 2;
            }
            
            string[] lines = string.IsNullOrEmpty(value) ? 
                new string[] { } :
                value.Replace(Environment.NewLine, "\n").Split('\n');

            // input field
            TextBox newValue = new TextBox {
                Font = form.Font,
                Name = "value",
                Lines = lines,
                BackColor = SystemColors.Window,
                ForeColor = SystemColors.ControlText,
                Location = new Point(left, top),
                Size = new Size(width - left * 2, (int)Math.Ceiling(fontHeight * 1.33f)),
                MinimumSize = new Size(width - left * 2, (int)Math.Ceiling(fontHeight * 1.33f)),
                Margin = new Padding(0),
                Multiline = multiline,
                AcceptsReturn = multiline,
            };

            // increase size and add scrollbar if multiline is enabled
            if (multiline)
            {
                newValue.ScrollBars = ScrollBars.Vertical;
                newValue.Size = new Size(newValue.Width, newValue.Height * 5);
            }

            form.Controls.Add(newValue);
            top += newValue.Height + fontHeight * 2;

            // buttons panel
            Panel panelButtons = new Panel {
                Name = "panel",
                BackColor = SystemColors.Control,
                Dock = DockStyle.Bottom,
                Size = new Size(width, fontHeight + 30),
                Padding = new Padding(0)
            };
            form.Controls.Add(panelButtons);

            buttonPosX = form.ClientSize.Width - 15;

            Button button;
            string actions = buttons.ToString();

            // Cancel
            if (actions.Contains("Cancel"))
            {
                button = createButton("Cancel", DialogResult.Cancel);
                button.Location = new Point(buttonPosX - button.Width, 10);
                panelButtons.Controls.Add(button);
                buttonPosX -= (button.Width + 10);
                form.CancelButton = button;
            }

            // OK
            button = createButton("OK", DialogResult.OK);
            button.Location = new Point(buttonPosX - button.Width, 10);
            panelButtons.Controls.Add(button);
            buttonPosX -= (button.Width + 10);
            form.AcceptButton = button;

            panelButtons.ResumeLayout(false);

            form.ClientSize = new Size(width, top + panelButtons.Height);
            form.Location = new Point(form.Location.X - form.Width / 2, form.Location.Y - form.Height / 2);
            form.ResumeLayout(false);
            form.PerformLayout();

            // enable/disable beep sound
            if (BeepOnShow)
            {
                System.Media.SystemSounds.Beep.Play();
            }

            // show input dialog
            if (form.ShowDialog() == DialogResult.OK)
            {
                result = newValue.Text;
            }

            form.Dispose();

            // return input text or null
            return result;
        }

        /// <summary>
        /// Fetch icon image of ressource from MessageIcon.
        /// </summary>
        /// <param name="icon"></param>
        /// <returns></returns>
        private static Image getImageFromString(MessageIcon icon)
        {
            byte index = (byte)icon;
            byte[] buffer = Convert.FromBase64String(_dialogIcons[index]);

            ImageConverter ic = new ImageConverter();
            return ic.ConvertFrom(buffer) as Image;
        }

        /// <summary>
        /// Base64 encoded icon ressources.
        /// </summary>
        private static readonly string[] _dialogIcons = new string[] {
            // Information (blue circle with white "i"):
            "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAMAAAEzo7pQAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8" +
            "YQUAAADbUExURQAAAACHtwB4owCi3QB5pACr6gB4owB4owB5pAB5pACFtQB/vwB5pQB/qgB5o8Ps+wB5" +
            "owB4ouP2/QCp5wB3pwB6pACDsgB4pAB2owCMwAB4pACn5ACw8ACBrwB5pAB4pQCl4AB5pAB4pACu7d/1" +
            "/f///wB/rACIuACj3wCGtQB4pAB5owB5owCYzwB/nwCh3ACq6AB5pAB/nwB5owB5ogB5pACNwACWzACo" +
            "5QB4owB5pACCsACLvQCUyQB0nwB5owCm4gCv7wB4pAB3pdfz/QCArQCJugCJuwB5ozoIlq8AAABJdFJO" +
            "UwD/z//b/9eD44//BCgM6/+XJP//IP//7xz/9////7dE/79M/////////9Pfi/8I///nEIAsm/////P/" +
            "////GLP///A8/////8O1R4u2AAAACXBIWXMAABcRAAAXEQHKJvM/AAABxklEQVQoU22SC1fiQAyFA4pQ" +
            "FV9VqxAf2K1WfACyqL0IAvX1/3/RZjJBa89+53R6c5OZaWdCRJE8nDBFblBF9ZxohRnEAr07RX/F4HfJ" +
            "OU+gXIbECSLIS0qE7qm+nMEDooUvmdLEGa4o9g7ocCmGzHvMscyqhsyPm7rAxgKTdtw7xNCHkHnGVVUM" +
            "3WDJc0bdtqrELSmATnsqfgybYsbjSBYZXKkWYvhtaZrB4bJG/hp1b00LQ4x7cXuCRdPHjUtbIoUcGtHX" +
            "usXMc0jNQ3Hb85ZMmKlhYOP3r/DTztKwLw1XS0aclYy0UzIqFxS8qDLD3Q1qamy7cRyIceQdx6frAaJ9" +
            "HGvYx5rGQqDHke1a6HmoN9RWtoKp2cb0C/go/GT7BageWVLSDaz3LfVNrYLBvs8PcfmdfkuSN5NcO4Fe" +
            "Qx0f5gjFAuZjyH/lGFv4H65xRq/wreHZS5I/Jh0pOhQVms0doR2iJ4Y0G3y3eUoFIW7oFtbvSqngznXX" +
            "VnGJ3wX9g+xejmmB1IxSwQwtvY5mFZW5eQXmn1iz3qR8gJNz843ZGJE2qtEMWsD1UxrGcZjeVQ7QCpaz" +
            "f7g/G3VWs+ymM7qQT/MQ/QObyHBVZmOizgAAAABJRU5ErkJggg==",
            // Success (green circle with white check):
            "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAMAAAEzo7pQAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8" +
            "YQUAAAEXUExURQAAAACMCwCIAOj48ACFAACVHQCGAACeLQCnPQCnQACHAACGAACwUACGAACKCACcKsPs" +
            "1hi3YACGAACFAAClOwCIAACuTACuTQCFAACFAACGAACRFQCFAACFAACFAACGAACsSACGAACGAQCPEwCK" +
            "ABy5YxS2XgB/AACGAACqRQCFADzDeef47wB/ADTAdACNDQCFAACWHv///wCFAPf8+QCoQQCLCgCGAACU" +
            "GvH79QCmPACvTzC/cQCSFwCSGCi8awCFAACFAACbJ8zv3ACFAEjGgfP79wCGAACtSgCFAACHAQCFAHDT" +
            "nQCQEgCQFACFAACHAAy0WACrRt716AB/AACOD9fz5AB/ACS7aRy4YgCFAPf9+QCpQ6q5YqwAAABbdFJO" +
            "UwD/HP/D/8////8g1/+D/////yTb/zz//+OP7/8o65f3/////xj//whM//D//xD//7f//7/////T////" +
            "///////fi///5///8/+A/yz///+bRP///wT//wz//7PORKXoAAAACXBIWXMAABcRAAAXEQHKJvM/AAAC" +
            "CElEQVQoU2VSjVoaQQyMVvHUoFC5gztrIYrVIhY9ithSRZHegVUQqtJa3v85ms2GH9v5PkhmJruX3Q0A" +
            "BPxDRAiiFNoMki7AV0RiFiGcmQx+sIBn7HHAFMsupsNIyoE4cAmjfiLBCNgGKJmIWISWCSEXedjkyMkT" +
            "hhw56RoLPV6VGCKevpMNHkvUGnuZJ+paSp5UGWwnWJAPCFJ3+DGG+nhCpSeCkwwOwrBpqXRnlqTDP0Lx" +
            "tM+btLct4a+T/SwUYzIwrsJ9CerXmjO6VMl44xaVRpbnNnQLh/jSAJbulSM2iGuOZ50iruZ5QU0J98d9" +
            "Pc6Owv1+w833U4H5EeJwywhH5QnHbGyE57CsHJ2qLHkOlWPvEPxzjl+Um9MDdWxuUPFZWJwpl2YGANZo" +
            "WWhhd104w5friN8qtThO5kQW7PhFlRXFJaKL6SERx+dEiUU12c7RfUGtKTo9aq9Zv0sb/9kGnQWSZ0jS" +
            "hSpzGHwy/8vE53KpItI8Bim+m++c7NEDvFDGqlOIHdm7pCoEOmy/9iXM23z7xMNGZto+RGFYbv5j83vR" +
            "FVyTzHvaPMmbm1c24oqZrh3ZQkte2Vi4jQ/4mkrkWP775+d5G2u7eXmOUYJ6DdXm0LikdZ1NcNu0sKq6" +
            "olahQAZVMfLzRHubzjCbHTorvVvK+5PVMxw89KtbcXxV7R9yaxYAfwFG011xkxgQgwAAAABJRU5ErkJg" +
            "gg==",
            // Warning (yellow triangle with black exclamation mark):
            "iVBORw0KGgoAAAANSUhEUgAAACIAAAAiCAMAAAF6nstmAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8" +
            "YQUAAAA5UExURQAAAP2+AOKpAP6/ACAYAP/AALyMAOatALuLACgeABwVALyLAMWTADwtALyMAL9/ALyM" +
            "AMKRAAAAAN9bgxcAAAARdFJOUwD/////////2///1///UARgYSu4qwAAAAlwSFlzAAAXEQAAFxEByibz" +
            "PwAAAQpJREFUKFOFkgGSwiAMRVldIrqrYO5/WJOfAEHb+mfspK+PEFpTSlV+KWW9VC5ast4Qkd5oKqjA" +
            "mnPRBwRsVwnlSy/YSspSddqDNhryB2inkXVAAhhI1t91uQBtZJtq1EKKjT1TTrSicsp5QQKYI1JDyEQK" +
            "QDoC8ABFsLSflWecdqQEHal0eZOk/SpVeROrhAmiJIqMHCVRlmOhi5IpaZd4UChGuoSNbkpcguIxCYqt" +
            "MikqJv35h+sJg3ta82I3jeiL0+j5f+yI8XM+dNTI+cgx48iBcWP+3XWsB0v2+vgupmw6fQ5XNpxuDOXD" +
            "GcZU3pxpxEQnGlfmq5fBWXpEZTjbu1jMefg/Zy/UXjvzEv3hM4RAAAAAAElFTkSuQmCC",
            // Danger (red circle with white "x"):
            "iVBORw0KGgoAAAANSUhEUgAAAB8AAAAfCAMAAAFfd9adAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8" +
            "YQUAAAEXUExURQAAAL8AAL8AAP/+/r8AAOIAAMMAANYAAOkAAP/z88AAAP/8/P8XF/8yMsAAAPAAAP+7" +
            "u78AAOQAAMUAAP/x8f8MDL8AAPcAANgAAP4AAN8AAMAAAL8AANMAAP+Tk8AAAMAAAOYAAL8AAPkAANoA" +
            "AMAAAP9bW8AAAP///+EAAL8AAL8AAP8sLNUAAMAAAL8AAL8AAPsAAL8AAP8YGP88PP9FRb8AAOMAAMQA" +
            "AMAAAP9gYP/X19cAAL8AAMAAAOoAAMAAAP8oKP0AAP/Dw8AAAL8AANIAAP/n58AAAOUAAP/5+cYAAMAA" +
            "AL8AAPgAANkAAMAAAMAAAP8AAMAAAOAAAL8AAPMAANQAAP+bm8AAAOcAAL8AAP+/v3Ct76YAAABcdFJO" +
            "UwBsGP8g///////f////5///OP////9A//////9Q//+z9P9Y//+7/8P//2gU///LcBz/JP///yz//+P/" +
            "//806/+X////n0T///v///+nTP//r/D/t/9c////v/8QZjqiFQAAAAlwSFlzAAAXEQAAFxEByibzPwAA" +
            "Af5JREFUKFNlUgtbElEQncpQqKQiQJgUSa0rJilRQfkIVmQLQzwIhfX/f0dn7l6kx/m+3TtnzjzuzqyI" +
            "ZPgAkAwcEks+74ls4bEK+hiKAu9FXmxRUmqA60dYkT1sREwZMF1XhgOGiPzMnNlhKTis2fnLLJEqorQD" +
            "RlJkehpoS4q50Q8sSYMRvrI0csNTO4m7mqoWi9WULgXqgzy0wT4pYMPq9N0GkDuQDOsCkXORncO2nFV5" +
            "9l0UWRROK7zLIfDRVL66vk3NXIauvvFtiINKu11JmiaYzHQ2CbbIha5nkd3XUULj86QAvsdGV7cDBcpX" +
            "IsctoNkk6fCVK0jc5ce7JjqOoyipn1LeuZfO5Wkl3ByezjmDmXLLSR8mDpW4ZPXyluLrFdgvb7n5t8Dg" +
            "m8hJ2RI9djf9fZcDXQtzHuvRFNNLnSWUqNW1fifYAcfjWOeIdwrBG/BkVVvX/LCA7v2WnvSCRjXWbd7y" +
            "b5Q1DhEXev6faljWscljvTbWTLu0HwE6/WA91TpXo+vem+fezU+VP4AfHo60JjPNejtE3FuowJQF9I+/" +
            "6tFXqg/eBUaoyqvbfF/5GZ9wjyR/ovvefh36zu9huFQOcUc/mE1/6EvrE3cD3Nj9RUahwr9Ymy+kF+ti" +
            "h3Psqj5PZKJ3pYMviyGWbga6uVA9CvWwPEOd/4VB5DfZFbtefQ1k8AAAAABJRU5ErkJggg=="
        };

        /// <summary>
        /// Create a button.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private static Button createButton(string text, DialogResult result)
        {
            Button button = new Button {
                Font = Font,
                Name = text.ToLower(),
                Text = getButtonText(text),
                AutoSize = false,
                MinimumSize = new Size(75, 25),
                Anchor = AnchorStyles.Right,
                FlatStyle = FlatStyle.System,
                DialogResult = result
            };

            button.Size = new Size(
                    Math.Max(
                            button.Text.Length * (int)Font.SizeInPoints,
                            button.Width
                        ),
                    Font.Height + 10
                );

            return button;
        }

        /// <summary>
        /// Return local button caption.
        /// </summary>
        /// <param name="button"></param>
        /// <returns></returns>
        private static string getButtonText(string button)
        {
            switch (Language.ToLower())
            {
                case "de":
                    switch (button)
                    {
                        case "Cancel": return "Abbrechen";
                        case "Close":  return "Schließen";
                        case "Ignore": return "Ignorieren";
                        case "No":     return "Nein";
                        case "Open":   return "Öffnen";
                        case "Save":   return "Speichern";
                        case "Retry":  return "Wiederholen";
                        case "Yes":    return "Ja";
                        default:       return "OK";
                    }

                case "fr":
                    switch (button)
                    {
                        case "Cancel": return "Annuler";
                        case "Close": return "Fermer";
                        case "Ignore": return "Ignorer";
                        case "No": return "Non";
                        case "Open": return "Ouvrir";
                        case "Save": return "Sauvegarder";
                        case "Retry": return "Répéter";
                        case "Yes": return "Oui";
                        default: return "OK";
                    }

                default:
                    return button;
            }
        }

        /// <summary>
        /// Create the message dialog as a form.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static Form createDialogForm(string name)
        {
            name = name ?? "";

            // dialog box (blank form with thin border and X button)
            Form form = new Form {
                AutoScaleMode = AutoScaleMode.None,
                ClientSize = new Size(DialogWidth, 10),
                AutoSize = false,
                AutoSizeMode = AutoSizeMode.GrowOnly,
                Padding = new Padding(0),
                Name = name,
                Text = name,
                BackColor = SystemColors.Window,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                ControlBox = true,
                MaximizeBox = false,
                MinimizeBox = false,
                HelpButton = false,
                ShowIcon = false,
                ShowInTaskbar = false,
                TopMost = true,
                StartPosition = FormStartPosition.Manual,
                Location = _dialogLocation,
                Font = Font,
                DialogResult = DialogResult.None
            };

            Panel line = new Panel {
                BackColor = SystemColors.Control,
                Location = Point.Empty,
                Size = new Size(form.Width, 1)
            };

            form.Controls.Add(line);

            return form;
        }

        /// <summary>
        /// Convert a message into rich text format.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private static string getRtfText(string message)
        {
            StringBuilder sb = new StringBuilder(message);

            sb.Replace("\\n", "\\par ");
            sb.Replace("<p>", "\\par ");
            sb.Replace("<t>", "\\tab ");
            sb.Replace("<b>", "\\b ");
            sb.Replace("</b>", "\\b0 ");
            sb.Replace("<i>", "\\i ");
            sb.Replace("</i>", "\\i0 ");
            sb.Replace("<u>", "\\ul ");
            sb.Replace("</u>", "\\ulnone ");

            sb.Insert(0, "{\\rtf1\\ansi\\ansicpg1252\n");

            return sb.ToString();
        }
    }
}
