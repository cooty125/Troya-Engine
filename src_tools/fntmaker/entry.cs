/* 
 * EntryPoint
 * =====================================================================
 * FileName: entry.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 */

using System;
using System.Windows.Forms;
using Troya.Tools;

internal static class EntryPoint
{
    [STAThread]
    internal static int Main( string[ ] args ) {
        Application.EnableVisualStyles( );
        Application.SetCompatibleTextRenderingDefault( false );

        WndMain window = new WndMain( );
        Application.Run( window );

        return 0x0;
    }
}