﻿using KeyboardPress_Analyzer.Helper;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KeyboardPress_Analyzer
{
    public class KeyboardControlAdapter
    {
        /// <summary>
        /// more info: http://tksinghal.blogspot.lt/2011/04/how-to-press-and-hold-keyboard-key.html
        /// </summary>
        /// <param name="bVk">A virtual-key code. The code must be a value in the range 1 to 254. For a complete list, see https://msdn.microsoft.com/en-us/library/dd375731(v=vs.85).aspx</param>
        /// <param name="bScan">A hardware scan code for the key</param>
        /// <param name="dwFlags">Controls various aspects of function operation. This parameter can be one or more of the following values
        /// KEYEVENTF_EXTENDEDKEY 0x0001 - If specified, the scan code was preceded by a prefix byte having the value 0xE0 (224).
        /// KEYEVENTF_KEYUP 0x0002 - If specified, the key is being released. If not specified, the key is being depressed.
        /// </param>
        /// <param name="dwExtraInfo">An additional value associated with the key stroke</param>
        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
        
        public static void pressButton(int keyboardKey, bool makeApplicationDoEvents = false)
        {
            try
            {
                    keybd_event((byte)keyboardKey, 0, 0, 0);// press

                if (makeApplicationDoEvents)
                    System.Windows.Forms.Application.DoEvents();
            }
            catch(Exception ex)
            {
                LogHelper.LogErrorMsg(ex);
                throw ex;
            }
        }

        public static void releaseButton(int keyboardKey, bool makeApplicationDoEvents = false)
        {
            try
            {
                keybd_event((byte)keyboardKey, 0, 2, 0); //release

                if (makeApplicationDoEvents)
                    System.Windows.Forms.Application.DoEvents();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static void pressAndReleaseButton(int keyboardKey, bool makeApplicationDoEvents = false)
        {
            try
            {
                System.Windows.Forms.Application.DoEvents();

                pressButton(keyboardKey, false);
                releaseButton(keyboardKey, false);

                if (makeApplicationDoEvents)
                    System.Windows.Forms.Application.DoEvents();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static void copySelectedText()
        {
            try
            {
                pressButton(VirtualKeysEnum.VK_CONTROL);
                pressButton(VirtualKeysEnum.key_c);

                releaseButton(VirtualKeysEnum.VK_CONTROL);
                releaseButton(VirtualKeysEnum.key_c);

                System.Windows.Forms.Application.DoEvents();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public static void pasteCopiedText()
        {
            try
            {
                pressButton(VirtualKeysEnum.VK_CONTROL);
                pressButton(VirtualKeysEnum.key_v);

                releaseButton(VirtualKeysEnum.VK_CONTROL);
                releaseButton(VirtualKeysEnum.key_v);

                System.Windows.Forms.Application.DoEvents();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        
        public static void pasteText(string text, bool setBackPreviosCopiedValue = true)
        {
            try
            {
                // nice to have: jei bus laiko patobulinti (paveiksleliai ir kiti objektai atmintyje)

                //bool containsAudio = false;
                //bool containsFileDropList = false;
                //bool containsImage = false;
                //bool containsText = false;
                //string str = "";
                //string

                //if (setBackPreviosCopiedValue)
                //{
                //    if (Clipboard.ContainsText())
                //    {
                //        containsText = true;
                //        str = Clipboard.GetText();
                //    }
                //    else if (Clipboard.ContainsFileDropList())
                //    {
                //        containsFileDropList = true;
                //        Clipboard.GetFileDropList();
                //    }
                //    else if (Clipboard.ContainsImage())
                //    {
                //        containsImage = true;
                //    }
                //    else if (Clipboard.ContainsAudio())
                //    {
                //        containsAudio = true;
                //    }
                //}

                
                string oldText = Clipboard.GetText();
                Clipboard.SetDataObject(text, true);

                pasteCopiedText();

                System.Windows.Forms.Application.DoEvents();
                if (setBackPreviosCopiedValue)
                {
                    
                    Clipboard.SetDataObject(oldText, true);
                    System.Windows.Forms.Application.DoEvents();
                }
                    
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }

    /// <summary>
    /// https://msdn.microsoft.com/en-us/library/dd375731(v=vs.85).aspx
    /// </summary>
    public static class VirtualKeysEnum
    {
        /// <summary>
        /// Left mouse button
        /// </summary>
        public const int VK_LBUTTON = 0x01;

        /// <summary>
        /// Right mouse button
        /// </summary>
        public const int VK_RBUTTON = 0x02;

        /// <summary>
        /// Control-break processing
        /// </summary>
        public const int VK_CANCEL = 0x03;
        
        /// <summary>
        /// Middle mouse button(three-button mouse)
        /// </summary>
        public const int VK_MBUTTON = 0x04;

        /// <summary>
        /// X1 mouse button
        /// </summary>
        public const int VK_XBUTTON1 = 0x05;

        /// <summary>
        /// X2 mouse button
        /// </summary>
        public const int VK_XBUTTON2 = 0x06;

        /// <summary>
        /// -
        /// </summary>
        public const int Undefined1 = 0x07;

        /// <summary>
        /// BACKSPACE key
        /// </summary>
        public const int VK_BACK = 0x08;

        /// <summary>
        /// TAB key
        /// </summary>
        public const int VK_TAB = 0x09;

        ///// <summary>
        ///// Reserved
        ///// </summary>
        //public const int Reserved1 = 0x0A - 0B;

        /// <summary>
        /// CLEAR key
        /// </summary>
        public const int VK_CLEAR = 0x0C;

        /// <summary>
        /// ENTER key
        /// </summary>
        public const int VK_RETURN = 0x0D;

        ///// <summary>
        ///// Undefined
        ///// </summary>
        //public const int Undefined2 = 0x0E - 0F;

        /// <summary>
        /// SHIFT key
        /// </summary>
        public const int VK_SHIFT = 0x10;

        /// <summary>
        /// CTRL key
        /// </summary>
        public const int VK_CONTROL = 0x11;

        /// <summary>
        /// ALT key
        /// </summary>
        public const int VK_MENU = 0x12;

        /// <summary>
        /// PAUSE key
        /// </summary>
        public const int VK_PAUSE = 0x13;

        /// <summary>
        /// CAPS LOCK key
        /// </summary>
        public const int VK_CAPITAL = 0x14;

        /// <summary>
        /// IME Kana mode
        /// </summary>
        public const int VK_KANA = 0x15;

        /// <summary>
        /// IME Hanguel mode(maintained for compatibility; use VK_HANGUL)
        /// </summary>
        public const int VK_HANGUEL = 0x15;

        /// <summary>
        /// IME Hangul mode
        /// </summary>
        public const int VK_HANGUL = 0x15;

        /// <summary>
        /// Undefined3 -
        /// </summary>
        public const int Undefined3 = 0x16;

        /// <summary>
        /// IME Junja mode
        /// </summary>
        public const int VK_JUNJA = 0x17;

        /// <summary>
        /// IME final mode
        /// </summary>
        public const int VK_FINAL = 0x18;

        /// <summary>
        /// IME Hanja mode
        /// </summary>
        public const int VK_HANJA = 0x19;

        /// <summary>
        /// IME Kanji mode
        /// </summary>
        public const int VK_KANJI = 0x19;

        /// <summary>
        /// Undefined -
        /// </summary>
        public const int Undefined4 = 0x1A;

        /// <summary>
        /// ESC key
        /// </summary>
        public const int VK_ESCAPE = 0x1B;

        /// <summary>
        /// IME convert
        /// </summary>
        public const int VK_CONVERT = 0x1C;

        /// <summary>
        /// IME nonconvert
        /// </summary>
        public const int VK_NONCONVERT = 0x1D;

        /// <summary>
        /// IME accept
        /// </summary>
        public const int VK_ACCEPT = 0x1E;

        /// <summary>
        /// IME mode change request
        /// </summary>
        public const int VK_MODECHANGE = 0x1F;

        /// <summary>
        /// SPACEBAR
        /// </summary>
        public const int VK_SPACE = 0x20;

        /// <summary>
        /// PAGE UP key
        /// </summary>
        public const int VK_PRIOR = 0x21;

        /// <summary>
        /// PAGE DOWN key
        /// </summary>
        public const int VK_NEXT = 0x22;

        /// <summary>
        /// END key
        /// </summary>
        public const int VK_END = 0x23;

        /// <summary>
        /// HOME key
        /// </summary>
        public const int VK_HOME = 0x24;

        /// <summary>
        /// LEFT ARROW key
        /// </summary>
        public const int VK_LEFT = 0x25;

        /// <summary>
        /// UP ARROW key
        /// </summary>
        public const int VK_UP = 0x26;

        /// <summary>
        /// RIGHT ARROW key
        /// </summary>
        public const int VK_RIGHT = 0x27;

        /// <summary>
        /// DOWN ARROW key
        /// </summary>
        public const int VK_DOWN = 0x28;

        /// <summary>
        /// SELECT key
        /// </summary>
        public const int VK_SELECT = 0x29;

        /// <summary>
        /// PRINT key
        /// </summary>
        public const int VK_PRINT = 0x2A;

        /// <summary>
        /// EXECUTE key
        /// </summary>
        public const int VK_EXECUTE = 0x2B;

        /// <summary>
        /// PRINT SCREEN key
        /// </summary>
        public const int VK_SNAPSHOT = 0x2C;

        /// <summary>
        /// INS key
        /// </summary>
        public const int VK_INSERT = 0x2D;

        /// <summary>
        /// DEL key
        /// </summary>
        public const int VK_DELETE = 0x2E;
        
        /// <summary>
        /// HELP key
        /// </summary>
        public const int VK_HELP = 0x2F;

        /// <summary>
        /// 0 key
        /// </summary>
        public const int key_0 =  0x30;

        /// <summary>
        /// 1 key
        /// </summary>
        public const int key_1 = 0x31;

        /// <summary>
        /// 2 key
        /// </summary>
        public const int key_2 = 0x32;

        /// <summary>
        /// 3 key
        /// </summary>
        public const int key_3 = 0x33;

        /// <summary>
        /// 4 key
        /// </summary>
        public const int key_4 = 0x34;

        /// <summary>
        /// 5 key
        /// </summary>
        public const int key_5 = 0x35;

        /// <summary>
        /// 6 key
        /// </summary>
        public const int key_6 = 0x36;

        /// <summary>
        /// 7 key
        /// </summary>
        public const int key_7 = 0x37;

        /// <summary>
        /// 8 key
        /// </summary>
        public const int key_8 = 0x38;

        /// <summary>
        /// 9 key
        /// </summary>
        public const int key_9 = 0x39;

        /// <summary>
        /// Undefined -
        /// </summary>
        public const int Undefined5 = 0x3A-40;

        /// <summary>
        /// A key
        /// </summary>
        public const int key_a = 0x41;

        /// <summary>
        /// B key
        /// </summary>
        public const int key_b = 0x42;

        /// <summary>
        /// C key
        /// </summary>
        public const int key_c = 0x43;

        /// <summary>
        /// D key
        /// </summary>
        public const int key_d = 0x44;

        /// <summary>
        /// E key
        /// </summary>
        public const int key_e = 0x45;

        /// <summary>
        /// F key
        /// </summary>
        public const int key_f = 0x46;


        /// <summary>
        /// G key
        /// </summary>
        public const int key_g = 0x47;

        /// <summary>
        /// H key
        /// </summary>
        public const int key_h = 0x48;

        /// <summary>
        /// I key
        /// </summary>
        public const int key_i = 0x49;

        /// <summary>
        /// J key
        /// </summary>
        public const int key_j = 0x4A;

        /// <summary>
        /// K key
        /// </summary>
        public const int key_k = 0x4B;

        /// <summary>
        /// L key
        /// </summary>
        public const int key_l = 0x4C;

        /// <summary>
        /// M key
        /// </summary>
        public const int key_m = 0x4D;

        /// <summary>
        /// N key
        /// </summary>
        public const int key_n = 0x4E;

        /// <summary>
        /// O key
        /// </summary>
        public const int key_o = 0x4F;

        /// <summary>
        /// P key
        /// </summary>
        public const int key_p = 0x50;

        /// <summary>
        /// Q key
        /// </summary>
        public const int key_q = 0x51;

        /// <summary>
        /// R key
        /// </summary>
        public const int key_r = 0x52;

        /// <summary>
        /// S key
        /// </summary>
        public const int key_s = 0x53;

        /// <summary>
        /// T key
        /// </summary>
        public const int key_t = 0x54;

        /// <summary>
        /// U key
        /// </summary>
        public const int key_u = 0x55;

        /// <summary>
        /// V key
        /// </summary>
        public const int key_v = 0x56;

        /// <summary>
        /// W key
        /// </summary>
        public const int key_w = 0x57;

        /// <summary>
        /// X key
        /// </summary>
        public const int key_x = 0x58;

        /// <summary>
        /// Y key
        /// </summary>
        public const int key_y = 0x59;

        /// <summary>
        /// Z key
        /// </summary>
        public const int key_z = 0x5A;

        /// <summary>
        /// Left Windows key(Natural keyboard)
        /// </summary>
        public const int VK_LWIN = 0x5B;

        /// <summary>
        /// Right Windows key(Natural keyboard)
        /// </summary>
        public const int VK_RWIN = 0x5C;

        /// <summary>
        /// Applications key(Natural keyboard)
        /// </summary>
        public const int VK_APPS = 0x5D;

        /// <summary>
        /// Reserved -
        /// </summary>
        public const int Reserved2 = 0x5E;

        /// <summary>
        /// Computer Sleep key
        /// </summary>
        public const int VK_SLEEP = 0x5F;

        /// <summary>
        /// Numeric keypad 0 key
        /// </summary>
        public const int VK_NUMPAD0 = 0x60;

        /// <summary>
        /// Numeric keypad 1 key
        /// </summary>
        public const int VK_NUMPAD1 = 0x61;

        /// <summary>
        /// Numeric keypad 2 key
        /// </summary>
        public const int VK_NUMPAD2 = 0x62;

        /// <summary>
        /// Numeric keypad 3 key
        /// </summary>
        public const int VK_NUMPAD3 = 0x63;

        /// <summary>
        /// Numeric keypad 4 key
        /// </summary>
        public const int VK_NUMPAD4 = 0x64;

        /// <summary>
        /// Numeric keypad 5 key
        /// </summary>
        public const int VK_NUMPAD5 = 0x65;

        /// <summary>
        /// Numeric keypad 6 key
        /// </summary>
        public const int VK_NUMPAD6 = 0x66;

        /// <summary>
        /// Numeric keypad 7 key
        /// </summary>
        public const int VK_NUMPAD7 = 0x67;

        /// <summary>
        /// Numeric keypad 8 key
        /// </summary>
        public const int VK_NUMPAD8 = 0x68;

        /// <summary>
        /// Numeric keypad 9 key
        /// </summary>
        public const int VK_NUMPAD9 = 0x69;


        /// <summary>
        /// Multiply key
        /// </summary>
        public const int VK_MULTIPLY = 0x6A;

        /// <summary>
        /// Add key
        /// </summary>
        public const int VK_ADD = 0x6B;

        /// <summary>
        /// Separator key
        /// </summary>
        public const int VK_SEPARATOR = 0x6C;

        /// <summary>
        /// Subtract key
        /// </summary>
        public const int VK_SUBTRACT = 0x6D;

        /// <summary>
        /// Decimal key
        /// </summary>
        public const int VK_DECIMAL = 0x6E;

        /// <summary>
        /// Divide key
        /// </summary>
        public const int VK_DIVIDE = 0x6F;

        /// <summary>
        /// F1 key
        /// </summary>
        public const int VK_F1 = 0x70;

        /// <summary>
        /// F2 key
        /// </summary>
        public const int VK_F2 = 0x71;

        /// <summary>
        /// F3 key
        /// </summary>
        public const int VK_F3 = 0x72;

        /// <summary>
        /// F4 key
        /// </summary>
        public const int VK_F4 = 0x73;

        /// <summary>
        /// F5 key
        /// </summary>
        public const int VK_F5 = 0x74;

        /// <summary>
        /// F6 key
        /// </summary>
        public const int VK_F6 = 0x75;

        /// <summary>
        /// F7 key
        /// </summary>
        public const int VK_F7 = 0x76;

        /// <summary>
        /// F8 key
        /// </summary>
        public const int VK_F8 = 0x77;

        /// <summary>
        /// F9 key
        /// </summary>
        public const int VK_F9 = 0x78;

        /// <summary>
        /// F10 key
        /// </summary>
        public const int VK_F10 = 0x79;

        /// <summary>
        /// F11 key
        /// </summary>
        public const int VK_F11 = 0x7A;

        /// <summary>
        /// F12 key
        /// </summary>
        public const int VK_F12 = 0x7B;

        /// <summary>
        /// F13 key
        /// </summary>
        public const int VK_F13 = 0x7C;

        //F14 key
        public const int VK_F14 = 0x7D;

        /// <summary>
        /// F15 key
        /// </summary>
        public const int VK_F15 = 0x7E;

        /// <summary>
        /// F16 key
        /// </summary>
        public const int VK_F16 = 0x7F;

        /// <summary>
        /// F17 key
        /// </summary>
        public const int VK_F17 = 0x80;

        /// <summary>
        /// F18 key
        /// </summary>
        public const int VK_F18 = 0x81;

        /// <summary>
        /// F19 key
        /// </summary>
        public const int VK_F19 = 0x82;

        /// <summary>
        /// F20 key
        /// </summary>
        public const int VK_F20 = 0x83;

        /// <summary>
        /// F21 key
        /// </summary>
        public const int VK_F21 = 0x84;

        /// <summary>
        /// F22 key
        /// </summary>
        public const int VK_F22 = 0x85;

        /// <summary>
        /// F23 key
        /// </summary>
        public const int VK_F23 = 0x86;

        /// <summary>
        /// F24 key
        /// </summary>
        public const int VK_F24 = 0x87;

        ///// <summary>
        ///// Unassigned -
        ///// </summary>
        //public const int Unassigned4 = 0x88 - 8F;

        /// <summary>
        /// NUM LOCK key
        /// </summary>
        public const int VK_NUMLOCK = 0x90;

        /// <summary>
        /// SCROLL LOCK key
        /// </summary>
        public const int VK_SCROLL = 0x91;

        /// <summary>
        /// OEM specific
        /// </summary>
        public const int OEM_specific = 0x92 - 96;

        ///// <summary>
        ///// Unassigned -
        ///// </summary>
        //public const int Unassigned5 = 0x97 - 9F;
        
        /// <summary>
        /// Left SHIFT key
        /// </summary>
        public const int VK_LSHIFT = 0xA0;

        /// <summary>
        /// Right SHIFT key
        /// </summary>
        public const int VK_RSHIFT = 0xA1;

        /// <summary>
        /// Left CONTROL key
        /// </summary>
        public const int VK_LCONTROL = 0xA2;

        /// <summary>
        /// Right CONTROL key
        /// </summary>
        public const int VK_RCONTROL = 0xA3;

        /// <summary>
        /// Left MENU key
        /// </summary>
        public const int VK_LMENU = 0xA4;

        /// <summary>
        /// Right MENU key
        /// </summary>
        public const int VK_RMENU = 0xA5;

        /// <summary>
        /// Browser Back key
        /// </summary>
        public const int VK_BROWSER_BACK = 0xA6;

        /// <summary>
        /// Browser Forward key
        /// </summary>
        public const int VK_BROWSER_FORWARD = 0xA7;

        /// <summary>
        /// Browser Refresh key
        /// </summary>
        public const int VK_BROWSER_REFRESH = 0xA8;

        /// <summary>
        /// Browser Stop key
        /// </summary>
        public const int VK_BROWSER_STOP = 0xA9;

        /// <summary>
        /// Browser Search key
        /// </summary>
        public const int VK_BROWSER_SEARCH = 0xAA;

        /// <summary>
        /// Browser Favorites key
        /// </summary>
        public const int VK_BROWSER_FAVORITES = 0xAB;

        /// <summary>
        /// Browser Start and Home key
        /// </summary>
        public const int VK_BROWSER_HOME = 0xAC;

        /// <summary>
        /// Volume Mute key
        /// </summary>
        public const int VK_VOLUME_MUTE = 0xAD;

        /// <summary>
        /// Volume Down key
        /// </summary>
        public const int VK_VOLUME_DOWN = 0xAE;

        /// <summary>
        /// Volume Up key
        /// </summary>
        public const int VK_VOLUME_UP = 0xAF;

        /// <summary>
        /// Next Track key
        /// </summary>
        public const int VK_MEDIA_NEXT_TRACK = 0xB0;

        /// <summary>
        /// Previous Track key
        /// </summary>
        public const int VK_MEDIA_PREV_TRACK = 0xB1;

        /// <summary>
        /// Stop Media key
        /// </summary>
        public const int VK_MEDIA_STOP = 0xB2;

        /// <summary>
        /// Play/Pause Media key
        /// </summary>
        public const int VK_MEDIA_PLAY_PAUSE = 0xB3;

        /// <summary>
        /// Start Mail key
        /// </summary>
        public const int VK_LAUNCH_MAIL = 0xB4;

        /// <summary>
        /// Select Media key
        /// </summary>
        public const int VK_LAUNCH_MEDIA_SELECT = 0xB5;

        /// <summary>
        /// Start Application 1 key
        /// </summary>
        public const int VK_LAUNCH_APP1 = 0xB6;

        /// <summary>
        /// Start Application 2 key
        /// </summary>
        public const int VK_LAUNCH_APP2 = 0xB7;

        ///// <summary>
        ///// Reserved -
        ///// </summary>
        //public const int Reserved3 = 0xB8-B9;

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard.
        /// For the US standard keyboard, the ';:' key
        /// </summary>
        public const int VK_OEM_1 = 0xBA;

        /// <summary>
        /// For any country/region, the '+' key
        /// </summary>
        public const int VK_OEM_PLUS = 0xBB;

        /// <summary>
        /// For any country/region, the ',' key
        /// </summary>
        public const int VK_OEM_COMMA = 0xBC;

        /// <summary>
        /// For any country/region, the '-' key
        /// </summary>
        public const int VK_OEM_MINUS = 0xBD;

        /// <summary>
        /// For any country/region, the '.' key
        /// </summary>
        public const int VK_OEM_PERIOD = 0xBE;

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard.
        /// For the US standard keyboard, the '/?' key
        /// </summary>
        public const int VK_OEM_2 = 0xBF;

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard.
        /// For the US standard keyboard, the '`~' key
        /// </summary>
        public const int VK_OEM_3 = 0xC0;

        ///// <summary>
        ///// Reserved -
        ///// </summary>
        //public const int Reserved6 = 0xC1-D7;

        ///// <summary>
        ///// Unassigned -
        ///// </summary>
        //public const int Unassigned7 = 0xD8-DA;

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard.
        /// For the US standard keyboard, the '[{' key
        /// </summary>
        public const int VK_OEM_4 = 0xDB;

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard.
        /// For the US standard keyboard, the '\|' key
        /// </summary>
        public const int VK_OEM_5 = 0xDC;

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard.
        /// For the US standard keyboard, the ']}' key
        /// </summary>
        public const int VK_OEM_6 = 0xDD;

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard.
        /// For the US standard keyboard, the 'single-quote/double-quote' key
        /// </summary>
        public const int VK_OEM_7 = 0xDE;

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard.
        /// </summary>
        public const int VK_OEM_8 = 0xDF;

        /// <summary>
        /// Reserved -
        /// </summary>
        public const int Reserved9 = 0xE0;

        /// <summary>
        /// OEM specific
        /// </summary>
        public const int OEM_specific2 = 0xE1;

        /// <summary>
        /// Either the angle bracket key or the backslash key on the RT 102-key keyboard
        /// </summary>
        public const int VK_OEM_102 = 0xE2;

        ///// <summary>
        ///// OEM specific
        ///// </summary>
        //public const int OEM_specific4 = 0xE3-E4;
        
        /// <summary>
        /// IME PROCESS key
        /// </summary>
        public const int VK_PROCESSKEY = 0xE5;

        /// <summary>
        /// OEM specific
        /// </summary>
        public const int OEM_specific5 = 0xE6;

        /// <summary>
        /// Used to pass Unicode characters as if they were keystrokes.The VK_PACKET key is the low word of a 32-bit Virtual Key value used for non-keyboard input methods.For more information, see Remark in KEYBDINPUT, SendInput, WM_KEYDOWN, and WM_KEYUP
        /// </summary>
        public const int VK_PACKET = 0xE7;

        /// <summary>
        /// Unassigned -
        /// </summary>
        public const int Unassigned9 = 0xE8;

        ///// <summary>
        ///// OEM specific
        ///// </summary>
        //public const int OEM_specific3 = 0xE9-F5;

        /// <summary>
        /// Attn key
        /// </summary>
        public const int VK_ATTN = 0xF6;

        /// <summary>
        /// CrSel key
        /// </summary>
        public const int VK_CRSEL = 0xF7;

        /// <summary>
        /// ExSel key
        /// </summary>
        public const int VK_EXSEL = 0xF8;

        /// <summary>
        /// Erase EOF key
        /// </summary>
        public const int VK_EREOF = 0xF9;

        /// <summary>
        /// Play key
        /// </summary>
        public const int VK_PLAY = 0xFA;


        /// <summary>
        /// Zoom key
        /// </summary>
        public const int VK_ZOOM = 0xFB;
        
        /// <summary>
        /// Reserved
        /// </summary>
        public const int VK_NONAME = 0xFC;


        /// <summary>
        /// PA1 key
        /// </summary>
        public const int VK_PA1 = 0xFD;


        /// <summary>
        /// Clear key
        /// </summary>
        public const int VK_OEM_CLEAR = 0xFE;

    }

}
