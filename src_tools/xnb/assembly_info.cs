/* 
 * AssemblyInfo
 * =====================================================================
 * FileName: assembly_info.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2017 - All rights reserved.
 * =====================================================================
 *
 * Troya Engine - DirectX Binary Content Builder Utility
 * Version: 2.2
 */


using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Resources;

[assembly: AssemblyTitle( "xnb" )]
[assembly: AssemblyDescription( "Troya Engine" )]
[assembly: AssemblyConfiguration( "" )]
[assembly: AssemblyCompany( "David Kutnar" )]
[assembly: AssemblyProduct( "XNB" )]
[assembly: AssemblyCopyright( "Copyright © David Kutnar 2018" )]
[assembly: AssemblyTrademark( "Troya Engine" )]
[assembly: AssemblyCulture( "" )]
[assembly: ComVisible( !AssemblyInfo.Obfuscate )]
[assembly: Guid( "acf3bd1f-7ca6-40ec-88b3-eed2ff137c96" )]
[assembly: AssemblyVersion( AssemblyInfo.Version )]
[assembly: AssemblyFileVersion( AssemblyInfo.Version )]
[assembly: NeutralResourcesLanguageAttribute( "en" )]
[assembly: ObfuscateAssembly( AssemblyInfo.Obfuscate )]

internal static class AssemblyInfo
{
    internal const string Version = "2.2.0.0";
    internal const string Build = "1504";
    internal const bool Obfuscate = true;
}