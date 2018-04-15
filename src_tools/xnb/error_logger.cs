/* 
 * ErrorLogger
 * ===============================================================
 * FileName: error_logger.cs
 * ---------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * ===============================================================
 */

using System.Collections.Generic;
using Microsoft.Build.Framework;

namespace Vixen.Tools
{
    public class ErrorLogger : ILogger
    {
        List<string> errors = new List<string>( );
        string parameters;
        LoggerVerbosity verbosity = LoggerVerbosity.Normal;

        string ILogger.Parameters {
            get { return this.parameters; }
            set { this.parameters = value; }
        }
        LoggerVerbosity ILogger.Verbosity {
            get { return this.verbosity; }
            set { this.verbosity = value; }
        }
        public List<string> Errors {
            get { return this.errors; }
        }


        public void Initialize( IEventSource eventSource ) {
            if ( eventSource != null ) {
                eventSource.ErrorRaised += this.errorRaised;
            }
        }
        public void Shutdown( ) {

        }


        private void errorRaised( object sender, BuildErrorEventArgs e ) {
           this.errors.Add( e.Message );
        }
    }
}